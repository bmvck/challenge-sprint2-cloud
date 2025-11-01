package com.fiap.financecontrol.services;

import com.fiap.financecontrol.domains.Cliente;
import com.fiap.financecontrol.gateways.ClienteRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
@RequiredArgsConstructor
public class FindByIdClienteService {

    private final ClienteRepository clienteRepository;

    public Optional<Cliente> execute(Long id) {
        return clienteRepository.findById(id);
    }

    public Cliente executeOrThrow(Long id) {
        return clienteRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Cliente não encontrado com ID: " + id));
    }
}
