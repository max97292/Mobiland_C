using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobiland
{
    static class Program
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Mobiland_C\Mobiland\Mobiland\Mobiland.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        //public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Mobiland.mdf;Integrated Security=True;MultipleActiveResultSets=True");
        public static string User;
        [STAThread]
        static async Task Main()
        {
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    await connection.OpenAsync();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Application.EnableVisualStyles();
            Application.ApplicationExit += Application_ApplicationExit;
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
