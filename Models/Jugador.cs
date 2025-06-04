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
}