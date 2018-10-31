using System.Linq;
using ProductionPlanning.LicenceManager.Model;

namespace ProductionPlanning.LicenceManager.LicenceUtils
{
    public static class LicenceExtensions
    {
        public static PlaneusLicence ToPlaneusLicence(this Licence licence)
        {
            return new PlaneusLicence
            {
                LicenceNumber = licence.LicenceNumber,
                LicenceName = licence.LicenceName,
                Description = licence.Description,
                ClientName = licence.Client.ClientName,
                ClientNumber = licence.Client.ClientNumber,
                ExpiryDate = licence.ExpiryDate,
                MaxNumberOfUsers = licence.MaxNumberOfUsers,
                Modules = licence.Modules.Select(m => m.ToPlaneusModule()).ToList()
            };
        }

        public static PlaneusModule ToPlaneusModule(this Module module)
        {
            return new PlaneusModule
            {
                ModuleName = module.ModuleName
            };
        }
    }
}
