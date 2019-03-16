namespace Assets.Scripts
{
    public class Notif
    {
        public string Title;
        public string Message;
        public Personne Personne;
        public int heure;
        public int minute;
    }

    public enum Personne
    {
        Doctor,
        Patron,
        Spam
    }
}