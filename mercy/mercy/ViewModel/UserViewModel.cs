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
    class UserViewModel
    {
        

        public UserViewModel() {

        }
        public User SearchUserById(User user)
        {
            User userResult = new User();
            String connectionString = "datasource=127.0.0.1;port=3306;username=root;password=root;database=mercydb;";

            String query = "SELECT * FROM user WHERE iduser="+user.GetUserId();

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                reader.Read();

                userResult.SetUserId(Convert.ToInt32( reader[0].ToString()));
                userResult.SetFirstName(reader[1].ToString());
                userResult.SetLastName(reader[2].ToString());
                userResult.SetAge(Convert.ToInt32(reader[3].ToString()));
                userResult.SetGender(reader[4].ToString());
                userResult.SetContactNumber(Convert.ToInt32(reader[5].ToString()) );
                userResult.SetEmail(reader[6].ToString());
                userResult.SetUserType(reader[7].ToString());
                userResult.SetPassWord(reader[8].ToString());
                userResult.SetAddress(reader[9].ToString());

                reader.Close();

                databaseConnection.Close();



            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }


            return userResult;
        }

        public void UpdateUser(User user) {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=root;database=mercydb;";

            //gender = ((ComboBoxItem)genderCombobox.SelectedItem).Content.ToString();
            //usertype = ((ComboBoxItem)typeCombobox.SelectedItem).Content.ToString();


            string query = "UPDATE user SET firstName='"+user.GetFirstName()+"',lastName='"+user.GetLast_name()+"',age="+user.GetAge()+",contact_number="+user.GetContactNumber()+",email='"+user.GetEmail()+"',userType='"+user.GetUserType()+"',pw='"+user.GetPassWord()+"',address='"+user.GetAddress()+ "' WHERE iduser="+user.GetUserId();
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                // Succesfully updated
                MessageBox.Show("Successfully user Details Updated");
                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }

        }
        public void DeleteUser(User user) {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=root;database=mercydb;";

            //gender = ((ComboBoxItem)genderCombobox.SelectedItem).Content.ToString();
            //usertype = ((ComboBoxItem)typeCombobox.SelectedItem).Content.ToString();


            string query = "DELETE FROM user  WHERE iduser=" + user.GetUserId();
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                // Succesfully updated
                MessageBox.Show("Successfully user Details Updated");
                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
        }
        public User LastAddedRow() {
            User userResult = new User();
            String connectionString = "datasource=127.0.0.1;port=3306;username=root;password=root;database=mercydb;";

            String query = "SELECT * FROM user ORDER BY iduser DESC LIMIT 1";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                reader.Read();

                userResult.SetUserId(Convert.ToInt32(reader[0].ToString()));
                  userResult.SetFirstName(reader[1].ToString());
                  userResult.SetLastName(reader[2].ToString());
                  userResult.SetAge(Convert.ToInt32(reader[3].ToString()));
                  userResult.SetGender(reader[4].ToString());
                  userResult.SetContactNumber(Convert.ToInt32(reader[5].ToString()));
                  userResult.SetEmail(reader[6].ToString());
                  userResult.SetUserType(reader[7].ToString());
                  userResult.SetPassWord(reader[8].ToString());
                  userResult.SetAddress(reader[9].ToString());

                reader.Close();

                databaseConnection.Close();



            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }
            return userResult;
        }

    }
}
