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
    class MedicineService
    {
        MySqlConnection connection = new MySqlConnection("SERVER = localhost; DATABASE=mercyDb;UID=root;PASSWORD=root;");

        public DataTable Select()
        {

            MySqlCommand newCmd = new MySqlCommand("select * from medicine", connection);
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


        public void Insert(Medicine medicine)
        {

            String insertMedicineQuery = "INSERT INTO mercyDb.medicine(m_Id, m_name, m_companyName, m_qty, m_cost, m_sellingPrice, m_mDate, m_expDate) VALUES (@Id,@Name,@CompanyName,@Qty, @Cost, @Sprice, @MenuDate, @ExpDate)";

            connection.Open();
            MySqlCommand insertCmd = new MySqlCommand(insertMedicineQuery, connection);
            insertCmd.Parameters.AddWithValue("@Id", medicine.Id);
            insertCmd.Parameters.AddWithValue("@Name", medicine.Name);
            insertCmd.Parameters.AddWithValue("@CompanyName", medicine.CompanyName);
            insertCmd.Parameters.AddWithValue("@Qty", medicine.Qty);
            insertCmd.Parameters.AddWithValue("@Cost", medicine.Cost);
            insertCmd.Parameters.AddWithValue("@Sprice", medicine.Sprice);
            insertCmd.Parameters.AddWithValue("@MenuDate", medicine.MenuDate);
            insertCmd.Parameters.AddWithValue("@ExpDate", medicine.ExpDate);

            try
            {
                if (insertCmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Medicine Added");
                }
                else
                {
                    MessageBox.Show("Medicine not Added Retry");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();


        }
        public void Update(Medicine medicine)
        {

            String UpdateMedicineQuery = "UPDATE mercyDb.medicine SET m_Id = @Id , m_name = @Name, m_companyName = @CompanyName, m_qty = @Qty , m_cost = @Cost, m_sellingPrice = @Sprice, m_mDate= @MenuDate, m_expDate = @ExpDate WHERE m_Id=@Id";

            connection.Open();
            MySqlCommand updateCmd = new MySqlCommand(UpdateMedicineQuery, connection);
            updateCmd.Parameters.AddWithValue("@Id", medicine.Id);
            updateCmd.Parameters.AddWithValue("@Name", medicine.Name);
            updateCmd.Parameters.AddWithValue("@CompanyName", medicine.CompanyName);
            updateCmd.Parameters.AddWithValue("@Qty", medicine.Qty);
            updateCmd.Parameters.AddWithValue("@Cost", medicine.Cost);
            updateCmd.Parameters.AddWithValue("@Sprice", medicine.Sprice);
            updateCmd.Parameters.AddWithValue("@MenuDate", medicine.MenuDate);
            updateCmd.Parameters.AddWithValue("@ExpDate", medicine.ExpDate);

            try
            {
                if (updateCmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Medicine Update Successfully");

                }
                else
                {
                    MessageBox.Show("Medicine not updated Retry");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();


        }
        public void Delete(Medicine medicine)
        {

            String DeleteMedicineQuery = "DELETE FROM mercyDb.medicine WHERE (m_Id=@Id)";

            connection.Open();
            MySqlCommand deleteCmd = new MySqlCommand(DeleteMedicineQuery, connection);
            deleteCmd.Parameters.AddWithValue("@Id", medicine.Id);

            try
            {
                if (deleteCmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Medicine Deleted Successfully");

                }
                else
                {
                    MessageBox.Show("Retry");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();


        }
        public DataTable Search(string keyword)
        {

            MySqlCommand newCmd = new MySqlCommand("select * from medicine WHERE m_Id LIKE'%" + keyword + "%' OR  m_name LIKE'%" + keyword + "%'  OR  m_companyName LIKE'%" + keyword + "%' ", connection);
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

        #region get id from name
        public Medicine GetMedicineIdFrmName(string name)
        {
            Medicine medicine = new Medicine();

            //MySqlCommand newCmd = new MySqlCommand("select m_Id from medicine WHERE m_name LIKE'%" + name + "%' ", connection);
            string newcmd = "select m_Id from medicine WHERE m_name LIKE'%" + name + "%' ";
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(newcmd, connection);
                connection.Open();
                // dt.Load(newCmd.ExecuteReader());
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    medicine.Id = int.Parse(dt.Rows[0]["m_Id"].ToString());
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

            return medicine;
        }
        #endregion
    }
}
