using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        Bitmap Graph;
        public Form1()
        {
            InitializeComponent();
        }

        private Complex f(Complex z, Complex c)
        {
            return z * z + c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graph = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Complex result = new Complex(0, 0);
            Complex nResult;

            for (double b = -1; b <= 1; b += 2 / pictureBox1.Height)
            {
                for (double a = -2.5; a <= 1; a += 3.5 / pictureBox1.Width)
                {
                    Complex c = new Complex(a, b);

                    for (int n = 0; n < 1000; n++)
                    {
                        nResult = f(result, c);
                        if (Complex.Abs(nResult) > 2)
                            break;
                        if (Complex.Abs(nResult) < 2 && n == 999)
                        {
                            double aCoord = (a / 3.5) * pictureBox1.Width + (2.5 / 3.5) * pictureBox1.Width;
                            double bCoord = ((b / 2) * pictureBox1.Height + pictureBox1.Height / 2);
                            Graph.SetPixel((int)aCoord, (int)bCoord, Color.Black);
                            pictureBox1.Image = Graph;
                        }
                    }
                }
            }
        }

        public Complex f(Complex z, Complex c)
        {
            return z * z + c;
        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bah = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    bah.SetPixel(x, y, Color.Black);
                    pictureBox1.Image = bah;
                }
            }
        }
    }
}
