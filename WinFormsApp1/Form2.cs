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


namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private DataTable dataTable = new DataTable();
        private Form1 _form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                openFileDialog.Title = "Выберите файл Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFilePath.Text = openFileDialog.FileName;
                }
                string filePath = textBoxFilePath.Text;

                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Пожалуйста, выберите файл.");
                    return;
                }

                try
                {
                    using (var workbook = new XLWorkbook(filePath))
                    {
                        var worksheet = workbook.Worksheet(1); // Assuming the data is in the first sheet

                        bool firstRow = true;
                        foreach (var row in worksheet.Rows())
                        {
                            if (firstRow)
                            {
                                foreach (var cell in row.Cells())
                                {
                                    dataTable.Columns.Add(cell.Value.ToString());
                                }
                                firstRow = false;
                            }
                            else
                            {
                                dataTable.Rows.Add();
                                int i = 0;
                                foreach (var cell in row.Cells())
                                {
                                    dataTable.Rows[dataTable.Rows.Count - 1][i] = cell.Value.ToString();
                                    i++;
                                }
                            }
                        }

                        dataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }
        }

        private void button_im_f1_Click(object sender, EventArgs e)
        {
            string filePath = textBoxFilePath.Text;



            if (_form1 == null || _form1.IsDisposed)
            {
                _form1 = new Form1( dataTable, filePath); // Передаем ссылку на текущую форму
                _form1.Show();
            }
            else
            {
                _form1.UpdateData(dataTable, filePath);
                _form1.BringToFront(); // Принести окно Form2 на передний план
            }


            this.Close(); // Закрыть Form1
        }
    }
}
