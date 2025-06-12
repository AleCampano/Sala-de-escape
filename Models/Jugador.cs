using Newtonsoft.Json;

public class Jugador
{
    [JsonProperty]
    public string nombre{get; private set;}


    [JsonProperty]
    public TimeSpan cronometro{get; private set;}

    public Jugador(string nombre, TimeSpan cronometro)
    {
        this.nombre = nombre;
        this.cronometro = cronometro;
    }

    public void GuardarNombre(string name)
    {
        this.nombre = name;
    }
    
}