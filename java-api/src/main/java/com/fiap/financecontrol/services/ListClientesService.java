package com.fiap.financecontrol.services;

import com.fiap.financecontrol.domains.Cliente;
import com.fiap.financecontrol.gateways.ClienteRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
public class ListClientesService {

    private final ClienteRepository clienteRepository;

    public Page<Cliente> listarClientes(int page, int size, Sort.Direction direction) {
        Pageable pageable = PageRequest.of(page, size, Sort.by(direction, "nomeCliente"));
        return clienteRepository.findAll(pageable);
    }

    public Page<Cliente> listarClientesAtivos(int page, int size, Sort.Direction direction) {
        Pageable pageable = PageRequest.of(page, size, Sort.by(direction, "nomeCliente"));
        return clienteRepository.findByAtivo("S", pageable);
    }

    public Page<Cliente> buscarClientesPorNome(String nome, int page, int size, Sort.Direction direction) {
        Pageable pageable = PageRequest.of(page, size, Sort.by(direction, "nomeCliente"));
        return clienteRepository.findByNomeContainingAndAtivo(nome, "S", pageable);
    }
}
