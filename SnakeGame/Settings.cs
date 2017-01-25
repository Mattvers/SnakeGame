using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    //enum value to know the direction of snake moveing
    public enum Direction  
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
        public static Direction direction { get; set; }

        //class constructor with default values
        public Settings()
        {
            Width = 16;
            Height = 16;
            Speed = 16;
            Score = 0;
            Points = 10;
            GameOver = false;
            direction = Direction.Right;
        }
    }
}
