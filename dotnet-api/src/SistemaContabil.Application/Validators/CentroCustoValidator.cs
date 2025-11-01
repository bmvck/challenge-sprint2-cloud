using FluentValidation;
using SistemaContabil.Application.DTOs;

namespace SistemaContabil.Application.Validators;

/// <summary>
/// Validador para CentroCustoDto
/// </summary>
public class CentroCustoValidator : AbstractValidator<CentroCustoDto>
{
    public CentroCustoValidator()
    {
        RuleFor(x => x.NomeCentroCusto)
            .NotEmpty().WithMessage("Nome do centro de custo é obrigatório")
            .MaximumLength(70).WithMessage("Nome não pode ter mais de 70 caracteres")
            .Matches(@"^[a-zA-Z0-9\s\-_]+$").WithMessage("Nome contém caracteres inválidos");
    }
}

/// <summary>
/// Validador para CriarCentroCustoDto
/// </summary>
public class CriarCentroCustoValidator : AbstractValidator<CriarCentroCustoDto>
{
    public CriarCentroCustoValidator()
    {
        RuleFor(x => x.NomeCentroCusto)
            .NotEmpty().WithMessage("Nome do centro de custo é obrigatório")
            .MaximumLength(70).WithMessage("Nome não pode ter mais de 70 caracteres")
            .Matches(@"^[a-zA-Z0-9\s\-_]+$").WithMessage("Nome contém caracteres inválidos");
    }
}

/// <summary>
/// Validador para AtualizarCentroCustoDto
/// </summary>
public class AtualizarCentroCustoValidator : AbstractValidator<AtualizarCentroCustoDto>
{
    public AtualizarCentroCustoValidator()
    {
        RuleFor(x => x.NomeCentroCusto)
            .NotEmpty().WithMessage("Nome do centro de custo é obrigatório")
            .MaximumLength(70).WithMessage("Nome não pode ter mais de 70 caracteres")
            .Matches(@"^[a-zA-Z0-9\s\-_]+$").WithMessage("Nome contém caracteres inválidos");
    }
}
