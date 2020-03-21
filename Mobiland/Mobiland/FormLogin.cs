using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBoxPassword.Text;
            string user = Convert.ToString(comboBoxUsers.SelectedItem);
            Form FormMain = new FormMain();

            if(!String.IsNullOrEmpty(user) & !String.IsNullOrEmpty(password)){
                if(user == "Продавец" & password == "1")
                {
                    /*MessageBox.Show("Добро пожаловать " + user);*/
                    textBoxPassword.Text = null;
                    label1.Visible = false;
                    label2.Visible = false;
                    comboBoxUsers.Visible = false;
                    textBoxPassword.Visible = false;
                    button1.Visible = false;
                    progressBar1.Visible = true;
                    for(int i = 0; i < 100; i++)
                    {
                        progressBar1.Value = i;
                        System.Threading.Thread.Sleep(25);
                        if (progressBar1.Value == 99)
                        {
                            FormMain.Show();
                            this.Visible = false;
                        }
                    }
                }
                else if(user == "Администратор" & password == "2")
                {
                    MessageBox.Show("Добро пожаловать " + user);
                    textBoxPassword.Text = null;

                }
                else
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
