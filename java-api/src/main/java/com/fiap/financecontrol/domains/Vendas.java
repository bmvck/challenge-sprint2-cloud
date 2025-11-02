package com.fiap.financecontrol.domains;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import lombok.*;

@Entity
@Table(name = "VENDAS")
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Builder
@EqualsAndHashCode(of = "id")
public class Vendas {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "vendas_seq")
    @SequenceGenerator(name = "vendas_seq", sequenceName = "vendas_seq", allocationSize = 1)
    @Column(name = "id_vendas")
    private Long id;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "cliente_id_cliente", nullable = false)
    private Cliente cliente;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "reg_cont_id_reg_cont", nullable = false)
    private RegistroContabil registroContabil;
}
