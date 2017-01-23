using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    //class body to remember positions of snake's body.
    class Body
    {
        public int X { get; set; }
        public int Y { get; set; }

        //constructor of class, default values to 0
        public Body()
        {
            X = 0;
            Y = 0;
        }
    }
}
