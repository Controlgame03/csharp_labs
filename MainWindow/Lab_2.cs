using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace MainWindow
{
    public partial class Lab_2 : Form
    {
        String exeptionString = "";
        public Lab_2()
        {
            InitializeComponent();
            radioButton2.Checked = true;
            numericUpDown1.Minimum = 1;
            numericUpDown2.Minimum = 1;
        }

        public String getString()
        {
            return exeptionString;
        }
        public class MyArray
        {
            int[] array;
            float[] createdArray;
            int divNumber = 1;
            int start;
            int end;
            int frequince;
            bool range;
            int seed;
            int value;



            public MyArray(int[] a, int s, int e)
            {
                start = s;
                end = e;
                array = a;
                range = false;
            }
            public MyArray(int[] a, int s, int e, int f, int value)
            {
                start = s;
                end = e;
                array = a;
                frequince = f;

                seed = value;

                range = true;
            }
            public void setDivNumber(int div)
            {
                divNumber = div;
            }
            public MyArray(float[] c, int[] a, int s, int e)
            {
                start = s;
                end = e;
                array = a;
                createdArray = c;
                range = false;
            }

            public float[] returnCreateArray()
            {
                return createdArray;
            }
            public void FillArray()
            {
                Random random = new Random();
                for (int i = start; i < end; i++)
                {
                    if (range)
                    {
                        seed += frequince;
                        array[i] = seed;
                    }
                    else
                    {
                        array[i] = random.Next(0, 100);
                    }

                }
            }

            public void Run()
            {
                for (int i = start; i < end; i++)
                {
                    createdArray[i] = i % 2 == 0 ? array[i] * array[i] : (float)2 * array[i];
                }
            }

            public void Find()
            {
                int findIndex = 0;
                for (int i = start; i < end; i++)
                {
                    if (createdArray[i] > 0)
                    {
                        findIndex = i;
                    }
                }
                createdArray[findIndex] = createdArray[1];

            }
            public void Replace()
            {
                for (int i = start; i < end; i++)
                {
                    if (i % 2 == 0)
                    {
                        createdArray[i] = (float)(createdArray[i] / divNumber);
                    }
                }
            }

            public int[] SelectionSort(int[] createdArray)
            {
                var arrayLength = end;
                for (int i = 0; i < arrayLength - 1; i++)
                {
                    var smallestVal = i;
                    for (int j = i + 1; j < arrayLength; j++)
                    {
                        if (createdArray[j] < createdArray[smallestVal])
                        {
                            smallestVal = j;
                        }
                    }
                    var tempVar = createdArray[smallestVal];
                    createdArray[smallestVal] = createdArray[i];
                    createdArray[i] = tempVar;
                }
                return createdArray;
            }
            public float[] InsertSort()
            {
                for (int i = 1; i < end; i++)
                {
                    var key = createdArray[i];
                    var flag = 0;
                    for (int j = i - 1; j >= 0 && flag != 1;)
                    {
                        if (key < createdArray[j])
                        {
                            createdArray[j + 1] = createdArray[j];
                            j--;
                            createdArray[j + 1] = key;
                        }
                        else flag = 1;
                    }
                }
                return createdArray;
            }
            public float[] BubbleSort()
            {
                var n = end;
                for (int i = 0; i < n - 1; i++)
                    for (int j = 0; j < n - i - 1; j++)
                        if (createdArray[j] > createdArray[j + 1])
                        {
                            var tempVar = createdArray[j];
                            createdArray[j] = createdArray[j + 1];
                            createdArray[j + 1] = tempVar;
                        }
                return createdArray;
            }
            public float[] QuickSort(int leftIndex, int rightIndex)
            {
                var i = leftIndex;
                var j = rightIndex;
                var pivot = createdArray[leftIndex];
                while (i <= j)
                {
                    while (createdArray[i] < pivot)
                    {
                        i++;
                    }

                    while (createdArray[j] > pivot)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        float temp = createdArray[i];
                        createdArray[i] = createdArray[j];
                        createdArray[j] = temp;
                        i++;
                        j--;
                    }
                }

                if (leftIndex < j)
                    QuickSort(leftIndex, j);
                if (i < rightIndex)
                    QuickSort(i, rightIndex);
                return createdArray;
            }
            public float[] MergeSort(int left, int right)
            {
                if (left < right)
                {
                    int middle = left + (right - left) / 2;
                    MergeSort(left, middle);
                    MergeSort(middle + 1, right);
                    Merge(left, middle, right);
                }
                return createdArray;
            }

            public void Merge(int left, int middle, int right)
            {
                var leftArrayLength = middle - left + 1;
                var rightArrayLength = right - middle;
                var leftTempArray = new float[leftArrayLength];
                var rightTempArray = new float[rightArrayLength];
                int i, j;
                for (i = 0; i < leftArrayLength; ++i)
                    leftTempArray[i] = createdArray[left + i];
                for (j = 0; j < rightArrayLength; ++j)
                    rightTempArray[j] = createdArray[middle + 1 + j];
                i = 0;
                j = 0;
                int k = left;
                while (i < leftArrayLength && j < rightArrayLength)
                {
                    if (leftTempArray[i] <= rightTempArray[j])
                    {
                        createdArray[k++] = leftTempArray[i++];
                    }
                    else
                    {
                        createdArray[k++] = rightTempArray[j++];
                    }
                }
                while (i < leftArrayLength)
                {
                    createdArray[k++] = leftTempArray[i++];
                }
                while (j < rightArrayLength)
                {
                    createdArray[k++] = rightTempArray[j++];
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = 0;
                long startAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                long endAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                long oneThread;
                long threeThread;
                MyArray myArray;
                int size = dataGridView1.ColumnCount - 1;
                int[] array = new int[size];
                int threadAmount = 5;
                Thread[] threads = new Thread[threadAmount];
                int step = (int)size / threadAmount;
                int frequiency = (int)numericUpDown3.Value;

                if (radioButton2.Checked || radioButton3.Checked)
                {
                    Random rand = new Random();
                    int value = rand.Next(0, 100);

                    for (int i = 0; i < threadAmount; i++)
                    {
                        int endArray = i == threadAmount - 1 ? array.Length : step * (i + 1);
                        if (radioButton3.Checked)
                        {
                            myArray = new MyArray(array, step * i, endArray, frequiency, value);
                            value += step * frequiency;
                        }
                        else
                        {
                            myArray = new MyArray(array, step * i, endArray);
                        }

                        threads[i] = new Thread(myArray.FillArray);
                        threads[i].Start();
                    }

                    for (int i = 0; i < threadAmount; i++)
                    {
                        threads[i].Join();
                    }
                }
                else
                {
                    string arrayItem = "";

                    try
                    {
                        for (int i = 1; i < dataGridView1.Columns.Count; i++)
                        {
                            arrayItem = dataGridView1.Rows[0].Cells[i].Value + "";
                            array[i - 1] = Int32.Parse(arrayItem);
                        }
                    }
                    catch (Exception exc)
                    {
                        System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n### " + DateTime.Now.ToUniversalTime());
                        System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n" + exc.StackTrace);
                        exeptionString += "\r\n";
                        exeptionString += DateTime.Now.ToUniversalTime().ToString();

                        exeptionString += exc.StackTrace;

                        MessageBox.Show("Некорректный ввод: " + arrayItem);
                        return;
                    }
                }
                progressBar1.PerformStep();
                //Вывод изначального массива
                dataGridView1.Rows.Clear();
                object[] tempRow = new object[(int)size + 1];
                tempRow[0] = "Изначальный массив";
                for (int i = 0; i < size; i++)
                {
                    tempRow[i + 1] = array[i];
                }
                dataGridView1.Rows.Add(tempRow);
                progressBar1.PerformStep();

                //Основа


                float[][] resultMas = new float[3][];
                float[] result;
                object[] temp;
                MyArray[] myArrayMas = new MyArray[3];

                startAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                for (int i = 0; i < 3; i++)
                {
                    resultMas[i] = new float[size];
                    myArrayMas[i] = new MyArray(resultMas[i], array, 0, array.Length);


                    for (int j = 0; j < size; j++) resultMas[i][j] = array[j];
                }
                threads[0] = new Thread(myArrayMas[0].Run);
                threads[0].Start();
                threads[0].Join();

                threads[0] = new Thread(myArrayMas[1].Find);
                threads[0].Start();
                threads[0].Join();

                myArrayMas[2].setDivNumber(array[0]);
                threads[0] = new Thread(myArrayMas[2].Replace);
                threads[0].Start();
                threads[0].Join();

                endAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                oneThread = endAction - startAction;

                for (int i = 0; i < 3; i++)
                {
                    temp = new object[(int)size + 1];
                    int j = 0;
                    temp[j] = "Результат " + (i + 1) + " ";
                    for (; j < size; j++)
                    {
                        temp[j + 1] = resultMas[i][j];
                    }
                    dataGridView1.Rows.Add(temp);
                    progressBar1.PerformStep();
                }
                startAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                for (int i = 0; i < 3; i++)
                {
                    resultMas[i] = new float[size];
                    myArrayMas[i] = new MyArray(resultMas[i], array, 0, array.Length);


                    for (int j = 0; j < size; j++) resultMas[i][j] = array[j];

                    if (i == 0)
                    {
                        threads[i] = new Thread(myArrayMas[i].Run);
                    }
                    else if (i == 1)
                    {
                        threads[i] = new Thread(myArrayMas[i].Find);
                    }
                    else if (i == 2)
                    {
                        myArrayMas[i].setDivNumber(array[0]);
                        threads[i] = new Thread(myArrayMas[i].Replace);
                    }

                    threads[i].Start();

                }
                for (int i = 0; i < 3; i++)
                {
                    threads[i].Join();
                }
                endAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                threeThread = endAction - startAction;

                temp = new object[(int)size + 1];
                temp[0] = "without multithreading: ";
                temp[1] = oneThread + "mili sec";

                dataGridView1.Rows.Add(temp);
                progressBar1.PerformStep();

                temp = new object[(int)size + 1];
                temp[0] = "with multithreading: ";
                temp[1] = threeThread + "mili sec";

                dataGridView1.Rows.Add(temp);
                progressBar1.PerformStep();

                //Доп. задание

                //merge sort
                result = new float[size];
                for (int i = 0; i < size; i++) result[i] = array[i];

                myArray = new MyArray(result, array, 0, size);

                startAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                myArray.MergeSort(0, size - 1);
                endAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                result = myArray.returnCreateArray();

                temp = new object[(int)size + 1];
                temp[0] = "merge sort: " + (long)(endAction - startAction) + "mili sec";
                for (int i = 0; i < size; i++)
                {
                    temp[i + 1] = result[i];
                }
                dataGridView1.Rows.Add(temp);
                progressBar1.PerformStep();

                //quick sort
                result = new float[size];
                for (int i = 0; i < size; i++) result[i] = array[i];

                myArray = new MyArray(result, array, 0, size);

                startAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                myArray.QuickSort(0, size - 1);
                endAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                result = myArray.returnCreateArray();

                temp = new object[(int)size + 1];
                temp[0] = "quick sort:" + (long)(endAction - startAction) + "mili sec";
                for (int i = 0; i < size; i++)
                {
                    temp[i + 1] = result[i];
                }
                dataGridView1.Rows.Add(temp);
                progressBar1.PerformStep();

                //bubble sort
                result = new float[size];
                for (int i = 0; i < size; i++) result[i] = array[i];

                myArray = new MyArray(result, array, 0, size);

                startAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                myArray.BubbleSort();
                endAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                result = myArray.returnCreateArray();

                temp = new object[(int)size + 1];
                temp[0] = "bubble sort:" + (long)(endAction - startAction) + "mili sec";
                for (int i = 0; i < size; i++)
                {
                    temp[i + 1] = result[i];
                }
                dataGridView1.Rows.Add(temp);
                progressBar1.PerformStep();

                //insert sort
                result = new float[size];
                for (int i = 0; i < size; i++) result[i] = array[i];

                myArray = new MyArray(result, array, 0, size);

                startAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                myArray.InsertSort();
                endAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                result = myArray.returnCreateArray();

                temp = new object[(int)size + 1];
                temp[0] = "insert sort:" + (long)(endAction - startAction) + "mili sec";
                for (int i = 0; i < size; i++)
                {
                    temp[i + 1] = result[i];
                }
                dataGridView1.Rows.Add(temp);
                progressBar1.PerformStep();

                //selection sort
                result = new float[size];
                for (int i = 0; i < size; i++) result[i] = array[i];

                myArray = new MyArray(result, array, 0, size);

                startAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                myArray.InsertSort();
                endAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();

                result = myArray.returnCreateArray();

                temp = new object[(int)size + 1];
                temp[0] = "selection sort:" + (long)(endAction - startAction) + "mili sec";
                for (int i = 0; i < size; i++)
                {
                    temp[i + 1] = result[i];
                }
                dataGridView1.Rows.Add(temp);
                progressBar1.PerformStep();


                progressBar1.PerformStep();
            }
            catch (Exception exc)
            {
                System.IO.File.AppendAllText("Errors_Lab_2.txt", Environment.NewLine);
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "### " + DateTime.Now.ToUniversalTime() + "\n" + exc.StackTrace);

                exeptionString += "\r\n";
                exeptionString += DateTime.Now.ToUniversalTime().ToString();
                exeptionString += "\n\n";
                exeptionString += exc.StackTrace;


                MessageBox.Show("Произошла ошибка");
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();
                Decimal size = this.numericUpDown1.Value;
                numericUpDown2.Value = size < numericUpDown2.Value ? size : numericUpDown2.Value;

                dataGridView1.Columns.Add("Arrays", "");
                dataGridView1.Columns[0].ReadOnly = true;
                for (int i = 0; i < size; i++)
                {
                    dataGridView1.Columns.Add("Pos " + i, "" + i);
                }
            }
            catch (Exception exc)
            {
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n### " + DateTime.Now.ToUniversalTime());
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n" + exc.StackTrace);
                MessageBox.Show("Произошла ошибка");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.ReadOnly = !radioButton1.Checked;
                panel1.Visible = false;
            }
            catch (Exception exc)
            {
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n### " + DateTime.Now.ToUniversalTime());
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n" + exc.StackTrace);
                MessageBox.Show("Произошла ошибка");
                exeptionString += "\r\n";
                exeptionString += DateTime.Now.ToUniversalTime().ToString();
                exeptionString += "\n\n";
                exeptionString += exc.StackTrace;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.ReadOnly = radioButton2.Checked;
                panel1.Visible = false;
            }
            catch (Exception exc)
            {
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n### " + DateTime.Now.ToUniversalTime());
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n" + exc.StackTrace);
                MessageBox.Show("Произошла ошибка");
                exeptionString += "\r\n";
                exeptionString += DateTime.Now.ToUniversalTime().ToString();
                exeptionString += "\n\n";
                exeptionString += exc.StackTrace;
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.ReadOnly = radioButton2.Checked;
                panel1.Visible = true;
            }
            catch (Exception exc)
            {
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n\n\n " + DateTime.Now.ToUniversalTime());
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n\n\n" + exc.StackTrace);
                exeptionString += "\r\n";
                exeptionString += DateTime.Now.ToUniversalTime().ToString();
                exeptionString += "\n\n";
                exeptionString += exc.StackTrace;
                MessageBox.Show("Произошла ошибка");
            }

        }
    }
}
