package com.fiap.financecontrol.services;

import com.fiap.financecontrol.domains.CentroCusto;
import com.fiap.financecontrol.gateways.CentroCustoRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
@RequiredArgsConstructor
public class UpdateCentroCustoService implements CentroCustoDataServiceInterface {

    private final CentroCustoRepository centroCustoRepository;

    @Override
    @Transactional
    public CentroCusto execute(CentroCusto centroCusto) {
        if (!centroCustoRepository.existsById(centroCusto.getId())) {
            throw new RuntimeException("Centro de Custo não encontrado com ID: " + centroCusto.getId());
        }
        return centroCustoRepository.save(centroCusto);
    }
}
