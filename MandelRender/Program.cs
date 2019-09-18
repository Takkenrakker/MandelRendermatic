using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelRender
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        private static string CheckNumbs(float x, float y, int iterations)
        {
            int counter;
            float n = 0;
            float m = 0;
            for (counter = 0; counter < iterations; counter++)
            {
                n = n * n - m * m + x;
                m = 2 * n * m + y;
                Console.WriteLine(n + ", " + m);
                if (Math.Sqrt(n + m) > 2)
                {
                    return "Not a mandel number!! " + counter;
                }
            }
            return "Mandel number!! Stopped at " + counter;
        }

        public static string renderMandelbrot(float num1, float num2, int iterations)
        {
            return "Result: " + CheckNumbs(num1, num2, iterations);
        }
    }
}
