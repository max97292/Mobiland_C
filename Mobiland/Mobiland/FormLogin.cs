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
        public FormLogin()
        {
            InitializeComponent();
            FillUser();
        }

        private async void FillUser()
        {
            if (Program.connection.State == ConnectionState.Closed)
            {
                Program.connection.Open();
            }
            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Users]", Program.connection))
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
            using (SqlCommand command = new SqlCommand($"SELECT * FROM [Users] WHERE [Username] = '{User}'", Program.connection))
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

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string password = textBoxPassword.Text;
            string user = Convert.ToString(comboBoxUsers.SelectedItem);
            Form FormMain = new FormMain();

            if (!String.IsNullOrEmpty(user) & !String.IsNullOrEmpty(password))
            {
                bool auth = await FillUsers(user, password);
                if (auth == true)
                {
                    textBoxPassword.Text = null;
                    labelUsers.Visible = false;
                    labelPassword.Visible = false;
                    comboBoxUsers.Visible = false;
                    textBoxPassword.Visible = false;
                    buttonLogin.Visible = false;
                    progressBar1.Visible = true;
                    for (int i = 0; i < 100; i++)
                    {
                        progressBar1.Value = i;
                        System.Threading.Thread.Sleep(25);
                        if (progressBar1.Value == 99)
                        {
                            if (user == "Seller")
                            {
                                Program.User = user;
                            }
                            else if (user == "Admin")
                            {
                                Program.User = user;
                            }
                            FormMain.Show();
                            this.Visible = false;
                        }
                    }

                }
                else if (auth == false)
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
    }
}
