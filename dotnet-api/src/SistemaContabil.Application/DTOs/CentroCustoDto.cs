using System.ComponentModel.DataAnnotations;

namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO para Centro de Custo
/// </summary>
public class CentroCustoDto
{
    /// <summary>
    /// Identificador único do centro de custo
    /// </summary>
    public int IdCentroCusto { get; set; }

    /// <summary>
    /// Nome do centro de custo
    /// </summary>
    [Required(ErrorMessage = "Nome do centro de custo é obrigatório")]
    [StringLength(70, ErrorMessage = "Nome não pode ter mais de 70 caracteres")]
    public string NomeCentroCusto { get; set; } = string.Empty;

    /// <summary>
    /// Quantidade de registros contábeis associados
    /// </summary>
    public int QuantidadeRegistros { get; set; }

    /// <summary>
    /// Data de criação
    /// </summary>
    public DateTime? DataCriacao { get; set; }
}

/// <summary>
/// DTO para criação de Centro de Custo
/// </summary>
public class CriarCentroCustoDto
{
    /// <summary>
    /// Nome do centro de custo
    /// </summary>
    [Required(ErrorMessage = "Nome do centro de custo é obrigatório")]
    [StringLength(70, ErrorMessage = "Nome não pode ter mais de 70 caracteres")]
    public string NomeCentroCusto { get; set; } = string.Empty;
}

/// <summary>
/// DTO para atualização de Centro de Custo
/// </summary>
public class AtualizarCentroCustoDto
{
    /// <summary>
    /// Nome do centro de custo
    /// </summary>
    [Required(ErrorMessage = "Nome do centro de custo é obrigatório")]
    [StringLength(70, ErrorMessage = "Nome não pode ter mais de 70 caracteres")]
    public string NomeCentroCusto { get; set; } = string.Empty;
}

/// <summary>
/// DTO para resposta de Centro de Custo com detalhes
/// </summary>
public class CentroCustoDetalhesDto
{
    /// <summary>
    /// Identificador único do centro de custo
    /// </summary>
    public int IdCentroCusto { get; set; }

    /// <summary>
    /// Nome do centro de custo
    /// </summary>
    public string NomeCentroCusto { get; set; } = string.Empty;

    /// <summary>
    /// Lista de registros contábeis associados
    /// </summary>
    public List<RegistroContabilDto> RegistrosContabeis { get; set; } = new();

    /// <summary>
    /// Total de registros
    /// </summary>
    public int TotalRegistros { get; set; }

    /// <summary>
    /// Valor total dos registros
    /// </summary>
    public decimal ValorTotal { get; set; }
}
