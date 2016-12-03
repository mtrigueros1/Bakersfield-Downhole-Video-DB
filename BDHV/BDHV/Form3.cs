using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDHV
{
    public partial class Form3 : Form
    {
        string startcal;
        public Form3()
        {
            InitializeComponent();
        }

        private void getstartdate_DateSelected(object sender, DateRangeEventArgs e)
        {
            startcal = getstartdate.SelectionRange.Start.ToShortDateString();
        }
        private void getstartdate_DateChanged(object sender, DateRangeEventArgs e)
        {
            startcal = getstartdate.SelectionRange.Start.ToShortDateString();
           
       }
        private void setdates(string day1, string day2, string month1, string month2, string year1, string year2)
        {

        }
        private void subweekbefore_Click(object sender, EventArgs e)
        {
           DateTime begdate = getstartdate.SelectionRange.Start;
           DateTime enddate = begdate;
           begdate = enddate.Subtract(TimeSpan.FromDays(7));
           Form1.day2 = enddate.Day.ToString();
           Console.WriteLine(Form1.day2);
           Form1.month2 = enddate.Month.ToString();
           Console.WriteLine(Form1.month2);
           Form1.year2 = enddate.Year.ToString();
           Console.WriteLine(Form1.year2);
           Form1.day1 = begdate.Day.ToString();
           Console.WriteLine(Form1.day1);
           Form1.month1 = begdate.Month.ToString();
           Console.WriteLine(Form1.month1);
           Form1.year1 = begdate.Year.ToString();
           Console.WriteLine(Form1.year1);
            this.Close();
        }

        private void subweekafter_Click(object sender, EventArgs e)
        {
            DateTime begdate = getstartdate.SelectionRange.Start;
            DateTime enddate = begdate.AddDays(7);
            Form1.day2 = enddate.Day.ToString();
            Console.WriteLine(Form1.day2);
            Form1.month2 = enddate.Month.ToString();
            Console.WriteLine(Form1.month2);
            Form1.year2 = enddate.Year.ToString();
            Console.WriteLine(Form1.year2);
            Form1.day1 = begdate.Day.ToString();
            Console.WriteLine(Form1.day1);
            Form1.month1 = begdate.Month.ToString();
            Console.WriteLine(Form1.month1);
            Form1.year1 = begdate.Year.ToString();
            Console.WriteLine(Form1.year1);
            this.Close();

        }

        private void submonthbefore_Click(object sender, EventArgs e)
        {
            DateTime begdate = getstartdate.SelectionRange.Start;
            DateTime enddate = begdate;
            begdate = enddate.AddMonths(-1);
            Form1.day2 = enddate.Day.ToString();
            Console.WriteLine(Form1.day2);
            Form1.month2 = enddate.Month.ToString();
            Console.WriteLine(Form1.month2);
            Form1.year2 = enddate.Year.ToString();
            Console.WriteLine(Form1.year2);
            Form1.day1 = begdate.Day.ToString();
            Console.WriteLine(Form1.day1);
            Form1.month1 = begdate.Month.ToString();
            Console.WriteLine(Form1.month1);
            Form1.year1 = begdate.Year.ToString();
            Console.WriteLine(Form1.year1);
            this.Close();

        }

        private void submonthafter_Click(object sender, EventArgs e)
        {
            DateTime begdate = getstartdate.SelectionRange.Start;
            DateTime enddate = begdate.AddMonths(1);
            Form1.day2 = enddate.Day.ToString();
            Console.WriteLine(Form1.day2);
            Form1.month2 = enddate.Month.ToString();
            Console.WriteLine(Form1.month2);
            Form1.year2 = enddate.Year.ToString();
            Console.WriteLine(Form1.year2);
            Form1.day1 = begdate.Day.ToString();
            Console.WriteLine(Form1.day1);
            Form1.month1 = begdate.Month.ToString();
            Console.WriteLine(Form1.month1);
            Form1.year1 = begdate.Year.ToString();
            Console.WriteLine(Form1.year1);
            this.Close();

        }

        private void subyearbefore_Click(object sender, EventArgs e)
        {
            DateTime begdate = getstartdate.SelectionRange.Start;
            DateTime enddate = begdate;
            begdate = enddate.AddYears(-1);
            Form1.day2 = enddate.Day.ToString();
            Console.WriteLine(Form1.day2);
            Form1.month2 = enddate.Month.ToString();
            Console.WriteLine(Form1.month2);
            Form1.year2 = enddate.Year.ToString();
            Console.WriteLine(Form1.year2);
            Form1.day1 = begdate.Day.ToString();
            Console.WriteLine(Form1.day1);
            Form1.month1 = begdate.Month.ToString();
            Console.WriteLine(Form1.month1);
            Form1.year1 = begdate.Year.ToString();
            Console.WriteLine(Form1.year1);
            this.Close();

        }

        private void subyearafter_Click(object sender, EventArgs e)
        {
            DateTime begdate = getstartdate.SelectionRange.Start;
            DateTime enddate = begdate.AddYears(1);
            Form1.day2 = enddate.Day.ToString();
            Console.WriteLine(Form1.day2);
            Form1.month2 = enddate.Month.ToString();
            Console.WriteLine(Form1.month2);
            Form1.year2 = enddate.Year.ToString();
            Console.WriteLine(Form1.year2);
            Form1.day1 = begdate.Day.ToString();
            Console.WriteLine(Form1.day1);
            Form1.month1 = begdate.Month.ToString();
            Console.WriteLine(Form1.month1);
            Form1.year1 = begdate.Year.ToString();
            Console.WriteLine(Form1.year1);
            this.Close();

        }
    }
}
