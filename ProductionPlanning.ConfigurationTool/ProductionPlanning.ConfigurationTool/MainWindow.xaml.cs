using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProductionPlanning.ConfigurationTool.Database;
using ProductionPlanning.ConfigurationTool.ViewModel;

namespace ProductionPlanning.ConfigurationTool
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            try
            {
                var licences = new LicenceDatabaseHandler().GetLicences();

                MessageBox.Show(licences.First().LicenceName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}|{ex.InnerException?.Message}");
            }
        }
    }
}
