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
        Size currentSize;
        public Form1()
        {
            InitializeComponent();
            Calculate();
        }

        private Complex f(Complex z, Complex c)
        {
            return z * z + c;
        }

        private void Calculate()
        {
            Graph = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            for (double b = -1; b <= 1; b += 2f / pictureBox1.Height)
            {
                for (double a = -2.5; a <= 1; a += 3.5 / pictureBox1.Width)
                {
                    Complex z = new Complex(0, 0);
                    Complex c = new Complex(a, b);
                    int n = 0;
                    while (Complex.Abs(z) < 2 && n < 1000)
                    {
                        z = f(z, c);
                        n++;
                    }
                    double aCoord = (a / 3.5) * pictureBox1.Width + (2.5 / 3.5) * pictureBox1.Width;
                    double bCoord = ((b / 2) * pictureBox1.Height + pictureBox1.Height / 2);
                    Graph.SetPixel((int)aCoord, (int)bCoord, Color.FromArgb(n / 4, 0, 0, 0));
                    pictureBox1.Image = Graph;
                }
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (currentSize != Size)
                Calculate();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            currentSize = Size;
        }
    }
}
