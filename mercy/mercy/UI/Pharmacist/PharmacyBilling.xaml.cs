using mercy.Model;
using mercy.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
            dateLabel.Content = DateTime.Now.ToString();
        }

        MedicineService medicineService = new MedicineService();
        Medicine medicine1 = new Medicine();
        PharmacyBillViewModel pharmacyBillViewModel = new PharmacyBillViewModel();
        PharmacySaleViewModel pharmacySaleViewModel = new PharmacySaleViewModel();

        DataTable AddedProductsGrid = new DataTable();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            AddedProductsGrid.Columns.Add("Product Name");
            AddedProductsGrid.Columns.Add("Quantity");
            AddedProductsGrid.Columns.Add("Price");
            AddedProductsGrid.Columns.Add("Total");

        }
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
                M_Name.Text = row_Selected["m_Name"].ToString();
                M_price.Text = row_Selected["m_sellingPrice"].ToString();
                M_AvQty.Text = row_Selected["m_qty"].ToString();


            }
        }

        private void Billing_Add(object sender, RoutedEventArgs e)
        {
            string ProductName = M_Name.Text;
            double price = double.Parse(M_price.Text);
            if (M_Qty.Text == "")
            {
                MessageBox.Show("Add The Quantity and Try Again");
            }
            else
            {
                int Qty = int.Parse(M_Qty.Text);

                double Total = price * Qty;

                double subTotal = double.Parse(M_SubTotal.Text);
                subTotal = subTotal + Total;

                if (ProductName == "")
                {
                    MessageBox.Show("Select the Product and Try Again");
                }

                else
                {
                    AddedProductsGrid.Rows.Add(ProductName, Qty, price, Total);

                    BillingGrid.DataContext = AddedProductsGrid;

                    M_SubTotal.Text = subTotal.ToString();

                    M_Name.Text = "";
                    M_price.Text = "";
                    M_Qty.Text = "";
                    M_AvQty.Text = "";

                }
            }


        }
        private void M_Discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = M_Discount.Text;

            if (value == "")
            {
                M_Discount.Text = "0";
                //MessageBox.Show("Please add Discount First");
            }
            else
            {
                double discount = double.Parse(M_Discount.Text);
                double subTotal = double.Parse(M_SubTotal.Text);

                double grandTotal = ((100 - discount) / 100) * subTotal;

                M_TotalAmount.Text = grandTotal.ToString();
            }
        }
        private void M_PaidAmoount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (M_PaidAmoount != null)
            {
                try
                {
                    double grandTotal = double.Parse(M_TotalAmount.Text);
                    double PaidAmount = double.Parse(M_PaidAmoount.Text);
                    double returnAmount = PaidAmount - grandTotal;
                    M_Balance.Text = returnAmount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {

            }


            //if(PaidAmount< grandTotal)
            //{
            //    MessageBox.Show("check the Paid Amount");
            //}
            //else
            //{

            //}
        }
        private void Billing_bill(object sender, RoutedEventArgs e)
        {
            PharmacySale newSale = new PharmacySale();

            newSale.Total = Convert.ToDouble(M_TotalAmount.Text);
            newSale.Sale_Date = DateTime.Now;
            newSale.Discount = Convert.ToInt32(M_Discount.Text);
            newSale.Added_by = 2;

            newSale.PharmacyBill = AddedProductsGrid;

            bool success = false;

            using (TransactionScope scope = new TransactionScope())
            {
                int SaleId = -1;

                bool w = pharmacySaleViewModel.Inert_Sales(newSale, out SaleId);

                for (int i = 0; i < AddedProductsGrid.Rows.Count; i++)
                {
                    PharmacyBill newbill = new PharmacyBill();

                    string productName = AddedProductsGrid.Rows[i][0].ToString();

                    Medicine medicine = medicineService.GetMedicineIdFrmName(productName);

                    newbill.Product_Id = medicine.Id;
                    newbill.Quantity = int.Parse(AddedProductsGrid.Rows[i][1].ToString());
                    newbill.Price = Double.Parse(AddedProductsGrid.Rows[i][2].ToString());
                    newbill.SubTotal = Double.Parse(AddedProductsGrid.Rows[i][3].ToString());
                    newbill.Bill_Date = DateTime.Now;
                    newbill.Added_by = 2;

                    bool y = pharmacyBillViewModel.Inert_Bill(newbill);

                    success = w && y;

                }
                if (success == true)
                {
                    scope.Complete();
                    MessageBox.Show("Bill Added successfully");

                    newBillGen();
                }
                else
                {
                    MessageBox.Show("Bill Failed");
                }

            }


        }
        private void newBillGen()
        {
            BillingGrid.DataContext = null;
            AddedProductsGrid.Rows.Clear();

            M_Name.Text = string.Empty;
            M_price.Text = "0";
            M_Qty.Text = string.Empty;
            M_AvQty.Text = string.Empty;

            M_SubTotal.Text = "0";
            M_TotalAmount.Text = "0";
            M_PaidAmoount.Text = string.Empty;
            M_Balance.Text = string.Empty;
            M_Discount.Text = string.Empty;
        }

        private void Billing_New(object sender, RoutedEventArgs e)
        {
            newBillGen();
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

        private void M_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
