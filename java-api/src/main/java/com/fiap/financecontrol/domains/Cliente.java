package com.fiap.financecontrol.domains;

import jakarta.persistence.*;
import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Size;
import lombok.*;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "CLIENTE")
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Builder
@EqualsAndHashCode(of = "id")
public class Cliente {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "cliente_seq")
    @SequenceGenerator(name = "cliente_seq", sequenceName = "CLIENTE_SEQ", allocationSize = 1)
    @Column(name = "id_cliente")
    private Long id;

    @NotBlank
    @Size(max = 100)
    @Column(name = "nome_cliente", nullable = false, length = 100)
    private String nomeCliente;

    @Column(name = "data_cadastro", nullable = false)
    private LocalDateTime dataCadastro;

    @NotBlank
    @Size(max = 14)
    @Column(name = "cpf_cnpj", nullable = false, unique = true, length = 14)
    private String cpfCnpj;

    @NotBlank
    @Email
    @Size(max = 100)
    @Column(name = "email", nullable = false, unique = true, length = 100)
    private String email;

    @NotBlank
    @Size(max = 100)
    @Column(name = "senha", nullable = false, length = 100)
    private String senha;

    @Column(name = "ativo", nullable = false, length = 1)
    @Builder.Default
    private String ativo = "S";

    @OneToMany(mappedBy = "cliente", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    @Builder.Default
    private List<Conta> contas = new ArrayList<>();

    @OneToMany(mappedBy = "cliente", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    @Builder.Default
    private List<Vendas> vendas = new ArrayList<>();

    @PrePersist
    protected void onCreate() {
        if (dataCadastro == null) {
            dataCadastro = LocalDateTime.now();
        }
    }

    public void adicionarConta(Conta conta) {
        contas.add(conta);
        conta.setCliente(this);
    }

    public void adicionarVenda(Vendas venda) {
        vendas.add(venda);
        venda.setCliente(this);
    }
}
