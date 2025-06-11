using Newtonsoft.Json;

public class Sala
{
    [JsonProperty]
    public string nombre{get; private set;}

    [JsonProperty]
    public bool Completado{get; private set;}
    [JsonProperty]
    public bool TieneElectricidad{get; private set;}
        
    public Sala (string nombre, bool Completado, bool TieneElectricidad)
    {
        this.nombre = nombre;
        this.Completado = false;
        this.TieneElectricidad = false;
    }
}
