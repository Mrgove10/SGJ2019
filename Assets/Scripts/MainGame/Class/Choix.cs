namespace Assets.Scripts.MainGame.Class
{
    public class Choix
    {
        public choix choix;
        public int SanteBonus;
        public int SanteMalus;
        public int ViePrivBonus;
        public int ViePrivMalus;
        public string Text;
    }

    public enum choix
    {
        oui,
        non
    }
}