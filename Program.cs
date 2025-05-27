using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Todo
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string cs = @"server=localhost;userid=root;password=;database=noteappdb";
                //string cs = @"server=localhost;userid=root;password=;database=todo";
                var con = new MySqlConnection(cs);
                con.Open();

                User user = new User();
                user.Login("root", "root");

                if (user != null)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainWindow(user));
                }


                Console.WriteLine($"MySQL version : {con.ServerVersion}");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
