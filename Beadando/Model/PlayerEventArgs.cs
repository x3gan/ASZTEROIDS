namespace Beadando.Model
{
    public class PlayerEventArgs
    {
        public Point Lokation { get; }  
        public Size Szize { get; }  

        public PlayerEventArgs(Point loc, Size siz)  
        {
            Lokation = loc;
            Szize = siz;
        }
    }
}