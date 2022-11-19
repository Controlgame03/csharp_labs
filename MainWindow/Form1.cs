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
    public partial class Form1 : Form
    {
        Lab_2 lab_2;
        Lab_3 lab_3_1_1;
        Lab3_1_2 lab_3_1_2;
        Lab3_2 lab_3_2;
        Lab4 lab_4;
        Lab4_dop lab4_dop;
        String buffer = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void part12ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void aboutTheAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_the_author author1 = new About_the_author();
            author1.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("File save");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
            MessageBox.Show("File open");
        }

        private void lab2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lab_2 = new Lab_2();
            lab_2.Show();
            textBox1.Text = lab_2.getString();
        }

        public void addErrorLog(String txt)
        {
            textBox1.Text = txt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lab_2 != null)
            {
                buffer += lab_2.getString();
                textBox1.Text += buffer;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            lab_3_1_1 = new Lab_3(this);
            lab_3_1_1.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            lab_3_1_2 = new Lab3_1_2(this);
            lab_3_1_2.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            lab_3_2 = new Lab3_2(this);
            lab_3_2.Show();
        }

        private void lab4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void основаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lab_4 = new Lab4(this);
            lab_4.Show();
        }

        private void допToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lab4_dop = new Lab4_dop();
            lab4_dop.Show();
        }
    }
}
