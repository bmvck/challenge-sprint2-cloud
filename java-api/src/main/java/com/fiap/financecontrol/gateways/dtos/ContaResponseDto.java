package com.fiap.financecontrol.gateways.dtos;

import com.fiap.financecontrol.domains.Conta;
import com.fiap.financecontrol.domains.TipoConta;
import lombok.Data;
import lombok.EqualsAndHashCode;
import org.springframework.hateoas.RepresentationModel;

@Data
@EqualsAndHashCode(callSuper = false)
public class ContaResponseDto extends RepresentationModel<ContaResponseDto> {

    private Long id;
    private String nomeConta;
    private TipoConta tipo;
    private Long clienteId;
    private String nomeCliente;

    public static ContaResponseDto fromEntity(Conta conta) {
        ContaResponseDto dto = new ContaResponseDto();
        dto.setId(conta.getId());
        dto.setNomeConta(conta.getNomeConta());
        dto.setTipo(conta.getTipo());
        dto.setClienteId(conta.getCliente() != null ? conta.getCliente().getId() : null);
        dto.setNomeCliente(conta.getCliente() != null ? conta.getCliente().getNomeCliente() : null);
        return dto;
    }
}
