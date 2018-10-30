using System;

namespace ProductionPlanning.ConfigurationTool.Database.Tables
{
    public class PlaneoLicence
    {
        public int Id { get; set; }
        public Guid LicenceNumber { get; set; }
        public string LicenceName { get; set; }
        public int MaxNumberOfUsers { get; set; }
        public Client Client { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Description { get; set; }
    }
}
