using Newtonsoft.Json;
using System;

namespace Assets.Scripts.MainGame.Class
{
    [Serializable]
    public class Choix
    {
        [JsonProperty("choix")]
        public int choix;

        [JsonProperty("SanteBonus")]
        public int SanteBonus;

        [JsonProperty("SanteMalus")]
        public int SanteMalus;

        [JsonProperty("ViePrivBonus")]
        public int ViePrivBonus;

        [JsonProperty("ViePrivMalus")]
        public int ViePrivMalus;

        [JsonProperty("Text")]
        public string Text;
    }
}