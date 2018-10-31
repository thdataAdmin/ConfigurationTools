using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using ProductionPlanning.LicenceManager.Model;
using ProductionPlanning.LicenceManager.Properties;

namespace ProductionPlanning.LicenceManager.Database
{
    public class LicenceDatabaseHandler
    {
        public List<Licence> GetLicences()
        {
            var licences = new List<Licence>();

            var connection = new SQLiteConnection(Resources.ConnStr);

            try
            {
                connection.Open();

                var command = new SQLiteCommand("select * from Licence", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var licence = new Licence
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

        public Licence GetLicence(int licenceId)
        {
            var licence = new Licence();

            var connection = new SQLiteConnection(Resources.ConnStr);

            try
            {
                connection.Open();

                var command = new SQLiteCommand("select * from Licence where Id = @licenceId", connection);

                command.Parameters.Add(new SQLiteParameter("@licenceId", licenceId));

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    licence = new Licence
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        LicenceNumber = Guid.Parse(reader["LicenceNumber"].ToString()),
                        LicenceName = reader["LicenceName"].ToString(),
                        MaxNumberOfUsers = Convert.ToInt32(reader["MaxNumberOfUsers"]),
                        ExpiryDate = DateTime.Parse(reader["ExpiryDate"].ToString()),
                        Description = reader["Description"].ToString(),
                        Modules = GetLicenceModules(licenceId)
                    };

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

            return licence;
        }

        private List<Module> GetLicenceModules(int licenceId)
        {
            var modules = new List<Module>();

            return modules;
        }

        public long CreateClient(Client currentClient)
        {
            long clientId = 0;

            var connection = new SQLiteConnection(Resources.ConnStr);

            try
            {
                connection.Open();

                var command = new SQLiteCommand("Insert into Client (ClientName, ClientNumber) values (@clientName, @clientNumber);select last_insert_rowid();", connection)
                {
                    CommandType = System.Data.CommandType.Text
                };

                command.Parameters.Add(new SQLiteParameter("@clientName", currentClient.ClientName));
                command.Parameters.Add(new SQLiteParameter("@clientNumber", currentClient.ClientNumber));

                clientId = (long)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return clientId;
        }

        public List<Client> GetClients()
        {
            var clients = new List<Client>();

            var connection = new SQLiteConnection(Resources.ConnStr);

            try
            {
                connection.Open();

                var command = new SQLiteCommand("select * from Client", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var client = new Client
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        ClientName = reader["ClientName"].ToString(),
                        ClientNumber = reader["ClientNumber"].ToString()
                    };

                    clients.Add(client);
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

            return clients;
        }

        public void AddModules(List<Module> modules)
        {
            var connection = new SQLiteConnection(Resources.ConnStr);

            try
            {
                connection.Open();

                modules.ForEach(m =>
                {
                    var command = new SQLiteCommand("Insert into Module (ModuleName, DisplayName, IsBaseModule) values (@moduleName, @displayName, @isBaseModule);", connection)
                    {
                        CommandType = System.Data.CommandType.Text
                    };

                    command.Parameters.Add(new SQLiteParameter("@moduleName", m.ModuleName));
                    command.Parameters.Add(new SQLiteParameter("@displayName", m.DisplayName));
                    command.Parameters.Add(new SQLiteParameter("@isBaseModule", m.IsBaseModule));

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Module> GetModules()
        {
            var modules = new List<Module>();

            var connection = new SQLiteConnection(Resources.ConnStr);

            try
            {
                connection.Open();

                var command = new SQLiteCommand("select * from Module", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var module = new Module
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        ModuleName = reader["ModuleName"].ToString(),
                        DisplayName = reader["DisplayName"].ToString(),
                        IsBaseModule = Convert.ToBoolean(reader["IsBaseModule"])
                    };

                    modules.Add(module);
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

            return modules;
        }

        public long CreateLicence(Licence licence)
        {
            long licenceId = 0;

            var connection = new SQLiteConnection(Resources.ConnStr);

            try
            {
                connection.Open();

                var command = new SQLiteCommand("Insert into Licence (LicenceNumber, LicenceName, MaxNumberOfUsers, ExpiryDate, Description, ClientId) " +
                                                "values (@LicenceNumber, @LicenceName, @MaxNumberOfUsers, @ExpiryDate, @Description, @ClientId);select last_insert_rowid();", connection)
                {
                    CommandType = System.Data.CommandType.Text
                };

                command.Parameters.Add(new SQLiteParameter("@LicenceNumber", licence.LicenceNumber.ToString()));
                command.Parameters.Add(new SQLiteParameter("@LicenceName", licence.LicenceName));
                command.Parameters.Add(new SQLiteParameter("@MaxNumberOfUsers", licence.MaxNumberOfUsers));

                command.Parameters.Add(licence.ExpiryDate != null
                    ? new SQLiteParameter("@ExpiryDate", licence.ExpiryDate.Value.ToString("yyyy-MM-dd"))
                    : new SQLiteParameter("@ExpiryDate", DBNull.Value));

                command.Parameters.Add(new SQLiteParameter("@Description", licence.Description));
                command.Parameters.Add(new SQLiteParameter("@ClientId", licence.Client.Id));

                licenceId = (long)command.ExecuteScalar();

                CreateLicenceModule(licenceId, licence.Modules);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return licenceId;
        }

        private void CreateLicenceModule(long licenceId, List<Module> licenceModules)
        {
            var connection = new SQLiteConnection(Resources.ConnStr);

            try
            {
                connection.Open();

                licenceModules.ForEach(m =>
                {
                    var command = new SQLiteCommand("Insert into LicenceModule (LicenceId, ModuleId) values (@LicenceId, @ModuleId);", connection)
                    {
                        CommandType = System.Data.CommandType.Text
                    };

                    command.Parameters.Add(new SQLiteParameter("@LicenceId", licenceId));
                    command.Parameters.Add(new SQLiteParameter("@ModuleId", m.Id));

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateLicence(Licence licence)
        {
            var connection = new SQLiteConnection(Resources.ConnStr);

            try
            {
                connection.Open();

                var command = new SQLiteCommand("Update Licence set LicenceName = @LicenceName, " +
                                                "MaxNumberOfUsers = @MaxNumberOfUsers, ExpiryDate = @ExpiryDate, " +
                                                "Description = @Description, ClientId = @ClientId where Id = @licenceId;", connection)
                {
                    CommandType = System.Data.CommandType.Text
                };

                command.Parameters.Add(new SQLiteParameter("@LicenceName", licence.LicenceName));
                command.Parameters.Add(new SQLiteParameter("@MaxNumberOfUsers", licence.MaxNumberOfUsers));

                command.Parameters.Add(licence.ExpiryDate != null
                    ? new SQLiteParameter("@ExpiryDate", licence.ExpiryDate.Value.ToString("yyyy-MM-dd"))
                    : new SQLiteParameter("@ExpiryDate", DBNull.Value));

                command.Parameters.Add(new SQLiteParameter("@Description", licence.Description));
                command.Parameters.Add(new SQLiteParameter("@ClientId", licence.Client.Id));
                command.Parameters.Add(new SQLiteParameter("@licenceId", licence.Id));

                command.ExecuteNonQuery();

                DeleteLicenceModules(licence.Id);

                CreateLicenceModule(licence.Id, licence.Modules);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void DeleteLicenceModules(long licenceId)
        {
            var connection = new SQLiteConnection(Resources.ConnStr);

            try
            {
                connection.Open();

                var command = new SQLiteCommand("Delete from LicenceModule where LicenceId = @licenceId;", connection)
                {
                    CommandType = System.Data.CommandType.Text
                };
                
                command.Parameters.Add(new SQLiteParameter("@licenceId", licenceId));

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
