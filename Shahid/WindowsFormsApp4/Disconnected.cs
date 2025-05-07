using System;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using SWE_project;

namespace WindowsFormsApp1
{
    public partial class Disconnected : Form
    {
        private string username;
        OracleDataAdapter adapter;
        DataSet ds;
        OracleCommandBuilder builder;
        public Disconnected()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void txt_Status_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=orcl ;User Id=scott;Password=tiger;";
            string cmdstr = "SELECT * FROM Users WHERE LOWER(SubscriptionStatus) = LOWER(:status)";

            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("status", textBox1.Text);

            ds = new DataSet();
            adapter.Fill(ds);

            dgv_Users.DataSource = ds.Tables[0];
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("Database updated successfully");
        }

    }
}
