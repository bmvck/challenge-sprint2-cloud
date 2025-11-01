package com.fiap.financecontrol.domains;

public enum TipoConta {
    R("Receita"),
    D("Despesa");

    private final String descricao;

    TipoConta(String descricao) {
        this.descricao = descricao;
    }

    public String getDescricao() {
        return descricao;
    }
}
