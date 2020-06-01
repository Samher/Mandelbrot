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
        Color[,] Graph;
        public Form1()
        {
            InitializeComponent();
        }

        float fmap(float x, float in_min, float in_max, float out_min, float out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        private Complex f(Complex z, Complex c)
        {
            return Complex.Pow(z, 2) + c;
        }

        private void Calculate()
        {
            int width = int.Parse(Length_Box.Text);
            int height = (int)(float.Parse(Length_Box.Text) / 3.5 * 2f);

            Graph = new Color[width, height];

            Parallel.For(0, height, b => 
            {
                Parallel.For(0, width, a =>
                {
                    Complex z = new Complex(0, 0);
                    Complex c = new Complex(fmap(a, 0, width - 1, -2.5f, 1), fmap(b, 0, height - 1, 1, -1));
                    int n = 0;
                    do
                    {
                        z = f(z, c);
                        n++;
                    } while (Complex.Abs(z) <= 2 && n < 1000);

                        if (n == 1000)
                        {
                            Graph[a,b] = Color.Black;
                        }
                        if (Complex.Abs(z) > 2)
                        {
                            double alpha = 255 * Math.Sqrt(n / 1000f);
                            Graph[a, b] = Color.FromArgb((int)alpha, 200, 0, 200);
                        }
                });    
            });
            /*for (double b = -1; b <= 1; b += 2d / Graph.Height)
            {
                for (double a = -2.5; a <= 1; a += 3.5d / Graph.Width)
                {
                    Complex z = new Complex(0, 0);
                    Complex c = new Complex(a, b);
                    int n = 0;
                    do
                    {
                        z = f(z, c);
                        n++;
                    } while (Complex.Abs(z) <= 2 && n < 1000);
                    
                    double aCoord = a / 3.5 * Graph.Width + Graph.Width * 2.5f / 3.5f;
                    double bCoord = b / 2 * Graph.Height + Graph.Height / 2;

                    if (n == 1000)
                    {
                        Graph.SetPixel((int)aCoord, (int)bCoord, Color.Black);
                    }
                    if (Complex.Abs(z) > 2)
                    {
                        double alpha = 255 * Math.Sqrt(n / 1000f);
                        Graph.SetPixel((int)aCoord, (int)bCoord, Color.FromArgb((int)alpha, 200, 0, 200));
                    }
                }
            }*/
            Bitmap image = new Bitmap(width, height);
            for (int b = 0; b < height; b++)
            {
                for (int a = 0; a < width; a++)
                {
                    image.SetPixel(a, b, Graph[a, b]);
                }
            }
            image.Save("GrandeMandel.PNG");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculate();
            MessageBox.Show("En grandemandel väntar på dig!");
            System.Diagnostics.Process.Start("explorer.exe", @"Grandemandel.PNG");
            this.Close();
        }
    }
}
