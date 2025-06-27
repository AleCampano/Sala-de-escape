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
    public IActionResult Comenzar(bool juegoFinalizado, TimeSpan cronometro, string nombre, bool Completado, bool TieneElectricidad, bool codigo, List<string> respuestas, DateTime tiempoInicio)
    {
            Juego juego = new Juego(juegoFinalizado, cronometro, nombre, Completado, TieneElectricidad, codigo, respuestas, tiempoInicio);
            HttpContext.Session.SetString("hola", Objeto.ObjectToString(juego));
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

    public IActionResult Formulario(string nombre)
    {   
        Jugador jugador = Objeto.StringToObject<Jugador>(HttpContext.Session.GetString("hola"));   
        jugador.GuardarNombre(nombre);
        HttpContext.Session.SetString("hola",Objeto.ObjectToString(jugador));
        return View("IndexA");
    }

    public IActionResult Formulario2(string color1, string color2, string color3)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("hola"));
        juego.AgregarLista();
        string palabra = "";
        if(color1 == juego.respuestas[0] && color2 == juego.respuestas[1] && color3 == juego.respuestas[2])
        {
            juego.Electricidad();
            ViewBag.hol = juego.TieneElectricidad;
            palabra = "sala3";
        }
        else
        {
            palabra="sala2";
        }
        HttpContext.Session.SetString("hola",Objeto.ObjectToString(juego));
        return View(palabra);
    }

    public ActionResult Juego()
    {
            ViewBag.MostrarSegundaImagen = false;
            return View("comenzar");
    }

    public IActionResult Formulario3(string password)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("hola"));
        while(juego.Completado == false)
        {
            juego.AgregarLista();
            if(password == juego.respuestas[3])
            {
                juego.FalsaT();
                juego.Cambiar();
                ViewBag.Completa = juego.Completado;
            }
        } 
        HttpContext.Session.SetString("hola",Objeto.ObjectToString(juego));
        return View("sala3");
    }

    public IActionResult Formulario4(string password)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("hola"));
        juego.FalsaT();
        while(juego.Completado == false)
        {
        juego.AgregarLista();
        if(password == juego.respuestas[4])
        {
            juego.FalsaT();
            juego.Cambiar();
            ViewBag.Hecho = juego.Completado;
        }
        }
        return View("sala3");
        HttpContext.Session.SetString("hola",Objeto.ObjectToString(juego));
    }

    public IActionResult Formulario5(string password)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("hola"));
        juego.FalsaT();
        string palabra = "";
        while(juego.Completado == false)
        {
        juego.AgregarLista();
        if(password == juego.respuestas[5])
        {
            juego.FalsaT();
            juego.Cambiar();
            palabra = "sala4";
        }
        else
        {
            palabra = "sala3";
        }
        }
        HttpContext.Session.SetString("hola",Objeto.ObjectToString(juego));
        return View(palabra);

    }

    public IActionResult Formulario6(string ingrese)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("hola"));
        juego.AgregarLista();
        if(ingrese == juego.respuestas[6])
        {
            juego.code();
            ViewBag.si = juego.codigo;
            return View("sala5");
        }
        else
        {
            return View("sala4");
            ViewBag.yay = juego.codigo;
        }
        HttpContext.Session.SetString("hola",Objeto.ObjectToString(juego));

    }

    public IActionResult Formulario7(string password)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("hola"));
        juego.AgregarLista();
        if(password == juego.respuestas[7])
        {
            juego.FalsaS();
            juego.code();
        }
        ViewBag.hey = juego.codigo;
        return View("sala5");
        HttpContext.Session.SetString("hola", Objeto.ObjectToString(juego));
    }

    public IActionResult Formulario8(string password)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("hola"));
        juego.AgregarLista();
        if(password == juego.respuestas[8])
        {
            juego.FalsaS();
            juego.code();
            juego.CalcularTiempoTotal();
            HttpContext.Session.SetString("hola", Objeto.ObjectToString(juego));
            return View("sala6");
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala5");
        }
        HttpContext.Session.SetString("hola", Objeto.ObjectToString(juego));
    }
}
