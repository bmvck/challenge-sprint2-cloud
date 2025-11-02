using System.ComponentModel.DataAnnotations;

namespace SistemaContabil.Application.DTOs;

/// <summary>
/// DTO para Cliente
/// </summary>
public class ClienteDto
{
    /// <summary>
    /// Identificador único do cliente
    /// </summary>
    public int IdCliente { get; set; }

    /// <summary>
    /// Nome do cliente
    /// </summary>
    public string NomeCliente { get; set; } = string.Empty;

    /// <summary>
    /// Data de cadastro
    /// </summary>
    public DateTime DataCadastro { get; set; }

    /// <summary>
    /// CPF ou CNPJ
    /// </summary>
    public string CpfCnpj { get; set; } = string.Empty;

    /// <summary>
    /// Email do cliente
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Status ativo (S/N)
    /// </summary>
    public string Ativo { get; set; } = "S";

    /// <summary>
    /// Descrição do status
    /// </summary>
    public string StatusDescricao => Ativo == "S" ? "Ativo" : "Inativo";
}

/// <summary>
/// DTO para criação de Cliente
/// </summary>
public class CriarClienteDto
{
    /// <summary>
    /// Nome do cliente
    /// </summary>
    [Required(ErrorMessage = "Nome do cliente é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome não pode ter mais de 100 caracteres")]
    public string NomeCliente { get; set; } = string.Empty;

    /// <summary>
    /// CPF ou CNPJ
    /// </summary>
    [Required(ErrorMessage = "CPF/CNPJ é obrigatório")]
    [StringLength(14, ErrorMessage = "CPF/CNPJ não pode ter mais de 14 caracteres")]
    public string CpfCnpj { get; set; } = string.Empty;

    /// <summary>
    /// Email do cliente
    /// </summary>
    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    [StringLength(100, ErrorMessage = "Email não pode ter mais de 100 caracteres")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Senha do cliente
    /// </summary>
    [Required(ErrorMessage = "Senha é obrigatória")]
    [StringLength(100, ErrorMessage = "Senha não pode ter mais de 100 caracteres")]
    public string Senha { get; set; } = string.Empty;

    /// <summary>
    /// Status ativo (S = Ativo, N = Inativo). Padrão: S
    /// </summary>
    [RegularExpression("^[SN]$", ErrorMessage = "Ativo deve ser 'S' (Ativo) ou 'N' (Inativo)")]
    public string Ativo { get; set; } = "S";

    /// <summary>
    /// Obtém o valor do status como char
    /// </summary>
    public char AtivoChar => !string.IsNullOrEmpty(Ativo) ? Ativo[0] : 'S';
}

/// <summary>
/// DTO para atualização de Cliente
/// </summary>
public class AtualizarClienteDto
{
    /// <summary>
    /// Nome do cliente
    /// </summary>
    [Required(ErrorMessage = "Nome do cliente é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome não pode ter mais de 100 caracteres")]
    public string NomeCliente { get; set; } = string.Empty;

    /// <summary>
    /// Email do cliente
    /// </summary>
    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    [StringLength(100, ErrorMessage = "Email não pode ter mais de 100 caracteres")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Status ativo (S/N)
    /// </summary>
    [RegularExpression("^[SN]$", ErrorMessage = "Ativo deve ser 'S' (Ativo) ou 'N' (Inativo)")]
    public string Ativo { get; set; } = "S";
}
