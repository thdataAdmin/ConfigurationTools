using System;
using System.Windows.Forms;
using ProductionPlanning.LicenceManager.Database;
using ProductionPlanning.LicenceManager.Model;

namespace ProductionPlanning.LicenceManager
{
    public partial class FrmCreateClient : Form
    {
        public Client CurrentClient { get; set; }

        public FrmCreateClient()
        {
            InitializeComponent();
        }

        private void btnCreateClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtClientName.Text) && !string.IsNullOrEmpty(txtClientNumber.Text))
            {
                CurrentClient = new Client
                {
                    ClientName = txtClientName.Text,
                    ClientNumber = txtClientNumber.Text
                };

                CurrentClient.Id = new LicenceDatabaseHandler().CreateClient(CurrentClient);

                DialogResult = DialogResult.OK;
            }
        }
    }
}
