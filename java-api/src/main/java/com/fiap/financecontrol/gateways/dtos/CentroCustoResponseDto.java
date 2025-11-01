package com.fiap.financecontrol.gateways.dtos;

import com.fiap.financecontrol.domains.CentroCusto;
import lombok.Data;

@Data
public class CentroCustoResponseDto {

    private Long id;
    private String nomeCentroCusto;

    public static CentroCustoResponseDto fromEntity(CentroCusto centroCusto) {
        CentroCustoResponseDto dto = new CentroCustoResponseDto();
        dto.setId(centroCusto.getId());
        dto.setNomeCentroCusto(centroCusto.getNomeCentroCusto());
        return dto;
    }
}
