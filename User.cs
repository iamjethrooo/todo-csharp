using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public void CreateTaskList(string name, DateTime currentDate)
        {
            userDAO.CreateTaskList(name, this, currentDate);
        }

        public void CreateTask(string name, int listId)
        {
            userDAO.CreateTask(name, listId, this);
        }

        public List<Task> GetTasksFromList(int listId)
        {
            return userDAO.GetTasksFromList(listId);
        }

        public void MarkTaskAsCompleted(int taskId)
        {
            userDAO.MarkTaskAsCompleted(taskId);
        }

        public void MarkTaskAsUnfinished(int taskId)
        {
            userDAO.MarkTaskAsUnfinished(taskId);
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

        public void CreateTaskList(string name, User user, DateTime currentDate)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO lists(name, user_id, created_at) VALUES (@name, @userId, @createdAt)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@userId", user.UserId);
                cmd.Parameters.AddWithValue("@createdAt", currentDate);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    TaskList taskList = new TaskList(TaskListDAO.GetId(name, user.UserId), name, user.UserId, currentDate);
                    user.TaskLists.Add(taskList);
                } else
                {
                    Console.WriteLine("Error: Task list not added.");
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

        public void CreateTask(string name, int listId, User user)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO tasks(name, list_id) VALUES (@name, @listId)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@listId", listId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Task added!");
                }
                else
                {
                    Console.WriteLine("Error: Task not added.");
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

        public List<Task> GetTasksFromList(int listId)
        {
            List<Task> tasks = new List<Task>();
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tasks WHERE list_id = @listId";
                cmd.Parameters.AddWithValue("@listId", listId);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable schemaTable = reader.GetSchemaTable();
                foreach (DataRow row in schemaTable.Rows)
                {
                    string columnName = row["ColumnName"].ToString();
                    int columnSize = (int)row["ColumnSize"];
                    Type dataType = (Type)row["DataType"];
                    Console.WriteLine(columnName);
                    // Do something with the column metadata...
                }
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DateTime? completionDate = null;
                        if (!reader.IsDBNull(5))
                        {
                            completionDate = reader.GetDateTime(5);
                        }
                        Task task = new Task(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(3), completionDate);
                        tasks.Add(task);
                    }
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

            return tasks;
        }

        public void MarkTaskAsCompleted(int taskId)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE tasks SET completion_date = @completionDate WHERE id = @taskId";
                cmd.Parameters.AddWithValue("@completionDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@taskId", taskId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Task updated!");
                }
                else
                {
                    Console.WriteLine("Error: Task not updated.");
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

        public void MarkTaskAsUnfinished(int taskId)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE tasks SET completion_date = @completionDate WHERE id = @taskId";
                cmd.Parameters.AddWithValue("@completionDate", null);
                cmd.Parameters.AddWithValue("@taskId", taskId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Task updated!");
                }
                else
                {
                    Console.WriteLine("Error: Task not updated.");
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
