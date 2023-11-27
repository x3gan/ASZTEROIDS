using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Model
{
    
    public class Player
    {
        private bool _goLeft, _goRight = false;
        public bool GoLeft { get => _goLeft; set => _goLeft = value; }  
        public bool GoRight { get => _goRight; set => _goRight = value; }  

        public Point Location => _location;  
        private Point _location;  
        public Size Size { get; }  

        public Player(Point loc, Size siz)  
        {
            _location = loc;
            Size = siz;
        }


        
        public void PlayerControls()  
        {
            if (GoLeft == true && _location.X > 0)
            {
                _location.X -= 10;

            }
            if (GoRight == true && _location.X < (900-this.Size.Width)-20)
            {
                _location.X += 10;
            }
        }
    }
}
