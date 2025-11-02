using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using SistemaContabil.Application.DTOs;

namespace SistemaContabil.Web.Helpers;

/// <summary>
/// Helper para gerar links HATEOAS
/// </summary>
public static class HateoasHelper
{
    /// <summary>
    /// Gera links HATEOAS básicos para um recurso
    /// </summary>
    public static Dictionary<string, LinkDto> GenerateResourceLinks(
        IUrlHelper urlHelper,
        string resourceName,
        int resourceId,
        bool includeDelete = true)
    {
        var links = new Dictionary<string, LinkDto>();

        var baseRoute = $"api/{resourceName}";

        // Link self
        links["self"] = new LinkDto("self", $"{baseRoute}/{resourceId}");

        // Link update
        links["update"] = new LinkDto("update", $"{baseRoute}/{resourceId}", "PUT");

        // Link delete (se permitido)
        if (includeDelete)
        {
            links["delete"] = new LinkDto("delete", $"{baseRoute}/{resourceId}", "DELETE");
        }

        // Link collection
        links["collection"] = new LinkDto("collection", baseRoute);

        // Link search
        links["search"] = new LinkDto("search", $"/api/search/{resourceName}", "GET");

        return links;
    }

    /// <summary>
    /// Gera links HATEOAS para resultado paginado
    /// </summary>
    public static Dictionary<string, LinkDto> GeneratePagedLinks(
        IUrlHelper urlHelper,
        string resourceName,
        int page,
        int pageSize,
        int totalPages,
        object? additionalParams = null)
    {
        var links = new Dictionary<string, LinkDto>();
        var baseRoute = $"api/search/{resourceName}";

        var queryParams = new Dictionary<string, object?>
        {
            ["page"] = page,
            ["pageSize"] = pageSize
        };

        // Adicionar parâmetros adicionais
        if (additionalParams != null)
        {
            foreach (var prop in additionalParams.GetType().GetProperties())
            {
                var value = prop.GetValue(additionalParams);
                if (value != null)
                {
                    queryParams[prop.Name] = value;
                }
            }
        }

        // Link self
        var selfParams = new Dictionary<string, object?>(queryParams);
        links["self"] = new LinkDto("self", BuildQueryUrl(urlHelper, baseRoute, selfParams));

        // Link first page
        if (page > 1)
        {
            var firstParams = new Dictionary<string, object?>(queryParams) { ["page"] = 1 };
            links["first"] = new LinkDto("first", BuildQueryUrl(urlHelper, baseRoute, firstParams));
        }

        // Link previous page
        if (page > 1)
        {
            var prevParams = new Dictionary<string, object?>(queryParams) { ["page"] = page - 1 };
            links["prev"] = new LinkDto("prev", BuildQueryUrl(urlHelper, baseRoute, prevParams));
        }

        // Link next page
        if (page < totalPages)
        {
            var nextParams = new Dictionary<string, object?>(queryParams) { ["page"] = page + 1 };
            links["next"] = new LinkDto("next", BuildQueryUrl(urlHelper, baseRoute, nextParams));
        }

        // Link last page
        if (page < totalPages && totalPages > 1)
        {
            var lastParams = new Dictionary<string, object?>(queryParams) { ["page"] = totalPages };
            links["last"] = new LinkDto("last", BuildQueryUrl(urlHelper, baseRoute, lastParams));
        }

        // Link create
        links["create"] = new LinkDto("create", $"api/{resourceName}", "POST");

        return links;
    }

    /// <summary>
    /// Adiciona links HATEOAS a um PagedResultDto
    /// </summary>
    public static PagedResultDto<T> AddHateoasLinks<T>(
        PagedResultDto<T> pagedResult,
        IUrlHelper urlHelper,
        string resourceName,
        object? additionalParams = null)
    {
        var links = GeneratePagedLinks(urlHelper, resourceName, pagedResult.Page, pagedResult.PageSize, pagedResult.TotalPages, additionalParams);
        
        foreach (var link in links)
        {
            pagedResult.Links[link.Key] = link.Value.Href;
        }

        return pagedResult;
    }

    /// <summary>
    /// Adiciona links HATEOAS a um PagedResultDto usando HttpContext
    /// </summary>
    public static PagedResultDto<T> AddHateoasLinks<T>(
        PagedResultDto<T> pagedResult,
        HttpContext httpContext,
        string resourceName,
        object? additionalParams = null)
    {
        var request = httpContext.Request;
        var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
        var baseRoute = $"{baseUrl}/api/search/{resourceName}";

        // Construir query string com parâmetros
        var queryParams = new List<string>
        {
            $"page={pagedResult.Page}",
            $"pageSize={pagedResult.PageSize}"
        };

        // Adicionar parâmetros adicionais do filtro
        if (additionalParams != null)
        {
            foreach (var prop in additionalParams.GetType().GetProperties())
            {
                var value = prop.GetValue(additionalParams);
                if (value != null && !prop.Name.Equals("Page", StringComparison.OrdinalIgnoreCase) && 
                    !prop.Name.Equals("PageSize", StringComparison.OrdinalIgnoreCase))
                {
                    queryParams.Add($"{prop.Name}={Uri.EscapeDataString(value.ToString() ?? "")}");
                }
            }
        }

        var queryString = string.Join("&", queryParams);
        
        // Link self
        pagedResult.Links["self"] = $"{baseRoute}?{queryString}";

        // Link first page
        if (pagedResult.Page > 1)
        {
            var firstQuery = queryString.Replace($"page={pagedResult.Page}", "page=1");
            pagedResult.Links["first"] = $"{baseRoute}?{firstQuery}";
        }

        // Link previous page
        if (pagedResult.HasPreviousPage)
        {
            var prevQuery = queryString.Replace($"page={pagedResult.Page}", $"page={pagedResult.Page - 1}");
            pagedResult.Links["prev"] = $"{baseRoute}?{prevQuery}";
        }

        // Link next page
        if (pagedResult.HasNextPage)
        {
            var nextQuery = queryString.Replace($"page={pagedResult.Page}", $"page={pagedResult.Page + 1}");
            pagedResult.Links["next"] = $"{baseRoute}?{nextQuery}";
        }

        // Link last page
        if (pagedResult.Page < pagedResult.TotalPages && pagedResult.TotalPages > 1)
        {
            var lastQuery = queryString.Replace($"page={pagedResult.Page}", $"page={pagedResult.TotalPages}");
            pagedResult.Links["last"] = $"{baseRoute}?{lastQuery}";
        }

        // Link create
        pagedResult.Links["create"] = $"{baseUrl}/api/{resourceName}";

        return pagedResult;
    }

    /// <summary>
    /// Adiciona links HATEOAS a um DTO individual
    /// </summary>
    public static TDto AddResourceLinks<TDto>(
        TDto dto,
        IUrlHelper urlHelper,
        string resourceName,
        int resourceId,
        bool includeDelete = true) where TDto : class
    {
        var links = GenerateResourceLinks(urlHelper, resourceName, resourceId, includeDelete);

        // Adicionar links ao DTO via reflection ou criar uma propriedade Links
        // Por enquanto, vamos criar uma propriedade Links nos DTOs que precisarem
        return dto;
    }

    private static string BuildQueryUrl(IUrlHelper urlHelper, string baseRoute, Dictionary<string, object?> queryParams)
    {
        var queryString = string.Join("&", queryParams
            .Where(kvp => kvp.Value != null)
            .Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value?.ToString() ?? "")}"));

        return $"{baseRoute}?{queryString}";
    }
}
