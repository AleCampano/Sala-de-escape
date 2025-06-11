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

    public IActionResult Formulario()
    {
        return View();
    }

    public IActionResult Formulario2(string cable1, string cable2, string cable3, string nombre, bool Completado, bool TieneElectricidad)
    {
        if(cable1 == "rojo" && cable2 == "azul" && cable3 == "verde")
        {
            Sala hola = new Sala (nombre, Completado, TieneElectricidad);
            HttpContext.Session.GetString("hola");
            TieneElectricidad = true;
            HttpContext.Session.SetString("hola", Objeto.ObjectToString(hola));
            return View("sala3");
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala2");
        }
    }
            public ActionResult Juego()
        {
            ViewBag.MostrarSegundaImagen = false;
            return View("comenzar");
        }

        public IActionResult Formulario3(string password, string answer, string respuesta, string nombre, bool Completado, bool TieneElectricidad)
        {
        if(password == "bigmac")
        {
            if(answer == "papas")
            {
                if(respuesta == "cocacola")
                {
                    Sala hola = new Sala (nombre, Completado, TieneElectricidad);
                    HttpContext.Session.GetString("hola");
                    Completado = true;
                    HttpContext.Session.SetString("hola", Objeto.ObjectToString(hola));
                    return View("sala4");
                }
            }
        }
        else
        {
            Console.WriteLine("NO");
            return View("sala3");
        }
        }

    [HttpPost]
    public ActionResult Juego(int? imgClick_x, int? imgClick_y)
    {
        // Supón que la imagen tiene 400x400 px
        int ancho = 400, alto = 400;
        bool mostrar = false;

        if (imgClick_x.HasValue && imgClick_y.HasValue)
        {
            // Zona: cuadrante superior izquierdo
            if (imgClick_x.Value < ancho/2 && imgClick_y.Value < alto/2)
            {
                mostrar = true;
            }
        }

        ViewBag.MostrarSegundaImagen = mostrar;
        return View("comenzar");
    }

    public IActionResult ResolverSala1(string respuesta)
    {
    Jugador jugador = ObtenerJugador();

    if (respuesta != null && respuesta == "mapa")
    {
        jugador.PistasEncontradas.Add("Mapa");
        jugador.SalaActual = "SALA2";
        GuardarJugador();
        return RedirectToAction("SALA2");
    }
    return View("comenzar");
    }
}
