using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Todo
{
    public class TaskList
    {
        private TaskListDAO taskListDAO;
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public TaskList(string name, int userId, DateTime createdAt)
        {
            Name = name;
            UserId = userId;
            CreatedAt = createdAt;
            taskListDAO = new TaskListDAO();
        }

        public TaskList(int id, string name, int userId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            UserId = userId;
            CreatedAt = createdAt;
            taskListDAO = new TaskListDAO();
        }

        public static bool Exists(string name, int userId)
        {
            return TaskListDAO.Exists(name, userId);
        }
    }

    public class TaskListDAO
    {
        private MySqlConnection connection;

        public TaskListDAO()
        {
            connection = new MySqlConnection(new DatabaseConfig().GetConnectionString());
        }

        public static int GetId(string name, int userId)
        {
            MySqlConnection connection = new MySqlConnection(new DatabaseConfig().GetConnectionString());
            int id = 0;

            try
            {
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT id FROM lists WHERE name = @name AND user_id = @userId";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@userId", userId);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    id = reader.GetInt32(0);
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

            return id;
        }

        public static bool Exists(string name, int userId)
        {
            MySqlConnection connection = new MySqlConnection(new DatabaseConfig().GetConnectionString());
            bool exists = false;
            try
            {
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM lists WHERE name = @name AND user_id = @userId";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@userId", userId);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                exists = count > 0;
                Console.WriteLine(exists);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return exists;
        }
    }
}
