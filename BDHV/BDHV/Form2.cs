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
    public partial class Form2 : Form
    {
        public Form2(int numofboxes)
        {
            InitializeComponent();
            createTxtTeamNames(numofboxes);
        }

        public void createTxtTeamNames(int numofboxes)
        {
            Label[] txtTeamNames = new Label[numofboxes];

            for (int u = 0; u < txtTeamNames.Count(); u++)
            {
                txtTeamNames[u] = new Label();
            }
            int i = 0;
            int j = 0;
            foreach (Label txt in txtTeamNames)
            {
                string name = "Week " + i.ToString();
                txt.BackColor = System.Drawing.Color.DimGray;
                txt.Name = name;
                txt.TextAlign = ContentAlignment.MiddleCenter;
                txt.Text = name;
                txt.Size = new Size(55, 21);
                if (i <= 10)
                {
                    txt.Location = new Point(20 + (i * 60), 32);
                }
                if (i > 10 && i <= 20)
                {
                    txt.Location = new Point(20 + (j * 60), 64);
                    j++;
                }
                txt.Visible = true;
                this.Controls.Add(txt);
                i++;
            }
        }
    }
}
