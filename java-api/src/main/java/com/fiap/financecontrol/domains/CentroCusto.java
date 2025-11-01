package com.fiap.financecontrol.domains;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.Size;
import lombok.*;

import java.util.ArrayList;
import java.util.List;

@Entity
@Table(name = "CENTRO_CUSTO")
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Builder
@EqualsAndHashCode(of = "id")
public class CentroCusto {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "centro_custo_seq")
    @SequenceGenerator(name = "centro_custo_seq", sequenceName = "CENTRO_CUSTO_SEQ", allocationSize = 1)
    @Column(name = "id_centro_custo")
    private Long id;

    @NotBlank
    @Size(max = 70)
    @Column(name = "nome_centro_custo", nullable = false, length = 70)
    private String nomeCentroCusto;

    @OneToMany(mappedBy = "centroCusto", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    @Builder.Default
    private List<RegistroContabil> registrosContabeis = new ArrayList<>();

    public void adicionarRegistroContabil(RegistroContabil registro) {
        registrosContabeis.add(registro);
        registro.setCentroCusto(this);
    }
}
