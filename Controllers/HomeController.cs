using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP05_SalaDeEscape.Models;
using Newtonsoft.Json;

namespace TP05_SalaDeEscape.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Comenzar(bool juegoFinalizado, TimeSpan cronometro)
    {
            Juego juego = new Juego(juegoFinalizado, cronometro);
            HttpContext.Session.GetString("juego");

            HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));
            return View("comenzar");
    }

    public IActionResult Historia()
    {
            return View("historia");
    }

    public IActionResult Creadores()
    {
        return View("creadores");
    }
    public IActionResult Sala2()
    {
        return View("sala2");
    }

    public IActionResult Formulario(string name, string nombre, TimeSpan cronometro)
    {   
        Jugador nombree = new Jugador (nombre, cronometro);
            HttpContext.Session.SetString("hola", Objeto.ObjectToString(nombree));
            nombree.GuardarNombre(name);
            HttpContext.Session.GetString("hola");
            return View("Index");
    }

    public IActionResult Formulario2(string color1, string color2, string color3, string nombre, bool codigo, bool Completado, bool TieneElectricidad)
    {
        if(color1 == "rojo" && color2 == "azul" && color3 == "verde")
        {
            Sala cambioE = new Sala (nombre, codigo, Completado, TieneElectricidad);
            HttpContext.Session.SetString("hola", Objeto.ObjectToString(cambioE));
            cambioE.Electricidad();
            HttpContext.Session.GetString("hola");
            return View("sala3");
        }
        else
        {
            ViewBag.lol = TieneElectricidad;
            return View("sala2");
        }
    }

    public ActionResult Juego()
    {
            ViewBag.MostrarSegundaImagen = false;
            return View("comenzar");
    }

    public IActionResult Formulario3(string password)
    {
        if(password == "bigmac")
        {
            Sala hola = HttpContext.Session.SetString("hola", Objeto.ObjectToString(hola));
            hola.Cambiar();
            HttpContext.Session.GetString("hola");
            ViewBag.Completa = Completado;
            return View("sala3");
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala3");
        }
    }

    public IActionResult Formulario4(string password, string answer, string respuesta, string nombre, bool codigo, bool Completado, bool TieneElectricidad)
    {
        if(password == "papas")
        {
            Sala hola = new Sala (nombre, codigo, Completado, TieneElectricidad);
            hola.FalsaT();
            HttpContext.Session.SetString("hola", Objeto.ObjectToString(hola));
            hola.Cambiar();
            ViewBag.Hecho = Completado;
            HttpContext.Session.GetString("hola");
            return View("sala3");
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala3");
        }
    }

    public IActionResult Formulario5(string password, string answer, string respuesta, string nombre, bool codigo, bool Completado, bool TieneElectricidad)
    {
        if(password == "cocacola")
        {
            Sala hola = new Sala (nombre, codigo, Completado, TieneElectricidad);
            hola.FalsaT();
            HttpContext.Session.SetString("hola", Objeto.ObjectToString(hola));
            hola.Cambiar();
            HttpContext.Session.GetString("hola");
            return View("sala4");
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala3");
        }
    }

    public IActionResult Formulario6(string ingrese, string answer, string respuesta, string nombre, bool codigo, bool Completado, bool TieneElectricidad)
    {
        if(ingrese == "hamburguesa al segundo piso")
        {
            Sala hola = new Sala (nombre, codigo, Completado, TieneElectricidad);
            HttpContext.Session.SetString("hola", Objeto.ObjectToString(hola));
            hola.code();
            ViewBag.yay = codigo;
            HttpContext.Session.GetString("hola");
            return View("sala5");
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala4");
        }
    }

    public IActionResult Formulario7(string ingrese, string answer, string respuesta, string nombre, bool codigo, bool Completado, bool TieneElectricidad)
    {
        if(ingrese == "V6T9JBCDS")
        {
            Sala hola = new Sala (nombre, codigo, Completado, TieneElectricidad);
            hola.FalsaS();
            HttpContext.Session.SetString("hola", Objeto.ObjectToString(hola));
            hola.code();
            ViewBag.hey = codigo;
            HttpContext.Session.GetString("hola");
            return View("sala5");
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala5");
        }
    }

    public IActionResult Formulario8(string ingrese, string answer, string respuesta, string nombre, bool codigo, bool Completado, bool TieneElectricidad)
    {
        if(ingrese == "LMTR55D8E")
        {
            Sala hola = new Sala (nombre, codigo, Completado, TieneElectricidad);
            hola.FalsaS();
            HttpContext.Session.SetString("hola", Objeto.ObjectToString(hola));
            hola.code();
            HttpContext.Session.GetString("hola");
            return View("sala6");
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala5");
        }
    }
}
