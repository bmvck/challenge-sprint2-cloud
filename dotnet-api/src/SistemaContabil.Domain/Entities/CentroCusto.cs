using System.ComponentModel.DataAnnotations;

namespace SistemaContabil.Domain.Entities;

/// <summary>
/// Entidade que representa um Centro de Custo no sistema contábil
/// </summary>
public class CentroCusto
{
    /// <summary>
    /// Identificador único do centro de custo
    /// </summary>
    [Key]
    public int IdCentroCusto { get; set; }

    /// <summary>
    /// Nome do centro de custo
    /// </summary>
    [Required]
    [StringLength(70)]
    public string NomeCentroCusto { get; set; } = string.Empty;

    /// <summary>
    /// Registros contábeis associados a este centro de custo
    /// </summary>
    public virtual ICollection<RegistroContabil> RegistrosContabeis { get; set; } = new List<RegistroContabil>();

    /// <summary>
    /// Valida se o centro de custo está válido para operações
    /// </summary>
    /// <returns>True se válido, False caso contrário</returns>
    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(NomeCentroCusto) && 
               NomeCentroCusto.Length <= 70;
    }

    /// <summary>
    /// Atualiza o nome do centro de custo
    /// </summary>
    /// <param name="novoNome">Novo nome para o centro de custo</param>
    /// <exception cref="ArgumentException">Lançada quando o nome é inválido</exception>
    public void AtualizarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
            throw new ArgumentException("Nome do centro de custo não pode ser vazio", nameof(novoNome));
        
        if (novoNome.Length > 70)
            throw new ArgumentException("Nome do centro de custo não pode ter mais de 70 caracteres", nameof(novoNome));

        NomeCentroCusto = novoNome.Trim();
    }
}
