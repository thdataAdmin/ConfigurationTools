using System;
using System.Collections.Generic;

namespace ProductionPlanning.LicenceManager.Model
{
    public class PlaneusLicence
    {
        public Guid LicenceNumber { get; set; }
        public string LicenceName { get; set; }
        public int MaxNumberOfUsers { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string ClientName { get; set; }
        public string ClientNumber { get; set; }
        public string Description { get; set; }
        public List<PlaneusModule> Modules { get; set; }
    }

    public class PlaneusModule
    {
        public string ModuleName { get; set; }
    }
}
