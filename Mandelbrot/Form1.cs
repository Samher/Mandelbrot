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
        public Form1()
        {
            InitializeComponent();
            Bitmap Graph = new Bitmap(Size.Width, Size.Height);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            
        }
    }
}
