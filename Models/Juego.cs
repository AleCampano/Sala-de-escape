using Newtonsoft.Json;

public class Juego
{
    [JsonProperty]
    public bool juegoFinalizado {get; private set;}
    [JsonProperty]
    public string nombre{get; private set;}
    [JsonProperty]
    public bool Completado{get; private set;}
    [JsonProperty]
    public bool TieneElectricidad{get; private set;}
    [JsonProperty]
    public bool codigo {get; private set;}
    [JsonProperty]
    public List<string> respuestas {get; private set;}

    public Juego (bool juegoFinalizado, string nombre, bool Completado, bool TieneElectricidad, bool codigo, List<string> respuestas)
    {
        this.juegoFinalizado = false;
        this.nombre = nombre;
        this.Completado = false;
        this.TieneElectricidad = false;
        this.codigo = false;
        this.respuestas = new List<string>
        {
            "rojo",
            "azul",
            "verde",
            "bigmac",
            "papas",
            "cocacola",
            "hamburguesa al segundo piso",
            "V6T9JBCDS",
            "LMTR55D8E"
        };
    }
    public void Electricidad ()
    {
        TieneElectricidad = true;
    }

    public void Cambiar ()
    {
        Completado = true;
    }

    public void FalsaT ()
    {
        Completado = false;
    }

    public void code ()
    {
        codigo = true;
    }

    public void FalsaS()
    {
        codigo = false;
    }
    public bool validar(string color1, string color2, string color3)
    {
        bool pasoSala = false;
        if(color1 == respuestas[0] && color2 == respuestas[1] && color3 == respuestas[2])
        {
            pasoSala=true;
            Electricidad();
        }
        return pasoSala;
    }
}
 