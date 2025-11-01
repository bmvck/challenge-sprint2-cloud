package com.fiap.financecontrol.gateways.dtos;

import com.fiap.financecontrol.domains.Cliente;
import lombok.Data;

import java.time.LocalDateTime;

@Data
public class ClienteResponseDto {

    private Long id;
    private String nomeCliente;
    private LocalDateTime dataCadastro;
    private String cpfCnpj;
    private String email;
    private String ativo;

    public static ClienteResponseDto fromEntity(Cliente cliente) {
        ClienteResponseDto dto = new ClienteResponseDto();
        dto.setId(cliente.getId());
        dto.setNomeCliente(cliente.getNomeCliente());
        dto.setDataCadastro(cliente.getDataCadastro());
        dto.setCpfCnpj(cliente.getCpfCnpj());
        dto.setEmail(cliente.getEmail());
        dto.setAtivo(cliente.getAtivo());
        return dto;
    }
}
