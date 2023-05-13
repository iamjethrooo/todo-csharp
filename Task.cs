using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ListId { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        public Task(int id, string name, int listId, DateTime? completionDate)
        {
            this.Id = id;
            this.Name = name;
            this.ListId = listId;
            this.CompletionDate = completionDate;
        }
    }

    public class TaskDAO
    {
        private MySqlConnection connection;

        public TaskDAO() {
            connection = new MySqlConnection(new DatabaseConfig().GetConnectionString());
        }
        public static int GetLastInsertedId()
        {
            MySqlConnection connection = new MySqlConnection(new DatabaseConfig().GetConnectionString());
            int id = 0;

            try
            {
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT LAST_INSERT_ID()";

                id = Convert.ToInt32(cmd.ExecuteScalar());
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
    }
}
