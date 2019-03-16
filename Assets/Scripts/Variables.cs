using Assets.Scripts.MainGame.Class;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class Variables
    {
        public static string NomJoueur = "Emil"; 
        public static int CurrentHeure;
        public static int CurrentMinute;
        public static int CurrentMissionID = 0;
        public static int JaugeSante = 50;
        public static int JaugeViePriv = 200;
        public static List<Mission> MissionList;
    }
}