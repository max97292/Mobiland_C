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
    public partial class FormLogin : Form
    {
        public string User;
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\source\repos\Mobiland_C\Mobiland\Mobiland\Mobiland.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Mobiland.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        public FormLogin()
        {
            InitializeComponent();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                FillUser();
                User = null;
            }
        }

        private async void FillUser()
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Users]", connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        comboBoxUsers.Items.Add(reader.GetString(1));
                    }
                }
            }
        }
        private async Task<bool> FillUsers(string User, string Pass)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Users] WHERE [Username] = '{User}'", connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    {
                        await reader.ReadAsync();
                        string Username = reader.GetString(1);
                        string Password = reader.GetString(2);
                        if(Username == User & Password == Pass)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string password = textBoxPassword.Text;
            string user = Convert.ToString(comboBoxUsers.SelectedItem);
            Form FormMain = new FormMain();

            if (!String.IsNullOrEmpty(user) & !String.IsNullOrEmpty(password))
            {
                bool auth = await FillUsers(user, password);
                if (user == "Seller" & auth == true)
                {
                    textBoxPassword.Text = null;
                    label1.Visible = false;
                    label2.Visible = false;
                    comboBoxUsers.Visible = false;
                    textBoxPassword.Visible = false;
                    button1.Visible = false;
                    progressBar1.Visible = true;
                    for (int i = 0; i < 100; i++)
                    {
                        progressBar1.Value = i;
                        System.Threading.Thread.Sleep(25);
                        if (progressBar1.Value == 99)
                        {
                            FormMain.Show();
                            this.Visible = false;
                            User = user;
                        }
                    }
                }
                else if (user == "Admin" & auth == true)
                {
                    MessageBox.Show("Добро пожаловать " + user);
                    textBoxPassword.Text = null;

                }
                else if(auth == false)
                {
                    MessageBox.Show("Введен не верный пароль, попробуйте еще раз!");
                    textBoxPassword.Text = null;
                }
            }
            else
            {
                if (String.IsNullOrEmpty(user))
                {
                    MessageBox.Show("Проверьте имя пользователя");
                }
                else if (String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Проверьте пароль");
                }
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
