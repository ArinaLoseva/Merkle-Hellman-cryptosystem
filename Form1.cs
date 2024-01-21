using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool IsPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        public bool Check_k()
        {
            if (textBox2.Text != "")
            {
                string k = textBox2.Text.ToString();
                string[] text = k.Split(' ');
                if (text.Length == 7)
                {
                    bool check = true;
                    for (int i = 0; i < 6; i++)
                    {
                        if (Convert.ToInt32(text[i]) > Convert.ToInt32(text[i + 1]) / 2)
                            check = false;
                    }
                    if (check == true)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool Check_m()
        {
            string k = textBox2.Text.ToString();
            string[] text = k.Split(' ');
            int sum = 0;
            for(int i = 0; i < text.Length; i++)
            {
                sum += Convert.ToInt32(text[i]);
            }
            if (Convert.ToInt32(textBox3.Text) > sum)
                return true;
            else
                return false;
        }

        public bool Check_n()
        {
            int n = Convert.ToInt32(textBox4.Text);
            int m = Convert.ToInt32(textBox3.Text);
            if (IsPrime(n))
            {
                for (int i = 2; i < m; i++)
                {
                    if (n % i == 0 && m % i == 0)
                        return false;
                }
                return true;
            }
            else
                return false;
        }

        public bool Check_other_n()
        {
            if ((Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox5.Text)) % Convert.ToInt32(textBox3.Text) == 1)
                return true;
            else
                return false;
        }

        public void Bin_code(char[] text)
        {
            string[] bin = { "1100001", "1100010", "1100010", "1100100", "1100101", "1100110", "1100111", "1101000", "1101001", "1101010", "1101011", "1101100", "1101101", "1101110", "1101111", "1110000", "1110001", "1110010", "1110011", "1110100", "1110101", "1110110", "1110111", "1111000", "1111001", "1111010", "1000000"};
            string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (text[i].ToString() == alphabet[j])
                    {
                        dataGridView1.Rows[i].Cells[0].Value = alphabet[j];
                        dataGridView1.Rows[i].Cells[1].Value = bin[j];
                    }
                }
            }
        }

        public void Find_X_i()
        {
            string k = textBox2.Text.ToString();
            string[] text_k = k.Split(' ');
            for(int i = 0; i < text_k.Length; i++)
            {
                textBox6.Text += 
                    (Convert.ToInt32(text_k[i]) * Convert.ToInt32(textBox4.Text)) % Convert.ToInt32(textBox3.Text);
                if (i < text_k.Length - 1)
                    textBox6.Text += " ";
            }
        }

        public void Find_C_i(int len)
        {
            string text_x = textBox6.Text.ToString();
            string[] x = text_x.Split(' ');
            
            for(int i = 0; i < len; i++)
            {
                int c_sum = 0;
                string number = dataGridView1.Rows[i].Cells[1].Value.ToString();
                char[] numbers = number.ToArray();
                for(int j = 0; j < numbers.Length; j++)
                {
                    if(numbers[j] == '1')
                    {
                        c_sum += Convert.ToInt32(x[j]);
                        dataGridView1.Rows[i].Cells[2].Value += x[j] + " ";
                    }
                    if (numbers[j] == '0')
                    {
                        dataGridView1.Rows[i].Cells[2].Value += "0 ";
                    }
                }
                dataGridView1.Rows[i].Cells[3].Value = c_sum;
                textBox7.Text += c_sum;
                if(i < len-1)
                    textBox7.Text += " ";
            }
        }

        public void Find_A_i()
        {
            int m = Convert.ToInt32(textBox3.Text);
            int other_n = Convert.ToInt32(textBox5.Text);
            string[] c = textBox7.Text.Split(' ');
            for(int i = 0; i < c.Length; i++)
            {
                int a = (Convert.ToInt32(c[i]) * other_n) % m;
                dataGridView1.Rows[i].Cells[1].Value = a;
            }
        }

        public void Find_bin(int len)
        {
            string[] bin = { "1100001", "1100010", "1100010", "1100100", "1100101", "1100110", "1100111", "1101000", "1101001", "1101010", "1101011", "1101100", "1101101", "1101110", "1101111", "1110000", "1110001", "1110010", "1110011", "1110100", "1110101", "1110110", "1110111", "1111000", "1111001", "1111010", "1000000" };
            string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", " " };
            string[] k = textBox2.Text.Split(' ');
            for(int i = 0; i < len; i++)
            {
                int a = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());
                for(int j = 6; j >= 0; j--)
                {
                    if(a - Convert.ToInt32(k[j]) >= 0)
                    {
                        dataGridView1.Rows[i].Cells[2].Value += k[j] + " ";
                        dataGridView1.Rows[i].Cells[3].Value += "1";
                        a = a - Convert.ToInt32(k[j]);
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[2].Value += "0 ";
                        dataGridView1.Rows[i].Cells[3].Value += "0";
                    }
                }
            }
            for(int i = 0; i < len; i++)
            {
                string binary = dataGridView1.Rows[i].Cells[3].Value.ToString();
                char[] a = binary.ToCharArray();
                Array.Reverse(a);
                string b = new string(a);
                dataGridView1.Rows[i].Cells[3].Value = b;

                for (int m = 0; m < bin.Length; m++)
                {
                    if (b == bin[m])
                    {
                        textBox1.Text += alphabet[m];
                        dataGridView1.Rows[i].Cells[4].Value = alphabet[m];
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check_k() == true && textBox1.Text !="")
            {
                string t = textBox1.Text;
                char[] text = t.ToArray();
                dataGridView1.ColumnCount = 4;
                dataGridView1.RowCount = text.Length;
                dataGridView1.Columns[0].Name = "символ";
                dataGridView1.Columns[1].Name = "bin-код";
                dataGridView1.Columns[2].Name = "сумма весов";
                dataGridView1.Columns[3].Name = "c_i шифрограмма";
                Bin_code(text);
                if (Check_m())
                {
                    if (Check_n())
                    {
                        if (Check_other_n())
                        {
                            Find_X_i();
                            Find_C_i(text.Length);
                        }
                        if (!Check_other_n())
                        {
                            MessageBox.Show("Ошибка при вводе n^-1");
                            textBox4.Text = "";
                        }
                    }
                    if (!Check_n())
                    {
                        MessageBox.Show("Ошибка при вводе n");
                        textBox4.Text = "";
                    }
                }
                if (!Check_m())
                {
                    MessageBox.Show("Ошибка при вводе m");
                    textBox3.Text = "";
                }
            }
            if (!Check_k())
            {
                MessageBox.Show("Ошибка при вводе K_i");
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox7.Text != "")
            {
                string[] c = textBox7.Text.Split(' ');
                dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = 5;
                dataGridView1.RowCount = c.Length;
                dataGridView1.Columns[0].Name = "c_i шифрограмма";
                dataGridView1.Columns[1].Name = "a_i";
                dataGridView1.Columns[2].Name = "сумма весов";
                dataGridView1.Columns[3].Name = "bin-код";
                dataGridView1.Columns[4].Name = "символ";
                for (int i = 0; i < c.Length; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = c[i];
                }
                if (Check_m())
                {
                    if (Check_n())
                    {
                        if (Check_other_n())
                        {
                            if (Check_k())
                            {
                                Find_A_i();
                                Find_bin(c.Length);
                            }
                            if (!Check_k())
                            {
                                MessageBox.Show("Ошибка при вводе K_i");
                                textBox4.Text = "";
                            }
                        }
                        if (!Check_other_n())
                        {
                            MessageBox.Show("Ошибка при вводе n^-1");
                            textBox4.Text = "";
                        }
                    }
                    if (!Check_n())
                    {
                        MessageBox.Show("Ошибка при вводе n");
                        textBox4.Text = "";
                    }
                }
                if (!Check_m())
                {
                    MessageBox.Show("Ошибка при вводе m");
                    textBox4.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "")
            {
                string k = textBox2.Text.ToString();
                string[] text = k.Split(' ');
                textBox2.Text = text[0] + " ";
                int count = Convert.ToInt32(text[0]);
                for (int i = 1; i < 7; i++)
                {
                    textBox2.Text += count * 2;
                    count = count * 2;
                    if (i < 6)
                        textBox2.Text += " ";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "k_i.txt");
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                textBox2.Text = text;
            }
            else
                MessageBox.Show("Файл k_i не найден!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] m = { 110, 157, 260, 341, 427};
            int[] n = { 31, 79, 29, 19, 5};
            int[] n_1 = {  71, 2, 9, 18, 171};

            if (Check_k())
            {
                string k = textBox2.Text.ToString();
                string[] text = k.Split(' ');
                int count = 0;
                for(int i = 0; i < 7; i++)
                {
                    count += Convert.ToInt32(text[i]);
                }
                for(int j = 0; j < m.Length; j++)
                {
                    if(m[j] > count)
                    {
                        textBox3.Text = m[j].ToString();
                        textBox4.Text = n[j].ToString();
                        textBox5.Text = n_1[j].ToString();
                        break;
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string text = "";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "m.txt");
            if (File.Exists(path))
            {
                text = File.ReadAllText(path);
            }
            else
                MessageBox.Show("Файл m не найден!");

            string[] t = text.Split(',');
            textBox3.Text = t[0];
            textBox4.Text = t[1];
            textBox5.Text = t[2];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string fileName1 = "c_i.txt";
            string textToWrite1 = textBox7.Text;
            File.WriteAllText(fileName1, textToWrite1);

            string fileName2 = "k.txt";
            string textToWrite2 = textBox2.Text;
            File.WriteAllText(fileName2, textToWrite2);

            string fileName3 = "m_n_n1.txt";
            string textToWrite3 = textBox3.Text + " " + textBox4.Text + " " + textBox5.Text;
            File.WriteAllText(fileName3, textToWrite3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "c_i.txt");
            string text1 = File.ReadAllText(path1);
            textBox7.Text = text1;

            string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "k.txt");
            string text2 = File.ReadAllText(path2);
            textBox2.Text = text2;

            string path3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "m_n_n1.txt");
            string text3 = File.ReadAllText(path3);
            string[] t3 = text3.Split(' ');
            textBox3.Text = t3[0];
            textBox4.Text = t3[1];
            textBox5.Text = t3[2];
        }
    }
}
