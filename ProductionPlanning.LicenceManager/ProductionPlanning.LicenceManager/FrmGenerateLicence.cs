using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProductionPlanning.LicenceManager.Database;
using ProductionPlanning.LicenceManager.LicenceUtils;
using ProductionPlanning.LicenceManager.Model;

namespace ProductionPlanning.LicenceManager
{
    public partial class FrmGenerateLicence : Form
    {
        public List<Client> Clients { get; set; }
        public LicenceDatabaseHandler LicenceDatabaseHandler { get; set; }
        public Licence CurrentLicence { get; set; }

        public FrmGenerateLicence(Licence licence = null)
        {
            InitializeComponent();

            CurrentLicence = licence;

            LicenceDatabaseHandler = new LicenceDatabaseHandler();

            Clients = new List<Client> { new Client() };
            Clients.AddRange(LicenceDatabaseHandler.GetClients());

            lbModules.DisplayMember = "DisplayName";
            lbModules.ValueMember = "Id";

            if (CurrentLicence != null)
            {
                txtLicenceNumber.Text = CurrentLicence.LicenceNumber.ToString();
                txtLicenceName.Text = CurrentLicence.LicenceName;
                txtDescription.Text = CurrentLicence.Description;
                nudNumberOfUsers.Value = CurrentLicence.MaxNumberOfUsers;

                if(CurrentLicence.ExpiryDate.HasValue)
                    dtpExpiryDate.Value = CurrentLicence.ExpiryDate.Value;
            }
            else
            {
                txtLicenceNumber.Text = Guid.NewGuid().ToString();
            }
            
            FillClients();
            FillAvailableModules();

            SubscribeEvents();
            ValidateFields();
        }

        private void SubscribeEvents()
        {
            txtLicenceNumber.KeyUp += TxtKeyUp;
            txtLicenceName.KeyUp += TxtKeyUp;
        }

        private void FillClients()
        {
            cmbCustomer.DataSource = null;
            
            cmbCustomer.DataSource = Clients;
            cmbCustomer.DisplayMember = "ClientName";
            cmbCustomer.ValueMember = "Id";

            if (CurrentLicence != null)
            {
                cmbCustomer.SelectedItem = CurrentLicence.Client;
            }
        }

        private void FillAvailableModules()
        {
            var availableModules = LicenceDatabaseHandler.GetModules();
            lbAvailableModules.DataSource = availableModules;

            lbAvailableModules.DisplayMember = "DisplayName";
            lbAvailableModules.ValueMember = "Id";

            if (CurrentLicence != null)
            {
                FillModules(CurrentLicence.Modules);
            }
        }

        private void btnModuleAdd_Click(object sender, EventArgs e)
        {
            var modules = lbAvailableModules.SelectedItems.Cast<Module>();

            FillModules(modules);

            ValidateFields();
        }

        private void FillModules(IEnumerable<Module> modules)
        {
            modules.ToList().ForEach(module =>
            {
                var item = new Module {Id = module.Id, ModuleName = module.ModuleName, DisplayName = module.DisplayName, IsBaseModule = module.IsBaseModule};

                if (lbModules.Items.Cast<Module>().ToList().Find(i => i.ModuleName == item.ModuleName) == null)
                    lbModules.Items.Add(item);
            });
        }

        private void btnModuleRemove_Click(object sender, EventArgs e)
        {
            var items = lbModules.Items.Cast<Module>();
            var selectedItems = lbModules.SelectedItems.Cast<Module>();

            var newItems = items.ToList().Except(selectedItems).ToList();

            lbModules.Items.Clear();

            FillModules(newItems);

            ValidateFields();
        }

        private void llClearDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dtpExpiryDate.CustomFormat = @" ";
        }

        private void dtpExpiryDate_ValueChanged(object sender, EventArgs e)
        {
            dtpExpiryDate.CustomFormat = @"dd.MM.yyyy";
        }

        private void llCreateCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var window = new FrmCreateClient();
            if (window.ShowDialog() == DialogResult.OK)
            {
                var client = window.CurrentClient;

                Clients.Add(client);

                FillClients();

                cmbCustomer.SelectedItem = client;

                window.Close();
            }
        }

        private void btnGenerateLicence_Click(object sender, EventArgs e)
        {
            var licence = new Licence
            {
                LicenceName = txtLicenceName.Text,
                LicenceNumber = Guid.Parse(txtLicenceNumber.Text),
                Client = (Client)cmbCustomer.SelectedItem,
                Description = txtDescription.Text,
                MaxNumberOfUsers = (int)nudNumberOfUsers.Value,
                Modules = lbModules.Items.Cast<Module>().ToList()
            };

            if (!string.IsNullOrWhiteSpace(dtpExpiryDate.Text))
                licence.ExpiryDate = dtpExpiryDate.Value.Date;

            licence.LicenceKey = new LicenceHandler().GenerateLicenceKey(licence);

            if (CurrentLicence == null)
            {
                licence.Id = LicenceDatabaseHandler.CreateLicence(licence);

                btnGenerateLicence.Text = @"Lizenzschlüssel aktualisieren";
            }
            else
            {
                licence.Id = CurrentLicence.Id;
                LicenceDatabaseHandler.UpdateLicence(licence);
            }

            CurrentLicence = licence;
        }

        private void TxtKeyUp(object sender, KeyEventArgs e)
        {
            ValidateFields();
        }

        private void ValidateFields()
        {
            btnGenerateLicence.Enabled = !string.IsNullOrEmpty(txtLicenceNumber.Text) 
                && !string.IsNullOrEmpty(txtLicenceName.Text) 
                && lbModules.Items.Count > 0 && nudNumberOfUsers.Value > 0
                && !string.IsNullOrEmpty(cmbCustomer.Text);
        }

        private void cmbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }

        private void nudNumberOfUsers_ValueChanged(object sender, EventArgs e)
        {
            ValidateFields();
        }
    }
}
