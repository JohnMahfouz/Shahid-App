using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SWE_project
{

    public partial class Sign_up : Form
    {
        string ordb = "Data Source = orcl ; User Id =scott; Password=tiger";
        OracleConnection conn;
        public Sign_up()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 back = new Form1();
            back.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = "Insert into Users values (user_seq.NEXTVAL,:name,:email,:pass,'Not Active')";
            cmd.Parameters.Add("name", textBox1.Text);
            cmd.Parameters.Add("email", textBox3.Text);
            cmd.Parameters.Add("pass", textBox2.Text);
            cmd.CommandType = CommandType.Text;
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("User registered successfully!");
            }
            else
            {
                MessageBox.Show("User registration failed.");
            }
            conn.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
