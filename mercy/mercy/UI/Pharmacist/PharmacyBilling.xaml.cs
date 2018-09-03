using mercy.Model;
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
    /// Interaction logic for PharmacyBilling.xaml
    /// </summary>
    public partial class PharmacyBilling : UserControl
    {
        public PharmacyBilling()
        {
            InitializeComponent();
        }

        MedicineService medicineService = new MedicineService();
        Medicine medicine1 = new Medicine();
        private void Billing_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keywords = Billing_Search.Text;

            if (keywords != null)
            {
                DataTable dt = medicineService.Search(keywords);
                BillingSearchGrid.DataContext = dt;
            }
            else
            {
                DataTable dt = medicineService.Select();
                BillingSearchGrid.DataContext = dt;
            }
        }

        private void BillingSearchGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_Selected = gd.SelectedItem as DataRowView;
            if (row_Selected != null)
            {
                M_Id.Text = row_Selected["m_Id"].ToString();
            }
        }

        private void Billing_Add(object sender, RoutedEventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }



        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void BillingGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
