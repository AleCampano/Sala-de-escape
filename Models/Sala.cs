using Newtonsoft.Json;

public class Sala
{
    [JsonProperty]
    public string nombre{get; private set;}

    [JsonProperty]
    public bool Completado{get; private set;}
    [JsonProperty]
    public bool TieneElectricidad{get; private set;}

    [JsonProperty]
    public bool codigo {get; private set;}
        
    public Sala (string nombre, bool Completado, bool TieneElectricidad, bool codigo)
    {
        this.nombre = nombre;
        this.Completado = false;
        this.TieneElectricidad = false;
        this.codigo = false;
    }

    public void Electricidad ()
    {
            TieneElectricidad = true;
    }

    public void Cambiar ()
    {
        Completado = true;
    }

    public void Falsa ()
    {
        Completado = false;
    }

    public void code ()
    {
        codigo = true;
    }
}
