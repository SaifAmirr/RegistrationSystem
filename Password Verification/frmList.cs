using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;

namespace Registration_System
{
    public partial class frmList : Form
    {
        public static ListBox listbox = new ListBox();
        
        public frmList()
        {
            InitializeComponent();
        }
        
        private void frmList_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listbox.BackColor = System.Drawing.Color.White;
            listbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listbox.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listbox.FormattingEnabled = true;
            listbox.ItemHeight = 25;
            listbox.Location = new System.Drawing.Point(285, 154);
            listbox.Name = "listBox1";
            listbox.Size = new System.Drawing.Size(346, 302);
            listbox.TabIndex = 35;
            this.Controls.Add(listbox);
            listbox.DoubleClick += new EventHandler(listbox_DoubleClick);
        }

        private void listbox_DoubleClick(object sender, EventArgs e)
        {
            if (listbox.SelectedItem != null)
            {
                User selectedUser = Program.users.Get(listbox.SelectedItem.ToString().Split('-')[0].Trim());
                MessageBox.Show($"Details for {selectedUser.Username}, \nRole: {selectedUser.Role} \nDepartment: {selectedUser.Department} \nHashed Password: {selectedUser.HashedPassword}");
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listbox.SelectedIndex!= -1)
            {
                User selectedUser = Program.users.Get(listbox.SelectedItem.ToString());
                listbox.Items.RemoveAt(listbox.SelectedIndex);
                Program.users.Remove(selectedUser.Username);
                MessageBox.Show($"User Removed Successfully.");
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmLogin().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listbox.SelectedIndex >= 0)
            {
                string selectedUsername = listbox.SelectedItem.ToString().Split('-')[0].Trim();
                User selectedUser = Program.users.Get(selectedUsername);

                string newusername =Interaction.InputBox($"Edit user '{selectedUsername}'.", "Edit User");
                string newdepartment = Interaction.InputBox($"Edit user '{selectedUsername}''s department.", "Edit Department");

                foreach (var user in Program.users.Values)
                {
                    if (newusername!=user.Username)
                    {
                        try
                        {
                            Program.users.Add(newusername, new User(newusername, selectedUser.Salt, selectedUser.HashedPassword, selectedUser.Role, newdepartment));
                            listbox.Items.RemoveAt(listbox.SelectedIndex);
                            Program.users.Remove(selectedUser.Username);
                            frmRegister.UpdateUserList();
                            MessageBox.Show("Username and Department Edited Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        catch
                        {
                            MessageBox.Show("Username Already Exists, Try another Username.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }   
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
