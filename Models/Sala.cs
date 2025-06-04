using Newtonsoft.Json;

public class Sala
{
    [JsonProperty]
    public string nombre{get;set;}
    [JsonProperty]
    public string Desafio{get;set;}
    [JsonProperty]
    public bool Completado{get;set;}
    [JsonProperty]
    public string Pista{get;set;}



    public void inicializarSala() 
    {

List <Sala> salas = new List<Sala> ();

Sala sala1 = new Sala{nombre = "entrada", Desafio = "¿ Donde esta el mapa?", Completado = false, Pista = "busca por abajo"};
    }
}
