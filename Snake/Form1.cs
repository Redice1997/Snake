using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private const int WIDTH = 900;
        private const int HEIGHT = 800;

        private int dirX = 0, dirY = 0;
        private int sizeOfSides = 40;

        private List<PictureBox> snake = new List<PictureBox>();

        private short score = 0;

        public Form1()
        {
            InitializeComponent();
            this.Width = WIDTH;
            this.Height = HEIGHT;

            snake.Add(snakeHead);

            GenerateMap();            

            timer.Tick += new EventHandler(MoveSnake);
            timer.Tick += new EventHandler(FindFruit);
            timer.Interval = 500;
            timer.Start();

            KeyDown += new KeyEventHandler(SetNewDir);            
        }  
        
        private void GenerateFruit()
        {
            Random r = new Random();
            Point point = fruit.Location;
            bool isOutOfSnake = false;

            while (!isOutOfSnake)
            {
                point.X = r.Next(0, Width / sizeOfSides - 2) * sizeOfSides;
                point.Y = r.Next(0, Height / sizeOfSides - 1) * sizeOfSides;
                isOutOfSnake = true;

                foreach (PictureBox cube in snake)
                {
                    if (point == cube.Location)
                        isOutOfSnake = false;
                }
            }           
            
            fruit.Location = point;
        }      
        

        private void MoveSnake(object sender, EventArgs e)
        {
            Point nextStep = new Point(snakeHead.Location.X + sizeOfSides * dirX, snakeHead.Location.Y + sizeOfSides * dirY);            
            for (int i = 1; i < snake.Count; i++)
            {
                snake[i].Location = snake[i - 1].Location;
            }
            snakeHead.Location = nextStep;
        }

        //private void MoveCube(object sender, EventArgs e)
        //{
        //    snakeHead.Location = new Point(snakeHead.Location.X + sizeOfSides * dirX, snakeHead.Location.Y + sizeOfSides * dirY);
        //}

        private void FindFruit(object sender, EventArgs e)
        {
            if (fruit.Location == snakeHead.Location) EatFruit();            
        }

        private void EatFruit()
        {            
            GenerateFruit();
            PictureBox body = new PictureBox();
            body.Size = new Size(40, 40);
            body.BackColor = snakeHead.BackColor;
            body.Location = snake[snake.Count - 1].Location;
            snake.Add(body);
            score++;
            labelScore.Text = $"Счёт: {score}";            
        }


        private void SetNewDir(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Up":
                    if (dirY != 1)
                    {
                        dirY = -1;
                        dirX = 0;
                    }                    
                    break;
                case "Down":
                    if (dirY != -1)
                    {
                        dirY = 1;
                        dirX = 0;
                    }                    
                    break;
                case "Left":
                    if (dirX != 1)
                    {
                        dirY = 0;
                        dirX = -1;
                    }                    
                    break;
                case "Right":
                    if (dirX != -1)
                    {
                        dirY = 0;
                        dirX = 1;
                    }
                    break;
            }            
        }
        private void GenerateMap()
        {
            for (int i = 0; i <= Height / sizeOfSides; i++)
            {
                PictureBox blackLine = new PictureBox();
                blackLine.BackColor = Color.Black;
                blackLine.Location = new Point(i * sizeOfSides, 0);
                blackLine.Size = new Size(1, Height);
                Controls.Add(blackLine);
            }
            for (int i = 0; i < Height / sizeOfSides; i++)
            {
                PictureBox blackLine = new PictureBox();
                blackLine.BackColor = Color.Black;
                blackLine.Location = new Point(0, i * sizeOfSides);
                blackLine.Size = new Size(Width - 100, 1);
                Controls.Add(blackLine);
            }
        }

    }
}
