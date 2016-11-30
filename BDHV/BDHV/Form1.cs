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

namespace BDHV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Add_Date();
            dd1_day.SelectedIndex = 0;
            dd1_day2.SelectedIndex = 0;
            Add_Month();
            dd1_month.SelectedIndex = 0;
            dd1_month2.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void Add_Date()
        {
            dd1_day.Items.Add("Day");
            dd1_day2.Items.Add("Day");

            for (int j = 0; j < 31; j++)
            {
                var newOption = Convert.ToString(j + 1);
                dd1_day.Items.Add(newOption);
                dd1_day2.Items.Add(newOption);
            }
        }
        private void Add_Month()
        {
            dd1_month.Items.Add("Month");
            dd1_month2.Items.Add("Month");

            for (int j = 0; j < 12; j++)
            {
                var newOption = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(j + 1);
                dd1_month.Items.Add(newOption);
                dd1_month2.Items.Add(newOption);

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string s = dd1_month.SelectedIndex + "-" + dd1_day.SelectedIndex + "-" + year1.Text;
            Console.WriteLine(s);
            int correct = 0;
            DateTime dt;
            if (!DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                correct += 0;
                Console.WriteLine("Date 1 wrong!");
            }
            else
            {
                s = dd1_day.SelectedIndex + "-" + dd1_month.SelectedIndex + "-" + year1.Text;
                correct += 1;
            }

            string s2 = dd1_month2.SelectedIndex + "-" + dd1_day2.SelectedIndex + "-" + year2.Text;
            DateTime dt2;
            if (!DateTime.TryParse(s2, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt2))
            {
                correct += 0;
                Console.WriteLine("Date 2 wrong!");
            }
            else
            {
                s2 = dd1_day2.SelectedIndex + "-" + dd1_month2.SelectedIndex + "-" + year2.Text;
                correct += 1;
            }
            if (correct == 2)
            {

                string test = null;

                try
                {
                    OracleConnection conn = new OracleConnection(oradb);
                    var cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CAM_SumHours";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("hrsum", OracleDbType.Decimal);
                    cmd.Parameters["hrsum"].Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add("start_date", s);
                    cmd.Parameters.Add("end_date", s2);
                    cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                    cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Connection succesful!");
                    Console.WriteLine(cmd.Parameters["hrsum"].Value);
                    var rt = cmd.Parameters["hrsum"].Value;
                    test = Convert.ToString(rt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}", ex.Message);
                }
                label1.Text = test;
            } else {
                Console.WriteLine("Test was less than 2!");
            }
        }
    }
}
