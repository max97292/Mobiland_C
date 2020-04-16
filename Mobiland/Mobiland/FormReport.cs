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
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private async void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private async void FormReport_Load(object sender, EventArgs e)
        {
            int Receipt_key;
            using (SqlCommand command = new SqlCommand($"SELECT TOP 1 * FROM [Receipt] ORDER BY Receipt_key DESC", Program.connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    await reader.ReadAsync();
                    Receipt_key = reader.GetInt32(0);
                }
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT [Receipt].[Receipt_key], [Receipt].[Staff_key], [Receipt].[Date], [Receipt].[Total_amount], [Sales].[Sales_key], [Sales].[Product_key], [Sales].[Amount], [Sales].[Sales_price], [Staff].[Full_name], [Product].[Product_name], [Product].[Price] FROM [Receipt],[Sales],[Staff],[Product] WHERE ([Receipt].[Receipt_key] LIKE '{Receipt_key}') AND ([Staff].[Staff_key] = [Receipt].[Staff_key]) AND ([Product].[Product_key] = [Sales].[Product_key]) AND ([Sales].Receipt_key LIKE '{Receipt_key}')", Program.connection);
            DataSet1 dataSet = new DataSet1();
            dataAdapter.Fill(dataSet, "DataTable1");
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load("CrystalReport1.rpt");
            reportDocument.SetDataSource(dataSet);
            crystalReportViewer1.ReportSource = reportDocument;
        }
    }
}
