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

    [JsonProperty]
    public List<string> respuestas {get; private set;}
        
    public Sala (string nombre, bool Completado, bool TieneElectricidad, bool codigo, List<string> respuestas)
    {
        this.nombre = nombre;
        this.Completado = false;
        this.TieneElectricidad = false;
        this.codigo = false;
        this.respuestas = new List<string>();
    }

    public void AgregarLista()
    {
        string rojo = "rojo";
        string azul = "azul";
        string verde = "verde";
        string bigmac = "bigmac";
        string papas = "papas";
        string cocacola = "cocacola";
        string hambur = "hamburguesa al segundo piso";
        string captcha1 = "V6T9JBCDS";
        string captcha2 = "LMTR55D8E";
        respuestas.Add(rojo);
        respuestas.Add(azul);
        respuestas.Add(verde);
        respuestas.Add(bigmac);
        respuestas.Add(papas);
        respuestas.Add(cocacola);
        respuestas.Add(hambur);
        respuestas.Add(captcha1);
        respuestas.Add(captcha2);
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
}
