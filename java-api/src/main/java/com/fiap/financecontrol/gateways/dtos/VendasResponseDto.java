package com.fiap.financecontrol.gateways.dtos;

import com.fiap.financecontrol.domains.Vendas;
import lombok.Data;

import java.math.BigDecimal;

@Data
public class VendasResponseDto {

    private Long id;
    private Long clienteId;
    private String nomeCliente;
    private String emailCliente;
    private Long registroContabilId;
    private BigDecimal valorRegistro;
    private String nomeConta;
    private String nomeCentroCusto;

    public static VendasResponseDto fromEntity(Vendas venda) {
        VendasResponseDto dto = new VendasResponseDto();
        dto.setId(venda.getId());
        dto.setClienteId(venda.getCliente().getId());
        dto.setNomeCliente(venda.getCliente().getNomeCliente());
        dto.setEmailCliente(venda.getCliente().getEmail());
        dto.setRegistroContabilId(venda.getRegistroContabil().getId());
        dto.setValorRegistro(venda.getRegistroContabil().getValor());
        dto.setNomeConta(venda.getRegistroContabil().getConta().getNomeConta());
        dto.setNomeCentroCusto(venda.getRegistroContabil().getCentroCusto().getNomeCentroCusto());
        return dto;
    }
}
