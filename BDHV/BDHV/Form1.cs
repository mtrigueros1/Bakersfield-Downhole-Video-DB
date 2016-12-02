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
        string[] compname = new string[100];
        int numofboxes = 0;
        DateTime week1 = DateTime.MinValue;
        DateTime week2 = DateTime.MinValue;
        string startcal;
        string endcal;
        string day1, day2, month1, month2, year1, year2;
        public Form1()
        {
            InitializeComponent();
            Fill_employees();
            get_emps.SelectedIndex = 0;
            get_orders.Items.Add("Order Number");
            get_orders.SelectedIndex = 0;
            complist.Items.Add("All Companys");
            complist.SelectedIndex = 0;
            Fill_companys();
            getorders.Items.Add("All Orders");
            getorders.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
        private void Fill_companys()
        {
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string cmdtxt = "select cName from CAM_COMPANY";
            using (OracleConnection conn = new OracleConnection(oradb))
            using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
            {
                conn.Open();
                OracleDataReader dr;
                dr = cmd.ExecuteReader();
                int i = 1;
                while (dr.Read())
                {
                    complist.Items.Add(dr[0].ToString());
                    compname[i] = Convert.ToString(dr[0].ToString());
                    Console.WriteLine(compname[i]);
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
        private void complist_SelectedIndexChanged(object sender, EventArgs e)
        {
            getorders.Items.Clear();
            getorders.Items.Add("All Orders");
            getorders.SelectedIndex = 0;
            int selectedcomp = complist.SelectedIndex;
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string cmdtxt = "select OrderID from CAM_MAKES where cName = '" + Convert.ToString(compname[selectedcomp]) + "'";
            try
            {
                using (OracleConnection conn = new OracleConnection(oradb))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();
                    OracleDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        getorders.Items.Add(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
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

        private void getstartdate_DateChanged(object sender, DateRangeEventArgs e)
        {
            startcal = getstartdate.SelectionRange.Start.ToShortDateString();
            DateTime begdate = Convert.ToDateTime(startcal);
            day1 = begdate.Day.ToString();
            month1 = begdate.Month.ToString();
            year1 = begdate.Year.ToString();
        }

        private void getenddate_DateChanged(object sender, DateRangeEventArgs e)
        {
            endcal = getstartdate.SelectionRange.Start.ToShortDateString();
            DateTime enddate = Convert.ToDateTime(endcal);
            day2 = enddate.Day.ToString();
            month2 = enddate.Month.ToString();
            year2 = enddate.Year.ToString();
        }

        private void getorders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getorders.SelectedIndex != 0)
            {
                label17.Show();
                equipname.Show();
                label27.Show();
                equipmentid.Show();
            } else
            {
                label17.Hide();
                equipname.Hide();
                label27.Hide();
                equipmentid.Hide();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string s = month1 + "-" + day1 + "-" + year1;
            Console.WriteLine(s);
            int correct = 0;
            DateTime dt;
            if (!DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                correct += 0;
                Console.WriteLine("Date 1 wrong!");
                MessageBox.Show("Incorrect Start Date!");
            }
            else
            {
                week1 = dt;
                s = day1 + "-" + month1 + "-" + year1;
                correct += 1;
            }

            string s2 = month2 + "-" + day2 + "-" + year2;
            DateTime dt2;
            if (!DateTime.TryParse(s2, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt2))
            {
                correct += 0;
                Console.WriteLine("Date 2 wrong!");
                MessageBox.Show("Incorrect End Date!");
            }
            else
            {
                week2 = dt2;
                s2 = day2 + "-" + month2 + "-" + year2;
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
                    if (complist.SelectedIndex == 0)
                    {
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
                    } else
                    {
                        string comname = Convert.ToString(complist.SelectedItem);
                        cmd.CommandText = "CAM_SumHoursSpecific";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("hrsum", OracleDbType.Decimal);
                        cmd.Parameters["hrsum"].Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add("start_date", s);
                        cmd.Parameters.Add("end_date", s2);
                        cmd.Parameters.Add("compname", comname);
                        cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                        cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                        cmd.Parameters["compname"].Direction = ParameterDirection.Input;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Connection succesful!");
                        Console.WriteLine(cmd.Parameters["hrsum"].Value);
                        var rt = cmd.Parameters["hrsum"].Value;
                        sumprofit = Convert.ToString(rt);
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}", ex.Message);
                }

                empprofit.Text = "$" + sumprofit;

                try
                {
                    OracleConnection conn = new OracleConnection(oradb);
                    var cmd = new OracleCommand();
                    cmd.Connection = conn;
                    if (complist.SelectedIndex == 0)
                    {
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

                        
                    } else
                    {
                        string comname = Convert.ToString(complist.SelectedItem);
                        cmd.CommandText = "CAM_TotalHoursSpecific";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("hrsum", OracleDbType.Decimal);
                        cmd.Parameters["hrsum"].Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add("start_date", s);
                        cmd.Parameters.Add("end_date", s2);
                        cmd.Parameters.Add("compname", comname);
                        cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                        cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                        cmd.Parameters["compname"].Direction = ParameterDirection.Input;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Connection succesful!");
                        Console.WriteLine(cmd.Parameters["hrsum"].Value);
                        var rt = cmd.Parameters["hrsum"].Value;
                        sumhours = Convert.ToString(rt);
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}", ex.Message);
                }
                emphours.Text = sumhours + " hrs";

            } else {
                Console.WriteLine("Test was less than 2!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int weeks = Convert.ToInt32((week2 - week1).TotalDays / 7);
            int numofboxes = weeks;
            Form2 frm = new Form2(numofboxes);
            frm.Show();
        }

        private void getstartdate_DateSelected(object sender, DateRangeEventArgs e)
        {
            startcal = getstartdate.SelectionRange.Start.ToShortDateString();
            DateTime begdate = Convert.ToDateTime(startcal);
            Console.WriteLine(begdate);
            day1 = begdate.Day.ToString();
            month1 = begdate.Month.ToString();
            year1 = begdate.Year.ToString();
        }

        private void getenddate_DateSelected(object sender, DateRangeEventArgs e)
        {
            endcal = getenddate.SelectionRange.Start.ToShortDateString();
            DateTime enddate = Convert.ToDateTime(endcal);
            Console.WriteLine(enddate);
            day2 = enddate.Day.ToString();
            month2 = enddate.Month.ToString();
            year2 = enddate.Year.ToString();
        }
    }
}
