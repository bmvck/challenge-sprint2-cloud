using Microsoft.AspNetCore.Mvc;

namespace SistemaContabil.Web.Controllers.Mvc;

/// <summary>
/// Controller para página inicial
/// </summary>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Página inicial do sistema
    /// </summary>
    public IActionResult Index()
    {
        ViewData["Title"] = "Início - Sistema Contábil";
        return View();
    }
}
