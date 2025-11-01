-- ========================================
-- SCRIPT DE VERIFICAÇÃO DO BANCO
-- Sistema Contábil - Oracle FIAP
-- ========================================

-- Verificar se as tabelas existem
SELECT '=== VERIFICAÇÃO DE TABELAS ===' as info FROM dual;

SELECT table_name, num_rows 
FROM user_tables 
WHERE table_name IN ('CENTRO_CUSTO', 'CONTA', 'REGISTRO_CONTABIL')
ORDER BY table_name;

-- Verificar se as sequences existem
SELECT '=== VERIFICAÇÃO DE SEQUENCES ===' as info FROM dual;

SELECT sequence_name, last_number 
FROM user_sequences 
WHERE sequence_name IN ('SEQ_CENTRO_CUSTO', 'SEQ_CONTA', 'SEQ_REGISTRO_CONTABIL')
ORDER BY sequence_name;

-- Verificar estrutura das tabelas
SELECT '=== ESTRUTURA DA TABELA CENTRO_CUSTO ===' as info FROM dual;
DESC centro_custo;

SELECT '=== ESTRUTURA DA TABELA CONTA ===' as info FROM dual;
DESC conta;

SELECT '=== ESTRUTURA DA TABELA REGISTRO_CONTABIL ===' as info FROM dual;
DESC registro_contabil;

-- Verificar dados inseridos
SELECT '=== DADOS DE CENTROS DE CUSTO ===' as info FROM dual;
SELECT * FROM centro_custo ORDER BY id_centro_custo;

SELECT '=== DADOS DE CONTAS ===' as info FROM dual;
SELECT * FROM conta ORDER BY id_conta;

SELECT '=== DADOS DE REGISTROS CONTÁBEIS ===' as info FROM dual;
SELECT 
    rc.id_registro_contabil,
    rc.valor,
    c.nome_conta,
    c.tipo,
    cc.nome_centro_custo,
    rc.data_criacao,
    rc.data_atualizacao
FROM registro_contabil rc
JOIN conta c ON rc.conta_id_conta = c.id_conta
JOIN centro_custo cc ON rc.centro_custo_id_centro_custo = cc.id_centro_custo
ORDER BY rc.id_registro_contabil;

-- Verificar constraints
SELECT '=== VERIFICAÇÃO DE CONSTRAINTS ===' as info FROM dual;

SELECT 
    constraint_name,
    table_name,
    constraint_type
FROM user_constraints 
WHERE table_name IN ('CENTRO_CUSTO', 'CONTA', 'REGISTRO_CONTABIL')
ORDER BY table_name, constraint_type;

-- Verificar triggers
SELECT '=== VERIFICAÇÃO DE TRIGGERS ===' as info FROM dual;

SELECT 
    trigger_name,
    table_name,
    trigger_type,
    status
FROM user_triggers 
WHERE table_name IN ('CENTRO_CUSTO', 'CONTA', 'REGISTRO_CONTABIL')
ORDER BY table_name, trigger_name;

-- Teste de inserção
SELECT '=== TESTE DE INSERÇÃO ===' as info FROM dual;

-- Testar inserção de novo centro de custo
INSERT INTO centro_custo (nome_centro_custo) VALUES ('Teste Centro Custo');
SELECT 'Centro de custo inserido com ID: ' || MAX(id_centro_custo) as resultado FROM centro_custo;

-- Testar inserção de nova conta
INSERT INTO conta (nome_conta, tipo) VALUES ('Conta Teste', 'D');
SELECT 'Conta inserida com ID: ' || MAX(id_conta) as resultado FROM conta;

-- Testar inserção de novo registro contábil
INSERT INTO registro_contabil (valor, conta_id_conta, centro_custo_id_centro_custo) 
VALUES (999.99, (SELECT MAX(id_conta FROM conta), (SELECT MAX(id_centro_custo) FROM centro_custo));
SELECT 'Registro contábil inserido com ID: ' || MAX(id_registro_contabil) as resultado FROM registro_contabil;

-- Limpar dados de teste
DELETE FROM registro_contabil WHERE valor = 999.99;
DELETE FROM conta WHERE nome_conta = 'Conta Teste';
DELETE FROM centro_custo WHERE nome_centro_custo = 'Teste Centro Custo';

SELECT '=== DADOS DE TESTE REMOVIDOS ===' as info FROM dual;

-- Estatísticas finais
SELECT '=== ESTATÍSTICAS FINAIS ===' as info FROM dual;

SELECT 
    'Centros de Custo' as entidade,
    COUNT(*) as total_registros
FROM centro_custo
UNION ALL
SELECT 
    'Contas' as entidade,
    COUNT(*) as total_registros
FROM conta
UNION ALL
SELECT 
    'Registros Contábeis' as entidade,
    COUNT(*) as total_registros
FROM registro_contabil;

SELECT '=== BANCO DE DADOS VERIFICADO COM SUCESSO! ===' as status FROM dual;
