using System.ComponentModel.DataAnnotations;

namespace SistemaContabil.Domain.Entities;

/// <summary>
/// Entidade que representa um Cliente no sistema
/// </summary>
public class Cliente
{
    /// <summary>
    /// Identificador único do cliente
    /// </summary>
    [Key]
    public int IdCliente { get; set; }

    /// <summary>
    /// Nome do cliente
    /// </summary>
    [Required]
    [StringLength(100)]
    public string NomeCliente { get; set; } = string.Empty;

    /// <summary>
    /// Data de cadastro do cliente
    /// </summary>
    [Required]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    /// <summary>
    /// CPF ou CNPJ do cliente
    /// </summary>
    [Required]
    [StringLength(14)]
    public string CpfCnpj { get; set; } = string.Empty;

    /// <summary>
    /// Email do cliente
    /// </summary>
    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Senha do cliente
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Senha { get; set; } = string.Empty;

    /// <summary>
    /// Indica se o cliente está ativo (S/N)
    /// </summary>
    [Required]
    [StringLength(1)]
    public char Ativo { get; set; } = 'S';

    /// <summary>
    /// Contas contábeis associadas ao cliente
    /// </summary>
    public virtual ICollection<Conta> Contas { get; set; } = new List<Conta>();

    /// <summary>
    /// Vendas associadas ao cliente
    /// </summary>
    public virtual ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();

    /// <summary>
    /// Valida se o cliente está válido para operações
    /// </summary>
    /// <returns>True se válido, False caso contrário</returns>
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(NomeCliente) &&
               NomeCliente.Length <= 100 &&
               !string.IsNullOrWhiteSpace(CpfCnpj) &&
               CpfCnpj.Length <= 14 &&
               !string.IsNullOrWhiteSpace(Email) &&
               Email.Length <= 100 &&
               (Ativo == 'S' || Ativo == 'N');
    }

    /// <summary>
    /// Atualiza o status ativo/inativo do cliente
    /// </summary>
    /// <param name="ativo">True para ativar, False para desativar</param>
    public void AtualizarStatus(bool ativo)
    {
        Ativo = ativo ? 'S' : 'N';
    }
}
