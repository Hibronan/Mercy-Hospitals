using mercy.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace mercy.ViewModel
{
    class PharmacySaleViewModel
    {
        MySqlConnection connection = new MySqlConnection("SERVER = localhost; DATABASE=mercyDb;UID=root;PASSWORD=root;");

        #region insert Sales
        public bool Inert_Sales(PharmacySale t, out int SalesId)
        {
            bool isSuccess = false;
            SalesId = -1;
            try
            {
                String insertSalesQuery = "INSERT INTO mercyDb.pharmacy_Sales(id_Sale, Total, Sale_Date, Discount, Added_by) VALUES (@id_Sale, @Total, @Sale_Date, @Discount, @Added_by); SELECT @@IDENTITY";

                MySqlCommand insertCmd = new MySqlCommand(insertSalesQuery, connection);
                insertCmd.Parameters.AddWithValue("@id_Sale", t.id_Sale);
                insertCmd.Parameters.AddWithValue("@Total", t.Total);
                insertCmd.Parameters.AddWithValue("@Sale_Date", t.Sale_Date);
                insertCmd.Parameters.AddWithValue("@Discount", t.Discount);
                insertCmd.Parameters.AddWithValue("@Added_by", t.Added_by);

                connection.Open();
                object o = insertCmd.ExecuteNonQuery();
                if (o != null)
                {
                    SalesId = int.Parse(o.ToString());
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
        #region Select all
        public DataTable SelectAll()
        {

            MySqlCommand newCmd = new MySqlCommand("select * from pharmacy_sales", connection);
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                dt.Load(newCmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
        #endregion

    }
}
