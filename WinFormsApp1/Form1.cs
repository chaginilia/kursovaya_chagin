using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<DataRow> filteredRows;
        private DataTable dataTable1;
        public Form1(DataTable dataTable, string filePath)
        {
            InitializeComponent();
            dataTable1 = dataTable;
            textBoxFilePath.Text = filePath;
        }

        public void UpdateData(DataTable _dataTable, string filePath)
        {
            dataTable1 = _dataTable;
            textBoxFilePath.Text = filePath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show(); // Открыть вторую форму как модальное окно
        }

        private void start_P1_Click(object sender, EventArgs e)
        {
            double threshold;
            int r, k;
            // Обработка исключений для проверки ввода пользователем
            if (!double.TryParse(textBox_gr.Text, out threshold))
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для границы срабатывания.");
                return;
            }

            if (!int.TryParse(textBoxR.Text, out r) || r <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для r (должно быть положительным целым числом).");
                return;
            }

            if (!int.TryParse(textBoxK.Text, out k) || k <= 0 || k > r)
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для k (должно быть положительным целым числом).k не может превышать r");
                return;
            }

            filteredRows = new List<DataRow>();
            List<int> binaryList = new List<int>();

            // Преобразование столбца в список из 0 и 1
            foreach (DataRow row in dataTable1.Rows)
            {
                double value;
                if (double.TryParse(row[1].ToString(), out value) && value > threshold) // Здесь 1 - это индекс столбца
                {
                    binaryList.Add(1);
                }
                else
                {
                    binaryList.Add(0);
                }
            }

            // Проверка условий в бинарном списке
            bool firstTriggered = false;
            for (int i = r - 1; i < binaryList.Count; i++)
            {
                int sum = 0;
                for (int j = i - r + 1; j <= i; j++)
                {
                    sum += binaryList[j];
                }

                if (sum >= k)
                {
                    filteredRows.Add(dataTable1.Rows[i]);
                    if (checkBox_first.Checked)
                    {
                        firstTriggered = true;
                        break;
                    }
                }
            }

            dataGridView1.DataSource = filteredRows.Count > 0 ? filteredRows.CopyToDataTable() : null;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button_start_p2_Click(object sender, EventArgs e)
        {
            double threshold;
            int r1, r2, k1, k2;
            // Обработка исключений для проверки ввода пользователем
            if (!double.TryParse(textBox_P2_gr.Text, out threshold))
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для границы срабатывания.");
                return;
            }

            if (!int.TryParse(textBox_r1_P2.Text, out r1) || r1 <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для r1 (должно быть положительным целым числом).");
                return;
            }

            if (!int.TryParse(textBox_k1_P2.Text, out k1) || k1 <= 1)
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для k1 (должно быть больше 1).");
                return;
            }

            if (!int.TryParse(textBox_r2_P2.Text, out r2) || r2 <= r1)
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для r2 (должно быть больше r1).");
                return;
            }

            if (!int.TryParse(textBox_k2_P2.Text, out k2) || k2 <= k1)
            {
                MessageBox.Show("Пожалуйста, введите корректное значение для k2 (должно быть больше k1).");
                return;
            }


            filteredRows = new List<DataRow>();
            List<int> binaryList = new List<int>();

            // Преобразование столбца в список из 0 и 1
            foreach (DataRow row in dataTable1.Rows)
            {
                double value;
                if (double.TryParse(row[1].ToString(), out value) && value > threshold) // Здесь 1 - это индекс столбца
                {
                    binaryList.Add(1);
                }
                else
                {
                    binaryList.Add(0);
                }
            }

            // Проверка условий в бинарном списке
            bool firstTriggered = false;
            for (int i = Math.Max(r1, r2) - 1; i < binaryList.Count; i++)
            {
                int sumR1 = 0;
                int sumR2 = 0;

                for (int j = i - r1 + 1; j <= i; j++)
                {
                    sumR1 += binaryList[j];
                }

                for (int j = i - r2 + 1; j <= i; j++)
                {
                    sumR2 += binaryList[j];
                }

                if (sumR1 >= k1 || sumR2 >= k2)
                {
                    filteredRows.Add(dataTable1.Rows[i]);
                    if (checkBox_first_p2.Checked)
                    {
                        firstTriggered = true;
                        break;
                    }
                }
            }

            dataGridView_P2.DataSource = filteredRows.Count > 0 ? filteredRows.CopyToDataTable() : null;

        }
    }
}
