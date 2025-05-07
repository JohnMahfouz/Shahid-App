using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace SWE_project
{
    public partial class Subscribe : Form
    {
        string ordb = "Data source=orcl ;User Id=scott;Password=tiger;";
        OracleConnection conn;
   
        public Subscribe()
        {
            InitializeComponent();

        }

        private void Subscribe_Load(object sender, EventArgs e)
        {
             conn = new OracleConnection(ordb);
              conn.Open();

                string planQuery = "SELECT PlanName FROM SubscriptionPlans";
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = planQuery;
 
            OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString(0));
                }

                reader.Close();
            
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a subscription plan.");
                return;
            }

           
                string selectedPlan = comboBox1.SelectedItem.ToString();
                int planID = 0;
                string query = "SELECT PlanID FROM SubscriptionPlans WHERE PlanName = :planName";
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.Parameters.Add("planName", OracleDbType.Varchar2).Value = selectedPlan;

                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    planID = Convert.ToInt32(reader.GetValue(0));
                }
                reader.Close();

                string username = textBox1.Text;
                int userID = 0;
                string query_1 = "SELECT UserID,SubscriptionStatus FROM Users WHERE Username = :username";
                OracleCommand cmd_1 = new OracleCommand();
                cmd_1.Connection = conn;
                cmd_1.CommandText = query_1;
                cmd_1.Parameters.Add("username", OracleDbType.Varchar2).Value = username;

                OracleDataReader reader_1 = cmd_1.ExecuteReader();
            if (reader_1.Read())
            {
                userID = Convert.ToInt32(reader_1.GetValue(0));
                string subscriptionStatus = reader_1.GetString(1);

                if (subscriptionStatus.ToLower() == "active")
                {
                    MessageBox.Show("Already Subscribed");
                    return;

                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Username not found.");
                return;
            }
        

                reader_1.Close();

                OracleCommand cmd_2 = new OracleCommand();
                cmd_2.Connection = conn;
                cmd_2.CommandText = "SubscribeUser";
                cmd_2.CommandType = CommandType.StoredProcedure;

                cmd_2.Parameters.Add("p_UserID", OracleDbType.Int32).Value = userID;
                cmd_2.Parameters.Add("p_PlanID", OracleDbType.Int32).Value = planID;
                cmd_2.ExecuteNonQuery();

            MessageBox.Show("Subscription successful!");            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}