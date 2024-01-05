using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Password_Verification;

namespace Registration_System
{
    public partial class userform : Form
    {
        public userform(string username)
        {
            InitializeComponent();
            label4.Text = username;
        }

        private void userform_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmLogin().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Schedule().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Calendar().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string vacationtime=Interaction.InputBox("Enter Vacation Time Needed Here(In Weeks): ", "Request Vacation");
            if (vacationtime.Length != 0)
            {
                MessageBox.Show($"Your Request for a {vacationtime} Week Vacation has been Submitted.","Request Submitted",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
