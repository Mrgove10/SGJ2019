using System;

namespace Assets.Scripts.MainGame.Class
{
    [System.Serializable]
    public class Mission
    {
        public int Id;
        
        public string Title;
        
        public string ObjetName;
        
        public string Text;
        
        public int Heure = 0;
        
        public int Minute = 0;
        
        public Choix ChoixOui;
        
        public Choix ChoixNon;
    }
}