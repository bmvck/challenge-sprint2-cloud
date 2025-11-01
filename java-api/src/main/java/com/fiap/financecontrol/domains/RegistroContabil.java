package com.fiap.financecontrol.domains;

import jakarta.persistence.*;
import jakarta.validation.constraints.DecimalMin;
import jakarta.validation.constraints.NotNull;
import lombok.*;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "REG_CONT")
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Builder
@EqualsAndHashCode(of = "id")
public class RegistroContabil {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "reg_cont_seq")
    @SequenceGenerator(name = "reg_cont_seq", sequenceName = "REG_CONT_SEQ", allocationSize = 1)
    @Column(name = "id_reg_cont")
    private Long id;

    @NotNull
    @DecimalMin(value = "0.01", message = "Valor deve ser maior que zero")
    @Column(name = "valor", nullable = false, precision = 9, scale = 2)
    private BigDecimal valor;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "CONTA_id_conta", nullable = false)
    private Conta conta;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "CENTRO_CUSTO_id_centro_custo", nullable = false)
    private CentroCusto centroCusto;

    @Column(name = "data_criacao")
    private LocalDateTime dataCriacao;

    @Column(name = "data_atualizacao")
    private LocalDateTime dataAtualizacao;

    @OneToMany(mappedBy = "registroContabil", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    @Builder.Default
    private List<Vendas> vendas = new ArrayList<>();

    @PrePersist
    protected void onCreate() {
        if (dataCriacao == null) {
            dataCriacao = LocalDateTime.now();
        }
    }

    @PreUpdate
    protected void onUpdate() {
        dataAtualizacao = LocalDateTime.now();
    }

    public void adicionarVenda(Vendas venda) {
        vendas.add(venda);
        venda.setRegistroContabil(this);
    }
}
