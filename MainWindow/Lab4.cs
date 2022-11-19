using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using mylib;

namespace MainWindow
{
    public partial class Lab4 : Form
    {
        Form home_form;
        public string s;
        public MatchCollection myMatch;
        public string signatura;
        public string[] form = new string[8] { "Form1.cs", "Lab_2.cs", "Lab3.cs", "Lab3_1_2.cs", "Lab3_2.cs", "Lab4.cs", "About_the_author.cs", "About_the_author.cs" };
        public Lab4(Form1 HomeForm)
        {
            InitializeComponent();
            home_form = HomeForm;
            this.dateTimePicker1.Format = DateTimePickerFormat.Time;
            this.dateTimePicker1.ShowUpDown = true;

            this.dateTimePicker2.Format = DateTimePickerFormat.Time;
            this.dateTimePicker2.ShowUpDown = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            s = richTextBox1.Text;
            signatura = comboBox1.Text;

            MatchCollection matches = mylib.Class1.Find(s, signatura);
            myMatch = matches;
            textBox1.Text = "Все вхождения строки " + signatura + " в исходном тексте: " + "\r\n";
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    textBox1.Text += match.Index + "-ая позиция" + "\t" + match.Value + "\r\n";
                }
            }
            else
            {
                textBox1.Text = "Совпадений не найдено";
            }
        }

        Color[] myColor = new Color[] { Color.Red, Color.Blue, Color.Yellow, Color.Lime, Color.CadetBlue, Color.Gold, Color.Pink, Color.ForestGreen, Color.Indigo, Color.Cyan, Color.Orange, Color.LightSalmon };

        int col = 0;
        private void SetSelectionStyle(int startIndex, int lenght, FontStyle style)
        {
            richTextBox1.Select(startIndex, lenght);
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | style);
            // richTextBox1.SelectionColor = System.Drawing.Color.myColor[i];
            richTextBox1.SelectionColor = myColor[col % 12];
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Select(0, richTextBox1.MaxLength);
            richTextBox1.SelectionColor = Color.Black;
            s = richTextBox1.Text;
            signatura = comboBox1.Text;
            MatchCollection matches = mylib.Class1.Find(s, signatura);
            myMatch = matches;
            foreach (Match m in myMatch)
            {
                SetSelectionStyle(m.Index, m.Length, FontStyle.Regular);
            }
            col++;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int count = 0;
            bool check = false;
            richTextBox1.Select(0, richTextBox1.MaxLength);
            richTextBox1.SelectionColor = Color.Black;
            textBox1.Text = "";
            s = richTextBox1.Text;
            for (int i = 0; i < form.Length; i++)
            {
                MatchCollection matches = mylib.Class1.Find(s, form[i]);
                myMatch = matches;
                if (matches.Count > 0)
                {
                    foreach (Match m in myMatch)
                    {
                        SetSelectionStyle(m.Index, m.Length, FontStyle.Regular);
                        count++;
                    }
                    check = true;
                    textBox1.Text += "Исключение появлялось в форме " + form[i] + " " + count + " раз\r\n";
                    count = 0;
                }

            }
            if (check != true)
            {
                textBox1.Text = "Исключений в формах не обнаруженно";
            }
            col++;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int hours = 0, minutes = 0, seconds = 0, result_strok, result_before = 0, result_after = 0;

            string[] data = dateTimePicker1.Text.Split(new char[] { ':' });
            seconds = Convert.ToInt32(data[2]);
            minutes = Convert.ToInt32(data[1]) * 60;
            hours = Convert.ToInt32(data[0]) * 3600;
            result_before = seconds + minutes + hours;

            data = dateTimePicker2.Text.Split(new char[] { ':' });
            seconds = Convert.ToInt32(data[2]);
            minutes = Convert.ToInt32(data[1]) * 60;
            hours = Convert.ToInt32(data[0]) * 3600;
            result_after = seconds + minutes + hours;
            s = richTextBox1.Text;
            MatchCollection matches = mylib.Class1.Date(s);
            int check = 0;
            int start = 0, end = 0;
            foreach (Match match in matches)
            {
                string[] words = match.Value.Split(new char[] { ':' });
                seconds = Convert.ToInt32(words[2]);
                minutes = Convert.ToInt32(words[1]) * 60;
                hours = Convert.ToInt32(words[0]) * 3600;
                result_strok = seconds + minutes + hours;
                if (result_strok > result_before && result_strok < result_after)
                {
                    SetSelectionStyle(match.Index, match.Length, FontStyle.Regular);
                    if (check == 0)
                    {
                        start = match.Index;
                        check++;
                    }
                }
                if (result_strok >= result_after && check == 1)
                {
                    end = match.Index;
                    check++;
                }
                else
                {
                    end = richTextBox1.Text.Length;
                }
            }
            if (check != 0)
            {
                matches = mylib.Class1.Find(s, "string");
                foreach (Match m in matches)
                {
                    if (m.Index > start && m.Index < end)
                    {
                        String extraText = "\\denserg765@gmail.com";
                        richTextBox1.Select(m.Index - 1 + col * (extraText.Length - 1), 1);
                        richTextBox1.SelectedText = extraText;
                        SetSelectionStyle(m.Index + col * (extraText.Length - 1), extraText.Length - 1, FontStyle.Regular);
                        col++;
                    }
                }

            }
            else
            {
                textBox1.Text = "В заданном периоде форм не обнаруженно";
            }
            col++;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
        }
    }
}



