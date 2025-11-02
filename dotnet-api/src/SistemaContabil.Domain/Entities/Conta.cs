using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaContabil.Domain.Entities;

/// <summary>
/// Entidade que representa uma Conta Contábil no plano de contas
/// </summary>
public class Conta
{
    /// <summary>
    /// Identificador único da conta contábil
    /// </summary>
    [Key]
    public int IdContaContabil { get; set; }

    /// <summary>
    /// Nome da conta contábil
    /// </summary>
    [Required]
    [StringLength(70)]
    public string NomeContaContabil { get; set; } = string.Empty;

    /// <summary>
    /// Tipo da conta (R = Receita, D = Despesa)
    /// </summary>
    [Required]
    [StringLength(1)]
    public char Tipo { get; set; }

    /// <summary>
    /// Identificador do cliente associado (nullable)
    /// </summary>
    public int? ClienteIdCliente { get; set; }

    /// <summary>
    /// Cliente associado à conta (se aplicável)
    /// </summary>
    [ForeignKey(nameof(ClienteIdCliente))]
    public virtual Cliente? Cliente { get; set; }

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
        return !string.IsNullOrWhiteSpace(NomeContaContabil) && 
               NomeContaContabil.Length <= 70 &&
               (Tipo == 'R' || Tipo == 'D');
    }

    /// <summary>
    /// Atualiza o nome da conta contábil
    /// </summary>
    /// <param name="novoNome">Novo nome para a conta</param>
    /// <exception cref="ArgumentException">Lançada quando o nome é inválido</exception>
    public void AtualizarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new ArgumentException("Nome da conta contábil não pode ser vazio", nameof(novoNome));
        
        if (novoNome.Length > 70)
            throw new ArgumentException("Nome da conta contábil não pode ter mais de 70 caracteres", nameof(novoNome));

        NomeContaContabil = novoNome.Trim();
    }

    /// <summary>
    /// Atualiza o tipo da conta
    /// </summary>
    /// <param name="novoTipo">Novo tipo para a conta (R ou D)</param>
    /// <exception cref="ArgumentException">Lançada quando o tipo é inválido</exception>
    public void AtualizarTipo(char novoTipo)
    {
        if (novoTipo != 'R' && novoTipo != 'D')
            throw new ArgumentException("Tipo da conta deve ser 'R' (Receita) ou 'D' (Despesa)", nameof(novoTipo));

        Tipo = novoTipo;
    }

    /// <summary>
    /// Retorna o tipo da conta como string descritiva
    /// </summary>
    /// <returns>Descrição do tipo da conta</returns>
    public string GetTipoDescricao()
    {
        return Tipo == 'R' ? "Receita" : "Despesa";
    }
}
