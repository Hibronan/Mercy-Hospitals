using mercy.Model;
using mercy.ViewModel;
using MySql.Data.MySqlClient;
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

namespace mercy.UI.Admin
{
    /// <summary>
    /// Interaction logic for Admin2.xaml
    /// </summary>
    public partial class Admin2 : UserControl
    {
        
        public Admin2()
        {
            
            InitializeComponent();
        }

        private void Search_btn_click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            User userRes = new User();
            UserViewModel userViewModel = new UserViewModel();

            user.SetUserId(Convert.ToInt32(search.Text));
            userRes = userViewModel.SearchUserById(user);

            f_name.Text = userRes.GetFirstName();
            l_name.Text = userRes.GetLast_name();
            age.Text = Convert.ToString(userRes.GetAge());
            address.Text = userRes.GetAddress();
            contact.Text = Convert.ToString(userRes.GetContactNumber());
            email.Text = userRes.GetEmail();
            userid.Text = Convert.ToString(userRes.GetUserId());
            password.Text = userRes.GetPassWord();
            user_type.Text = userRes.GetUserType();

            //String connectionString = "datasource=127.0.0.1;port=3306;username=root;password=root;database=mercydb;";

            //String query = "SELECT * FROM user WHERE iduser=" + Convert.ToInt32(search.Text);/*user.GetUserId()*/

            //MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            //MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            //commandDatabase.CommandTimeout = 60;
            //MySqlDataReader reader;
            //try
            //{
            //    databaseConnection.Open();
            //    reader = commandDatabase.ExecuteReader();
            //    reader.Read();

            //    f_name.Text = reader.GetString(1);
            //    l_name.Text = reader[2].ToString();
            //    age.Text = reader[3].ToString();
            //    address.Text = reader[9].ToString();
            //    contact.Text = reader[5].ToString();
            //    email.Text = reader[6].ToString();
            //    userid.Text = reader[0].ToString();
            //    password.Text = reader[8].ToString();
            //    user_type.Text = reader[7].ToString();

            //    reader.Close();



            //    databaseConnection.Close();



            //}
            //catch (Exception ex)
            //{
            //    // Ops, maybe the id doesn't exists ?
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Cancel_btn(object sender, RoutedEventArgs e)
        {
            f_name.Clear();
            l_name.Clear();
            age.Clear();
            contact.Clear();
            email.Clear();
            password.Clear();
            //validpassword.Clear();
            address.Clear();
            //genderCombobox.SelectedIndex = -1;
            user_type.Clear();
            userid.Clear();
            search.Clear();
        }

        private void Delete_btn(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Do you want to remove this User?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {


                User user = new User();
                // User userRes = new User();
                UserViewModel userViewModel = new UserViewModel();
                user.SetUserId(Convert.ToInt32(userid.Text));

                userViewModel.DeleteUser(user);
            }
            else {
                return;
            }

        }

        private void Update_btn(object sender, RoutedEventArgs e)
        {
            User user = new User();
            User userRes = new User();
            UserViewModel userViewModel = new UserViewModel();
            //userRes = userViewModel.SearchUserById(user);

            user.SetUserId(Convert.ToInt32(search.Text));
            user.SetFirstName(f_name.Text);
            user.SetLastName(l_name.Text);
            user.SetAge(Convert.ToInt32(age.Text));
            user.SetAddress(address.Text);
            user.SetContactNumber(Convert.ToInt32(contact.Text));
            user.SetEmail(email.Text);
            user.SetUserId(Convert.ToInt32(userid.Text));
            user.SetPassWord(password.Text);
            user.SetUserType(user_type.Text);

            userViewModel.UpdateUser(user);
        }

        
    }
}
