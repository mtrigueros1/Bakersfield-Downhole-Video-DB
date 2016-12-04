using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Globalization;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;


namespace BDHV
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            if (Form1.year == true)
            {
                reporttypelabel.Text = "Yearly";
            }
            if(Form1.week == true)
            {
                reporttypelabel.Text = "Weekly";
            }
            if(Form1.month == true)
            {
                reporttypelabel.Text = "Monthly";
            }
            reportstartdate.Text = Convert.ToString(Form1.week1.ToShortDateString());
            reportenddate.Text = Convert.ToString(Form1.week2.ToShortDateString());
            reportcompincluded.Text = Form1.compselected;
            reporttoday.Text = Convert.ToString(DateTime.Now.ToShortDateString());
            ordernumbertext.Text = Form1.bestordnumselected;
            leastordernumtext.Text = Form1.worstordnumselected;
            totalempincome.Text = Form1.empprofselected;
            totalequipincome.Text = Form1.equipprofselected;
            totalhours.Text = Form1.emphourselected;
            finalincome.Text = Form1.totalprofselected;
            try
            {
                string cmdtxt = "select * from cam_orderview where orderid = " + Form1.bestordnumselected;
                using (OracleConnection conn = new OracleConnection(oradb))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();
                    OracleDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        orderenddatetext.Text = (dr[4].ToString());
                        orderstartdatetext.Text = (dr[3].ToString());
                        totalorderprofittext.Text = "$" + (dr[2].ToString());
                        companynametext.Text = (dr[0].ToString());
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }
            try
            {
                string cmdtxt = "select count(*) from cam_usedon where orderid = " + Form1.bestordnumselected;
                using (OracleConnection conn = new OracleConnection(oradb))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();
                    OracleDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        equipusedtext.Text = (dr[0].ToString());
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }
            try
            {
                string cmdtxt = "select * from cam_orderview where orderid = " + Form1.worstordnumselected;
                using (OracleConnection conn = new OracleConnection(oradb))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();
                    OracleDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        leastorderenddate.Text = (dr[4].ToString());
                        leastorderstartdate.Text = (dr[3].ToString());
                        leastorderprofit.Text = "$" + (dr[2].ToString());
                        leastordercompany.Text = (dr[0].ToString());
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }
            try
            {
                string cmdtxt = "select count(*) from cam_usedon where orderid = " + Form1.worstordnumselected;
                using (OracleConnection conn = new OracleConnection(oradb))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();
                    OracleDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                       leastorderequip.Text = (dr[0].ToString());
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.doc_PrintPage;

            PrintDialog dlg = new PrintDialog();
            dlg.Document = doc;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            e.Graphics.DrawImage((Image)bmp, 50, 50);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
