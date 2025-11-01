package com.fiap.financecontrol.services;

import com.fiap.financecontrol.domains.Conta;
import com.fiap.financecontrol.gateways.ContaRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
@RequiredArgsConstructor
public class FindByIdContaService {

    private final ContaRepository contaRepository;

    public Optional<Conta> execute(Long id) {
        return contaRepository.findById(id);
    }

    public Conta executeOrThrow(Long id) {
        return contaRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Conta não encontrada com ID: " + id));
    }
}
