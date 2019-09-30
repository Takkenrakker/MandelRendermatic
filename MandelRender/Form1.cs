using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelRender
{
    public partial class Form1 : Form
    {
        public static Bitmap mandelImage = new Bitmap(500, 500);
        public static void CheckNumbs(int screenX, int screenY, int iterations, float zoom, float offsetx, float offsety, int paletteOffset)
        {
            int counter;
            double newx = (screenX - 250);
            newx /= zoom;
            newx += offsetx;
            double newy = (screenY - 250);
            newy /= zoom;
            newy += offsety;
            double n = 0;
            double n0;
            double m = 0;
            for (counter = 0; counter < iterations; counter++)
            {
                if (n*n + m*m >= 2*2)
                {
                    Form1.mandelImage.SetPixel(screenX, screenY, Color.FromArgb((255 * ((counter + paletteOffset) % 16)) / 16, (255 * ((counter + paletteOffset) % 8)) / 8, (255 * ((counter + paletteOffset) % 4)) / 4));
                    return;
                }
                n0 = n*n - m*m + newx;
                m = 2*n*m + newy;
                n = n0;
            }
            Form1.mandelImage.SetPixel(screenX, screenY, Color.Black);
        }
        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.Image = mandelImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MandelRender()
        {


            for (int screenY = 0; screenY < 500; screenY++)
            {
                int time = System.DateTime.Now.Second;
                for (int screenX = 0; screenX < 500; screenX++)
                {
                    CheckNumbs(screenX, screenY, int.Parse(textBox3.Text), float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox4.Text), time);
                }
            }
            this.pictureBox1.Image = mandelImage;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MandelRender();
        }

        private void PictureBox1_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    textBox4.Text = "" + (int.Parse(textBox4.Text) + 100);
                    return;
                case Keys.A:
                    textBox2.Text = "" + (int.Parse(textBox2.Text) - 100);
                    return;
                case Keys.S:
                    textBox4.Text = "" + (int.Parse(textBox4.Text) - 100);
                    return;
                case Keys.D:
                    textBox2.Text = "" + (int.Parse(textBox2.Text) + 100);
                    return;
            }
            MandelRender();
        }

    }
}
