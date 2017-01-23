using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    //enum value to know the direction of snake moveing
    public enum direction  
    {
        Up,
        Down,
        Left,
        Right
    };


    class Settings
    {
        public static int Width { get; set; }  //
        public static int Height { get; set; }
        public static int Speed { get; set; }  //how speed snake moves
        public static int Score { get; set; }  // how many points player have
        public static int Points { get; set; } //how many poinst will be added
        public static bool GameOver { get; set; } //is the game continiue
        public static direction Direction { get; set; }

        //class constructor with default values
        public Settings()
        {
            Width = 20;
            Height = 20;
            Speed = 10;
            Score = 0;
            Points = 10;
            GameOver = false;
            Direction = direction.Right;
        }
    }
}
