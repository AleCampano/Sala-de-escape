using Newtonsoft.Json;

public class Jugador
{
    [JsonProperty]
    public string nombre{get; private set;}

// Constructor requerido por JsonConvert
    public Jugador() { }
    
    public Jugador(string nombre)
    {
        this.nombre = nombre;
    }

    public void GuardarNombre(string name)
    {
        this.nombre = name;
    }
    
}