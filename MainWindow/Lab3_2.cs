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
    public partial class Lab3_2 : Form
    {
        Form1 homeForm;
        Pen myPen = new Pen(Color.Black);
        Font drawFont = new Font("Arial", 10);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        public Lab3_2(Form1 home)
        {
            homeForm = home;
            InitializeComponent();
        }

        String buffer = "";
        private void button1_Click(object sender, EventArgs e)
        {

            pictureBox1.Refresh();
            Graphics g = pictureBox1.CreateGraphics();



            buffer = "";

            long n = (long)numericUpDown1.Value;

            factorial(n, 1);
            g.DrawString(buffer, drawFont, drawBrush, 0, 0);
        }


        private long factorial(long n, int deep)
        {
            if (n == 0)
            {
                buffer += deep + ") ---> " + "f(0) = 1\r\n";
                return 1;
            }
            if (n == 1)
            {
                buffer += deep + ") ---> " + "f(1) = 1\r\n";
                return 1;
            }
            else
            {
                buffer += deep + ") ---> " + "f(" + n + ") = " + n + " * f(" + (n - 1) + ");\r\n";
                long fact = factorial(n - 1, deep + 1);
                buffer += deep + ") ---> " + "f(" + n + ") = " + n + " * " + fact + " = " + fact * n + "\r\n";
                n = n * fact;
                return n;
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;
            pictureBox1.Height = 30 * size;
            pictureBox1.Width = 30 * (size + 3) + 200;
            Size f = new Size();
            f.Height = 30 * (size + 3);
            f.Width = 30 * (size + 4) + 200;
            ClientSize = f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("error");
            }
            catch (Exception exc)
            {
                String exeptionString = "";
                exeptionString += DateTime.Now.ToUniversalTime().ToString();
                exeptionString += "\n\n";
                exeptionString += exc.StackTrace;

                homeForm.textBox1.Text += exeptionString;
            }
        }
    }
}
