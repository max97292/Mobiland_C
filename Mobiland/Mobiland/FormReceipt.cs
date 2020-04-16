using CrystalDecisions.CrystalReports.Engine;
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
    public partial class FormReceipt : Form
    {
        public FormReceipt()
        {
            InitializeComponent();
            FillTable();
        }

        private async void FillTable()
        {
            int Receipt_key, Staff_key;
            double Total_amount;
            string Product_name, Full_name;
            using (SqlCommand command = new SqlCommand($"SELECT TOP 1 * FROM [Receipt] ORDER BY Receipt_key DESC", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    Receipt_key = reader.GetInt32(0);
                    Total_amount = reader.GetDouble(3);
                    Staff_key = reader.GetInt32(1);
                }
            }

            using (SqlCommand command = new SqlCommand($"SELECT [Full_name] FROM [Staff] WHERE [Staff_key] LIKE '{Staff_key}'", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    Full_name = reader.GetString(0);
                }
            }

            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Sales] WHERE [Receipt_key] LIKE '{Receipt_key}'", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            int Sales_key = reader.GetInt32(0);
                            int Product_key = reader.GetInt32(2);
                            int Amount = reader.GetInt32(3);
                            double Sales_price = reader.GetDouble(4);

                            using (SqlCommand command1 = new SqlCommand($"SELECT [Product_name] FROM [Product] WHERE [Product_key] LIKE '{Product_key}'", Program.connection))
                            {
                                using (SqlDataReader reader1 = await command1.ExecuteReaderAsync())
                                {
                                    await reader1.ReadAsync();
                                    Product_name = reader1.GetString(0);
                                }
                            }

                            double Price = Sales_price / Amount;

                            dataGridView2.Rows.Add(Sales_key, Product_key, Product_name, Price, Amount, Sales_price);
                            labelReceiptNumber.Text = "Чек № " + Convert.ToString(Receipt_key);
                            labelStaff.Text = "Кассир: " + Full_name;
                            labelSales_price.Text = "Сумма по чеку " + Convert.ToString(Total_amount) + " грн.";

                        }
                    }
                    else
                    {
                        buttonDeleteProduct.Visible = false;
                        labelReceiptNumber.Text = "Чек № " + Convert.ToString(Receipt_key);
                        labelStaff.Text = "Кассир: " + Full_name;
                        labelSales_price.Text = "Сумма по чеку " + Convert.ToString(Total_amount) + " грн.";
                    }
                    
                }
            }
        }

        private void FormReceipt_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private async void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            int Receipt_key;
            double Total_amount;
            DataGridViewCell Sales_key_cell = dataGridView2.SelectedCells[0];
            int Sales_key = Convert.ToInt32(Sales_key_cell.Value);
            DataGridViewCell Total_amount_cell = dataGridView2.SelectedCells[5];
            double Total_amount_Cell = Convert.ToDouble(Total_amount_cell.Value);
            using (SqlCommand command1 = new SqlCommand($"DELETE FROM [Sales] WHERE [Sales_key] = '{Sales_key}'", Program.connection))
            {
                await command1.ExecuteNonQueryAsync();
            }

            using (SqlCommand command = new SqlCommand($"SELECT TOP 1 * FROM [Receipt] ORDER BY Receipt_key DESC", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    Receipt_key = reader.GetInt32(0);
                    Total_amount = reader.GetDouble(3);
                }
            }

            Total_amount -= Total_amount_Cell;

            using (SqlCommand command2 = new SqlCommand($"UPDATE [Receipt] SET [Total_amount] = '{Total_amount}'  WHERE [Receipt_key] = '{Receipt_key}'", Program.connection))
            {
                await command2.ExecuteNonQueryAsync();
            }

            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            FillTable();
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete) 
            {
                if(buttonDeleteProduct.Visible == true)
                {
                    buttonDeleteProduct_Click(sender, e);
                }
            }
        }
    }
}
