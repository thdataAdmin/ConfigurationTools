using System.Linq;
using System.Windows.Forms;
using ProductionPlanning.LicenceManager.Database;
using ProductionPlanning.LicenceManager.Model;

namespace ProductionPlanning.LicenceManager
{
    public partial class FrmLicenceManager : Form
    {
        public FrmLicenceManager()
        {
            InitializeComponent();
            var licenceDatabaseHandler = new LicenceDatabaseHandler();

            var modules = licenceDatabaseHandler.GetModules();
            var newModules = ModulesConfig.Modules.Where(module => !modules.Select(m => m.ModuleName).Contains(module.ModuleName));

            if(newModules.Any())
                licenceDatabaseHandler.AddModules(ModulesConfig.Modules);
        }

        private void lizenzGenerierenToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            var window = new FrmGenerateLicence();
            window.ShowDialog();
        }
    }
}
