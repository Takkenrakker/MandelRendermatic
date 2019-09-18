using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace MandelRender
{
    public partial class Form1 : Form
    {
        public static Bitmap mandelImage = new Bitmap(500, 500);
        public static void CheckNumbs(int x, int y, int iterations, int zoom, int offsetx, int offsety, int paletteOffset)
        {
            int counter;
            double newx = (x - 250 + offsetx);
            newx /= zoom;
            double newy = (y - 250 + offsety);
            newy /= zoom;
            double n = 0;
            double ntemp;
            double m = 0;

            for (counter = 0; counter < iterations; counter++)
            {
                if (n*n + m*m >= 2*2)
                {
                    Form1.mandelImage.SetPixel(x, y, Color.FromArgb((255 * ((counter + paletteOffset) % 16)) / 16, (255 * ((counter + paletteOffset) % 8)) / 8, (255 * ((counter + paletteOffset) % 4)) / 4));
                    return;
                }
                ntemp = n*n - m*m + newx;
                m = 2*n*m + newy;
                n = ntemp;
            }
            Form1.mandelImage.SetPixel(x, y, Color.Black);
        }
        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.Image = mandelImage;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int time = System.DateTime.Now.Second;

            for (int y = 0; y < 500; y++)
            {
                for (int x = 0; x < 500; x++)
                {
                    CheckNumbs(x, y, int.Parse(textBox3.Text), int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox4.Text), time);
                }
            }
            this.pictureBox1.Image = mandelImage;
        }
    }
}
