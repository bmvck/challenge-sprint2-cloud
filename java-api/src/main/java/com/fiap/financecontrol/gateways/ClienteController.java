package com.fiap.financecontrol.gateways;

import com.fiap.financecontrol.domains.Cliente;
import com.fiap.financecontrol.gateways.dtos.ClienteRequestDto;
import com.fiap.financecontrol.gateways.dtos.ClienteResponseDto;
import com.fiap.financecontrol.services.*;
import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Sort;
import org.springframework.hateoas.EntityModel;
import org.springframework.hateoas.PagedModel;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.linkTo;
import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.methodOn;

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
    public ResponseEntity<EntityModel<ClienteResponseDto>> getCliente(@PathVariable Long id) {
        Cliente cliente = findByIdClienteService.executeOrThrow(id);
        ClienteResponseDto dto = ClienteResponseDto.fromEntity(cliente);
        EntityModel<ClienteResponseDto> model = EntityModel.of(dto);
        addLinksToCliente(model, id);
        return ResponseEntity.ok(model);
    }

    @GetMapping
    public ResponseEntity<PagedModel<EntityModel<ClienteResponseDto>>> getClientes(
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
        }

        PagedModel.PageMetadata pageMetadata = new PagedModel.PageMetadata(
                clientes.getSize(),
                clientes.getNumber(),
                clientes.getTotalElements(),
                clientes.getTotalPages()
        );

        PagedModel<EntityModel<ClienteResponseDto>> pagedModel = PagedModel.of(
                response.map(dto -> {
                    EntityModel<ClienteResponseDto> model = EntityModel.of(dto);
                    addLinksToCliente(model, dto.getId());
                    return model;
                }).toList(),
                pageMetadata
        );

        // Links de navegação
        pagedModel.add(linkTo(methodOn(ClienteController.class).getClientes(0, direction, size, nome)).withRel("first"));
        if (clientes.hasPrevious()) {
            pagedModel.add(linkTo(methodOn(ClienteController.class).getClientes(clientes.getNumber() - 1, direction, size, nome)).withRel("prev"));
        }
        pagedModel.add(linkTo(methodOn(ClienteController.class).getClientes(clientes.getNumber(), direction, size, nome)).withSelfRel());
        if (clientes.hasNext()) {
            pagedModel.add(linkTo(methodOn(ClienteController.class).getClientes(clientes.getNumber() + 1, direction, size, nome)).withRel("next"));
        }
        pagedModel.add(linkTo(methodOn(ClienteController.class).getClientes(clientes.getTotalPages() - 1, direction, size, nome)).withRel("last"));

        return ResponseEntity.ok(pagedModel);
    }

    @PostMapping
    public ResponseEntity<EntityModel<ClienteResponseDto>> createCliente(@RequestBody @Valid ClienteRequestDto clienteDto) {
        Cliente cliente = createClienteService.execute(clienteDto.toEntity());
        ClienteResponseDto dto = ClienteResponseDto.fromEntity(cliente);
        EntityModel<ClienteResponseDto> model = EntityModel.of(dto);
        addLinksToCliente(model, cliente.getId());
        return ResponseEntity.status(HttpStatus.CREATED)
                .location(linkTo(methodOn(ClienteController.class).getCliente(cliente.getId())).toUri())
                .body(model);
    }

    @PutMapping("/{id}")
    public ResponseEntity<EntityModel<ClienteResponseDto>> updateCliente(@PathVariable Long id, @RequestBody @Valid ClienteRequestDto clienteDto) {
        Cliente cliente = clienteDto.toEntity();
        cliente.setId(id);
        Cliente clienteAtualizado = updateClienteService.execute(cliente);
        ClienteResponseDto dto = ClienteResponseDto.fromEntity(clienteAtualizado);
        EntityModel<ClienteResponseDto> model = EntityModel.of(dto);
        addLinksToCliente(model, id);
        return ResponseEntity.ok(model);
    }

    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void deleteCliente(@PathVariable Long id) {
        deleteClienteService.execute(id);
    }

    private void addLinksToCliente(EntityModel<ClienteResponseDto> model, Long id) {
        model.add(linkTo(methodOn(ClienteController.class).getCliente(id)).withSelfRel());
        model.add(linkTo(methodOn(ClienteController.class).updateCliente(id, null)).withRel("update"));
        model.add(linkTo(ClienteController.class).slash(id).withRel("delete"));
        model.add(linkTo(methodOn(ContaController.class).getContas(0, Sort.Direction.ASC, 10, null, null)).withRel("contas"));
        model.add(linkTo(methodOn(VendasController.class).getVendas(0, Sort.Direction.ASC, 10, id, null)).withRel("vendas"));
    }
}
