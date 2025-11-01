package com.fiap.financecontrol.gateways;

import com.fiap.financecontrol.domains.Cliente;
import com.fiap.financecontrol.gateways.dtos.ClienteRequestDto;
import com.fiap.financecontrol.gateways.dtos.ClienteResponseDto;
import com.fiap.financecontrol.services.*;
import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Sort;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/fiap/clientes")
@RequiredArgsConstructor
public class ClienteController {

    private final CreateClienteService createClienteService;
    private final UpdateClienteService updateClienteService;
    private final ListClientesService listClientesService;
    private final FindByIdClienteService findByIdClienteService;
    private final DeleteClienteService deleteClienteService;

    @GetMapping("/{id}")
    public ResponseEntity<ClienteResponseDto> getCliente(@PathVariable Long id) {
        Cliente cliente = findByIdClienteService.executeOrThrow(id);
        return ResponseEntity.ok(ClienteResponseDto.fromEntity(cliente));
    }

    @GetMapping
    public ResponseEntity<Page<ClienteResponseDto>> getClientes(
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "ASC") Sort.Direction direction,
            @RequestParam(defaultValue = "10") int size,
            @RequestParam(required = false) String nome
    ) {
        Page<Cliente> clientes;
        
        if (nome != null && !nome.trim().isEmpty()) {
            clientes = listClientesService.buscarClientesPorNome(nome, page, size, direction);
        } else {
            clientes = listClientesService.listarClientesAtivos(page, size, direction);
        }

        Page<ClienteResponseDto> response = clientes.map(ClienteResponseDto::fromEntity);

        if (clientes.isEmpty()) {
            return ResponseEntity.noContent().build();
        } else {
            return ResponseEntity.ok(response);
        }
    }

    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public ClienteResponseDto createCliente(@RequestBody @Valid ClienteRequestDto clienteDto) {
        Cliente cliente = createClienteService.execute(clienteDto.toEntity());
        return ClienteResponseDto.fromEntity(cliente);
    }

    @PutMapping("/{id}")
    public ClienteResponseDto updateCliente(@PathVariable Long id, @RequestBody @Valid ClienteRequestDto clienteDto) {
        Cliente cliente = clienteDto.toEntity();
        cliente.setId(id);
        Cliente clienteAtualizado = updateClienteService.execute(cliente);
        return ClienteResponseDto.fromEntity(clienteAtualizado);
    }

    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void deleteCliente(@PathVariable Long id) {
        deleteClienteService.execute(id);
    }
}
