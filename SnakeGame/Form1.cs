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
    public partial class Form1 : System.Windows.Forms.Form
    {

        private List<Body> Snake = new List<Body>(); //list of snake body points;
        private Body food = new Body();  //food object that snake eats to growing

        public Form1()
        {
            InitializeComponent();

            new Settings(); //reset settings 

            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
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
            if (Settings.GameOver)
            {
                // if you click ENTER it will start a new game;
                if (Inputs.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                //checking correct direction buttons clicked
                if (Inputs.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if (Inputs.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Inputs.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Inputs.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

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
            if (!Settings.GameOver)
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

        //function that snake moveing on the field
        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--) 
            {
                //move head of snake
                if (i == 0) 
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;
                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                        case Direction.Up:
                            Snake[i].Y--;
                            break;
                        case Direction.Left:
                            Snake[i].X--;
                            break;

                    }
                }
                else  //rest of snake body
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        //event that if key on keyboard is down that change state of him to true
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Inputs.ChangeState(e.KeyCode, true);
        }

        //event that if key on keyboard is down that change state of him to false
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Inputs.ChangeState(e.KeyCode, false);
        }
    }
}

