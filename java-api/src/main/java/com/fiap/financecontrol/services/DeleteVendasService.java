package com.fiap.financecontrol.services;

import com.fiap.financecontrol.gateways.VendasRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@RequiredArgsConstructor
public class DeleteVendasService {

    private final VendasRepository vendasRepository;

    @Transactional
    public void execute(Long id) {
        if (!vendasRepository.existsById(id)) {
            throw new RuntimeException("Venda não encontrada com ID: " + id);
        }
        vendasRepository.deleteById(id);
    }
}
