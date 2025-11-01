package com.fiap.financecontrol.services;

import com.fiap.financecontrol.domains.Cliente;
import com.fiap.financecontrol.gateways.ClienteRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@RequiredArgsConstructor
public class CreateClienteService implements ClienteDataServiceInterface {

    private final ClienteRepository clienteRepository;

    @Override
    @Transactional
    public Cliente execute(Cliente cliente) {
        return clienteRepository.save(cliente);
    }
}
