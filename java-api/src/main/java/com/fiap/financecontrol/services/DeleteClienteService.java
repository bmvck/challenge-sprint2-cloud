package com.fiap.financecontrol.services;

import com.fiap.financecontrol.gateways.ClienteRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@RequiredArgsConstructor
public class DeleteClienteService {

    private final ClienteRepository clienteRepository;

    @Transactional
    public void execute(Long id) {
        if (!clienteRepository.existsById(id)) {
            throw new RuntimeException("Cliente não encontrado com ID: " + id);
        }
        clienteRepository.deleteById(id);
    }
}
