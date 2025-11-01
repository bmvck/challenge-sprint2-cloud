package com.fiap.financecontrol.gateways;

import com.fiap.financecontrol.domains.CentroCusto;
import com.fiap.financecontrol.gateways.dtos.CentroCustoRequestDto;
import com.fiap.financecontrol.gateways.dtos.CentroCustoResponseDto;
import com.fiap.financecontrol.services.*;
import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Sort;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/fiap/centros-custo")
@RequiredArgsConstructor
public class CentroCustoController {

    private final CreateCentroCustoService createCentroCustoService;
    private final UpdateCentroCustoService updateCentroCustoService;
    private final ListCentrosCustoService listCentrosCustoService;
    private final FindByIdCentroCustoService findByIdCentroCustoService;
    private final DeleteCentroCustoService deleteCentroCustoService;

    @GetMapping("/{id}")
    public ResponseEntity<CentroCustoResponseDto> getCentroCusto(@PathVariable Long id) {
        CentroCusto centroCusto = findByIdCentroCustoService.executeOrThrow(id);
        return ResponseEntity.ok(CentroCustoResponseDto.fromEntity(centroCusto));
    }

    @GetMapping
    public ResponseEntity<Page<CentroCustoResponseDto>> getCentrosCusto(
            @RequestParam(defaultValue = "0") int page,
            @RequestParam(defaultValue = "ASC") Sort.Direction direction,
            @RequestParam(defaultValue = "10") int size,
            @RequestParam(required = false) String nome
    ) {
        Page<CentroCusto> centrosCusto;
        
        if (nome != null && !nome.trim().isEmpty()) {
            centrosCusto = listCentrosCustoService.buscarCentrosCustoPorNome(nome, page, size, direction);
        } else {
            centrosCusto = listCentrosCustoService.listarCentrosCusto(page, size, direction);
        }

        Page<CentroCustoResponseDto> response = centrosCusto.map(CentroCustoResponseDto::fromEntity);

        if (centrosCusto.isEmpty()) {
            return ResponseEntity.noContent().build();
        } else {
            return ResponseEntity.ok(response);
        }
    }

    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public CentroCustoResponseDto createCentroCusto(@RequestBody @Valid CentroCustoRequestDto centroCustoDto) {
        CentroCusto centroCusto = createCentroCustoService.execute(centroCustoDto.toEntity());
        return CentroCustoResponseDto.fromEntity(centroCusto);
    }

    @PutMapping("/{id}")
    public CentroCustoResponseDto updateCentroCusto(@PathVariable Long id, @RequestBody @Valid CentroCustoRequestDto centroCustoDto) {
        CentroCusto centroCusto = centroCustoDto.toEntity();
        centroCusto.setId(id);
        CentroCusto centroCustoAtualizado = updateCentroCustoService.execute(centroCusto);
        return CentroCustoResponseDto.fromEntity(centroCustoAtualizado);
    }

    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    public void deleteCentroCusto(@PathVariable Long id) {
        deleteCentroCustoService.execute(id);
    }
}
