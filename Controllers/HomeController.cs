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
    

    public IActionResult Comenzar()
        {
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

    public IActionResult Formulario2(string color1, string color2, string color3, List<Sala>colores)
    {
        ViewBag.Color1 = color1;
        ViewBag.Color2 = color2;
        ViewBag.Color3 = color3;
        if() // si el clor es igual al de la lista...
        {

        }
        return View("sala2");
    }
    public IActionResult Sala2(List<Sala>colores)
        {
            HttpContext.Session.SetString("colores", Objeto.ListoString(colores));
            ViewBag.Colores = Objeto.StringToList<Sala>(HttpContext.Session.GetString("colores"));

            string rojo = "rojo";
            string amarillo = "amarillo";
            string verde = "verde";
            colores.Add(rojo);
            colores.Add(amarillo);
            colores.Add(verde);
            
            return View("sala2");
        }
        
        
        
        
            public ActionResult Juego()
        {
            ViewBag.MostrarSegundaImagen = false;
            return View("comenzar");
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
