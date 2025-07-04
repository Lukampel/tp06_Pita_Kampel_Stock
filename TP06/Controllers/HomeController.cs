using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06.Models;

namespace TP06.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Mensaje = "Ingrese";
        return View();
    }
    public IActionResult Perfil(string nombreUsuario, string contraseña)
    {
        Integrante integrantePerfil = new Integrante();
        integrantePerfil = BD.LevantarIntegrante(nombreUsuario);
        if(integrantePerfil != null && integrantePerfil.InicioSesion(nombreUsuario, contraseña)){
            return View("Perfil");
        }
        else{

            return View("View");
        }
    }
    
}
