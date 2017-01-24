using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class FormMain : System.Windows.Forms.Form
    {

        private List<Body> Snake = new List<Body>(); //list of snake body points;
        private Body food = new Body();  //food object that snake eats to growing

        public FormMain()
        {
            InitializeComponent();

            new Settings(); //reset settings 

            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen();
            gameTimer.Start(); //start timer

            //starting new game
            StartGame();
        }

        //function starts a new game, clear all values from last game, and create new player object 
        private void StartGame()
        {
            labelGameOver.Visible = false;
            //clear settings
            new Settings();

            //Createing a new player object
            Snake.Clear(); //clear snake body
            Body head = new Body();  //the head of Snake
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);

            labelScore.Text = Settings.Score.ToString();
            GenerateFood();
        }

        //function that create a new food object in the game
        private void GenerateFood()
        {
            //must know maximum X and Y position in place
            int maxXPosition = pictureBoxCanvas.Size.Width / Settings.Width;
            int maxYPosition = pictureBoxCanvas.Size.Height / Settings.Height;

            //next create a new food object in random location
            Random rand = new Random();
            food = new Body();
            food.X = rand.Next(0, maxXPosition);
            food.Y = rand.Next(0, maxYPosition);
        }

        //Function update scrren by checking game status and buttons clicked by player
        private void UpdateScreen(object sender, EventArgs e)
        {
            //First i checking that gameOver is true
            if (Settings.GameOver == true)
            {
                // if you click ENTER it will start a new game;
                if (Inputs.KeyPressed(Keys.Enter))
                    StartGame();
            }
            else
            {
                //checking correct direction buttons clicked
                if (Inputs.KeyPressed(Keys.Right) && Settings.Direction != direction.Left)
                    Settings.Direction = direction.Right;
                else if (Inputs.KeyPressed(Keys.Left) && Settings.Direction != direction.Right)
                    Settings.Direction = direction.Left;
                else if (Inputs.KeyPressed(Keys.Up) && Settings.Direction != direction.Down)
                    Settings.Direction = direction.Up;
                else if (Inputs.KeyPressed(Keys.Down) && Settings.Direction != direction.Up)
                    Settings.Direction = direction.Down;

                //adding movePlayer function
                MovePlayer();
            }

            //refreshing Data on Canvas Screen
            pictureBoxCanvas.Invalidate();
        }

        //function that drawing a snake in pictureBox or shows end game screen
        private void pictureBoxCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics; //which canvas to use

            //makeing a snake move
            if (Settings.GameOver != false)
            {
                //create a value of snake color
                Brush snakeColor;
                //First i draw a snake on canvas
                for(int i=0; i<Snake.Count;i++)
                {
                    //first put red color of snake head, and black color to rest body
                    if (i == 0)
                        snakeColor = Brushes.Red;
                    else
                        snakeColor = Brushes.Black;

                    //drawing snake
                    canvas.FillRectangle(snakeColor, new Rectangle(Snake[i].X * Settings.Width, Snake[i].Y * Settings.Height, Settings.Width, Settings.Height));

                    //drawing snake food
                    canvas.FillEllipse(Brushes.Yellow, new Rectangle(food.X * Settings.Width, food.Y * Settings.Height, Settings.Width, Settings.Height));

                }

            }
            else
            {
                //creating a game over message
                string gameOverMessage = "Game Over \nYour Score is: " + Settings.Score + "\nEnter to NewGame";
                labelGameOver.Text = gameOverMessage;
                labelGameOver.Visible = true;
            }

        }
    }
}

