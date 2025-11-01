package com.fiap.financecontrol.gateways;

import com.fiap.financecontrol.domains.Vendas;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface VendasRepository extends JpaRepository<Vendas, Long> {

    List<Vendas> findByClienteId(Long clienteId);

    List<Vendas> findByRegistroContabilId(Long registroContabilId);

    Page<Vendas> findByClienteId(Long clienteId, Pageable pageable);

    Page<Vendas> findByRegistroContabilId(Long registroContabilId, Pageable pageable);

    @Query("SELECT v FROM Vendas v WHERE v.cliente.nomeCliente LIKE %:nomeCliente%")
    List<Vendas> findByClienteNomeContaining(@Param("nomeCliente") String nomeCliente);

    @Query("SELECT v FROM Vendas v WHERE v.cliente.email = :email")
    List<Vendas> findByClienteEmail(@Param("email") String email);

    @Query("SELECT COUNT(v) FROM Vendas v WHERE v.cliente.id = :clienteId")
    Long countByClienteId(@Param("clienteId") Long clienteId);

    @Query("SELECT v FROM Vendas v JOIN v.registroContabil rc WHERE rc.valor >= :valorMinimo")
    List<Vendas> findByValorRegistroMaiorOuIgual(@Param("valorMinimo") java.math.BigDecimal valorMinimo);
}
