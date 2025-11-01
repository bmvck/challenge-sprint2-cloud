package com.fiap.financecontrol.services;

import com.fiap.financecontrol.domains.Vendas;
import com.fiap.financecontrol.gateways.VendasRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
@RequiredArgsConstructor
public class FindByIdVendasService {

    private final VendasRepository vendasRepository;

    public Optional<Vendas> execute(Long id) {
        return vendasRepository.findById(id);
    }

    public Vendas executeOrThrow(Long id) {
        return vendasRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Venda não encontrada com ID: " + id));
    }
}
