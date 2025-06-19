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
        return View("Index");
       
    }

    public IActionResult Formulario2(string color1, string color2, string color3)
    {
        Sala sala = Objeto.StringToObject<Sala>(HttpContext.Session.GetString("hola"));
        string palabra = "";
        if(color1 == sala.respuestas[0] && color2 == sala.respuestas[1] && color3 == sala.respuestas[2])
        {
            sala.Electricidad();
            palabra = "sala3";
        }
        else
        {
            palabra="sala2";
        }
        HttpContext.Session.SetString("hola",Objeto.ObjectToString(sala));
        return View(palabra);
    }

    public ActionResult Juego()
    {
            ViewBag.MostrarSegundaImagen = false;
            return View("comenzar");
    }

    public IActionResult Formulario3(string password)
    {
        Sala sala = Objeto.StringToObject<Sala>(HttpContext.Session.GetString("hola"));
        if(password == sala.respuestas[3])
        {
            sala.FalsaT();
            sala.Cambiar();
            ViewBag.Completa = sala.Completado;
            return View("sala3");
        }
        HttpContext.Session.SetString("hola",Objeto.ObjectToString(sala));
        return View("sala3");
    }

    public IActionResult Formulario4(string password)
    {
        Sala sala = Objeto.StringToObject<Sala>(HttpContext.Session.GetString("hola"));
        if(password == sala.respuestas[4])
        {
            sala.FalsaT();
            sala.Cambiar();
            ViewBag.Completa = sala.Completado;
            return View("sala3");
        }
        return View("sala3");
        HttpContext.Session.SetString("hola",Objeto.ObjectToString(sala));
    }

    public IActionResult Formulario5(string password)
    {
        Sala sala = Objeto.StringToObject<Sala>(HttpContext.Session.GetString("hola"));
        if(password == sala.respuestas[5])
        {
            sala.FalsaT();
            sala.Cambiar();
            ViewBag.Completa = sala.Completado;
            return View("sala4");
        }
        else
        {
             return View("sala3");
        }
        HttpContext.Session.SetString("hola",Objeto.ObjectToString(sala));

    }

    public IActionResult Formulario6(string ingrese)
    {
        Sala sala = Objeto.StringToObject<Sala>(HttpContext.Session.GetString("hola"));

        if(ingrese == sala.respuestas[6])
        {
            sala.code();
            ViewBag.yay = sala.codigo;
            return View("sala5");
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala4");
        }
        HttpContext.Session.SetString("hola",Objeto.ObjectToString(sala));

    }

    public IActionResult Formulario7(string password)
    {
        Sala sala = Objeto.StringToObject<Sala>(HttpContext.Session.GetString("hola"));

        if(password == sala.respuestas[7])
        {
            sala.FalsaS();
            sala.code();
            ViewBag.hey = sala.codigo;
            return View("sala5");
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala5");
        }
        HttpContext.Session.SetString("hola", Objeto.ObjectToString(sala));
    }

    public IActionResult Formulario8(string password)
    {
        Sala sala = Objeto.StringToObject<Sala>(HttpContext.Session.GetString("hola"));

        if(password == sala.respuestas[8])
        {
            sala.FalsaS();
            sala.code();
            ViewBag.hey = sala.codigo;
            return View("sala6");
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala5");
        }
        HttpContext.Session.SetString("hola", Objeto.ObjectToString(sala));
    }
}
