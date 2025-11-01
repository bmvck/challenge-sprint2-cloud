package com.fiap.financecontrol.gateways;

import com.fiap.financecontrol.domains.Cliente;
import com.fiap.financecontrol.domains.RegistroContabil;
import com.fiap.financecontrol.domains.Vendas;
import com.fiap.financecontrol.gateways.dtos.VendasRequestDto;
import com.fiap.financecontrol.gateways.dtos.VendasResponseDto;
import com.fiap.financecontrol.services.*;
import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Sort;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/fiap/vendas")
@RequiredArgsConstructor
public class VendasController {

    private final CreateVendasService createVendasService;
    private final UpdateVendasService updateVendasService;
    private final ListVendasService listVendasService;
    private final FindByIdVendasService findByIdVendasService;
    private final DeleteVendasService deleteVendasService;

    @GetMapping("/{id}")
    public ResponseEntity<VendasResponseDto> getVenda(@PathVariable Long id) {
        Vendas venda = findByIdVendasService.executeOrThrow(id);
        return ResponseEntity.ok(VendasResponseDto.fromEntity(venda));
    }

    @GetMapping
    public ResponseEntity<Page<VendasResponseDto>> getVendas(
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "ASC") Sort.Direction direction,
            @RequestParam(defaultValue = "10") int size,
            @RequestParam(required = false) Long clienteId,
            @RequestParam(required = false) Long registroContabilId
    ) {
        Page<Vendas> vendas;
        
        if (clienteId != null) {
            vendas = listVendasService.listarVendasPorCliente(clienteId, page, size, direction);
        } else if (registroContabilId != null) {
            vendas = listVendasService.listarVendasPorRegistroContabil(registroContabilId, page, size, direction);
        } else {
            vendas = listVendasService.listarVendas(page, size, direction);
        }

        Page<VendasResponseDto> response = vendas.map(VendasResponseDto::fromEntity);

        if (vendas.isEmpty()) {
            return ResponseEntity.noContent().build();
        } else {
            return ResponseEntity.ok(response);
        }
    }

    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public VendasResponseDto createVenda(@RequestBody @Valid VendasRequestDto vendaDto) {
        Vendas venda = vendaDto.toEntity();
        
        // Criar objetos de referência com os IDs fornecidos
        venda.setCliente(Cliente.builder().id(vendaDto.getClienteId()).build());
        venda.setRegistroContabil(RegistroContabil.builder().id(vendaDto.getRegistroContabilId()).build());
        
        Vendas vendaCriada = createVendasService.execute(venda);
        return VendasResponseDto.fromEntity(vendaCriada);
    }

    @PutMapping("/{id}")
    public VendasResponseDto updateVenda(@PathVariable Long id, @RequestBody @Valid VendasRequestDto vendaDto) {
        Vendas venda = vendaDto.toEntity();
        venda.setId(id);
        
        // Criar objetos de referência com os IDs fornecidos
        venda.setCliente(Cliente.builder().id(vendaDto.getClienteId()).build());
        venda.setRegistroContabil(RegistroContabil.builder().id(vendaDto.getRegistroContabilId()).build());
        
        Vendas vendaAtualizada = updateVendasService.execute(venda);
        return VendasResponseDto.fromEntity(vendaAtualizada);
    }

    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void deleteVenda(@PathVariable Long id) {
        deleteVendasService.execute(id);
    }
}
