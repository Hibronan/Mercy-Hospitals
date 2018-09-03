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
    /// Interaction logic for PharmacyProducts.xaml
    /// </summary>
    public partial class PharmacyProducts : UserControl
    {
        public PharmacyProducts()
        {
            InitializeComponent();

            //MySqlCommand newCmd = new MySqlCommand("select * from medicine", connection);

            //connection.Open();
            //DataTable dt = new DataTable();
            //dt.Load(newCmd.ExecuteReader());
            //connection.Close();
            DataTable dt = new DataTable();


            dt = medicineService.Select();
            MedicineGrid.DataContext = dt;
            MedicineGrid1.DataContext = dt;
        }

        MedicineService medicineService = new MedicineService();
        Medicine medicine1 = new Medicine();
       
        DateTime date = Convert.ToDateTime(DateTime.Now.ToString());

        private void Add_medicine_add(object sender, RoutedEventArgs e)
        {
            //id++;
            //String insertMedicineQuery = "INSERT INTO mercyDb.medicine(m_Id, m_name, m_companyName, m_qty, m_cost, m_sellingPrice, m_mDate, m_expDate) VALUES ('" + id + "','" + M_name.Text + "','" + M_companyName.Text + "','" + M_Qty.Text + "','" + M_cost.Text + "','" + M_sPrice.Text + "','" + M_manuDate.Text + "','" + M_expDate.Text + "')";
            //connection.Open();
            //MySqlCommand insertCmd = new MySqlCommand(insertMedicineQuery, connection);

            //try
            //{
            //    if (insertCmd.ExecuteNonQuery() == 1)
            //    {
            //        MessageBox.Show("Medicine Added");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Medicine not Added Retry");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //connection.Close();
            bool isSuccess = false;
            bool isSuccessDate = false;

            try
            {
                medicine1.Name = M_name.Text;
                medicine1.CompanyName = M_companyName.Text;
                medicine1.Qty = Convert.ToInt32(M_Qty.Text);

                if (Convert.ToDouble(M_cost.Text) < Convert.ToDouble(M_sPrice.Text))
                {
                    medicine1.Cost = Convert.ToDouble(M_cost.Text);
                    medicine1.Sprice = Convert.ToDouble(M_sPrice.Text);
                    isSuccess = true;
                }
                else
                {

                    MessageBox.Show("Cost is Greater than the Selling");
                    isSuccess = false;
                }
                if (Convert.ToDateTime(M_expDate.Text) > Convert.ToDateTime(M_manuDate.Text) && Convert.ToDateTime(M_expDate.Text) > date)
                {
                    medicine1.MenuDate = Convert.ToDateTime(M_manuDate.Text);
                    medicine1.ExpDate = Convert.ToDateTime(M_expDate.Text);
                    isSuccessDate = true;
                }
                else
                {
                    MessageBox.Show("Check the Dates");
                    isSuccessDate = false;
                }
                if (isSuccess && isSuccessDate)
                {
                    medicineService.Insert(medicine1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Clear();
            }



        }

        private void Add_medicine_reset(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Add_medicine_LoadFullTb(object sender, RoutedEventArgs e)
        {
            //MySqlCommand newCmd = new MySqlCommand("select * from medicine", connection);

            //connection.Open();
            //DataTable dt = new DataTable();
            //dt.Load(newCmd.ExecuteReader());
            //connection.Close();
            //MedicineGrid1.DataContext = dt;


            DataTable dt = new DataTable();

            dt = medicineService.Select();
            MedicineGrid1.DataContext = dt;

        }

        private void DataGrid_AddMedicine(object sender, MouseButtonEventArgs e)
        {


        }

        private void M_upSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keywords = M_upSearch.Text;

            if (keywords != null)
            {
                DataTable dt = medicineService.Search(keywords);
                MedicineGrid.DataContext = dt;
            }
            else
            {
                DataTable dt = medicineService.Select();
                MedicineGrid.DataContext = dt;
            }
        }

        public void Clear()
        {
            M_upId.Text = string.Empty;
            M_upSearch.Text = string.Empty;
            M_upName.Text = string.Empty;
            M_opCompanyName.Text = string.Empty;
            M_upQty.Text = string.Empty;
            M_upCost.Text = string.Empty;
            M_upSellPrice.Text = string.Empty;
            M_upMenuDate.Text = string.Empty;
            M_upExpDate.Text = string.Empty;

            M_name.Text = string.Empty;
            M_companyName.Text = string.Empty;
            M_Qty.Text = string.Empty;
            M_cost.Text = string.Empty;
            M_sPrice.Text = string.Empty;
            M_manuDate.Text = string.Empty;
            M_expDate.Text = string.Empty;
        }
        private void Medicine_reset(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Medicine_update(object sender, RoutedEventArgs e)
        {
            bool isSuccess = false;
            bool isSuccessDate = false;
            try
            {

                medicine1.Id = Convert.ToInt32(M_upId.Text);
                medicine1.Name = M_upName.Text;
                medicine1.CompanyName = M_opCompanyName.Text;
                medicine1.Qty = Convert.ToInt32(M_upQty.Text);
                if (Convert.ToDouble(M_upCost.Text) < Convert.ToDouble(M_upSellPrice.Text))
                {
                    medicine1.Cost = Convert.ToDouble(M_upCost.Text);
                    medicine1.Sprice = Convert.ToDouble(M_upSellPrice.Text);
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
                if (Convert.ToDateTime(M_upExpDate.Text) > Convert.ToDateTime(M_upMenuDate.Text) && Convert.ToDateTime(M_upExpDate.Text) > date)
                {
                    medicine1.MenuDate = Convert.ToDateTime(M_upMenuDate.Text);
                    medicine1.ExpDate = Convert.ToDateTime(M_upExpDate.Text);
                    isSuccessDate = true;
                }
                else
                {
                    MessageBox.Show("Check the Dates");
                    isSuccessDate = false;
                }
                if (isSuccess && isSuccessDate)
                {
                    medicineService.Update(medicine1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                Clear();
            }
        }

        private void Medicine_loadfullTb(object sender, RoutedEventArgs e)
        {
            //MySqlCommand newCmd = new MySqlCommand("select * from medicine", connection);

            //connection.Open();
            //DataTable dt = new DataTable();
            //dt.Load(newCmd.ExecuteReader());
            //connection.Close();
            //MedicineGrid.DataContext = dt;

            DataTable dt = new DataTable();

            dt = medicineService.Select();
            MedicineGrid.DataContext = dt;

        }
        private void MedicineGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();

            dt = medicineService.Select();
            MedicineGrid.DataContext = dt;
        }



        private void MedicineGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_Selected = gd.SelectedItem as DataRowView;
            if (row_Selected != null)
            {
                M_upId.Text = row_Selected["m_Id"].ToString();
                M_upName.Text = row_Selected["m_name"].ToString();
                M_opCompanyName.Text = row_Selected["m_companyName"].ToString();
                M_upQty.Text = row_Selected["m_qty"].ToString();
                M_upCost.Text = row_Selected["m_cost"].ToString();
                M_upSellPrice.Text = row_Selected["m_sellingPrice"].ToString();
                M_upMenuDate.Text = row_Selected["m_mDate"].ToString();
                M_upExpDate.Text = row_Selected["m_expDate"].ToString();
            }

        }

        private void Medicine_Remove(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Did you want to remove this Item ?", "confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                medicine1.Id = Convert.ToInt32(M_upId.Text);
                medicineService.Delete(medicine1);
                Clear();
            }
            else
                return;
        }

        private void Transection_LoadFullTb(object sender, RoutedEventArgs e)
        {

        }

        private void Stock_search(object sender, RoutedEventArgs e)
        {

        }

        private void Stock_loadFulltb(object sender, RoutedEventArgs e)
        {

        }

        private void Stock_addRequset(object sender, RoutedEventArgs e)
        {

        }

        private void Stock_Req_Remove(object sender, RoutedEventArgs e)
        {

        }

        private void Stock_Req_Comfrim(object sender, RoutedEventArgs e)
        {

        }
    }
}
