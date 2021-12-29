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
        const int WIDTH = 900;
        const int HEIGHT = 800;
        
        public Form1()
        {
            InitializeComponent();
            this.Width = WIDTH;
            this.Height = HEIGHT;
            GenerateMap();
            KeyDown += new KeyEventHandler(MoveCube);
        }
        private void GenerateMap()
        {
            for (int i = 0; i <= Height / Cube.Size.Height; i++)
            {
                PictureBox blackLine = new PictureBox();
                blackLine.BackColor = Color.Black;
                blackLine.Location = new Point(i * Cube.Size.Width, 0);
                blackLine.Size = new Size(1, Height);
                Controls.Add(blackLine);
            }
            for (int i = 0; i < Height / Cube.Size.Height; i++)
            {
                PictureBox blackLine = new PictureBox();
                blackLine.BackColor = Color.Black;
                blackLine.Location = new Point(0, i * Cube.Size.Width);
                blackLine.Size = new Size(Width - 100, 1);
                Controls.Add(blackLine);
            }
        }

        private void MoveCube(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Up":
                    Cube.Location = new Point(Cube.Location.X, Cube.Location.Y - 40);
                    break;
                case "Down":
                    Cube.Location = new Point(Cube.Location.X, Cube.Location.Y + 40);
                    break;
                case "Left":
                    Cube.Location = new Point(Cube.Location.X - 40, Cube.Location.Y);
                    break;
                case "Right":
                    Cube.Location = new Point(Cube.Location.X + 40, Cube.Location.Y);
                    break;
            }
        }
       
    }
}
