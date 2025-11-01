package com.fiap.financecontrol.gateways;

import com.fiap.financecontrol.domains.CentroCusto;
import com.fiap.financecontrol.domains.Conta;
import com.fiap.financecontrol.domains.RegistroContabil;
import com.fiap.financecontrol.gateways.dtos.RegistroContabilRequestDto;
import com.fiap.financecontrol.gateways.dtos.RegistroContabilResponseDto;
import com.fiap.financecontrol.services.*;
import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Sort;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.math.BigDecimal;

@RestController
@RequestMapping("/fiap/registros-contabeis")
@RequiredArgsConstructor
public class RegistroContabilController {

    private final CreateRegistroContabilService createRegistroContabilService;
    private final UpdateRegistroContabilService updateRegistroContabilService;
    private final ListRegistrosContabeisService listRegistrosContabeisService;
    private final FindByIdRegistroContabilService findByIdRegistroContabilService;
    private final DeleteRegistroContabilService deleteRegistroContabilService;

    @GetMapping("/{id}")
    public ResponseEntity<RegistroContabilResponseDto> getRegistroContabil(@PathVariable Long id) {
        RegistroContabil registro = findByIdRegistroContabilService.executeOrThrow(id);
        return ResponseEntity.ok(RegistroContabilResponseDto.fromEntity(registro));
    }

    @GetMapping
    public ResponseEntity<Page<RegistroContabilResponseDto>> getRegistrosContabeis(
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "ASC") Sort.Direction direction,
            @RequestParam(defaultValue = "10") int size,
            @RequestParam(required = false) Long contaId,
            @RequestParam(required = false) Long centroCustoId,
            @RequestParam(required = false) BigDecimal valorMinimo,
            @RequestParam(required = false) BigDecimal valorMaximo
    ) {
        Page<RegistroContabil> registros;
        
        if (contaId != null) {
            registros = listRegistrosContabeisService.listarRegistrosPorConta(contaId, page, size, direction);
        } else if (centroCustoId != null) {
            registros = listRegistrosContabeisService.listarRegistrosPorCentroCusto(centroCustoId, page, size, direction);
        } else if (valorMinimo != null && valorMaximo != null) {
            registros = listRegistrosContabeisService.listarRegistrosPorValor(valorMinimo, valorMaximo, page, size, direction);
        } else {
            registros = listRegistrosContabeisService.listarRegistrosContabeis(page, size, direction);
        }

        Page<RegistroContabilResponseDto> response = registros.map(RegistroContabilResponseDto::fromEntity);

        if (registros.isEmpty()) {
            return ResponseEntity.noContent().build();
        } else {
            return ResponseEntity.ok(response);
        }
    }

    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public RegistroContabilResponseDto createRegistroContabil(@RequestBody @Valid RegistroContabilRequestDto registroDto) {
        RegistroContabil registro = registroDto.toEntity();
        
        // Criar objetos de referência com os IDs fornecidos
        registro.setConta(Conta.builder().id(registroDto.getContaId()).build());
        registro.setCentroCusto(CentroCusto.builder().id(registroDto.getCentroCustoId()).build());
        
        RegistroContabil registroCriado = createRegistroContabilService.execute(registro);
        return RegistroContabilResponseDto.fromEntity(registroCriado);
    }

    @PutMapping("/{id}")
    public RegistroContabilResponseDto updateRegistroContabil(@PathVariable Long id, @RequestBody @Valid RegistroContabilRequestDto registroDto) {
        RegistroContabil registro = registroDto.toEntity();
        registro.setId(id);
        
        // Criar objetos de referência com os IDs fornecidos
        registro.setConta(Conta.builder().id(registroDto.getContaId()).build());
        registro.setCentroCusto(CentroCusto.builder().id(registroDto.getCentroCustoId()).build());
        
        RegistroContabil registroAtualizado = updateRegistroContabilService.execute(registro);
        return RegistroContabilResponseDto.fromEntity(registroAtualizado);
    }

    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void deleteRegistroContabil(@PathVariable Long id) {
        deleteRegistroContabilService.execute(id);
    }
}
