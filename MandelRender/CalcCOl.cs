using System;
using System.Drawing;

namespace MandelRender
{
    public class CalcCol
    {
        public static Color Palette(int type, int array)
        {
            Color[] palette = new Color[16];
            switch(type)
            {
                case 0:
                    {
                        palette[0] = Color.Red;
                        palette[1] = Color.Green;
                        palette[2] = Color.Blue;
                        palette[3] = Color.Yellow;
                        return palette[array % 4];
                    }
                case 1:
                    {
                        palette[0] = Color.FromArgb(66, 30, 15);
                        palette[1] = Color.FromArgb(25, 7, 26);
                        palette[2] = Color.FromArgb(9, 1, 47);
                        palette[3] = Color.FromArgb(4, 4, 73);
                        palette[4] = Color.FromArgb(0, 7, 100);
                        palette[5] = Color.FromArgb(12, 44, 138);
                        palette[6] = Color.FromArgb(24, 82, 177);
                        palette[7] = Color.FromArgb(57, 125, 209);
                        palette[8] = Color.FromArgb(134, 181, 229);
                        palette[9] = Color.FromArgb(211, 236, 248);
                        palette[10] = Color.FromArgb(241, 233, 191);
                        palette[11] = Color.FromArgb(248, 201, 95);
                        palette[12] = Color.FromArgb(255, 170, 0);
                        palette[13] = Color.FromArgb(204, 128, 0);
                        palette[14] = Color.FromArgb(153, 87, 0);
                        palette[15] = Color.FromArgb(106, 52, 3);
                        return palette[array % 16];
                    }
                case 2:
                    {
                        palette[0] = Color.Black;
                        palette[1] = Color.Green;
                        palette[2] = Color.LightGreen;
                        palette[3] = Color.Green;
                        return palette[array % 4];
                    }
                case 3:
                    {
                        palette[0] = Color.Black;
                        palette[1] = Color.White;
                        return palette[array % 2];
                    }
            }
            return Color.Black;
        }
        public static Color CalculateColor(double iter, int palette)
        {
            Color resultCol = Palette(palette, Convert.ToInt32(iter));
            return resultCol;

        }
        public static Color BlendColor(Color col1, Color col2, double frac)
        {
            return Color.FromArgb(Convert.ToInt32(col1.R + frac * Convert.ToDouble(col2.R-col1.R)), Convert.ToInt32(col1.G + frac * Convert.ToDouble(col2.G - col1.G)), Convert.ToInt32(col1.B + frac * Convert.ToDouble(col2.B - col1.B)));
        }
    }
}
