using System;
using System.Collections.Generic;

namespace ProductionPlanning.LicenceManager.Model
{
    public class Licence
    {
        public long Id { get; set; }
        public Guid LicenceNumber { get; set; }
        public string LicenceName { get; set; }
        public int MaxNumberOfUsers { get; set; }
        public Client Client { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Description { get; set; }
        public string LicenceKey { get; set; }
        public List<Module> Modules { get; set; }
    }
}
