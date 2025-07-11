using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    [HttpPost]
   [HttpPost]
public IActionResult Perfil(string nombreUsuario, string contrasena)
{
    var integrantePerfil = BaseDeDatos.LevantarIntegrante(nombreUsuario);

    if (integrantePerfil != null && integrantePerfil.InicioSesion(contrasena))
    {
        HttpContext.Session.SetString("NombreUsuario", integrantePerfil.NombreUsuario);
        ViewBag.Usuario = integrantePerfil;
        return View("Perfil");
    }
    else
    {
        ViewBag.Mensaje = "Usuario o contraseña incorrectos";
        return View("Index");
    }
}


        public IActionResult PerfilSesion()
    {
        var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");

        if (string.IsNullOrEmpty(nombreUsuario))
        {
            return RedirectToAction("Index");
        }

        Integrante integrantePerfil = BaseDeDatos.LevantarIntegrante(nombreUsuario);
        ViewBag.Usuario = integrantePerfil;

        return View("Perfil");
    }


    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
    

