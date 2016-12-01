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
        int[] EmpID = new int[100];
        public Form1()
        {
            InitializeComponent();
            Add_Date();
            dd1_day.SelectedIndex = 0;
            dd1_day2.SelectedIndex = 0;
            Add_Month();
            dd1_month.SelectedIndex = 0;
            dd1_month2.SelectedIndex = 0;
            Fill_employees();
            get_emps.SelectedIndex = 0;
            get_orders.Items.Add("Order Number");
            get_orders.SelectedIndex = 0;

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
        private void Fill_employees()
        {
            get_emps.Items.Add("Employee Name");
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string cmdtxt = "select EmpName, EmpSSN from CAM_EMPLOYEE";
            using (OracleConnection conn = new OracleConnection(oradb))
            using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
            {
                conn.Open();
                OracleDataReader dr;
                dr = cmd.ExecuteReader();
                int i = 1;
                while (dr.Read())
                {
                    get_emps.Items.Add(dr[0].ToString());
                    EmpID[i] = Convert.ToInt32(dr[1].ToString());
                    Console.WriteLine(EmpID[i]);
                    i++;
                }
            }

        }

        private void get_emps_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_orders.Items.Clear();
            get_orders.Items.Add("Order Number");
            get_orders.SelectedIndex = 0;
            int selectedemp = get_emps.SelectedIndex;
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string cmdtxt = "select unique OrderID from CAM_WORKSON where EmpSSN = " + EmpID[selectedemp];
            using (OracleConnection conn = new OracleConnection(oradb))
            using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
            {
                conn.Open();
                OracleDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    get_orders.Items.Add(dr[0].ToString());
                }
            }
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int selectedemp = get_emps.SelectedIndex;
            Console.WriteLine("Order Selected:" + get_orders.SelectedItem);
            Console.WriteLine("Employee Selected:" + EmpID[selectedemp]);
            Console.WriteLine("Days To Add:" + hours_to_add.Text);
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            //----------------------Sums Hours Before update---------------------------//
            try
            {
                OracleConnection conn = new OracleConnection(oradb);
                var cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CAM_SpecificHours";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("hrsum", OracleDbType.Decimal);
                cmd.Parameters["hrsum"].Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("empid", Convert.ToString(EmpID[selectedemp]));
                cmd.Parameters.Add("ordernum", Convert.ToString(get_orders.SelectedItem));
                cmd.Parameters["empid"].Direction = ParameterDirection.Input;
                cmd.Parameters["ordernum"].Direction = ParameterDirection.Input;
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Connection succesful!");
                Console.WriteLine(cmd.Parameters["hrsum"].Value);
                var rt = cmd.Parameters["hrsum"].Value;
                oldhours.Text = Convert.ToString(rt);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }

            //--------------------Updates End Date-------------------------------------//
            try
            {
                string cmdtxt = null;
                if (Convert.ToInt32(hours_to_add.Text) < 24)
            {
                cmdtxt = "update CAM_WORKSON SET hours = hours + " + Convert.ToString(hours_to_add.Text) + " WHERE EmpSSN = " + EmpID[selectedemp] + " AND OrderID = " + Convert.ToString(get_orders.SelectedItem);
            } else
            {
                cmdtxt = "update CAM_WORKSON SET hours = hours + " + Convert.ToString(hours_to_add.Text) + ", eDate = eDate + " + (Convert.ToInt32(hours_to_add.Text) / 24) + 
                                " WHERE EmpSSN = " + EmpID[selectedemp] + " AND OrderID = " + Convert.ToString(get_orders.SelectedItem);
            }
            
                using (OracleConnection conn = new OracleConnection(oradb))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }
            //----------------------Sums Hours After update---------------------------//
            try
            {
                OracleConnection conn = new OracleConnection(oradb);
                var cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CAM_SpecificHours";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("hrsum", OracleDbType.Decimal);
                cmd.Parameters["hrsum"].Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("empid", Convert.ToString(EmpID[selectedemp]));
                cmd.Parameters.Add("ordernum", Convert.ToString(get_orders.SelectedItem));
                cmd.Parameters["empid"].Direction = ParameterDirection.Input;
                cmd.Parameters["ordernum"].Direction = ParameterDirection.Input;
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Connection succesful!");
                Console.WriteLine(cmd.Parameters["hrsum"].Value);
                var rt = cmd.Parameters["hrsum"].Value;
                newhours.Text = Convert.ToString(rt);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string s = dd1_month.SelectedIndex + "-" + dd1_day.SelectedIndex + "-" + dd1_year1.Text;
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
                s = dd1_day.SelectedIndex + "-" + dd1_month.SelectedIndex + "-" + dd1_year1.Text;
                correct += 1;
            }

            string s2 = dd1_month2.SelectedIndex + "-" + dd1_day2.SelectedIndex + "-" + dd1_year2.Text;
            DateTime dt2;
            if (!DateTime.TryParse(s2, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt2))
            {
                correct += 0;
                Console.WriteLine("Date 2 wrong!");
            }
            else
            {
                s2 = dd1_day2.SelectedIndex + "-" + dd1_month2.SelectedIndex + "-" + dd1_year2.Text;
                correct += 1;
            }
            if (correct == 2)
            {

                string sumprofit = null;
                string sumhours = null;

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
                    sumprofit = Convert.ToString(rt);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}", ex.Message);
                }

                label5.Text = "$" + sumprofit;

                try
                {
                    OracleConnection conn = new OracleConnection(oradb);
                    var cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CAM_TotalHours";
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
                    sumhours = Convert.ToString(rt);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}", ex.Message);
                }
                label6.Text = sumhours + " hrs";

            } else {
                Console.WriteLine("Test was less than 2!");
            }
        }

       
    }
}
