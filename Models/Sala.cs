using Newtonsoft.Json;

public class Sala
{
    [JsonProperty]
    public string nombre{get; private set;}
    [JsonProperty]
    public string Desafio{get; private set;}
    [JsonProperty]
    public bool Completado{get; private set;}
   public List <Sala> colores = new List<Sala>();
        
}
