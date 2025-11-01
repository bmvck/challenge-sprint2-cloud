package com.fiap.financecontrol.gateways;

import com.fiap.financecontrol.domains.Cliente;
import com.fiap.financecontrol.gateways.dtos.ClienteRequestDto;
import com.fiap.financecontrol.services.*;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.test.web.servlet.MockMvc;

import java.time.LocalDateTime;
import java.util.Optional;

import static org.mockito.ArgumentMatchers.any;
import static org.mockito.ArgumentMatchers.anyLong;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

@WebMvcTest(ClienteController.class)
@ActiveProfiles("test")
class ClienteControllerTest {

    @Autowired
    private MockMvc mockMvc;

    @Autowired
    private ObjectMapper objectMapper;

    @MockBean
    private CreateClienteService createClienteService;

    @MockBean
    private UpdateClienteService updateClienteService;

    @MockBean
    private ListClientesService listClientesService;

    @MockBean
    private FindByIdClienteService findByIdClienteService;

    @MockBean
    private DeleteClienteService deleteClienteService;

    @Test
    void shouldCreateCliente() throws Exception {
        // Given
        ClienteRequestDto requestDto = new ClienteRequestDto();
        requestDto.setNomeCliente("João Silva");
        requestDto.setCpfCnpj("12345678901");
        requestDto.setEmail("joao@email.com");
        requestDto.setSenha("senha123");
        requestDto.setAtivo("S");

        Cliente cliente = Cliente.builder()
                .id(1L)
                .nomeCliente("João Silva")
                .cpfCnpj("12345678901")
                .email("joao@email.com")
                .senha("senha123")
                .ativo("S")
                .dataCadastro(LocalDateTime.now())
                .build();

        when(createClienteService.execute(any(Cliente.class))).thenReturn(cliente);

        // When & Then
        mockMvc.perform(post("/fiap/clientes")
                        .contentType(MediaType.APPLICATION_JSON)
                        .content(objectMapper.writeValueAsString(requestDto)))
                .andExpect(status().isCreated())
                .andExpect(jsonPath("$.id").value(1))
                .andExpect(jsonPath("$.nomeCliente").value("João Silva"))
                .andExpect(jsonPath("$.email").value("joao@email.com"));
    }

    @Test
    void shouldGetClienteById() throws Exception {
        // Given
        Cliente cliente = Cliente.builder()
                .id(1L)
                .nomeCliente("João Silva")
                .cpfCnpj("12345678901")
                .email("joao@email.com")
                .senha("senha123")
                .ativo("S")
                .dataCadastro(LocalDateTime.now())
                .build();

        when(findByIdClienteService.executeOrThrow(1L)).thenReturn(cliente);

        // When & Then
        mockMvc.perform(get("/fiap/clientes/1"))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$.id").value(1))
                .andExpect(jsonPath("$.nomeCliente").value("João Silva"))
                .andExpect(jsonPath("$.email").value("joao@email.com"));
    }

    @Test
    void shouldReturnBadRequestForInvalidData() throws Exception {
        // Given
        ClienteRequestDto requestDto = new ClienteRequestDto();
        // Dados inválidos - campos obrigatórios vazios

        // When & Then
        mockMvc.perform(post("/fiap/clientes")
                        .contentType(MediaType.APPLICATION_JSON)
                        .content(objectMapper.writeValueAsString(requestDto)))
                .andExpect(status().isBadRequest());
    }

    @Test
    void shouldUpdateCliente() throws Exception {
        // Given
        ClienteRequestDto requestDto = new ClienteRequestDto();
        requestDto.setNomeCliente("João Silva Santos");
        requestDto.setCpfCnpj("12345678901");
        requestDto.setEmail("joao.santos@email.com");
        requestDto.setSenha("senha123");
        requestDto.setAtivo("S");

        Cliente clienteAtualizado = Cliente.builder()
                .id(1L)
                .nomeCliente("João Silva Santos")
                .cpfCnpj("12345678901")
                .email("joao.santos@email.com")
                .senha("senha123")
                .ativo("S")
                .dataCadastro(LocalDateTime.now())
                .build();

        when(updateClienteService.execute(any(Cliente.class))).thenReturn(clienteAtualizado);

        // When & Then
        mockMvc.perform(put("/fiap/clientes/1")
                        .contentType(MediaType.APPLICATION_JSON)
                        .content(objectMapper.writeValueAsString(requestDto)))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$.id").value(1))
                .andExpect(jsonPath("$.nomeCliente").value("João Silva Santos"))
                .andExpect(jsonPath("$.email").value("joao.santos@email.com"));
    }

    @Test
    void shouldDeleteCliente() throws Exception {
        // When & Then
        mockMvc.perform(delete("/fiap/clientes/1"))
                .andExpect(status().isNoContent());
    }
}
