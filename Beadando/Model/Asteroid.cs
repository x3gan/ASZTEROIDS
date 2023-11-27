using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Model
{
    public class Asteroid
    {
        private readonly int _speed;  
        public Point Location => _location; 
        private Point _location;  
        public Size Size { get; }  

        public Asteroid(Point loc, Size siz)  
        {
            _speed = 5;
            _location = loc;
            Size = siz;
        }
        public void MoveOneAsteroid()  
        {
            _location.Y += _speed;
        }
    }
}
