using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows;
using ProductionPlanning.ConfigurationTool.Database.Tables;

namespace ProductionPlanning.ConfigurationTool.Database
{
    public class LicenceDatabaseHandler
    {
        public List<PlaneoLicence> GetLicences()
        {
            var licences = new List<PlaneoLicence>();

            var connection = new SQLiteConnection("Data Source=prodplandb.sqlite;Version=3;");

            try
            {
                connection.Open();

                var command = new SQLiteCommand("select * from Licence", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var licence = new PlaneoLicence
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        LicenceNumber = Guid.Parse(reader["LicenceNumber"].ToString()),
                        LicenceName = reader["LicenceName"].ToString(),
                        MaxNumberOfUsers = Convert.ToInt32(reader["MaxNumberOfUsers"]),
                        ExpiryDate = DateTime.Parse(reader["ExpiryDate"].ToString()),
                        Description = reader["Description"].ToString()
                    };

                    licences.Add(licence);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return licences;
        }
    }
}
