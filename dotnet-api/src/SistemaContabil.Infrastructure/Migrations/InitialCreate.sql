-- Script de criação inicial das tabelas para Oracle
-- Baseado no challenge_oracle.sql fornecido

-- Remover tabelas existentes (se existirem)
DROP TABLE registro_contabil CASCADE CONSTRAINTS;
DROP TABLE centro_custo CASCADE CONSTRAINTS;
DROP TABLE conta CASCADE CONSTRAINTS;

-- Criar sequências para IDs
CREATE SEQUENCE seq_centro_custo START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seq_conta START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE seq_registro_contabil START WITH 1 INCREMENT BY 1;

-- Criar tabela centro_custo
CREATE TABLE centro_custo (
    id_centro_custo   NUMBER(4) NOT NULL,
    nome_centro_custo VARCHAR2(70) NOT NULL
);

-- Criar tabela conta
CREATE TABLE conta (
    id_conta   NUMBER(4) NOT NULL,
    nome_conta VARCHAR2(70) NOT NULL,
    tipo       CHAR(1) NOT NULL
);

-- Criar tabela registro_contabil
CREATE TABLE registro_contabil (
    id_registro_contabil         NUMBER(4) NOT NULL,
    valor                        NUMBER(9, 2) NOT NULL,
    conta_id_conta               NUMBER(4) NOT NULL,
    centro_custo_id_centro_custo NUMBER(4) NOT NULL,
    data_criacao                 DATE DEFAULT SYSDATE,
    data_atualizacao             DATE
);

-- Adicionar chaves primárias
ALTER TABLE centro_custo ADD CONSTRAINT centro_custo_pk PRIMARY KEY ( id_centro_custo );
ALTER TABLE conta ADD CONSTRAINT conta_pk PRIMARY KEY ( id_conta );
ALTER TABLE registro_contabil ADD CONSTRAINT registro_contabil_pk PRIMARY KEY ( id_registro_contabil );

-- Adicionar chaves estrangeiras
ALTER TABLE registro_contabil
    ADD CONSTRAINT registro_contabil_centro_custo_fk FOREIGN KEY ( centro_custo_id_centro_custo )
        REFERENCES centro_custo ( id_centro_custo );

ALTER TABLE registro_contabil
    ADD CONSTRAINT registro_contabil_conta_fk FOREIGN KEY ( conta_id_conta )
        REFERENCES conta ( id_conta );

-- Criar índices para performance
CREATE INDEX idx_registro_contabil_conta ON registro_contabil (conta_id_conta);
CREATE INDEX idx_registro_contabil_centro_custo ON registro_contabil (centro_custo_id_centro_custo);
CREATE INDEX idx_registro_contabil_data_criacao ON registro_contabil (data_criacao);

-- Inserir dados de exemplo
INSERT INTO centro_custo (id_centro_custo, nome_centro_custo) VALUES (seq_centro_custo.NEXTVAL, 'Administração');
INSERT INTO centro_custo (id_centro_custo, nome_centro_custo) VALUES (seq_centro_custo.NEXTVAL, 'Vendas');
INSERT INTO centro_custo (id_centro_custo, nome_centro_custo) VALUES (seq_centro_custo.NEXTVAL, 'Produção');

INSERT INTO conta (id_conta, nome_conta, tipo) VALUES (seq_conta.NEXTVAL, 'Caixa', 'D');
INSERT INTO conta (id_conta, nome_conta, tipo) VALUES (seq_conta.NEXTVAL, 'Bancos', 'D');
INSERT INTO conta (id_conta, nome_conta, tipo) VALUES (seq_conta.NEXTVAL, 'Receitas', 'C');
INSERT INTO conta (id_conta, nome_conta, tipo) VALUES (seq_conta.NEXTVAL, 'Despesas', 'D');

-- Inserir registros contábeis de exemplo
INSERT INTO registro_contabil (id_registro_contabil, valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (seq_registro_contabil.NEXTVAL, 1000.00, 1, 1);

INSERT INTO registro_contabil (id_registro_contabil, valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (seq_registro_contabil.NEXTVAL, 2500.00, 2, 2);

INSERT INTO registro_contabil (id_registro_contabil, valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (seq_registro_contabil.NEXTVAL, 5000.00, 3, 2);

-- Commit das alterações
COMMIT;
