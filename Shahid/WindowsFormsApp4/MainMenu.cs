using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp4;

namespace SWE_project
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void signupToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
        }

        private void signupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sign_up sign = new Sign_up();
            sign.Show();
        }

        private void editUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnected edit= new Disconnected();
            edit.Show();
        }

        private void showContentRatingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Content_Rating=new Form2();
            Content_Rating.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            

        }

        private void report1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user_crys_form sa = new user_crys_form();
            sa.Show();
        }

        private void report2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crys2 ma = new crys2();
            ma.Show();
        }

        private void subscribeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Subscribe sub = new Subscribe();
            sub.Show();
        }

        private void showStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 status = new Form1();
            status.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
