using Newtonsoft.Json;

public class Jugador
{
    [JsonProperty]
    public string nombre{get;set;}
    [JsonProperty]
    public string SalaActual{get;set;}
    [JsonProperty]
    List<string>PistasEncontradas = new List<string>();
    [JsonProperty]
    public TimeSpan cronometro{get;set;}

    public Jugador(string nombre, string SalaActual, List<string> PistasEncontradas, TimeSpan cronometro)
    {
        this.nombre = nombre;
        this.SalaActual=SalaActual;
        this.PistasEncontradas = new List<string>();
        this.cronometro = cronometro;
    }

    private Jugador ObtenerJugador()
    {
    Jugador jugadorJson = HttpContext.Session.GetString("jugador");
    if (jugadorJson != null)
    {
        return JsonConvert.DeserializeObject<Jugador>(jugadorJson);
    }
    else
    {
        return new Jugador("Invitado", "SALA1", new List<string>(), TimeSpan.Zero);
    }
    }
    
    private void  GuardarJugador()
    {
    Jugador jugador = new Jugador(nombre, SalaActual, PistasEncontradas, cronometro);
    HttpContext.Session.SetString("jugador", Objeto.ObjectToString(jugador));
    }


    
}