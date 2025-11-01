using System.ComponentModel.DataAnnotations;

namespace SistemaContabil.Domain.Entities;

/// <summary>
/// Entidade que representa uma Conta no plano de contas
/// </summary>
public class Conta
{
    /// <summary>
    /// Identificador único da conta
    /// </summary>
    [Key]
    public int IdConta { get; set; }

    /// <summary>
    /// Nome da conta
    /// </summary>
    [Required]
    [StringLength(70)]
    public string NomeConta { get; set; } = string.Empty;

    /// <summary>
    /// Tipo da conta (D = Débito, C = Crédito)
    /// </summary>
    [Required]
    [StringLength(1)]
    public char Tipo { get; set; }

    /// <summary>
    /// Registros contábeis associados a esta conta
    /// </summary>
    public virtual ICollection<RegistroContabil> RegistrosContabeis { get; set; } = new List<RegistroContabil>();

    /// <summary>
    /// Valida se a conta está válida para operações
    /// </summary>
    /// <returns>True se válido, False caso contrário</returns>
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(NomeConta) && 
               NomeConta.Length <= 70 &&
               (Tipo == 'D' || Tipo == 'C');
    }

    /// <summary>
    /// Atualiza o nome da conta
    /// </summary>
    /// <param name="novoNome">Novo nome para a conta</param>
    /// <exception cref="ArgumentException">Lançada quando o nome é inválido</exception>
    public void AtualizarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new ArgumentException("Nome da conta não pode ser vazio", nameof(novoNome));
        
        if (novoNome.Length > 70)
            throw new ArgumentException("Nome da conta não pode ter mais de 70 caracteres", nameof(novoNome));

        NomeConta = novoNome.Trim();
    }

    /// <summary>
    /// Atualiza o tipo da conta
    /// </summary>
    /// <param name="novoTipo">Novo tipo para a conta (D ou C)</param>
    /// <exception cref="ArgumentException">Lançada quando o tipo é inválido</exception>
    public void AtualizarTipo(char novoTipo)
    {
        if (novoTipo != 'D' && novoTipo != 'C')
            throw new ArgumentException("Tipo da conta deve ser 'D' (Débito) ou 'C' (Crédito)", nameof(novoTipo));

        Tipo = novoTipo;
    }

    /// <summary>
    /// Retorna o tipo da conta como string descritiva
    /// </summary>
    /// <returns>Descrição do tipo da conta</returns>
    public string GetTipoDescricao()
    {
        return Tipo == 'D' ? "Débito" : "Crédito";
    }
}
