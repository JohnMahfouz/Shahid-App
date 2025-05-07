using System;
using System.Collections;
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

namespace SWE_project
{
    public partial class Form2 : Form
    {
        string ordb = "Data Source = orcl ; User Id =scott; Password=tiger";
        OracleConnection conn;
        public Form2()
        {
            InitializeComponent();

        }
      
            private void Form2_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            Genre_ComboBox.Items.Clear();
            Genre_ComboBox.Items.Add("All");

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetContentData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("input", OracleDbType.Varchar2).Value ="genres";
            cmd.Parameters.Add("selected_genre", OracleDbType.Varchar2).Value = DBNull.Value;
            cmd.Parameters.Add("select_result", OracleDbType.RefCursor,ParameterDirection.Output);

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Genre_ComboBox.Items.Add(reader.GetString(0));
            }
            reader.Close();
            Genre_ComboBox.SelectedIndex = 0;
            conn.Close();



        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGenre = Genre_ComboBox.SelectedItem.ToString();
            comboBox1.Items.Clear();
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetContentData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("input", OracleDbType.Varchar2).Value = "titles";
            if (selectedGenre == "All")
            {
                cmd.Parameters.Add("selected_genre", OracleDbType.Varchar2).Value = "All";
            }
            else
            {
                cmd.Parameters.Add("selected_genre", OracleDbType.Varchar2).Value = selectedGenre;
            }

            cmd.Parameters.Add("result_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }
            reader.Close();
            conn.Close();

        }


     

        private void label2_Click(object sender, EventArgs e)
        {

        }





        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void Rating_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a title first.");
                return;
            }

            string selectedTitle = comboBox1.SelectedItem.ToString();
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetShowRating";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("selected_title", OracleDbType.Varchar2).Value = selectedTitle;
            cmd.Parameters.Add("result_rating", OracleDbType.Decimal, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            textBox1.Text = cmd.Parameters["result_rating"].Value.ToString();
            conn.Close();
            }
        
        
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

