using FluentValidation;
using SistemaContabil.Application.DTOs;

namespace SistemaContabil.Application.Validators;

/// <summary>
/// Validador para RegistroContabilDto
/// </summary>
public class RegistroContabilValidator : AbstractValidator<RegistroContabilDto>
{
    public RegistroContabilValidator()
    {
        RuleFor(x => x.Valor)
            .GreaterThan(0).WithMessage("Valor deve ser maior que zero")
            .LessThanOrEqualTo(999999.99m).WithMessage("Valor não pode ser maior que 999.999,99");

        RuleFor(x => x.ContaIdConta)
            .GreaterThan(0).WithMessage("ID da conta deve ser maior que zero");

        RuleFor(x => x.CentroCustoIdCentroCusto)
            .GreaterThan(0).WithMessage("ID do centro de custo deve ser maior que zero");
    }
}

/// <summary>
/// Validador para CriarRegistroContabilDto
/// </summary>
public class CriarRegistroContabilValidator : AbstractValidator<CriarRegistroContabilDto>
{
    public CriarRegistroContabilValidator()
    {
        RuleFor(x => x.Valor)
            .GreaterThan(0).WithMessage("Valor deve ser maior que zero")
            .LessThanOrEqualTo(999999.99m).WithMessage("Valor não pode ser maior que 999.999,99");

        RuleFor(x => x.ContaIdConta)
            .GreaterThan(0).WithMessage("ID da conta deve ser maior que zero");

        RuleFor(x => x.CentroCustoIdCentroCusto)
            .GreaterThan(0).WithMessage("ID do centro de custo deve ser maior que zero");
    }
}

/// <summary>
/// Validador para AtualizarRegistroContabilDto
/// </summary>
public class AtualizarRegistroContabilValidator : AbstractValidator<AtualizarRegistroContabilDto>
{
    public AtualizarRegistroContabilValidator()
    {
        RuleFor(x => x.Valor)
            .GreaterThan(0).WithMessage("Valor deve ser maior que zero")
            .LessThanOrEqualTo(999999.99m).WithMessage("Valor não pode ser maior que 999.999,99");

        RuleFor(x => x.ContaIdConta)
            .GreaterThan(0).WithMessage("ID da conta deve ser maior que zero");

        RuleFor(x => x.CentroCustoIdCentroCusto)
            .GreaterThan(0).WithMessage("ID do centro de custo deve ser maior que zero");
    }
}

/// <summary>
/// Validador para FiltroRegistroContabilDto
/// </summary>
public class FiltroRegistroContabilValidator : AbstractValidator<FiltroRegistroContabilDto>
{
    public FiltroRegistroContabilValidator()
    {
        RuleFor(x => x.ContaId)
            .GreaterThan(0).When(x => x.ContaId.HasValue)
            .WithMessage("ID da conta deve ser maior que zero");

        RuleFor(x => x.CentroCustoId)
            .GreaterThan(0).When(x => x.CentroCustoId.HasValue)
            .WithMessage("ID do centro de custo deve ser maior que zero");

        RuleFor(x => x.ValorMinimo)
            .GreaterThanOrEqualTo(0).When(x => x.ValorMinimo.HasValue)
            .WithMessage("Valor mínimo deve ser maior ou igual a zero");

        RuleFor(x => x.ValorMaximo)
            .GreaterThan(0).When(x => x.ValorMaximo.HasValue)
            .WithMessage("Valor máximo deve ser maior que zero");

        RuleFor(x => x)
            .Must(x => !x.ValorMinimo.HasValue || !x.ValorMaximo.HasValue || x.ValorMinimo <= x.ValorMaximo)
            .WithMessage("Valor mínimo deve ser menor ou igual ao valor máximo");

        RuleFor(x => x)
            .Must(x => !x.DataInicio.HasValue || !x.DataFim.HasValue || x.DataInicio <= x.DataFim)
            .WithMessage("Data de início deve ser menor ou igual à data de fim");

        RuleFor(x => x.OrdenarPor)
            .Must(campo => string.IsNullOrEmpty(campo) || 
                          new[] { "IdRegistroContabil", "Valor", "DataCriacao", "ContaIdConta", "CentroCustoIdCentroCusto" }
                          .Contains(campo))
            .WithMessage("Campo de ordenação inválido");

        RuleFor(x => x.DirecaoOrdenacao)
            .Must(direcao => string.IsNullOrEmpty(direcao) || 
                           new[] { "asc", "desc" }.Contains(direcao?.ToLower()))
            .WithMessage("Direção de ordenação deve ser 'asc' ou 'desc'");
    }
}
