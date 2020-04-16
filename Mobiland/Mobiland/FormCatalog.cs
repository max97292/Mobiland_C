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
        public FormCatalog()
        {
            InitializeComponent();
            FillTables();
        }

        private async void FillTables()
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Product]", Program.connection))
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

            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Staff]", Program.connection))
            {
                List<string> Positions = new List<string>();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    dataGridViewStaff.Rows.Clear();
                    dataGridViewStaff.Refresh();
                    comboBoxPosition.Items.Clear();
                    while (await reader.ReadAsync())
                    {
                        int Staff_key = reader.GetInt32(0);
                        string Full_name = reader.GetString(1);
                        string Position = reader.GetString(2);
                        dataGridViewStaff.Rows.Add(Staff_key, Full_name, Position);
                        Positions.Add(Position);
                    }
                    var unique_list = new HashSet<string>(Positions);
                    foreach (string s in unique_list)
                    {
                        comboBoxPosition.Items.Add(s);
                    }
                }
            }

            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Manufacturer]", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    comboBoxManufacturerKey.Items.Clear();
                    dataGridViewManufacturer.Rows.Clear();
                    dataGridViewManufacturer.Refresh();
                    while (await reader.ReadAsync())
                    {
                        int Manufacturer_key = reader.GetInt32(0);
                        string Product_name = reader.GetString(1);
                        dataGridViewManufacturer.Rows.Add(Manufacturer_key, Product_name);
                        comboBoxManufacturerKey.Items.Add(Manufacturer_key);
                    }
                }
            }

            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Category]", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    comboBoxCategoryKey.Items.Clear();
                    while (await reader.ReadAsync())
                    {
                        int Category_key = reader.GetInt32(0);
                        comboBoxCategoryKey.Items.Add(Category_key);
                    }
                }
            }

            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Receipt]", Program.connection))
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
        private void FormCatalog_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain FormMain = new FormMain();
            FormMain.Show();
        }

        private void FormCatalog_Load(object sender, EventArgs e)
        {
            if(Program.User == "Admin")
            {
                panelProduct.Visible = true;
                panelStaff.Visible = true;
            }
        }

        public string Status_product;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0 && Status_staff != null)
            {
                DialogResult dialogResult = MessageBox.Show("Сохранить изменения во вкладке Персонал?", "Mobiland", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    buttonOkStaff_Click(sender, e);
                }
                else if (dialogResult == DialogResult.No)
                {
                    buttonCancelStaff_Click(sender, e);
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    tabControl1.SelectedIndex = 1;
                }
            }
            if (tabControl1.SelectedIndex == 1 && Status_product != null)
            {
                DialogResult dialogResult = MessageBox.Show("Сохранить изменения во вкладке Товары?", "Mobiland", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    buttonOkProduct_Click(sender, e); 
                }
                else if (dialogResult == DialogResult.No)
                {
                    buttonCancelProduct_Click(sender, e);
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    tabControl1.SelectedIndex = 0;
                }
            }
        }

        private void buttonAddStaff_Click(object sender, EventArgs e)
        {
            labelFullName.Visible = true;
            labelPosition.Visible = true;
            labelStaffKey.Visible = false;

            textBoxFullName.Visible = true;
            textBoxFullName.Text = null;
            textBoxStaffKey.Visible = false;


            comboBoxPosition.Visible = true;
            comboBoxPosition.Enabled = true;
            comboBoxPosition.SelectedIndex = -1;

            buttonOkStaff.Visible = true;
            buttonCancelStaff.Visible = true;

            Status_staff = "Add";
        }

        private async void buttonEditStaff_Click(object sender, EventArgs e)
        {
            buttonAddStaff_Click(sender, e);
            labelStaffKey.Visible = true;
            textBoxStaffKey.Visible = true;
            comboBoxPosition.Enabled = false;
            Status_staff = "Edit";

            DataGridViewCell Staff_key_cell = dataGridViewStaff.SelectedCells[0];
            int Staff_key = Convert.ToInt32(Staff_key_cell.Value);

            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Staff] WHERE [Staff_key] LIKE '{Staff_key}'", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    string Full_name = reader.GetString(1);
                    string Position = reader.GetString(2);
                    textBoxStaffKey.Text = Convert.ToString(Staff_key);
                    textBoxFullName.Text = Full_name;
                    comboBoxPosition.Text = Position;
                }
            }
        }

        private async void buttonDeleteStaff_Click(object sender, EventArgs e)
        {
            DataGridViewCell Staff_key_cell = dataGridViewStaff.SelectedCells[0];
            int Staff_key = Convert.ToInt32(Staff_key_cell.Value);

            using (SqlCommand command1 = new SqlCommand($"DELETE FROM [Staff] WHERE [Staff_key] = '{Staff_key}'", Program.connection))
            {
                await command1.ExecuteNonQueryAsync();
            }

            labelStaffKey.Visible = false;
            labelFullName.Visible = false;
            labelPosition.Visible = false;

            textBoxStaffKey.Visible = false;
            textBoxFullName.Visible = false;
            comboBoxPosition.Visible = false;

            buttonOkStaff.Visible = false;
            buttonCancelStaff.Visible = false;

            Status_staff = null;

            FillTables();
        }

        private async void buttonOkStaff_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxFullName.Text) & !String.IsNullOrEmpty(Convert.ToString(comboBoxPosition.SelectedItem)))
            {
                if (Status_staff == "Add")
                {
                    using (SqlCommand command = new SqlCommand($"INSERT INTO [Staff] ([Full_name],[Position]) VALUES (@Full_name, @Position)", Program.connection))
                    {
                        command.Parameters.AddWithValue("Full_name", textBoxFullName.Text);
                        command.Parameters.AddWithValue("Position", Convert.ToString(comboBoxPosition.SelectedItem));
                        await command.ExecuteNonQueryAsync();
                    }
                }
                else if (Status_staff == "Edit")
                {
                    using (SqlCommand command2 = new SqlCommand($"UPDATE [Staff] SET [Full_name] = '{textBoxFullName.Text}' WHERE [Staff_key] = '{textBoxStaffKey.Text}'", Program.connection))
                    {
                        await command2.ExecuteNonQueryAsync();
                    }
                }
                FillTables();
                buttonCancelStaff_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Не все данные были введены!");
                tabControl1.SelectedIndex = 1;
            }
        }

        private void buttonCancelStaff_Click(object sender, EventArgs e)
        {
            labelStaffKey.Visible = false;
            labelFullName.Visible = false;
            labelPosition.Visible = false;

            textBoxStaffKey.Visible = false;
            textBoxStaffKey.Text = null;
            textBoxFullName.Visible = false;
            textBoxFullName.Text = null;

            comboBoxPosition.Visible = false;
            comboBoxPosition.SelectedIndex = -1;

            buttonOkStaff.Visible = false;
            buttonCancelStaff.Visible = false;

            Status_staff = null;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            labelCategoryKey.Visible = true;
            labelManufacturerKey.Visible = true;
            labelProductName.Visible = true;
            labelPrice.Visible = true;
            labelProductKey.Visible = false;

            comboBoxCategoryKey.Visible = true;
            comboBoxManufacturerKey.Visible = true;
            comboBoxCategoryKey.SelectedIndex = -1;
            comboBoxManufacturerKey.SelectedIndex = -1;

            textBoxProductName.Visible = true;
            textBoxPrice.Visible = true;
            textBoxProductKey.Visible = false;
            textBoxProductName.Text = null;
            textBoxPrice.Text = null;

            buttonCancelProduct.Visible = true;
            buttonOkProduct.Visible = true;

            Status_product = "Add";
        }

        private async void buttonEditProduct_Click(object sender, EventArgs e)
        {
            buttonAddProduct_Click(sender, e);
            labelProductKey.Visible = true;
            textBoxProductKey.Visible = true;
            comboBoxCategoryKey.Enabled = false;
            comboBoxManufacturerKey.Enabled = false;
            Status_product = "Edit";

            DataGridViewCell Product_key_cell = dataGridViewProduct.SelectedCells[0];
            int Product_key = Convert.ToInt32(Product_key_cell.Value);

            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Product] WHERE [Product_key] LIKE '{Product_key}'", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    int Category_key = reader.GetInt32(1);
                    int Manufacturer_key = reader.GetInt32(2);
                    string Product_name = reader.GetString(3);
                    double Price = reader.GetDouble(4);
                    textBoxProductKey.Text = Convert.ToString(Product_key);
                    comboBoxCategoryKey.Text = Convert.ToString(Category_key);
                    comboBoxManufacturerKey.Text = Convert.ToString(Manufacturer_key);
                    textBoxProductName.Text = Product_name;
                    textBoxPrice.Text = Convert.ToString(Price);
                }
            }
        }

        private async void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            DataGridViewCell Product_key_cell = dataGridViewProduct.SelectedCells[0];
            int Product_key = Convert.ToInt32(Product_key_cell.Value);

            using (SqlCommand command1 = new SqlCommand($"DELETE FROM [Product] WHERE [Product_key] = '{Product_key}'", Program.connection))
            {
                await command1.ExecuteNonQueryAsync();
            }

            labelCategoryKey.Visible = false;
            labelManufacturerKey.Visible = false;
            labelProductName.Visible = false;
            labelPrice.Visible = false;
            labelProductKey.Visible = false;

            comboBoxCategoryKey.Visible = false;
            comboBoxManufacturerKey.Visible = false;

            textBoxProductName.Visible = false;
            textBoxPrice.Visible = false;
            textBoxProductKey.Visible = false;

            buttonCancelProduct.Visible = false;
            buttonOkProduct.Visible = false;

            Status_product = null;

            FillTables();
        }

        private async void buttonOkProduct_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxProductName.Text) & !String.IsNullOrEmpty(textBoxPrice.Text) & !String.IsNullOrEmpty(Convert.ToString(comboBoxCategoryKey.SelectedItem)) & !String.IsNullOrEmpty(Convert.ToString(comboBoxManufacturerKey.SelectedItem)))
            {
                if (Status_product == "Add")
                {
                    using (SqlCommand command = new SqlCommand($"INSERT INTO [Product] ([Category_key],[Manufacturer_key],[Product_name],[Price]) VALUES ({comboBoxCategoryKey.SelectedItem},{comboBoxManufacturerKey.SelectedItem},@Product_name,{textBoxPrice.Text})", Program.connection))
                    {
                        command.Parameters.AddWithValue("Product_name", textBoxProductName.Text);
                        await command.ExecuteNonQueryAsync();
                    }
                }
                else if (Status_product == "Edit")
                {
                    using (SqlCommand command2 = new SqlCommand($"UPDATE [Product] SET [Product_name] = '{textBoxProductName.Text}', [Price] = '{textBoxPrice.Text}' WHERE [Product_key] = '{textBoxProductKey.Text}'", Program.connection))
                    {
                        await command2.ExecuteNonQueryAsync();
                    }
                }
                FillTables();
                buttonCancelProduct_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Не все данные были введены!");
                tabControl1.SelectedIndex = 0;
            }
        }

        private void buttonCancelProduct_Click(object sender, EventArgs e)
        {
            labelCategoryKey.Visible = false;
            labelManufacturerKey.Visible = false;
            labelProductName.Visible = false;
            labelPrice.Visible = false;
            labelProductKey.Visible = false;

            comboBoxCategoryKey.Visible = false;
            comboBoxManufacturerKey.Visible = false;
            comboBoxCategoryKey.SelectedIndex = -1;
            comboBoxManufacturerKey.SelectedIndex = -1;

            textBoxProductName.Visible = false;
            textBoxPrice.Visible = false;
            textBoxProductKey.Visible = false;
            textBoxProductName.Text = null;
            textBoxPrice.Text = null;

            buttonCancelProduct.Visible = false;
            buttonOkProduct.Visible = false;

            Status_product = null;
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
