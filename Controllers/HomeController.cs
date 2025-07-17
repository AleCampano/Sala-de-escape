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

     public IActionResult IndexA()
    {
        return View("IndexA");
    }
    public IActionResult Comenzar(bool juegoFinalizado, string nombre, bool Completado, bool TieneElectricidad, bool codigo, List<string> respuestas)
    {
            Juego juego = new Juego(juegoFinalizado, nombre, Completado, TieneElectricidad, codigo, respuestas);
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

    public IActionResult Formulario(string nombre)
    {   
        Jugador jugador = Objeto.StringToObject<Jugador>(HttpContext.Session.GetString("juego"));
        if (jugador == null)
        {
            jugador = new Jugador();
        }
        jugador.GuardarNombre(nombre);
        HttpContext.Session.SetString("juego",Objeto.ObjectToString(jugador));
        return View("IndexA");
    }

    public IActionResult Formulario2(string color1, string color2, string color3)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
        string palabra = "";
        if (juego == null) 
        {
            palabra="sala2";
        }
        bool pasaSala;
        if(color1 != null && color2 != null && color3 != null)
        {
            pasaSala=juego.validar(color1, color2, color3);
            if(pasaSala == true)
            {
                ViewBag.hol = juego.TieneElectricidad;
                palabra="sala3";
            }
            else
            {
                ViewBag.lol = false; 
                palabra="sala2";
            }
        
        }
        else{
            palabra="sala2";
        }
        HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));
        return View (palabra);
    }

    public ActionResult Juego()
    {
            ViewBag.MostrarSegundaImagen = false;
            return View("comenzar");
    }

    public IActionResult Formulario3(string password)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
        if (juego == null) 
        {
            return RedirectToAction("Index");
        }
            if(password == juego.respuestas[3])
            {
                juego.FalsaT();
                juego.Cambiar();
                ViewBag.Completa = juego.Completado;
            } 
        HttpContext.Session.SetString("juego",Objeto.ObjectToString(juego));
        return View("sala3");

    }

    public IActionResult Formulario4(string password)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
        if (juego == null)
        {
            return RedirectToAction("Index");
        }
        juego.FalsaT();
        if (password == juego.respuestas[4])
        {
            juego.FalsaT();
            juego.Cambiar();
            ViewBag.Hecho = juego.Completado;
        }
        HttpContext.Session.SetString("juego",Objeto.ObjectToString(juego));
        return View("sala3");
    }

    public IActionResult Formulario5(string password)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
        if (juego == null)
        {
            return RedirectToAction("Index");
        }
        juego.FalsaT();
        string palabra = "";
        if (password == juego.respuestas[5])
        {
            juego.FalsaT();
            juego.Cambiar();
            palabra = "sala4";
        }
        else
        {
            palabra = "sala3";
        }
        HttpContext.Session.SetString("juego",Objeto.ObjectToString(juego));
        return View(palabra);

    }

    public IActionResult Formulario6(string ingrese)
    {
        Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
        if (juego == null)
        {
            return RedirectToAction("Index");
        }

        if (ingrese == juego.respuestas[6])
        {
            juego.code();
            ViewBag.si = juego.codigo;
            HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));
            return View("sala5");
        }
        else
        {
            ViewBag.yay = juego.codigo;
            HttpContext.Session.SetString("juego",Objeto.ObjectToString(juego));
            return View("sala4");
        }
    }

    public IActionResult Formulario7(string password)
    {
       Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
        if (juego == null)
        {
            return RedirectToAction("Index");
        }

        if (password == juego.respuestas[7])
        {
            juego.FalsaS();
            juego.code();
        }
        
        ViewBag.hey = juego.codigo;
        HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));
        return View("sala5");
    }

    public IActionResult Formulario8(string password)
    {
       Juego juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("juego"));
        if (juego == null)
        {
            return RedirectToAction("Index");
        }

        if (password == juego.respuestas[8])
        {
            juego.FalsaS();
            juego.code();
            HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));
            return View("sala6");
        }
        else
        {
            HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));
            return View("sala5");
        }
    }
}
