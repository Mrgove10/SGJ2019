using System;

namespace Assets.Scripts.MainGame.Class
{
    [Serializable]
    public class Choix
    {
        public int choix;

        public int deltaSanté = 0;
        
        public int deltaViePriv;

        public string Text;
    }
}