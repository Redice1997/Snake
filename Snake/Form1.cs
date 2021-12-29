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

        public Form1()
        {
            InitializeComponent();
            this.Width = WIDTH;
            this.Height = HEIGHT;
            GenerateMap();
            timer.Tick += new EventHandler(DoNextStep);
            timer.Interval = 500;
            timer.Start();
            KeyDown += new KeyEventHandler(MoveCube);            
        }              
        
        private void GenerateMap()
        {
            for (int i = 0; i <= Height / sizeOfSides; i++)
            {
                PictureBox blackLine = new PictureBox();
                blackLine.BackColor = Color.Black;
                blackLine.Location = new Point(i * Cube.Size.Width, 0);
                blackLine.Size = new Size(1, Height);
                Controls.Add(blackLine);
            }
            for (int i = 0; i < Height / sizeOfSides; i++)
            {
                PictureBox blackLine = new PictureBox();
                blackLine.BackColor = Color.Black;
                blackLine.Location = new Point(0, i * Cube.Size.Width);
                blackLine.Size = new Size(Width - 100, 1);
                Controls.Add(blackLine);
            }
        }

        private void DoNextStep(object sender, EventArgs e)
        {
            Cube.Location = new Point(Cube.Location.X + sizeOfSides * dirX, Cube.Location.Y + sizeOfSides * dirY);
        }

        private void MoveCube(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Up":
                    dirY = -1;
                    dirX = 0;
                    break;
                case "Down":
                    dirY = 1;
                    dirX = 0;
                    break;
                case "Left":
                    dirY = 0;
                    dirX = -1;
                    break;
                case "Right":
                    dirY = 0;
                    dirX = 1;
                    break;
            }
        }
       
    }
}
