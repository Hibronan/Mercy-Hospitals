using mercy.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace mercy.ViewModel
{
    class PharmacyBillViewModel
    {
        MySqlConnection connection = new MySqlConnection("SERVER = localhost; DATABASE=mercyDb;UID=root;PASSWORD=root;");


        #region Insert Bill
        public bool Inert_Bill(PharmacyBill t)
        {
            bool isSuccess = false;
            try
            {
                String insertSalesQuery = "INSERT INTO mercyDb.pharmacy_bill(id_Bill, Product_Id, Quantity, SubTotal, Bill_Date, Added_by) VALUES (@id_Bill, @Product_Id, @Quantity, @SubTotal,@Bill_Date, @Added_by)";

                MySqlCommand insertCmd = new MySqlCommand(insertSalesQuery, connection);
                insertCmd.Parameters.AddWithValue("@id_Bill", t.id_Bill);
                insertCmd.Parameters.AddWithValue("@Product_Id", t.Product_Id);
                insertCmd.Parameters.AddWithValue("@Quantity", t.Quantity);
                insertCmd.Parameters.AddWithValue("@SubTotal", t.SubTotal);
                insertCmd.Parameters.AddWithValue("@Bill_Date", t.Bill_Date);
                insertCmd.Parameters.AddWithValue("@Added_by", t.Added_by);

                connection.Open();
                object o = insertCmd.ExecuteNonQuery();
                if (o != null)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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

            return isSuccess;
        }
        #endregion

    }
}
