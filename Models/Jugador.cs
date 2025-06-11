using Newtonsoft.Json;

public class Jugador
{
    [JsonProperty]
    public string nombre{get;set;}


    [JsonProperty]
    public TimeSpan cronometro{get;set;}

    public Jugador(string nombre, TimeSpan cronometro)
    {
        this.nombre = nombre;
        this.cronometro = cronometro;
    }


    
}