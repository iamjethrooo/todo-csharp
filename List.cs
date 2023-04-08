using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    internal class List
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public List(int id, string name, int userId, DateTime createdAt)
        {
            Id = id;
            Name = name;
            UserId = userId;
            CreatedAt = createdAt;
        }
    }
}
