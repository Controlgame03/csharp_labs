using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainWindow
{
    public partial class Lab3_1_2 : Form
    {
        Pen myPen = new Pen(Color.Black);
        Pen grafPen = new Pen(Color.Black);
        int nterms = 1;


        Form1 home;
        public Lab3_1_2(Form1 home_form)
        {
            InitializeComponent();
            home = home_form;
        }
        private void Lab3_1_2_Load(object sender, EventArgs e)
        {
            myPen.Color = Color.Black;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Pifagor(this.Width / 2, this.Height - panel3.Height, Math.PI / 2, 50, (int)numericUpDown2.Value, (int)numericUpDown2.Value);
        }

        async public Task Pifagor(double x0, double y0, double a, double L, int N, int maxN)
        {
            Graphics g = pictureBox1.CreateGraphics();
            const double k = 0.6;
            double x1, y1;

            if (N > 0)
            {
                x1 = x0 + L * Math.Cos(a);
                y1 = y0 - L * Math.Sin(a);


                double coef1 = (double)numericUpDown1.Value;
                double coef2 = (double)numericUpDown4.Value;
                coef1 = coef1 / 180;
                coef2 = coef2 / 180;

                Task first = Pifagor(x1, y1, a + Math.PI * (coef1) + Math.PI * (coef2), L * k, N - 1, maxN);
                Task second = Pifagor(x1, y1, a - Math.PI * (coef1) + Math.PI * (coef2), L * k, N - 1, maxN);
                g.DrawLine(new Pen(Color.FromArgb(255, 255 * N / maxN, 0)), (float)x0, (float)y0, (float)x1, (float)y1);
                pictureBox1.Update();
                await first;
                await second;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            pictureBox1.Refresh();
            g.Dispose();
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            pictureBox1.Refresh();
            g.Dispose();
        }

        async private Task salfetka(double x0, double y0, double L, int N, int maxN)
        {
            Graphics g = pictureBox1.CreateGraphics();
            double x1, y1, xright, yright, xleft, yleft;
            if (N > 0)
            {
                x1 = x0 - L * Math.Cos(30);
                y1 = y0 - L * Math.Sin(60);
                xright = x0 - L * 0.5 * Math.Cos(30);
                yright = y0 - L * 0.5 * Math.Sin(60);

                g.DrawLine(new Pen(Color.FromArgb(255, 255 * N / maxN, 0)), (float)x0, (float)y0, (float)x1, (float)y1);
                x0 = x1;
                y0 = y1;
                x1 = x0 + 2 * L * Math.Cos(30);

                g.DrawLine(new Pen(Color.FromArgb(255, 255 * N / maxN, 0)), (float)x0, (float)y0, (float)x1, (float)y1);
                x0 = x1;
                y0 = y1;
                x1 = x0 - L * Math.Cos(30);
                y1 = y0 + L * Math.Sin(60);
                xleft = x0 - L * 0.5 * Math.Cos(30);
                yleft = y0 + L * 0.5 * Math.Sin(60);

                g.DrawLine(new Pen(Color.FromArgb(255, 255 * N / maxN, 0)), (float)x0, (float)y0, (float)x1, (float)y1);

                Task first = salfetka(x1, y1, L / 2, N - 1, maxN);
                Task second = salfetka(xright, yright, L / 2, N - 1, maxN);
                Task third = salfetka(xleft, yleft, L / 2, N - 1, maxN);
                await first;
                await second;
                await third;
                pictureBox1.Update();
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            pictureBox1.Refresh();
            g.Dispose();

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await salfetka(panel3.Width / 2, panel3.Height * 0.25, 500, (int)numericUpDown3.Value, (int)numericUpDown3.Value);
        }

        private void Lab3_1_2_Load_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            pictureBox1.Refresh();
            g.Dispose();
        }

        private void numericUpDown4_ValueChanged_1(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            pictureBox1.Refresh();
            g.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
