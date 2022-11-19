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
    public partial class Lab4_dop : Form
    {
        
        public Lab4_dop()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            startPars(fileText);

        }
        void startPars(string input) {
           
            int index = input.IndexOf("namespace");
            textBox1.Text += input.Substring(0, index);

            int count = 0;
            bool isMethods = false;
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] == '{')
                {   
                    if(count <= 2)
                    {
                        int start = i;
                        int finish = i;
                        for (finish = i; input[finish] != '\n'; finish--) ;
                        for (start = finish - 1; input[start] != '\n'; start--);
                        start++;
                       
                        textBox1.Text += input.Substring(start, finish - start);
                        if (isMethods)
                        {
                            textBox1.Text += ";\r\n";
                        }
                        else
                        {
                            if (count == 2)
                            {
                                textBox1.Text += ";\r\n";
                                isMethods = true;
                            }
                            else textBox1.Text += " {\r\n";
                        }
                    }
                    
                    count++;
                }
                else if(input[i] == '}')
                {
                    count--;
                }
            }
            textBox1.Text += "    }\r\n";
            textBox1.Text += "}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
