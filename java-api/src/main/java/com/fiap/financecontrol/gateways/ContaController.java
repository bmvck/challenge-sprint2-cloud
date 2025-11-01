package com.fiap.financecontrol.gateways;

import com.fiap.financecontrol.domains.Cliente;
import com.fiap.financecontrol.domains.Conta;
import com.fiap.financecontrol.domains.TipoConta;
import com.fiap.financecontrol.gateways.dtos.ContaRequestDto;
import com.fiap.financecontrol.gateways.dtos.ContaResponseDto;
import com.fiap.financecontrol.services.*;
import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Sort;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/fiap/contas")
@RequiredArgsConstructor
public class ContaController {

    private final CreateContaService createContaService;
    private final UpdateContaService updateContaService;
    private final ListContasService listContasService;
    private final FindByIdContaService findByIdContaService;
    private final DeleteContaService deleteContaService;

    @GetMapping("/{id}")
    public ResponseEntity<ContaResponseDto> getConta(@PathVariable Long id) {
        Conta conta = findByIdContaService.executeOrThrow(id);
        return ResponseEntity.ok(ContaResponseDto.fromEntity(conta));
    }

    @GetMapping
    public ResponseEntity<Page<ContaResponseDto>> getContas(
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "ASC") Sort.Direction direction,
            @RequestParam(defaultValue = "10") int size,
            @RequestParam(required = false) TipoConta tipo,
            @RequestParam(required = false) String nome
    ) {
        Page<Conta> contas;
        
        if (nome != null && !nome.trim().isEmpty() && tipo != null) {
            contas = listContasService.buscarContasPorNome(nome, tipo, page, size, direction);
        } else if (tipo != null) {
            contas = listContasService.listarContasPorTipo(tipo, page, size, direction);
        } else {
            contas = listContasService.listarContas(page, size, direction);
        }

        Page<ContaResponseDto> response = contas.map(ContaResponseDto::fromEntity);

        if (contas.isEmpty()) {
            return ResponseEntity.noContent().build();
        } else {
            return ResponseEntity.ok(response);
        }
    }

    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public ContaResponseDto createConta(@RequestBody @Valid ContaRequestDto contaDto) {
        Conta conta = contaDto.toEntity();
        
        // Se clienteId foi fornecido, criar um objeto Cliente com o ID
        if (contaDto.getClienteId() != null) {
            conta.setCliente(Cliente.builder().id(contaDto.getClienteId()).build());
        }
        
        Conta contaCriada = createContaService.execute(conta);
        return ContaResponseDto.fromEntity(contaCriada);
    }

    @PutMapping("/{id}")
    public ContaResponseDto updateConta(@PathVariable Long id, @RequestBody @Valid ContaRequestDto contaDto) {
        Conta conta = contaDto.toEntity();
        conta.setId(id);
        
        // Se clienteId foi fornecido, criar um objeto Cliente com o ID
        if (contaDto.getClienteId() != null) {
            conta.setCliente(Cliente.builder().id(contaDto.getClienteId()).build());
        }
        
        Conta contaAtualizada = updateContaService.execute(conta);
        return ContaResponseDto.fromEntity(contaAtualizada);
    }

    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void deleteConta(@PathVariable Long id) {
        deleteContaService.execute(id);
    }
}
