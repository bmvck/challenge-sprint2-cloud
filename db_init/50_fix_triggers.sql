ALTER SESSION SET current_schema = APPUSER;

-- (re)crie aqui os três triggers, QUALIFICANDO as tabelas com APPUSER.
-- Exemplo (ajuste os nomes exatos das tabelas/colunas conforme seu SQL):
CREATE OR REPLACE TRIGGER APPUSER.trg_reg_cont_biu_aud
BEFORE INSERT OR UPDATE ON APPUSER.reg_cont
FOR EACH ROW
BEGIN
  :NEW.dt_atualizacao := SYSTIMESTAMP;
END;
/

CREATE OR REPLACE TRIGGER APPUSER.trg_venda_evento_ai
AFTER INSERT ON APPUSER.vendas
FOR EACH ROW
BEGIN
  -- sua lógica…
  NULL;
END;
/

CREATE OR REPLACE TRIGGER APPUSER.trg_vendas_ai_ensure_regcont
AFTER INSERT ON APPUSER.vendas
FOR EACH ROW
BEGIN
  -- sua lógica…
  NULL;
END;
/
