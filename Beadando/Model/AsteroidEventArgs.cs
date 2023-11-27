namespace Beadando.Model
{
    public class AsteroidEventArgs
    {
        public Point Lokation { get; }  
        public Size Szize { get; }  

        public AsteroidEventArgs(Point loc, Size siz)  
        {
            Lokation = loc;  
            Szize = siz;
        }
    }
}