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
            Graph = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Complex result = new Complex(0,0);
            Complex nResult;

            for (double b = -1; b <= 1; b += 2 / 500)
            {
                for (double a = -2.5; a <= 1; a += 3.5 / 750)
                {
                    Complex c = new Complex(a, b);

                    for (int n = 0; n < 1000; n++)
                    {
                        nResult = f(result, c);
                        if (Complex.Abs(nResult) > 2)
                            break;
                        if (Complex.Abs(nResult) < 2 && n == 999) { }
                            //set pixel color
                    }
                }
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            return z * z + c;
        }
    }
}
