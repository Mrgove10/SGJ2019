using Newtonsoft.Json;
using System;

namespace Assets.Scripts.MainGame.Class
{
    [Serializable]
    public class Mission
    {
        [JsonProperty("Id")]
        public int Id;

        [JsonProperty("Title")]
        public string Title;

        [JsonProperty("ObjetName")]
        public string ObjetName;

        [JsonProperty("Text")]
        public string Text;

        [JsonProperty("Heure")]
        public int Heure;

        [JsonProperty("Minute")]
        public int Minute;

        [JsonProperty("ChoixOui")]
        public Choix ChoixOui;

        [JsonProperty("ChoixNon")]
        public Choix ChoixNon;
    }
}