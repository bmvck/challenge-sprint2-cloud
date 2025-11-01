-- ========================================
-- SCRIPT COMPLETO DE CRIAÇÃO DO BANCO
-- Sistema Contábil - Oracle FIAP
-- ========================================

-- Limpar ambiente (remover tabelas existentes)
DROP TABLE registro_contabil CASCADE CONSTRAINTS;
DROP TABLE conta CASCADE CONSTRAINTS;
DROP TABLE centro_custo CASCADE CONSTRAINTS;

-- Remover sequences existentes
DROP SEQUENCE seq_centro_custo;
DROP SEQUENCE seq_conta;
DROP SEQUENCE seq_registro_contabil;

-- ========================================
-- CRIAÇÃO DAS SEQUENCES
-- ========================================

CREATE SEQUENCE seq_centro_custo 
    START WITH 1 
    INCREMENT BY 1 
    NOCACHE;

CREATE SEQUENCE seq_conta 
    START WITH 1 
    INCREMENT BY 1 
    NOCACHE;

CREATE SEQUENCE seq_registro_contabil 
    START WITH 1 
    INCREMENT BY 1 
    NOCACHE;

-- ========================================
-- CRIAÇÃO DAS TABELAS
-- ========================================

-- Tabela CENTRO_CUSTO
CREATE TABLE centro_custo (
    id_centro_custo   NUMBER(4) NOT NULL,
    nome_centro_custo VARCHAR2(70) NOT NULL
);

ALTER TABLE centro_custo 
ADD CONSTRAINT centro_custo_pk 
PRIMARY KEY (id_centro_custo);

-- Tabela CONTA
CREATE TABLE conta (
    id_conta   NUMBER(4) NOT NULL,
    nome_conta VARCHAR2(70) NOT NULL,
    tipo       CHAR(1) NOT NULL
);

ALTER TABLE conta 
ADD CONSTRAINT conta_pk 
PRIMARY KEY (id_conta);

-- Tabela REGISTRO_CONTABIL
CREATE TABLE registro_contabil (
    id_registro_contabil         NUMBER(4) NOT NULL,
    valor                        NUMBER(9, 2) NOT NULL,
    conta_id_conta               NUMBER(4) NOT NULL,
    centro_custo_id_centro_custo NUMBER(4) NOT NULL,
    data_criacao                 DATE DEFAULT SYSDATE,
    data_atualizacao             DATE DEFAULT SYSDATE
);

ALTER TABLE registro_contabil 
ADD CONSTRAINT registro_contabil_pk 
PRIMARY KEY (id_registro_contabil);

-- ========================================
-- CHAVES ESTRANGEIRAS
-- ========================================

ALTER TABLE registro_contabil
ADD CONSTRAINT registro_contabil_centro_custo_fk 
FOREIGN KEY (centro_custo_id_centro_custo)
REFERENCES centro_custo (id_centro_custo);

ALTER TABLE registro_contabil
ADD CONSTRAINT registro_contabil_conta_fk 
FOREIGN KEY (conta_id_conta)
REFERENCES conta (id_conta);

-- ========================================
-- TRIGGERS PARA AUTO-INCREMENTO
-- ========================================

-- Trigger para CENTRO_CUSTO
CREATE OR REPLACE TRIGGER trg_centro_custo_id
    BEFORE INSERT ON centro_custo
    FOR EACH ROW
BEGIN
    IF :NEW.id_centro_custo IS NULL THEN
        :NEW.id_centro_custo := seq_centro_custo.NEXTVAL;
    END IF;
END;
/

-- Trigger para CONTA
CREATE OR REPLACE TRIGGER trg_conta_id
    BEFORE INSERT ON conta
    FOR EACH ROW
BEGIN
    IF :NEW.id_conta IS NULL THEN
        :NEW.id_conta := seq_conta.NEXTVAL;
    END IF;
END;
/

-- Trigger para REGISTRO_CONTABIL
CREATE OR REPLACE TRIGGER trg_registro_contabil_id
    BEFORE INSERT ON registro_contabil
    FOR EACH ROW
BEGIN
    IF :NEW.id_registro_contabil IS NULL THEN
        :NEW.id_registro_contabil := seq_registro_contabil.NEXTVAL;
    END IF;
END;
/

-- Trigger para atualizar DATA_ATUALIZACAO
CREATE OR REPLACE TRIGGER trg_registro_contabil_update
    BEFORE UPDATE ON registro_contabil
    FOR EACH ROW
BEGIN
    :NEW.data_atualizacao := SYSDATE;
END;
/

-- ========================================
-- DADOS BÁSICOS
-- ========================================

-- Centros de Custo
INSERT INTO centro_custo (nome_centro_custo) VALUES ('Administração');
INSERT INTO centro_custo (nome_centro_custo) VALUES ('Vendas');
INSERT INTO centro_custo (nome_centro_custo) VALUES ('Produção');
INSERT INTO centro_custo (nome_centro_custo) VALUES ('Marketing');
INSERT INTO centro_custo (nome_centro_custo) VALUES ('Recursos Humanos');

-- Contas
INSERT INTO conta (nome_conta, tipo) VALUES ('Caixa', 'D');
INSERT INTO conta (nome_conta, tipo) VALUES ('Bancos', 'D');
INSERT INTO conta (nome_conta, tipo) VALUES ('Contas a Receber', 'D');
INSERT INTO conta (nome_conta, tipo) VALUES ('Estoque', 'D');
INSERT INTO conta (nome_conta, tipo) VALUES ('Imóveis', 'D');
INSERT INTO conta (nome_conta, tipo) VALUES ('Veículos', 'D');
INSERT INTO conta (nome_conta, tipo) VALUES ('Receitas de Vendas', 'C');
INSERT INTO conta (nome_conta, tipo) VALUES ('Receitas de Serviços', 'C');
INSERT INTO conta (nome_conta, tipo) VALUES ('Outras Receitas', 'C');
INSERT INTO conta (nome_conta, tipo) VALUES ('Salários', 'D');
INSERT INTO conta (nome_conta, tipo) VALUES ('Aluguel', 'D');
INSERT INTO conta (nome_conta, tipo) VALUES ('Energia Elétrica', 'D');
INSERT INTO conta (nome_conta, tipo) VALUES ('Telefone', 'D');
INSERT INTO conta (nome_conta, tipo) VALUES ('Material de Escritório', 'D');
INSERT INTO conta (nome_conta, tipo) VALUES ('Marketing e Publicidade', 'D');

-- Registros Contábeis de Exemplo
INSERT INTO registro_contabil (valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (10000.00, 1, 1); -- Caixa - Administração

INSERT INTO registro_contabil (valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (25000.50, 2, 2); -- Bancos - Vendas

INSERT INTO registro_contabil (valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (5000.00, 7, 2); -- Receitas de Vendas - Vendas

INSERT INTO registro_contabil (valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (15000.00, 8, 3); -- Receitas de Serviços - Produção

INSERT INTO registro_contabil (valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (5000.00, 10, 1); -- Salários - Administração

INSERT INTO registro_contabil (valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (2000.00, 11, 1); -- Aluguel - Administração

INSERT INTO registro_contabil (valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (800.00, 12, 1); -- Energia Elétrica - Administração

INSERT INTO registro_contabil (valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (300.00, 13, 1); -- Telefone - Administração

INSERT INTO registro_contabil (valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (500.00, 14, 1); -- Material de Escritório - Administração

INSERT INTO registro_contabil (valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (3000.00, 15, 4); -- Marketing e Publicidade - Marketing

-- ========================================
-- VERIFICAÇÃO DOS DADOS
-- ========================================

-- Verificar estrutura das tabelas
SELECT 'CENTRO_CUSTO' as tabela, COUNT(*) as registros FROM centro_custo
UNION ALL
SELECT 'CONTA' as tabela, COUNT(*) as registros FROM conta
UNION ALL
SELECT 'REGISTRO_CONTABIL' as tabela, COUNT(*) as registros FROM registro_contabil;

-- Verificar dados inseridos
SELECT '=== CENTROS DE CUSTO ===' as info FROM dual;
SELECT * FROM centro_custo ORDER BY id_centro_custo;

SELECT '=== CONTAS ===' as info FROM dual;
SELECT * FROM conta ORDER BY id_conta;

SELECT '=== REGISTROS CONTÁBEIS ===' as info FROM dual;
SELECT 
    rc.id_registro_contabil,
    rc.valor,
    c.nome_conta,
    c.tipo,
    cc.nome_centro_custo,
    rc.data_criacao
FROM registro_contabil rc
JOIN conta c ON rc.conta_id_conta = c.id_conta
JOIN centro_custo cc ON rc.centro_custo_id_centro_custo = cc.id_centro_custo
ORDER BY rc.id_registro_contabil;

-- ========================================
-- COMMIT E FINALIZAÇÃO
-- ========================================

COMMIT;

SELECT '=== BANCO DE DADOS CRIADO COM SUCESSO! ===' as status FROM dual;
SELECT 'Sistema Contábil pronto para uso!' as mensagem FROM dual;
