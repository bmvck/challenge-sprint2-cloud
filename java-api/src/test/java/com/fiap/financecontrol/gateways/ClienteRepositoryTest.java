package com.fiap.financecontrol.gateways;

import com.fiap.financecontrol.domains.Cliente;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import org.springframework.test.context.ActiveProfiles;

import java.time.LocalDateTime;
import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThat;

@DataJpaTest
@ActiveProfiles("test")
class ClienteRepositoryTest {

    @Autowired
    private TestEntityManager entityManager;

    @Autowired
    private ClienteRepository clienteRepository;

    @Test
    void shouldFindClienteByEmail() {
        // Given
        Cliente cliente = Cliente.builder()
                .nomeCliente("João Silva")
                .cpfCnpj("12345678901")
                .email("joao@email.com")
                .senha("senha123")
                .ativo("S")
                .dataCadastro(LocalDateTime.now())
                .build();
        
        entityManager.persistAndFlush(cliente);

        // When
        Optional<Cliente> found = clienteRepository.findByEmail("joao@email.com");

        // Then
        assertThat(found).isPresent();
        assertThat(found.get().getNomeCliente()).isEqualTo("João Silva");
    }

    @Test
    void shouldFindClienteByCpfCnpj() {
        // Given
        Cliente cliente = Cliente.builder()
                .nomeCliente("Maria Santos")
                .cpfCnpj("98765432100")
                .email("maria@email.com")
                .senha("senha456")
                .ativo("S")
                .dataCadastro(LocalDateTime.now())
                .build();
        
        entityManager.persistAndFlush(cliente);

        // When
        Optional<Cliente> found = clienteRepository.findByCpfCnpj("98765432100");

        // Then
        assertThat(found).isPresent();
        assertThat(found.get().getNomeCliente()).isEqualTo("Maria Santos");
    }

    @Test
    void shouldReturnEmptyWhenClienteNotFound() {
        // When
        Optional<Cliente> found = clienteRepository.findByEmail("inexistente@email.com");

        // Then
        assertThat(found).isEmpty();
    }

    @Test
    void shouldCheckIfEmailExists() {
        // Given
        Cliente cliente = Cliente.builder()
                .nomeCliente("Pedro Costa")
                .cpfCnpj("11122233344")
                .email("pedro@email.com")
                .senha("senha789")
                .ativo("S")
                .dataCadastro(LocalDateTime.now())
                .build();
        
        entityManager.persistAndFlush(cliente);

        // When & Then
        assertThat(clienteRepository.existsByEmail("pedro@email.com")).isTrue();
        assertThat(clienteRepository.existsByEmail("inexistente@email.com")).isFalse();
    }
}
