using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionPlanning.ConfigurationTool.Database.Tables
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientNumber { get; set; }
    }
}
