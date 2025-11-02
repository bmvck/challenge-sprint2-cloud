using Microsoft.AspNetCore.Mvc;

namespace SistemaContabil.Web.Helpers;

/// <summary>
/// Helper para padronizar respostas de API
/// </summary>
public static class ApiControllerHelper
{
    /// <summary>
    /// Cria uma resposta ProblemDetails padronizada
    /// </summary>
    public static ProblemDetails CreateProblemDetails(
        int statusCode,
        string title,
        string detail,
        string? instance = null,
        IDictionary<string, object?>? extensions = null)
    {
        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Instance = instance
        };

        if (extensions != null)
        {
            foreach (var extension in extensions)
            {
                problem.Extensions.Add(extension.Key, extension.Value);
            }
        }

        return problem;
    }

    /// <summary>
    /// Cria resposta de erro BadRequest com ProblemDetails
    /// </summary>
    public static ActionResult BadRequestProblem(string detail, string? instance = null)
    {
        return new ObjectResult(CreateProblemDetails(
            StatusCodes.Status400BadRequest,
            "Erro de validação",
            detail,
            instance))
        {
            StatusCode = StatusCodes.Status400BadRequest
        };
    }

    /// <summary>
    /// Cria resposta de erro NotFound com ProblemDetails
    /// </summary>
    public static ActionResult NotFoundProblem(string detail, string? instance = null)
    {
        return new ObjectResult(CreateProblemDetails(
            StatusCodes.Status404NotFound,
            "Recurso não encontrado",
            detail,
            instance))
        {
            StatusCode = StatusCodes.Status404NotFound
        };
    }

    /// <summary>
    /// Cria resposta de erro InternalServerError com ProblemDetails
    /// </summary>
    public static ActionResult InternalServerErrorProblem(string detail, string? instance = null)
    {
        return new ObjectResult(CreateProblemDetails(
            StatusCodes.Status500InternalServerError,
            "Erro interno do servidor",
            detail,
            instance))
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}
