using mercy.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace mercy.UI.Pharmacist
{
    /// <summary>
    /// Interaction logic for PharmacyReport.xaml
    /// </summary>
    public partial class PharmacyReport : UserControl
    {
        PharmacySaleViewModel pharmacySaleViewModel = new PharmacySaleViewModel();
        DataTable dt = new DataTable();

        public PharmacyReport()
        {
            InitializeComponent();



            dt = pharmacySaleViewModel.SelectAll();
            SalesGrid.DataContext = dt;
        }


        private void Sale_Search(object sender, RoutedEventArgs e)
        {

        }

        private void Sales_Print(object sender, RoutedEventArgs e)
        {

        }

        private void Sales_Filter(object sender, RoutedEventArgs e)
        {

        }

        private void Sales_LoadFullTb(object sender, RoutedEventArgs e)
        {

            dt = pharmacySaleViewModel.SelectAll();
            SalesGrid.DataContext = dt;

        }
    }
}
