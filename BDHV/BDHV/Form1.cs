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
        int[] OrderID = new int[100];
        string[] compname = new string[100];
        string[] equipnames = new string[100];
        string[] equipids = new string[100];
        int[] get_orders_equipids = new int[100];
        public static DateTime week1 = DateTime.MinValue;
        public static DateTime week2 = DateTime.MinValue;
        string endcal;
        public static string day1, day2, month1, month2, year1, year2;
        public static bool year, month, week;
        public static string compselected, bestordnumselected, worstordnumselected, empprofselected, emphourselected, equipprofselected, totalprofselected, s, s2;
        public static DataTable pls = new DataTable();
        public static string equipsel, equipselid;
        public Form1()
        {
            InitializeComponent();
            Fill_orders();
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

        private void Fill_orders()
        {
            get_orders.Items.Add("Order Number");
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string cmdtxt = "select unique OrderID from CAM_WORKSON";
            try
            {
                using (OracleConnection conn = new OracleConnection(oradb))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();
                    OracleDataReader dr;
                    dr = cmd.ExecuteReader();
                    int i = 1;
                    while (dr.Read())
                    {
                        get_orders.Items.Add(dr[0].ToString());
                        OrderID[i] = Convert.ToInt32(dr[0].ToString());
                        Console.WriteLine(OrderID[i]);
                        i++;
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
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
           /* get_orders.Items.Clear();
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
            }*/
            
        }

        private void showorders_Click(object sender, EventArgs e)
        {
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string cmdtxt = "select * from cam_orderview";
            Console.WriteLine(cmdtxt);
            try
            {
                using (OracleConnection conn = new OracleConnection(oradb))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();
                    DataTable dataTable = new DataTable();
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        
                        dataTable.Load(dr);
                        dataGridView1.DataSource = dataTable;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    }
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    pls = dataTable;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }
            dataGridView1.Show();
        }

        private void complist_SelectedIndexChanged(object sender, EventArgs e)
        {
            empprofit.Text = string.Empty;
            emphours.Text = string.Empty;
            equipprofit.Text = string.Empty;
            overallprofit.Text = string.Empty;
            if(complist.SelectedIndex == 0)
            {
                mostorderlabel.Show();
                mostorderbox.Show();
                leastorderlabel.Show();
                leastorderbox.Show();
                mosthourslabel.Show();
                mosthoursbox.Show();
                leasthourslabel.Show();
                leasthoursbox.Show();
            } else {
                mostorderlabel.Hide();
                mostorderbox.Hide();
                mostorderbox.Text = string.Empty;
                leastorderlabel.Hide();
                leastorderbox.Hide();
                leastorderbox.Text = string.Empty;
                mosthourslabel.Hide();
                mosthoursbox.Hide();
                mostorderbox.Text = string.Empty;
                leasthourslabel.Hide();
                leasthoursbox.Hide();
                leasthoursbox.Text = string.Empty;
            }
            getorders.Items.Clear();
            getorders.Items.Add("All Orders");
            getorders.SelectedIndex = 0;
            int selectedcomp = complist.SelectedIndex;
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string cmdtxt = "select OrderID from CAM_MAKES where cName = '" + Convert.ToString(compname[selectedcomp]) + "'";
            Console.WriteLine(cmdtxt);
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

        private void get_orders_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_emps.Items.Clear();
            get_emps.Items.Add("All Employees");
            get_emps.SelectedIndex = 0;
            get_equip.Items.Clear();
            get_equip.Items.Add("All Equipment");
            get_equip.SelectedIndex = 0;
            int selectedorder = get_orders.SelectedIndex;
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string cmdtxt = "select EmpSSN, EmpName from CAM_EMPLOYEE where EmpSSN IN (" 
                             + "select unique EmpSSN from CAM_WORKSON where OrderID = " + OrderID[selectedorder] + ")";
            string cmdtxt2 = "select EquipID, EquipType from CAM_EQUIPMENT where EquipID IN ("
                             + "select unique EquipID from CAM_USEDON where OrderID = " + OrderID[selectedorder] + ")";
            using (OracleConnection conn = new OracleConnection(oradb))
            using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
            {
                conn.Open();
                OracleDataReader dr;
                int i = 1;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    get_emps.Items.Add(dr[1].ToString());
                    EmpID[i] = Convert.ToInt32(dr[0].ToString());
                    i++;

                }
            }
            using (OracleConnection conn = new OracleConnection(oradb))
            using (OracleCommand cmd = new OracleCommand(cmdtxt2, conn))
            {
                conn.Open();
                OracleDataReader dr;
                int i = 1;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    get_equip.Items.Add(dr[1].ToString());
                    get_orders_equipids[i] = Convert.ToInt32(dr[0].ToString());
                    i++;

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
                if ((get_equip.SelectedIndex == 0 && get_emps.SelectedIndex == 0) || (get_equip.SelectedIndex != 0 && get_emps.SelectedIndex == 0))
                {
                    OracleConnection conn = new OracleConnection(oradb);
                    var cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CAM_NonSpecificHours";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("hrsum", OracleDbType.Decimal);
                    cmd.Parameters["hrsum"].Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add("ordernum", Convert.ToString(get_orders.SelectedItem));
                    cmd.Parameters["ordernum"].Direction = ParameterDirection.Input;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Connection succesful!");
                    Console.WriteLine(cmd.Parameters["hrsum"].Value);
                    var rt = cmd.Parameters["hrsum"].Value;
                    oldhours.Text = Convert.ToString(rt);
                    conn.Close();
                } else
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }

            //--------------------Gets the Old End Date-----------//
            try
            {
                if ((get_equip.SelectedIndex == 0 && get_emps.SelectedIndex == 0) || (get_equip.SelectedIndex != 0 && get_emps.SelectedIndex == 0))
                {
                    string cmdtxt = "select edate from cam_workson where orderid = " + get_orders.SelectedItem + " order by EmpSSN";
                    string cmdtxt2 = "select unique eenddate from cam_usedon where orderid = " + get_orders.SelectedItem;
                    using (OracleConnection conn = new OracleConnection(oradb))
                    using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                    {
                        conn.Open();
                        OracleDataReader dr;
                        int i = 1;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if(get_equip.SelectedIndex == 0)
                                oldenddatebox.Text = (dr[0].ToString());       
                            Console.WriteLine("OldDate from workson:" + oldenddatebox.Text);

                        }
                        conn.Close();
                    }
                    using (OracleConnection conn = new OracleConnection(oradb))
                    using (OracleCommand cmd = new OracleCommand(cmdtxt2, conn))
                    {
                        conn.Open();
                        OracleDataReader dr;
                        int i = 1;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if(get_equip.SelectedIndex != 0)
                                oldenddatebox.Text = (dr[0].ToString());
                            Console.WriteLine("OldDate from usedon:" + oldenddatebox);

                        }
                        conn.Close();
                    }
                }
                else
                {
                    string cmdtxt = "select unique edate from cam_workson where orderid = " + get_orders.SelectedItem + " and empssn = " + Convert.ToString(EmpID[selectedemp]);
                    string cmdtxt2 = "select unique eenddate from cam_usedon where orderid = " + get_orders.SelectedItem;
                    using (OracleConnection conn = new OracleConnection(oradb))
                    using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                    {
                        conn.Open();
                        OracleDataReader dr;
                        int i = 1;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            oldenddatebox.Text = (dr[0].ToString());
                            Console.WriteLine("OldDate from workson:" + oldenddatebox.Text);

                        }
                        conn.Close();
                    }
                    using (OracleConnection conn = new OracleConnection(oradb))
                    using (OracleCommand cmd = new OracleCommand(cmdtxt2, conn))
                    {
                        conn.Open();
                        OracleDataReader dr;
                        int i = 1;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            string temp = (dr[0].ToString());
                            Console.WriteLine("OldDate from usedon:" + temp);

                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }

            //--------------------Updates End Date-------------------------------------//
            try
            {
                string cmdtxt = null;
                string cmdtxt2 = null;
                if (Convert.ToInt32(hours_to_add.Text) < 12)
            {
                    if (get_emps.SelectedIndex == 0 && get_equip.SelectedIndex == 0)
                    {
                        cmdtxt = "update CAM_WORKSON SET hours = hours + " + Convert.ToString(hours_to_add.Text) + " WHERE EmpSSN = " + EmpID[selectedemp] + " AND OrderID = " + Convert.ToString(get_orders.SelectedItem);
                    }
            } else
            {
                    if (get_emps.SelectedIndex == 0 && get_equip.SelectedIndex == 0)
                    {
                        cmdtxt = "update CAM_WORKSON SET hours = hours + " + Convert.ToString(hours_to_add.Text) + ", eDate = eDate + " + Convert.ToString(Convert.ToInt32(hours_to_add.Text) / 12) +
                                        " WHERE OrderID = " + Convert.ToString(get_orders.SelectedItem);
                        cmdtxt2 = "update CAM_USEDON SET eenddate = eenddate + " + (Convert.ToInt32(hours_to_add.Text) / 12) +
                                        " WHERE OrderID = " + Convert.ToString(get_orders.SelectedItem);
                    }
                    else
                    {
                        cmdtxt = "update CAM_WORKSON SET hours = hours + " + Convert.ToString(hours_to_add.Text) + ", eDate = eDate + " + Convert.ToString(Convert.ToInt32(hours_to_add.Text) / 12) +
                                        " WHERE EmpSSN = " + EmpID[selectedemp] + " AND OrderID = " + Convert.ToString(get_orders.SelectedItem);
                        cmdtxt2 = "update CAM_USEDON SET eenddate = eenddate + " + (Convert.ToInt32(hours_to_add.Text) / 12) +
                                        " WHERE OrderID = " + Convert.ToString(get_orders.SelectedItem);
                    }
                }
                Console.WriteLine(cmdtxt);
                using (OracleConnection conn = new OracleConnection(oradb))
                using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                using (OracleConnection conn = new OracleConnection(oradb))
                using (OracleCommand cmd = new OracleCommand(cmdtxt2, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }
            //----------------------Sums Hours After update---------------------------//
            try
            {
                if ((get_equip.SelectedIndex == 0 && get_emps.SelectedIndex == 0) || (get_equip.SelectedIndex != 0 && get_emps.SelectedIndex == 0))
                {
                    OracleConnection conn = new OracleConnection(oradb);
                    var cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CAM_NonSpecificHours";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("hrsum", OracleDbType.Decimal);
                    cmd.Parameters["hrsum"].Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add("ordernum", Convert.ToString(get_orders.SelectedItem));
                    cmd.Parameters["ordernum"].Direction = ParameterDirection.Input;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Connection succesful!");
                    Console.WriteLine(cmd.Parameters["hrsum"].Value);
                    var rt = cmd.Parameters["hrsum"].Value;
                    newhours.Text = Convert.ToString(rt);
                    Console.WriteLine(newhours.Text);
                    conn.Close();
                }
                else
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
                    Console.WriteLine(newhours.Text);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }

            //--------------------Gets the New End Date-----------//
            try
            {
                if ((get_equip.SelectedIndex == 0 && get_emps.SelectedIndex == 0) || (get_equip.SelectedIndex != 0 && get_emps.SelectedIndex == 0))
                {
                    string cmdtxt = "select edate from cam_workson where orderid = " + get_orders.SelectedItem + " order by EmpSSN";
                    string cmdtxt2 = "select unique eenddate from cam_usedon where orderid = " + get_orders.SelectedItem;
                    using (OracleConnection conn = new OracleConnection(oradb))
                    using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                    {
                        conn.Open();
                        OracleDataReader dr;
                        int i = 1;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (get_equip.SelectedIndex == 0)
                                newenddatebox.Text = (dr[0].ToString());
                            newenddatebox.Text = (dr[0].ToString());
                            Console.WriteLine("NewDate from workson:" + newenddatebox.Text);

                        }
                        conn.Close();
                    }
                    using (OracleConnection conn = new OracleConnection(oradb))
                    using (OracleCommand cmd = new OracleCommand(cmdtxt2, conn))
                    {
                        conn.Open();
                        OracleDataReader dr;
                        int i = 1;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (get_equip.SelectedIndex != 0)
                                newenddatebox.Text = (dr[0].ToString());
                            Console.WriteLine("NewDate from usedon:" + newenddatebox.Text);

                        }
                        conn.Close();
                    }
                }
                else
                {
                    string cmdtxt = "select unique edate from cam_workson where orderid = " + get_orders.SelectedItem + " and empssn = " + Convert.ToString(EmpID[selectedemp]);
                    string cmdtxt2 = "select unique eenddate from cam_usedon where orderid = " + get_orders.SelectedItem;
                    using (OracleConnection conn = new OracleConnection(oradb))
                    using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                    {
                        conn.Open();
                        OracleDataReader dr;
                        int i = 1;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            newenddatebox.Text = (dr[0].ToString());
                            Console.WriteLine("NewDate from workson:" + newenddatebox.Text);

                        }
                        conn.Close();
                    }
                    using (OracleConnection conn = new OracleConnection(oradb))
                    using (OracleCommand cmd = new OracleCommand(cmdtxt2, conn))
                    {
                        conn.Open();
                        OracleDataReader dr;
                        int i = 1;
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            string temp = (dr[0].ToString());
                            Console.WriteLine("NewDate from usedon:" + temp);

                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }

        }

        private void datebutton_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void getorders_SelectedIndexChanged(object sender, EventArgs e)
        {
            empprofit.Text = string.Empty;
            emphours.Text = string.Empty;
            equipprofit.Text = string.Empty;
            overallprofit.Text = string.Empty;
            int j = 1;
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            string cmdtxt = "select EquipID, EquipType from CAM_EQUIPMENT where EquipID IN"+
                            "(select EquipID from CAM_USEDON where OrderID = " + getorders.SelectedItem +")";
            using (OracleConnection conn = new OracleConnection(oradb))
            using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
            {
                try
                {
                    conn.Open();
                    OracleDataReader dr;
                    dr = cmd.ExecuteReader();
                    int i = 1;
                    while (dr.Read())
                    {
                        equipids[i] = Convert.ToString(dr[0].ToString());
                        equipnames[i] = Convert.ToString(dr[1].ToString());
                        i++;
                    }
                    j = i;
                } catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}", ex.Message);
                }
            }
            if (j >= 2)
            {
                equipname1.Show();
                equipnamebox1.Show();
                equipnamebox1.Text = equipnames[1];
                equipid1.Show();
                equipidbox1.Show();
                equipidbox1.Text = equipids[1];
            } else
            {
                equipname1.Hide();
                equipnamebox1.Hide();
                equipid1.Hide();
                equipidbox1.Hide();
            }
            if (j >= 3)
            {
                equipname2.Show();
                equipnamebox2.Show();
                equipnamebox2.Text = equipnames[2];
                equipid2.Show();
                equipidbox2.Show();
                equipidbox2.Text = equipids[2];
            }
            else
            {
                equipname2.Hide();
                equipnamebox2.Hide();
                equipid2.Hide();
                equipidbox2.Hide();
            }
            if (j >= 4)
            {
                equipname3.Show();
                equipnamebox3.Show();
                equipnamebox3.Text = equipnames[3];
                equipid3.Show();
                equipidbox3.Show();
                equipidbox3.Text = equipids[3];
            }
            else
            {
                equipname3.Hide();
                equipnamebox3.Hide();
                equipid3.Hide();
                equipidbox3.Hide();
            }
            if (j >= 5)
            {
                equipname4.Show();
                equipnamebox4.Show();
                equipnamebox4.Text = equipnames[4];
                equipid4.Show();
                equipidbox4.Show();
                equipidbox4.Text = equipids[4];
            }
            else
            {
                equipname4.Hide();
                equipnamebox4.Hide();
                equipid4.Hide();
                equipidbox4.Hide();
            }
            if (j >= 6)
            {
                equipname5.Show();
                equipnamebox5.Show();
                equipnamebox5.Text = equipnames[5];
                equipid5.Show();
                equipidbox5.Show();
                equipidbox5.Text = equipids[5];
            }
            else
            {
                equipname5.Hide();
                equipnamebox5.Hide();
                equipid5.Hide();
                equipidbox5.Hide();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
            s = month1 + "-" + day1 + "-" + year1;
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

            s2 = month2 + "-" + day2 + "-" + year2;
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
            string sumprofit = null;
            string sumhours = null;
            string equipmentprofit = null;
            int sumtotal = 0;
            if (correct == 2)
            {

            
 
                    if (complist.SelectedIndex == 0 && getorders.SelectedIndex == 0)
                    {
                    //string sumprofit = null;
                    //string sumhours = null;
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
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error:{0}", ex.Message);
                    }
                    try
                    {
                        OracleConnection conn = new OracleConnection(oradb);
                        var cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "CAM_ORDERPROFIT";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("ordnum", OracleDbType.Decimal);
                        cmd.Parameters["ordnum"].Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add("start_date", s);
                        cmd.Parameters.Add("end_date", s2);
                        cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                        cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        var rt = cmd.Parameters["ordnum"].Value;
                        mosthoursbox.Text = "Order: " + Convert.ToString(rt);
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error:{0}", ex.Message);
                    }
                    try
                    {
                        OracleConnection conn = new OracleConnection(oradb);
                        var cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "CAM_ORDERLOWPROFIT";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("ordnum", OracleDbType.Decimal);
                        cmd.Parameters["ordnum"].Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add("start_date", s);
                        cmd.Parameters.Add("end_date", s2);
                        cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                        cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        var rt = cmd.Parameters["ordnum"].Value;
                        leasthoursbox.Text = "Order: " + Convert.ToString(rt);
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error:{0}", ex.Message);
                    }
                    try
                    {
                        OracleConnection conn = new OracleConnection(oradb);
                        var cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "CAM_GETTOTALEQUIPPROF";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("equipsum", OracleDbType.Decimal);
                        cmd.Parameters["equipsum"].Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add("start_date", s);
                        cmd.Parameters.Add("end_date", s2);
                        cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                        cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Connection succesful!");
                        Console.WriteLine(cmd.Parameters["equipsum"].Value);
                        var rt = cmd.Parameters["equipsum"].Value;
                        equipmentprofit = Convert.ToString(rt);
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error:{0}", ex.Message);
                    }
                    try
                    {
                        string cmdtxt = "select a.* from (select * from cam_masterprofit order by totalsum desc) a where rownum = 1";
                        using (OracleConnection conn = new OracleConnection(oradb))
                        using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                        {
                            conn.Open();
                            OracleDataReader dr;
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                    mostorderbox.Text = (dr[0].ToString());
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
                        string cmdtxt = "select a.* from (select * from cam_masterprofit order by totalsum asc) a where rownum = 1";
                        using (OracleConnection conn = new OracleConnection(oradb))
                        using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
                        {
                            conn.Open();
                            OracleDataReader dr;
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                leastorderbox.Text = (dr[0].ToString());
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error:{0}", ex.Message);
                    }
                } else {
                    try
                    {
                        if (getorders.SelectedIndex == 0)
                        {
                            OracleConnection conn = new OracleConnection(oradb);
                            var cmd = new OracleCommand();
                            cmd.Connection = conn;
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
                        } else
                        {
                            OracleConnection conn = new OracleConnection(oradb);
                            var cmd = new OracleCommand();
                            cmd.Connection = conn;
                            string ordernum = Convert.ToString(getorders.SelectedItem);
                            cmd.CommandText = "CAM_SumHoursSpecificOrder";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("hrsum", OracleDbType.Decimal);
                            cmd.Parameters["hrsum"].Direction = ParameterDirection.ReturnValue;
                            cmd.Parameters.Add("start_date", s);
                            cmd.Parameters.Add("end_date", s2);
                            cmd.Parameters.Add("ordnum", ordernum);
                            cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                            cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                            cmd.Parameters["ordnum"].Direction = ParameterDirection.Input;
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
                    if (getorders.SelectedIndex != 0)
                    {
                        try
                        {
                            OracleConnection conn = new OracleConnection(oradb);
                            var cmd = new OracleCommand();
                            cmd.Connection = conn;
                            string ordernum = Convert.ToString(getorders.SelectedItem);
                            cmd.CommandText = "CAM_GETEQUIPPROF";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("equipsum", OracleDbType.Decimal);
                            cmd.Parameters["equipsum"].Direction = ParameterDirection.ReturnValue;
                            cmd.Parameters.Add("start_date", s);
                            cmd.Parameters.Add("end_date", s2);
                            cmd.Parameters.Add("ordnum", ordernum);
                            cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                            cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                            cmd.Parameters["ordnum"].Direction = ParameterDirection.Input;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Connection succesful!");
                            Console.WriteLine(cmd.Parameters["equipsum"].Value);
                            var rt = cmd.Parameters["equipsum"].Value;
                            equipmentprofit = Convert.ToString(rt);
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error:{0}", ex.Message);
                        }
                    } else
                    {
                        try
                        {
                            OracleConnection conn = new OracleConnection(oradb);
                            var cmd = new OracleCommand();
                            cmd.Connection = conn;
                            string comname = Convert.ToString(complist.SelectedItem);
                            cmd.CommandText = "CAM_GETCOMPANYEQUIPPROF";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("equipsum", OracleDbType.Decimal);
                            cmd.Parameters["equipsum"].Direction = ParameterDirection.ReturnValue;
                            cmd.Parameters.Add("start_date", s);
                            cmd.Parameters.Add("end_date", s2);
                            cmd.Parameters.Add("comname", comname);
                            cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                            cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                            cmd.Parameters["comname"].Direction = ParameterDirection.Input;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Connection succesful!");
                            Console.WriteLine(cmd.Parameters["equipsum"].Value);
                            var rt = cmd.Parameters["equipsum"].Value;
                            equipmentprofit = Convert.ToString(rt);
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error:{0}", ex.Message);
                        }
                    }
                }
                
                
                if (sumprofit == "null")
                {
                    empprofit.Text = "$0";
                } else {
                    empprofit.Text = "$" + sumprofit;
                    sumtotal += Convert.ToInt32(sumprofit);
                }
                if(equipmentprofit == "null")
                {
                    equipprofit.Text = "$0";
                } else
                {
                    equipprofit.Text = "$" + equipmentprofit;
                    sumtotal += Convert.ToInt32(equipmentprofit);
                }
                overallprofit.Text = "$" + Convert.ToString(sumtotal);

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
                    }
                    else
                    {
                        if (getorders.SelectedIndex == 0)
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
                        } else
                        {
                            string ordernum = Convert.ToString(getorders.SelectedItem);
                            cmd.CommandText = "CAM_TotalHoursSpecificOrder";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("hrsum", OracleDbType.Decimal);
                            cmd.Parameters["hrsum"].Direction = ParameterDirection.ReturnValue;
                            cmd.Parameters.Add("start_date", s);
                            cmd.Parameters.Add("end_date", s2);
                            cmd.Parameters.Add("ordnum", ordernum);
                            cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                            cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                            cmd.Parameters["ordnum"].Direction = ParameterDirection.Input;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Connection succesful!");
                            Console.WriteLine(cmd.Parameters["hrsum"].Value);
                            var rt = cmd.Parameters["hrsum"].Value;
                            sumhours = Convert.ToString(rt);
                            conn.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}", ex.Message);
                }
                if (sumhours == "null")
                {
                    emphours.Text = "0 hrs";
                } else {
                    emphours.Text = sumhours + " hrs";

                }

            } else {
                Console.WriteLine("Test was less than 2!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine(getorders.SelectedIndex + " " + complist.SelectedIndex);
            if (getorders.SelectedIndex == 0 && complist.SelectedIndex == 0)
            {
                string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
                string cmdtxt = "CREATE OR REPLACE VIEW CAM_ORDERVIEWGROUPED as " +
                    "select (c.cname)company, SUM(b.bsum + q.csum) Profit, (j.jobtype)jobtype, (q.estartdate) started, (q.eenddate) ended " +
                    "from cam_makes c, cam_emphours b, cam_mosthours q, cam_order j " +
                    "where q.orderid = c.orderid and b.orderid = c.orderid and j.orderid = c.orderid and q.eenddate > to_date('" + s + "','DD-MM-YYYY') and q.estartdate < to_date('" + s2 + "','DD-MM-YYYY')" +
                    " group by c.cname, j.jobtype, q.estartdate, q.eenddate" +
                    " order by c.cname";
                Console.WriteLine(cmdtxt);
                try
                {
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
                compselected = Convert.ToString(complist.SelectedItem);
                bestordnumselected = mostorderbox.Text;
                worstordnumselected = leastorderbox.Text;
                emphourselected = emphours.Text;
                empprofselected = empprofit.Text;
                equipprofselected = equipprofit.Text;
                totalprofselected = overallprofit.Text;
                Form2 frm = new Form2();
                frm.Show();
            }
            else if (getorders.SelectedIndex == 0 && complist.SelectedIndex != 0)
            {
                string tempbignum = null;
                string templownum = null;
                compselected = Convert.ToString(complist.SelectedItem);
                string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
                try
                {
                    OracleConnection conn = new OracleConnection(oradb);
                    var cmd = new OracleCommand();
                    cmd.Connection = conn;
                    string comname = Convert.ToString(complist.SelectedItem);
                    cmd.CommandText = "CAM_GETHIGHORDER";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("highnum", OracleDbType.Decimal);
                    cmd.Parameters["highnum"].Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add("start_date", s);
                    cmd.Parameters.Add("end_date", s2);
                    cmd.Parameters.Add("comname", comname);
                    cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                    cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                    cmd.Parameters["comname"].Direction = ParameterDirection.Input;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Connection succesful!");
                    Console.WriteLine(cmd.Parameters["highnum"].Value);
                    var rt = cmd.Parameters["highnum"].Value;
                    tempbignum = Convert.ToString(rt);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}", ex.Message);
                }
                try
                {
                    OracleConnection conn = new OracleConnection(oradb);
                    var cmd = new OracleCommand();
                    cmd.Connection = conn;
                    string comname = Convert.ToString(complist.SelectedItem);
                    cmd.CommandText = "CAM_GETLOWORDER";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("lownum", OracleDbType.Decimal);
                    cmd.Parameters["lownum"].Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add("start_date", s);
                    cmd.Parameters.Add("end_date", s2);
                    cmd.Parameters.Add("comname", comname);
                    cmd.Parameters["end_date"].Direction = ParameterDirection.Input;
                    cmd.Parameters["start_date"].Direction = ParameterDirection.Input;
                    cmd.Parameters["comname"].Direction = ParameterDirection.Input;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Connection succesful!");
                    Console.WriteLine(cmd.Parameters["lownum"].Value);
                    var rt = cmd.Parameters["lownum"].Value;
                    templownum = Convert.ToString(rt);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}", ex.Message);
                }
                if (tempbignum != null)
                {
                    bestordnumselected = tempbignum;
                }
                else
                {
                    bestordnumselected = "NA";
                }
                if (templownum != null)
                {
                    worstordnumselected = templownum;
                }
                else
                {
                    worstordnumselected = "NA";
                }
                emphourselected = emphours.Text;
                empprofselected = empprofit.Text;
                equipprofselected = equipprofit.Text;
                totalprofselected = overallprofit.Text;

                string cmdtxt = "CREATE OR REPLACE VIEW CAM_ORDERVIEWGROUPED as " +
                    "select (c.cname)company, SUM(b.bsum + q.csum) Profit, (j.jobtype)jobtype, (q.estartdate) started, (q.eenddate) ended " +
                    "from cam_makes c, cam_emphours b, cam_mosthours q, cam_order j " +
                    "where q.orderid = c.orderid and b.orderid = c.orderid and j.orderid = c.orderid and c.cname = '" + Convert.ToString(complist.SelectedItem) + "' and q.eenddate > to_date('" + s + "','DD-MM-YYYY') and q.estartdate < to_date('" + s2 + "','DD-MM-YYYY')" +
                    " group by c.cname, j.jobtype, q.estartdate, q.eenddate" +
                    " order by c.cname";
                Console.WriteLine(cmdtxt);
                try
                {
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
                Form2 frm = new Form2();
                frm.Show();
            }
            else if (getorders.SelectedIndex != 0 && complist.SelectedIndex != 0)
            {
                compselected = Convert.ToString(complist.SelectedItem);
                bestordnumselected = mostorderbox.Text;
                worstordnumselected = leastorderbox.Text;
                emphourselected = emphours.Text;
                empprofselected = empprofit.Text;
                equipprofselected = equipprofit.Text;
                totalprofselected = overallprofit.Text;
                equipsel = equipnamebox1.Text;
                equipselid = equipidbox1.Text;
                string oradb = "DATA SOURCE=delphi.cs.csubak.edu:1521/dbs01.cs.csubak;USER ID=cs3420; PASSWORD=c3m4p2s";
                string cmdtxt = "CREATE OR REPLACE VIEW CAM_ORDERVIEWGROUPED as " +
                    "select (c.cname)company, SUM(b.bsum + q.csum) Profit, (j.jobtype)jobtype, (q.estartdate) started, (q.eenddate) ended " +
                    "from cam_makes c, cam_emphours b, cam_mosthours q, cam_order j " +
                    "where q.orderid = " + Convert.ToString(getorders.SelectedItem) + " and b.orderid = c.orderid and j.orderid = c.orderid and c.orderid = " + Convert.ToString(getorders.SelectedItem) + " and c.cname = '" + Convert.ToString(complist.SelectedItem) + "'" +
                    " group by c.cname, j.jobtype, q.estartdate, q.eenddate" +
                    " order by c.cname";
                Console.WriteLine(cmdtxt);
                try
                {
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
                string cmdtxt2 = "CREATE OR REPLACE VIEW CAM_EMPVIEW as select (e.empname) name, (e.empssn)social, w.orderid from cam_employee e, cam_workson w " +
                                   "where e.empssn = w.empssn and w.orderid = " + Convert.ToString(getorders.SelectedItem) +
                                    " order by w.orderid";
                Console.WriteLine(cmdtxt);
                try
                {
                    using (OracleConnection conn = new OracleConnection(oradb))
                    using (OracleCommand cmd = new OracleCommand(cmdtxt2, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:{0}", ex.Message);
                }
                Form4 frm = new Form4();
                frm.Show();
            }
        }
    }
}
