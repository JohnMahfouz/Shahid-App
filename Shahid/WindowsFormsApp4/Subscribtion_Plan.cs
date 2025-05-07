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
    public partial class Form1 : Form
    {
        string ordb = "Data Source = orcl ; User Id =scott; Password=tiger";
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            conn = new OracleConnection(ordb);
            conn.Open();
            string query = "SELECT UserID FROM Users WHERE Username = :username AND Password = :password";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.Parameters.Add(new OracleParameter("username", username));
            cmd.Parameters.Add(new OracleParameter("password", password));

            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                int userID = Convert.ToInt32(reader.GetValue(0));

                string subscriptionQuery = "SELECT PLANNAME FROM subscriptions WHERE USERID = :userID";
                OracleCommand subscriptionCmd = new OracleCommand();
                subscriptionCmd.Connection = conn;
                subscriptionCmd.CommandText = subscriptionQuery;
                subscriptionCmd.Parameters.Add("userID", OracleDbType.Int32).Value = userID;

                OracleDataReader subscriptionReader = subscriptionCmd.ExecuteReader();

                if (subscriptionReader.Read())
                {
                    string planeName = subscriptionReader.GetString(0);
                    MessageBox.Show("Plane Name: " + planeName);
                }
                else
                {
                    MessageBox.Show("Not Active");
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
            reader.Close();
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
