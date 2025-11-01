using System.ComponentModel.DataAnnotations;

namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO para Registro Contábil
/// </summary>
public class RegistroContabilDto
{
    /// <summary>
    /// Identificador único do registro contábil
    /// </summary>
    public int IdRegistroContabil { get; set; }

    /// <summary>
    /// Valor do registro contábil
    /// </summary>
    [Required(ErrorMessage = "Valor é obrigatório")]
    [Range(0.01, 999999.99, ErrorMessage = "Valor deve estar entre 0,01 e 999.999,99")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Identificador da conta associada
    /// </summary>
    [Required(ErrorMessage = "ID da conta é obrigatório")]
    public int ContaIdConta { get; set; }

    /// <summary>
    /// Identificador do centro de custo associado
    /// </summary>
    [Required(ErrorMessage = "ID do centro de custo é obrigatório")]
    public int CentroCustoIdCentroCusto { get; set; }

    /// <summary>
    /// Nome da conta associada
    /// </summary>
    public string NomeConta { get; set; } = string.Empty;

    /// <summary>
    /// Nome do centro de custo associado
    /// </summary>
    public string NomeCentroCusto { get; set; } = string.Empty;

    /// <summary>
    /// Data de criação do registro
    /// </summary>
    public DateTime DataCriacao { get; set; }

    /// <summary>
    /// Data da última atualização
    /// </summary>
    public DateTime? DataAtualizacao { get; set; }
}

/// <summary>
/// DTO para criação de Registro Contábil
/// </summary>
public class CriarRegistroContabilDto
{
    /// <summary>
    /// Valor do registro contábil
    /// </summary>
    [Required(ErrorMessage = "Valor é obrigatório")]
    [Range(0.01, 999999.99, ErrorMessage = "Valor deve estar entre 0,01 e 999.999,99")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Identificador da conta associada
    /// </summary>
    [Required(ErrorMessage = "ID da conta é obrigatório")]
    public int ContaIdConta { get; set; }

    /// <summary>
    /// Identificador do centro de custo associado
    /// </summary>
    [Required(ErrorMessage = "ID do centro de custo é obrigatório")]
    public int CentroCustoIdCentroCusto { get; set; }
}

/// <summary>
/// DTO para atualização de Registro Contábil
/// </summary>
public class AtualizarRegistroContabilDto
{
    /// <summary>
    /// Valor do registro contábil
    /// </summary>
    [Required(ErrorMessage = "Valor é obrigatório")]
    [Range(0.01, 999999.99, ErrorMessage = "Valor deve estar entre 0,01 e 999.999,99")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Identificador da conta associada
    /// </summary>
    [Required(ErrorMessage = "ID da conta é obrigatório")]
    public int ContaIdConta { get; set; }

    /// <summary>
    /// Identificador do centro de custo associado
    /// </summary>
    [Required(ErrorMessage = "ID do centro de custo é obrigatório")]
    public int CentroCustoIdCentroCusto { get; set; }
}

/// <summary>
/// DTO para resposta de Registro Contábil com detalhes
/// </summary>
public class RegistroContabilDetalhesDto
{
    /// <summary>
    /// Identificador único do registro contábil
    /// </summary>
    public int IdRegistroContabil { get; set; }

    /// <summary>
    /// Valor do registro contábil
    /// </summary>
    public decimal Valor { get; set; }

    /// <summary>
    /// Data de criação do registro
    /// </summary>
    public DateTime DataCriacao { get; set; }

    /// <summary>
    /// Data da última atualização
    /// </summary>
    public DateTime? DataAtualizacao { get; set; }

    /// <summary>
    /// Informações da conta associada
    /// </summary>
    public ContaDto Conta { get; set; } = new();

    /// <summary>
    /// Informações do centro de custo associado
    /// </summary>
    public CentroCustoDto CentroCusto { get; set; } = new();
}

/// <summary>
/// DTO para filtros de busca de Registro Contábil
/// </summary>
public class FiltroRegistroContabilDto
{
    /// <summary>
    /// ID da conta para filtrar
    /// </summary>
    public int? ContaId { get; set; }

    /// <summary>
    /// ID do centro de custo para filtrar
    /// </summary>
    public int? CentroCustoId { get; set; }

    /// <summary>
    /// Data de início do período
    /// </summary>
    public DateTime? DataInicio { get; set; }

    /// <summary>
    /// Data de fim do período
    /// </summary>
    public DateTime? DataFim { get; set; }

    /// <summary>
    /// Valor mínimo
    /// </summary>
    public decimal? ValorMinimo { get; set; }

    /// <summary>
    /// Valor máximo
    /// </summary>
    public decimal? ValorMaximo { get; set; }

    /// <summary>
    /// Ordenação por campo
    /// </summary>
    public string? OrdenarPor { get; set; }

    /// <summary>
    /// Direção da ordenação (asc/desc)
    /// </summary>
    public string? DirecaoOrdenacao { get; set; } = "asc";
}
