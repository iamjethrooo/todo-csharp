using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public TaskList(int id, string name, int userId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            UserId = userId;
            CreatedAt = createdAt;
        }
    }

    public class TaskListDAO
    {
        private MySqlConnection connection;

        public TaskListDAO()
        {
            connection = new MySqlConnection(new DatabaseConfig().GetConnectionString());
        }
    }
}
