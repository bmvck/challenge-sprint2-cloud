package com.fiap.financecontrol.gateways;

import com.fiap.financecontrol.domains.Cliente;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface ClienteRepository extends JpaRepository<Cliente, Long> {

    Optional<Cliente> findByEmail(String email);

    Optional<Cliente> findByCpfCnpj(String cpfCnpj);

    List<Cliente> findByAtivo(String ativo);

    Page<Cliente> findByAtivo(String ativo, Pageable pageable);

    @Query("SELECT c FROM Cliente c WHERE c.nomeCliente LIKE %:nome%")
    List<Cliente> findByNomeContaining(@Param("nome") String nome);

    @Query("SELECT c FROM Cliente c WHERE c.nomeCliente LIKE %:nome% AND c.ativo = :ativo")
    Page<Cliente> findByNomeContainingAndAtivo(@Param("nome") String nome, @Param("ativo") String ativo, Pageable pageable);

    boolean existsByEmail(String email);

    boolean existsByCpfCnpj(String cpfCnpj);
}
