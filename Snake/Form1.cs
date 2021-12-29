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
        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(MoveCube);
        }

        private void MoveCube(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Up":
                    Cube.Location = new Point(Cube.Location.X, Cube.Location.Y - 20);
                    break;
                case "Down":
                    Cube.Location = new Point(Cube.Location.X, Cube.Location.Y + 20);
                    break;
                case "Left":
                    Cube.Location = new Point(Cube.Location.X - 20, Cube.Location.Y);
                    break;
                case "Right":
                    Cube.Location = new Point(Cube.Location.X + 20, Cube.Location.Y);
                    break;
            }
        }
       
    }
}
