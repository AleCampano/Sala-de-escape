using Newtonsoft.Json;

public class Juego{
        [JsonProperty]
         public bool juegoFinalizado {get; private set;}
        [JsonProperty]
         public TimeSpan cronometro {get; private set;}

        public Juego (bool juegoFinalizado, TimeSpan cronometro)
        {
            this.cronometro = cronometro;
            this.juegoFinalizado = false;
        }

}
 