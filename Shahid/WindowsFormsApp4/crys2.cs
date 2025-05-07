using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class crys2 : Form
    {
        CrystalReport1 CR1;
        public crys2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CR1;

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void crys2_Load(object sender, EventArgs e)
        {
            CR1 = new CrystalReport1() ;
        }
    }
}
