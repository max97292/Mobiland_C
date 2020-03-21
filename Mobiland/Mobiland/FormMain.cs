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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        
        private void FormMain_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Form FormLogin = new FormLogin();
            FormLogin.Visible = true;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mobilandDataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.mobilandDataSet.Product);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mobilandDataSet.Staff". При необходимости она может быть перемещена или удалена.
            this.staffTableAdapter.Fill(this.mobilandDataSet.Staff);
        }

        private void buttonCreateReceipt_Click(object sender, EventArgs e)
        {
            /*MessageBox.Show(Convert.ToString(comboBoxSelectStaff.SelectedValue));*/
            MessageBox.Show(Convert.ToString(dateTimePicker1.Value));
        }
    }
}
