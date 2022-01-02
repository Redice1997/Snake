using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Snake
{
    public partial class Form1 : Form
    {
        private const int WIDTH = 900;
        private const int HEIGHT = 800;
        private const int xMax = WIDTH - 180;
        private const int xMin = 0;
        private const int yMax = HEIGHT - 80;
        private const int yMin = 0;
        
        private int dirX = 0, dirY = 0;
        private int sizeOfSides = 40;

        private List<PictureBox> snake = new List<PictureBox>();

        private short score = 0;

        private bool DirCanChange = false;
        private int interval = 300;

        public Form1()
        {
            InitializeComponent();

            this.Width = WIDTH;
            this.Height = HEIGHT;
            snake.Add(snakeHead);
            GenerateMap();            

            timer.Tick += new EventHandler(MoveSnake);
            timer.Tick += new EventHandler(EatSmth);
            timer.Tick += new EventHandler(GiveOpportunityToChange);
            timer.Interval = interval;
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
                point.X = r.Next(0, Width / sizeOfSides - 3) * sizeOfSides;
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
            for (int i = snake.Count - 1; i > 0; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }

            Point location = new Point(snakeHead.Location.X + sizeOfSides * dirX, snakeHead.Location.Y + sizeOfSides * dirY);

            if (location.X > xMax) location.X = xMin;
            if (location.Y > yMax) location.Y = yMin;
            if (location.X < xMin) location.X = yMax;
            if (location.Y < yMin) location.Y = yMax;

            snakeHead.Location = location; 

            labelScore.Text = $"Счёт: {score}";
        }

        private void EatSmth(object sender, EventArgs e)
        {
            if (fruit.Location == snakeHead.Location) EatFruit();
            for (int i = 2; i < snake.Count; i++)
                if (snakeHead.Location == snake[i].Location)                
                    for (int j = snake.Count - 1; j >= i; j--)
                    {                        
                        Controls.Remove(snake[j]);
                        snake.Remove(snake[j]);
                        score--;
                    }                
        }


        private void EatFruit()
        {            
            GenerateFruit();
            PictureBox body = new PictureBox();
            body.Size = new Size(sizeOfSides, sizeOfSides);
            body.BackColor = snakeHead.BackColor;
            body.Location = snake[snake.Count - 1].Location;
            snake.Add(body);
            Controls.Add(body);
            score++;                        
        }

        private void GiveOpportunityToChange(object sender, EventArgs e)
        {
            DirCanChange = true;
        }

        private void SetNewDir(object sender, KeyEventArgs e)
        {
            if (DirCanChange)
                switch (e.KeyCode.ToString())
                {
                    case "Up":
                        if (dirY != 1)
                        {
                            dirY = -1;
                            dirX = 0;
                            DirCanChange = false;                            
                        }                    
                        break;
                    case "Down":
                        if (dirY != -1)
                        {
                            dirY = 1;
                            dirX = 0;
                            DirCanChange = false;                            
                        }                    
                        break;
                    case "Left":
                        if (dirX != 1)
                        {
                            dirY = 0;
                            dirX = -1;
                            DirCanChange = false;
                        }                    
                        break;
                    case "Right":
                        if (dirX != -1)
                        {
                            dirY = 0;
                            dirX = 1;
                            DirCanChange = false;
                        }
                        break;
                }            
        }
                

        private void GenerateMap()
        {
            for (int i = 0; i < (Width - 100) / sizeOfSides; i++)
            {
                PictureBox blackLine = new PictureBox();
                blackLine.BackColor = Color.Black;
                blackLine.Location = new Point(i * sizeOfSides, 0);
                blackLine.Size = new Size(1, Height);
                Controls.Add(blackLine);
                blackLine.BringToFront();
            }
            for (int i = 0; i < Height / sizeOfSides; i++)
            {
                PictureBox blackLine = new PictureBox();
                blackLine.BackColor = Color.Black;
                blackLine.Location = new Point(0, i * sizeOfSides);
                blackLine.Size = new Size(Width - 140, 1);
                Controls.Add(blackLine);
                blackLine.BringToFront();
            }
        }

    }
}
