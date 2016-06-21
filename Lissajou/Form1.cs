using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void doDrawing()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics gr = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            gr.Clear(Color.Beige);

            double x, y, x0, y0;
            double kx, ky;
            kx = hScrollBar1.Value + 1;
            ky = vScrollBar1.Value + 1;
            x0 = 0;
            y0 = 0;
            Color c;
            int n = (int)(kx * ky);
            for (int t = 0; t < 360 * n; t += 1)
            {
                int r, g, b;
                r = 0; g = 0; b = 0;
                int d = vScrollBar2.Value;
                r = (int)(128 + 127 * Math.Pow(0.5 + 0.5 * Math.Sin((t / n -   0.0 - d) / 90.0 * Math.PI), 4));
                g = (int)(128 + 127 * Math.Pow(0.5 + 0.5 * Math.Sin((t / n - 120.0 - d) / 90.0 * Math.PI), 4));
                b = (int)(128 + 127 * Math.Pow(0.5 + 0.5 * Math.Sin((t / n - 240.0 - d) / 90.0 * Math.PI), 4));

                c = Color.FromArgb(r, g, b);
                Pen pn = new Pen(c, 15); 
                x = 100 + 100 * Math.Cos((t - 0) / 180.0 * Math.PI / kx);
                y = 100 + 100 * Math.Sin((t - ky * d) / 180.0 * Math.PI / ky);
                if (t != 0) 
                   gr.DrawLine(pn, (float)x0, (float)y0, (float)x, (float)y);
                x0 = x;
                y0 = y;
            }
        }

        private void btDraw_Click(object sender, EventArgs e)
        {
            doDrawing();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            doDrawing();
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            doDrawing();
        }

        private void vScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            doDrawing();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text + string.Format("{0:03}", vScrollBar2.Value) + ".png";
            pictureBox1.Image.Save(fname, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
