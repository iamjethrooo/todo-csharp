using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public class DatabaseConfig
    {

        public string GetConnectionString()
        {
            return @"server=localhost;userid=root;password=;database=todo";
        }
    }
}
