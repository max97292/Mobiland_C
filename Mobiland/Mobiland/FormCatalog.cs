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
    public partial class FormCatalog : Form
    {
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\source\repos\Mobiland_C\Mobiland\Mobiland\Mobiland.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Mobiland.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        public FormCatalog()
        {
            InitializeComponent();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                FillTables();
            }
        }

        private async void FillTables()
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Product]", connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    dataGridViewProduct.Rows.Clear();
                    dataGridViewProduct.Refresh();
                    while (await reader.ReadAsync())
                    {
                        int Product_key = reader.GetInt32(0);
                        int Category_key = reader.GetInt32(1);
                        int Manufacturer_key = reader.GetInt32(2);
                        string Product_name = reader.GetString(3);
                        double Price = reader.GetDouble(4);
                        dataGridViewProduct.Rows.Add(Product_key, Category_key, Manufacturer_key, Product_name, Price);
                    }
                }
            }

            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Staff]", connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    dataGridViewStaff.Rows.Clear();
                    dataGridViewStaff.Refresh();
                    while (await reader.ReadAsync())
                    {
                        int Staff_key = reader.GetInt32(0);
                        string Full_name = reader.GetString(1);
                        string Position = reader.GetString(2);
                        dataGridViewStaff.Rows.Add(Staff_key, Full_name, Position);
                    }
                }
            }

            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Manufacturer]", connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    dataGridViewManufacturer.Rows.Clear();
                    dataGridViewManufacturer.Refresh();
                    while (await reader.ReadAsync())
                    {
                        int Manufacturer_key = reader.GetInt32(0);
                        string Product_name = reader.GetString(1);
                        dataGridViewManufacturer.Rows.Add(Manufacturer_key, Product_name);
                    }
                }
            }

            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Receipt]", connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    dataGridViewReceipt.Rows.Clear();
                    dataGridViewReceipt.Refresh();
                    while (await reader.ReadAsync())
                    {
                        int Receipt_key = reader.GetInt32(0);
                        int Staff_key = reader.GetInt32(1);
                        DateTime Date = reader.GetDateTime(2);
                        double Total_amount = reader.GetDouble(3);
                        dataGridViewReceipt.Rows.Add(Receipt_key, Staff_key, Date, Total_amount);
                    }
                }
            }
        }
        public string Status_staff;
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;

            button4.Visible = true;
            button5.Visible = true;

            Status_staff = "Add";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            Status_staff = "Edit";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if(Status_staff == "Add")
            {
                using (SqlCommand command = new SqlCommand($"INSERT INTO [Staff] ([Staff_key],[Full_name],[Position]) VALUES ({textBox1.Text}, {textBox2.Text}, {textBox3.Text})", connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
                FillTables();
            }
            else if (Status_staff == "Edit")
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            textBox1.Visible = false;
            textBox1.Text = null;
            textBox2.Visible = false;
            textBox2.Text = null;
            textBox3.Visible = false;
            textBox3.Text = null;

            button4.Visible = false;
            button5.Visible = false;

            Status_staff = null;
        }
    }
}
