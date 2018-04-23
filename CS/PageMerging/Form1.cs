using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace PageMerging {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            MainReport report = new MainReport();
            DataSet1 ds = new DataSet1();
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 50; i++)
            {
                int OrderID = rnd.Next(100);
                int ProductID = rnd.Next(50);
                if (ds.Order_Details.FindByOrderIDProductID(OrderID, ProductID) == null)
                    ds.Order_Details.AddOrder_DetailsRow(OrderID, ProductID, (decimal)Math.Round(rnd.NextDouble()*50, 2), 5, 0.0f);
            }
            report.DataSource = ds;
            report.AfterPrint += new EventHandler(report_AfterPrint);
            report.ShowPreview();            
        }

        void report_AfterPrint(object sender, EventArgs e) {
            AdditionalReport add = new AdditionalReport();
            add.CreateDocument();
            ((MainReport)sender).Pages.AddRange(add.Pages);
        }
    }
}