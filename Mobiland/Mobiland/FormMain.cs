using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobiland
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            FillStaff();
        }

        private async void FillProducts()
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Product]",Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    dataGridView2.Rows.Clear();
                    dataGridView2.Refresh();
                    while (await reader.ReadAsync())
                    {
                        int Product_key = reader.GetInt32(0);
                        int Category_key = reader.GetInt32(1);
                        int Manufacturer_key = reader.GetInt32(2);
                        string Product_name = reader.GetString(3);
                        double Price = reader.GetDouble(4);
                        dataGridView2.Rows.Add(Product_key, Category_key, Manufacturer_key, Product_name,Price);
                    }
                }
            }
        }

        private async void FillStaff()
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Staff]", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        string Full_name = reader.GetString(1);
                        comboBoxSelectStaff.Items.Add(Full_name);
                    }
                }
            }
        }

        private async void InsertReceipt(int Staff_key, DateTime Date, float Total_amount)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO [Receipt] ([Staff_key],[Date],[Total_amount]) VALUES ({Staff_key}, @date, {Total_amount})", Program.connection))
            {
                command.Parameters.AddWithValue("@date", Date);
                await command.ExecuteNonQueryAsync();
            }
        }

        private async void InsertSales(string Product_name, int Amount, float Price, DateTime Date)
        {
            int Receipt_key, Product_key;
            double Total_amount;

            using (SqlCommand command1 = new SqlCommand($"SELECT TOP 1 [Receipt_key],[Total_amount] FROM [Receipt] ORDER BY Receipt_key DESC", Program.connection))
            {
                using (SqlDataReader reader1 = await command1.ExecuteReaderAsync())
                {
                    await reader1.ReadAsync();
                    Receipt_key = reader1.GetInt32(0);
                    Total_amount = reader1.GetDouble(1);
                }
            }

            using (SqlCommand command2 = new SqlCommand($"SELECT [Product_key] FROM [Product] WHERE [Product_name] LIKE '{Product_name}'", Program.connection))
            {
                using (SqlDataReader reader2 = await command2.ExecuteReaderAsync())
                {
                    await reader2.ReadAsync();
                    Product_key = reader2.GetInt32(0);
                }
            }

            float Sales_price = Amount * Price;
            Total_amount += Sales_price;

            using (SqlCommand command3 = new SqlCommand($"UPDATE [Receipt] SET [Total_amount] = '{Total_amount}' WHERE [Receipt_key] = '{Receipt_key}'", Program.connection))
            {
                await command3.ExecuteNonQueryAsync();
            }

            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Sales] WHERE [Product_key] LIKE '{Product_key}' AND [Receipt_key] LIKE '{Receipt_key}'", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    if (reader.HasRows)
                    {
                        Amount += reader.GetInt32(3);
                        using (SqlCommand command2 = new SqlCommand($"UPDATE [Sales] SET [Amount] = '{Amount}', [Sales_price] = '{Total_amount}'  WHERE [Receipt_key] = '{Receipt_key}'", Program.connection))
                        {
                            await command2.ExecuteNonQueryAsync();
                        }
                    }
                    else
                    {
                        using (SqlCommand command1 = new SqlCommand($"INSERT INTO [Sales] ([Receipt_key],[Product_key],[Amount],[Sales_price],[Date]) VALUES ({Receipt_key},{Product_key},{Amount},{Sales_price},@date)", Program.connection))
                        {
                            command1.Parameters.AddWithValue("@date", Date);
                            await command1.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
        }

        private async Task<int> SelectStaff(string Value)
        {
            using (SqlCommand command = new SqlCommand($"SELECT [Staff_key] FROM [Staff] WHERE [Full_name] LIKE '{Value}'",Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    int Staff_key = reader.GetInt32(0);
                    return Staff_key;
                }
            }
        }

        private void FormMain_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Form FormLogin = new FormLogin();
            FormLogin.Visible = true;
        }

        private async void buttonCreateReceipt_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(Convert.ToString(comboBoxSelectStaff.SelectedItem)))
            {
                dateTimePicker1.Enabled = false;
                buttonCreateReceipt.Visible = false;
                comboBoxSelectStaff.Enabled = false;
                labelSelectStaff.Visible = false;
                labelSelectDate.Visible = false;

                dataGridView2.Visible = true;
                labelStaff.Visible = true;
                labelDate.Visible = true;
                labelSearch.Visible = true;
                textBoxSearch.Visible = true;
                groupBox1.Visible = true;
                buttonClear.Visible = true;

                int Staff_key = await SelectStaff(Convert.ToString(comboBoxSelectStaff.SelectedItem));
                InsertReceipt(Staff_key, dateTimePicker1.Value.Date, 0);
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
                FillProducts();
            }
            else
            {
                MessageBox.Show("Выберите сотрудника!");
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.connection.State == ConnectionState.Open)
            {
                Program.connection.Close();
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            buttonAddProductToReceipt_Click(sender, e);
        }

        private void buttonAddProductToReceipt_Click(object sender, EventArgs e)
        {
            DataGridViewCell Product_name_cell = dataGridView2.SelectedCells[3];
            string Product_name = Convert.ToString(Product_name_cell.Value);
            DataGridViewCell Price_cell = dataGridView2.SelectedCells[4];
            float Price = Convert.ToSingle(Price_cell.Value);
            int Amount = Convert.ToInt32(numericUpDown1.Value);
            DialogResult dialogResult = MessageBox.Show("Добавить товар в чек?", "Mobiland", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                InsertSales(Product_name, Amount, Price, DateTime.Now);
                numericUpDown1.Value = 1;
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                numericUpDown1.Value = 1;
            }
        }

        private async void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if(textBoxSearch.Text == null)
            {
                FillProducts();
            }
            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Product] WHERE [Product_name] LIKE '%{textBoxSearch.Text}%'", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        dataGridView2.Rows.Clear();
                        dataGridView2.Refresh();
                        while (await reader.ReadAsync())
                        {
                            int Product_key = reader.GetInt32(0);
                            int Category_key = reader.GetInt32(1);
                            int Manufacturer_key = reader.GetInt32(2);
                            string Product_name = reader.GetString(3);
                            double Price = reader.GetDouble(4);
                            dataGridView2.Rows.Add(Product_key, Category_key, Manufacturer_key, Product_name, Price);
                        }
                    }
                    else
                    {
                        using (SqlCommand command1 = new SqlCommand($"SELECT * FROM [Product] WHERE [Product_key] LIKE '{textBoxSearch.Text}%'", Program.connection))
                        {
                            using (SqlDataReader reader1 = await command1.ExecuteReaderAsync())
                            {
                                if (reader1.HasRows)
                                {
                                    dataGridView2.Rows.Clear();
                                    dataGridView2.Refresh();
                                    while (await reader1.ReadAsync())
                                    {
                                        int Product_key = reader1.GetInt32(0);
                                        int Category_key = reader1.GetInt32(1);
                                        int Manufacturer_key = reader1.GetInt32(2);
                                        string Product_name = reader1.GetString(3);
                                        double Price = reader1.GetDouble(4);
                                        dataGridView2.Rows.Add(Product_key, Category_key, Manufacturer_key, Product_name, Price);
                                    }
                                }
                                else
                                {
                                    dataGridView2.Rows.Clear();
                                    dataGridView2.Refresh();
                                }
                            }
                        }
                    }                    
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = null;
        }

        private void buttonShowReceipt_Click(object sender, EventArgs e)
        {
            FormReceipt FormReceipt = new FormReceipt();
            FormReceipt.ShowDialog();
        }

        private void buttonCloseReceipt_Click(object sender, EventArgs e)
        {
            FormReport formReport = new FormReport();
            formReport.Show();

            dateTimePicker1.Enabled = true;
            buttonCreateReceipt.Visible = true;
            comboBoxSelectStaff.Enabled = true;
            labelSelectStaff.Visible = true;
            labelSelectDate.Visible = true;

            dataGridView2.Visible = false;
            labelStaff.Visible = false;
            labelDate.Visible = false;
            labelSearch.Visible = false;
            textBoxSearch.Visible = false;
            groupBox1.Visible = false;
            buttonClear.Visible = false;
        }

        private void toolStripMenuItemCatalog_Click(object sender, EventArgs e)
        {
            FormCatalog FormCatalog = new FormCatalog();
            if (groupBox1.Visible == true)
            {
                DialogResult dialogResult = MessageBox.Show("Текущий чек будет закрыт?", "Mobiland", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    FormCatalog.Show();
                    this.Hide();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    numericUpDown1.Value = 1;
                }
            }
            else
            {
                FormCatalog.Show();
                this.Hide();
            }
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            if (Program.connection.State == ConnectionState.Open)
            {
                Program.connection.Close();
            }

            Application.Exit();
        }
    }
}
