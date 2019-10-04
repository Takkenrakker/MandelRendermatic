using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MandelRender
{
    public partial class Form1 : Form
    {
        public static Bitmap s_mandelImage = new Bitmap(900, 900);
        public void CheckNumbs(int screenX, int screenY, int iterations, float zoom, float offsetx, float offsety, int palette)
        {

            double newx = (screenX - 450);
            newx /= zoom;
            newx += offsetx;
            double newy = (screenY - 450);
            newy /= zoom;
            newy += offsety;
            double n = 0;
            double n0;
            double m = 0;
            double counter = 0;
            while (n * n + m * m <= (1 << 16) && counter < iterations)
            {
                n0 = n * n - m * m + newx;
                m = 2 * n * m + newy;
                n = n0;
                counter++;
            }
            if (counter < iterations)
            {
                double normalized = Math.Log(n * n + m * m) / 2;
                double rest = Math.Log(normalized / Math.Log(2)) / Math.Log(2);
                counter = counter + 1 - rest;
            }
            else
            {
                s_mandelImage.SetPixel(screenX, screenY, Color.Black);
                return;
            }

            Color col1 = CalcCol.CalculateColor(Math.Floor(counter), palette);
            Color col2 = CalcCol.CalculateColor(Math.Floor(counter) + 1, palette);
            s_mandelImage.SetPixel(screenX, screenY, CalcCol.BlendColor(col1, col2, counter % 1));
            return;
        }
        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.Image = s_mandelImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MandelRender()
        {
            var watch = Stopwatch.StartNew();
            int repeats = 0;
            int orint = 256;
            int interlaces = 256;
            int screenY = interlaces;
            int iterations = int.Parse(textIter.Text);
            float zoom = 1 / float.Parse(textZoom.Text);
            float offsetX = float.Parse(textX.Text);
            float offsetY = float.Parse(textY.Text);
            int palette = comboBox1.SelectedIndex;
            while (screenY < 900)
            {
                for (int screenX = 0; screenX < 900; screenX++)
                {
                    CheckNumbs(screenX, screenY, iterations, zoom, offsetX, offsetY, palette);
                }
                screenY += interlaces;
                if (screenY % 225 == 0)
                {
                    pictureBox1.Image = s_mandelImage;
                    Refresh();
                }
                if (screenY >= 900)
                {
                    repeats++;
                    screenY = orint >> repeats;
                    if (interlaces == 1)
                    {
                        pictureBox1.Image = s_mandelImage;
                        Refresh();
                        watch.Stop();
                        label5.Text = "Elapsed time: " + watch.ElapsedMilliseconds + " ms";
                        return;
                    }
                    interlaces = orint >> repeats;
                }
            }
            pictureBox1.Image = s_mandelImage;
            watch.Stop();
            label5.Text = "Elapsed time: " + watch.ElapsedMilliseconds + " ms";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MandelRender();
        }

        private void PictureBox1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    textY.Text = "" + (int.Parse(textY.Text) + 100);
                    return;
                case Keys.A:
                    textX.Text = "" + (int.Parse(textX.Text) - 100);
                    return;
                case Keys.S:
                    textY.Text = "" + (int.Parse(textY.Text) - 100);
                    return;
                case Keys.D:
                    textX.Text = "" + (int.Parse(textX.Text) + 100);
                    return;
            }
            MandelRender();
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textX.Text = ""+ (double.Parse(textX.Text)+(e.X - 450)* double.Parse(textZoom.Text));
            textY.Text = ""+ (double.Parse(textY.Text)+(e.Y - 450)* double.Parse(textZoom.Text));
            textZoom.Text = "" + 0.5 * double.Parse(textZoom.Text);
            MandelRender();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}
