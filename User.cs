using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public class User
    {
        private UserDAO userDAO;
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
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
                Console.WriteLine(this.Username + " " + this.Password + " " + this.UserId);
                LoadTaskListsFromDatabase();
                return this;
            } else
            {
                return null;
            }
        }

        public void LoadTaskListsFromDatabase()
        {
            userDAO.LoadTaskListsFromDatabase(this);
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
                    user.UserId = reader.GetInt32(0);
                    user.TaskLists = new List<TaskList>();
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

        public void LoadTaskListsFromDatabase(User user)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM lists WHERE user_id = @userId";
                cmd.Parameters.AddWithValue("@userId", user.UserId);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TaskList taskList = new TaskList(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3));
                    user.TaskLists.Add(taskList);
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

        }
    }
}
