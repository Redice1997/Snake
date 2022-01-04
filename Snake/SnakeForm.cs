using System;
using System.IO;
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
        private int record;
        private int score = 0;
        private int interval = 300;        

        private List<PictureBox> snake = new List<PictureBox>();        

        private bool DirCanChange = false;        

        string path = Path.Combine(Environment.CurrentDirectory, "Record.txt");

        public Form1()
        { 
            InitializeComponent();            

            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))            
                using (StreamReader input = new StreamReader(file))                
                    record = int.Parse(input.ReadLine() ?? "0");                
            
            labelRecord.Text = $"Рекорд: {record}";
            this.Width = WIDTH;
            this.Height = HEIGHT;

            snake.Add(snakeHead);

            GenerateMap();            

            timer.Tick += new EventHandler(_Update);
            timer.Interval = interval;
            timer.Start();            

            KeyDown += new KeyEventHandler(SetNewDir);
            KeyUp += new KeyEventHandler(StopExceed);            
        }
        private void StopExceed(object sender, KeyEventArgs e)
        {
            string code = e.KeyCode.ToString();
            if (code != "Up" && code != "Left" && code != "Right" && code != "Down")
            {                
                timer.Interval = interval;
            }
        }
        
        private void _Update(object sender, EventArgs e)
        {
            MoveSnake();
            EatSmth();
            DirCanChange = true;
            labelScore.Text = $"Счёт: {score}";
            if (score > record)
            {
                record = score;                
                using (StreamWriter output = new StreamWriter(path))
                {
                    output.Write(record);
                }
            }
            labelRecord.Text = $"Рекорд: {record}";           

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
        
        private void MoveSnake()
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
        }
        private void EatSmth()
        {
            if (fruit.Location == snakeHead.Location) EatFruit();
            else
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
                    default:
                        timer.Interval = 80;
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
