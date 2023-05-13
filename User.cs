using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public class User
    {
        private UserDAO userDAO;
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public List<TaskList> TaskLists { get; set; }

        public User()
        {
            userDAO = new UserDAO();
        }

        public User Login(string username, string password)
        {
            bool success = userDAO.Login(username, password, this);
            if (success)
            {
                // Console.WriteLine(this.Username + " " + this.Password + " " + this.UserId);
                return this;
            } else
            {
                return null;
            }
        }

    }

    public class UserDAO
    {
        private MySqlConnection connection;

        public UserDAO()
        {
            connection = new MySqlConnection(new DatabaseConfig().GetConnectionString()); 
        }

        public bool Login(string username, string password, User user)
        {
            bool success = false;

            try
            {
                connection.Open();

                // Check if user exists in database
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT id FROM users WHERE username = @username AND password = @password";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                success = reader.Read();
                if (success)
                {
                    user.Username = username;
                    user.Password = password;
                    user.UserId = reader["id"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return success;
        }
    }
}
