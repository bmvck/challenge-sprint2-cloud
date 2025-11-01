package com.fiap.financecontrol.services;

import com.fiap.financecontrol.domains.Cliente;
import com.fiap.financecontrol.domains.Conta;
import com.fiap.financecontrol.gateways.ClienteRepository;
import com.fiap.financecontrol.gateways.ContaRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@RequiredArgsConstructor
public class CreateContaService implements ContaDataServiceInterface {

    private final ContaRepository contaRepository;
    private final ClienteRepository clienteRepository;

    @Override
    @Transactional
    public Conta execute(Conta conta) {
        if (conta.getCliente() != null && conta.getCliente().getId() != null) {
            Cliente cliente = clienteRepository.findById(conta.getCliente().getId())
                    .orElseThrow(() -> new RuntimeException("Cliente não encontrado com ID: " + conta.getCliente().getId()));
            conta.setCliente(cliente);
        }
        return contaRepository.save(conta);
    }
}
