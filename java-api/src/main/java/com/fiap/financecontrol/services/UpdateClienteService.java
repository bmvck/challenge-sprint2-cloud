package com.fiap.financecontrol.services;

import com.fiap.financecontrol.domains.Cliente;
import com.fiap.financecontrol.gateways.ClienteRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@RequiredArgsConstructor
public class UpdateClienteService implements ClienteDataServiceInterface {

    private final ClienteRepository clienteRepository;

    @Override
    @Transactional
    public Cliente execute(Cliente cliente) {
        if (!clienteRepository.existsById(cliente.getId())) {
            throw new RuntimeException("Cliente não encontrado com ID: " + cliente.getId());
        }
        return clienteRepository.save(cliente);
    }
}
