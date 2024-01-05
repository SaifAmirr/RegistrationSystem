using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Registration_System
{
     partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username= txtusername.Text;
            string password = txtpassword.Text;

            string usernamecheck = username.ToLower();

            if (usernamecheck == "admin" && password == "admin")
            {
                new frmList().Show();
                this.Hide();
            }
            else if (Login(Program.users, username, password) == 1)
            {
                MessageBox.Show($"Login successful for user '{username}'.", "Login");
                new userform(username).Show();
                this.Hide();
            }
            else if (Login(Program.users, username, password) == 0)
            {
                MessageBox.Show($"Invalid login for user '{username}'.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Login(Program.users,username, password)==2)
            {
                MessageBox.Show("Error: Please Enter Missing Information.","Login Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Username not found for user '{username}'.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static int Login(HashTable<string, User> users, string username, string password)
        {
            if (Program.users.ContainsKey(username))
            {
                User user = users.Get(username);

                // Hash the provided password with the stored salt
                string hashedPassword = HashPassword(password, user.Salt);

                // Check if the hashed passwords match
                if (hashedPassword.Equals(user.HashedPassword))
                {
                    //  Successful Login
                    return 1;
                }
                else
                {
                    //  Invalid Password
                    return 0;
                }
            }
            else if (username.Length==0||password.Length==0)
            {
                //  Username or Password textbox is Empty
                return 2;
            }
            else
            {
                //  Username Not Found
                return -1;
            }
        }

        static string HashPassword(string password, byte[] salt)
        {
            // Hash the password using SHA-256 and the provided salt
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] combinedBytes = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkboxshowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxshowpass.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
