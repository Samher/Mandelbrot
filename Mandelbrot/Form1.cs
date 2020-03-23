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

        private void Calculate()
        {
            Graph = new Bitmap(int.Parse(Length_Box.Text), (int)(float.Parse(Length_Box.Text) / 3.5f * 2f));

            for (int y = 0; y < Graph.Height; y++)
                for (int x = 0; x < Graph.Width; x++)
                    Graph.SetPixel(x, y, Color.White);

            for (double b = -1; b <= 1; b += 2f / Graph.Height)
            {
                for (double a = -2.5; a <= 1; a += 3.5 / Graph.Width)
                {
                    Complex z = new Complex(0, 0);
                    Complex c = new Complex(a, b);
                    int n = 0;
                    while (Complex.Abs(z) < 2 && n < 1000)
                    {
                        z = f(z, c);
                        n++;
                    }
                    //if (Complex.Abs(z) < 2)
                    //{
                        double aCoord = (a / 3.5) * Graph.Width + (2.5 / 3.5) * Graph.Width;
                        double bCoord = ((b / 2) * Graph.Height + Graph.Height / 2);
                        Graph.SetPixel((int)aCoord, (int)bCoord, Color.FromArgb(255, 255 - n / 4, 255 - n / 4, 255 - n / 4));
                    //}
                }
            }
            Graph.Save("GrandeMandel.PNG");
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
