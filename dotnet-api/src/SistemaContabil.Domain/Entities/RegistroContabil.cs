using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaContabil.Domain.Entities;

/// <summary>
/// Entidade que representa um Registro Contábil (lançamento contábil)
/// </summary>
public class RegistroContabil
{
    /// <summary>
    /// Identificador único do registro contábil
    /// </summary>
    [Key]
    public int IdRegCont { get; set; }

    /// <summary>
    /// Valor do registro contábil
    /// </summary>
    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Identificador da conta associada
    /// </summary>
    [Required]
    public int ContaIdConta { get; set; }

    /// <summary>
    /// Identificador do centro de custo associado
    /// </summary>
    [Required]
    public int CentroCustoIdCentroCusto { get; set; }

    /// <summary>
    /// Data de criação do registro
    /// </summary>
    public DateTime DataCriacao { get; set; } = DateTime.Now;

    /// <summary>
    /// Data da última atualização
    /// </summary>
    public DateTime? DataAtualizacao { get; set; }

    /// <summary>
    /// Conta associada ao registro
    /// </summary>
    [ForeignKey(nameof(ContaIdConta))]
    public virtual Conta Conta { get; set; } = null!;

    /// <summary>
    /// Centro de custo associado ao registro
    /// </summary>
    [ForeignKey(nameof(CentroCustoIdCentroCusto))]
    public virtual CentroCusto CentroCusto { get; set; } = null!;

    /// <summary>
    /// Vendas associadas ao registro contábil
    /// </summary>
    public virtual ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();

    /// <summary>
    /// Valida se o registro contábil está válido para operações
    /// </summary>
    /// <returns>True se válido, False caso contrário</returns>
    public bool IsValid()
    {
        return Valor > 0 && 
               Valor <= 999999.99m &&
               ContaIdConta > 0 &&
               CentroCustoIdCentroCusto > 0;
    }

    /// <summary>
    /// Atualiza o valor do registro contábil
    /// </summary>
    /// <param name="novoValor">Novo valor para o registro</param>
    /// <exception cref="ArgumentException">Lançada quando o valor é inválido</exception>
    public void AtualizarValor(decimal novoValor)
    {
        if (novoValor <= 0)
            throw new ArgumentException("Valor deve ser maior que zero", nameof(novoValor));
        
        if (novoValor > 999999.99m)
            throw new ArgumentException("Valor não pode ser maior que 999.999,99", nameof(novoValor));

        Valor = novoValor;
        DataAtualizacao = DateTime.Now;
    }

    /// <summary>
    /// Atualiza a conta associada ao registro
    /// </summary>
    /// <param name="contaId">ID da nova conta</param>
    /// <exception cref="ArgumentException">Lançada quando o ID é inválido</exception>
    public void AtualizarConta(int contaId)
    {
        if (contaId <= 0)
            throw new ArgumentException("ID da conta deve ser maior que zero", nameof(contaId));

        ContaIdConta = contaId;
        DataAtualizacao = DateTime.Now;
    }

    /// <summary>
    /// Atualiza o centro de custo associado ao registro
    /// </summary>
    /// <param name="centroCustoId">ID do novo centro de custo</param>
    /// <exception cref="ArgumentException">Lançada quando o ID é inválido</exception>
    public void AtualizarCentroCusto(int centroCustoId)
    {
        if (centroCustoId <= 0)
            throw new ArgumentException("ID do centro de custo deve ser maior que zero", nameof(centroCustoId));

        CentroCustoIdCentroCusto = centroCustoId;
        DataAtualizacao = DateTime.Now;
    }

    /// <summary>
    /// Retorna uma descrição resumida do registro
    /// </summary>
    /// <returns>Descrição do registro</returns>
    public string GetDescricao()
    {
        return $"Registro: {IdRegCont} - Valor: {Valor:C} - Conta: {ContaIdConta} - Centro: {CentroCustoIdCentroCusto}";
    }
}
