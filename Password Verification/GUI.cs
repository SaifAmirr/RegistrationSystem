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

namespace Registration_System
{
     partial class frmRegister : Form
    {
        public frmRegister()
        {       
            InitializeComponent();
        }

        public static void UpdateUserList()
        {
            frmList.listbox.Items.Clear();
            foreach (var user in Program.users.Values)
            {
               frmList.listbox.Items.Add($"{user.Username}");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            string password2 = textBox1.Text;
            string usernamecheck = username.ToLower();

            try
            {
                UserRole role = (UserRole)Enum.Parse(typeof(UserRole), comboBox2.SelectedItem.ToString());
                
                if (usernamecheck == "admin")
                {
                    MessageBox.Show("Error: This Username is Unavailable", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    try
                    {
                        RegisterUser(Program.users, username, password, role, "Computer Engineering", password2);
                        UpdateUserList();
                        MessageBox.Show($"User '{username}' Registered Successfully.", "Registration");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error: Please Enter Missing Information.","Registration Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Checkpassword(string password, string password2)
        {
            if (password != password2)
                throw new ArgumentException("Passwords do not Match");
        }

        public static void RegisterUser(HashTable<string, User> users, string username, string password, UserRole role, string department,string password2)
        {
            // Validate password strength
            ValidatePasswordStrength(password);

            // Check if Passwords match
            Checkpassword(password,password2);

            // Generate a random salt
            byte[] salt = GenerateSalt();

            // Hash the password with the salt
            string hashedPassword = HashPassword(password, salt);

            // Register the user with role and department information
            users.Add(username, new User(username, salt, hashedPassword, role, department));
        }

        static void ValidatePasswordStrength(string password)
        {
            if (password.Length < 8 || !password.Any(char.IsDigit) || !password.Any(char.IsUpper))
            {
                throw new ArgumentException("Password must be at least 8 characters long and contain a digit and an uppercase letter.");
            }
        }

        public static byte[] GenerateSalt()
        {
            // Generate a random salt using a cryptographic random number generator
            byte[] salt = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
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

        private void checkboxshowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxshowpass.Checked)
            {
                txtpassword.PasswordChar = '\0';
                textBox1.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
                textBox1.PasswordChar = '•';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            textBox1.Clear();
            comboBox2.SelectedIndex=-1;
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
