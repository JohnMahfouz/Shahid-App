using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp4
{
    public partial class user_crys_form : Form
    {
        CrystalReport2 CR;

        string ordb = "Data Source=orcl;User Id=scott;Password=tiger";
        OracleConnection conn;
        public user_crys_form()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            CR.SetParameterValue(0, comboBox1.SelectedItem);
            crystalReportViewer1.ReportSource = CR;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //conn = new OracleConnection(ordb);
            //conn.Open();

            //OracleCommand cmd = new OracleCommand("SELECT *USERNAME FROM USERS", conn);
            //OracleDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    comboBox1.Items.Add(reader["USERNAME"].ToString());
            //}
            //reader.Close();
            CR = new CrystalReport2();
            foreach (ParameterDiscreteValue v in CR.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
