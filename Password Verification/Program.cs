using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;


namespace Registration_System
{
    public class Program
    {
        // Create a hashtable for storing user information
        public static HashTable<string, User> users = new HashTable<string, User>();

        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create and run the GUI
            Application.Run(new frmLogin());
        }
    }
}





