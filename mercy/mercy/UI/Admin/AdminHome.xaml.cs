using mercy.Model;
using mercy.Validation;
using mercy.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : UserControl
    {
        string gender,usertype;
       

        public AdminHome()
        {
            
            InitializeComponent();
        }

        private void Cancel_btn_click(object sender, RoutedEventArgs e)
        {
            this.Clear();
        }

        private void Reset_btn_click(object sender, RoutedEventArgs e)
        {

            this.Clear();

        }

        //private void Email_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    bool result = ValidatorExtensions.IsValidEmailAddress(email.Text);
        //}

        private void Submit_btn_click(object sender, RoutedEventArgs e)
        {
            UserViewModel userViewModel=new UserViewModel();
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=root;database=mercydb;";

            

            //if (f_name.Text == null)
            //{
            //    MessageBox.Show("Fill the First Name");
            //}



            //if(f_name.Text.Length == 0 || l_name.Text.Length == 0)
            //{ 
            //    MessageBox.Show("Enter an correct Name.");
            //    f_name.Focus();
            //}else

            if (f_name.Text.Length == 0 || l_name.Text.Length == 0)
            {
                MessageBox.Show("Enter an correct Name.");
                f_name.Focus();
                return;
            }

            //if (email.Text.Length == 0 || password.Password.Length == 0)
            //{
            //    MessageBox.Show("Enter an email.");
            //    email.Focus();
            //}

            if (!Regex.IsMatch(email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Enter a valid email.");
                email.Select(0, email.Text.Length);
                email.Focus();
                return;
            }

            if (Convert.ToInt32(age.Text)>90 || Convert.ToInt32(age.Text)<1) {
                MessageBox.Show("Enter Valid Age");
                age.Focus();
                return;
            }
            if (contact.Text.Length <10 || contact.Text.Length >10)
            {
                MessageBox.Show("Please enter Valid Contact Number");
                password.Focus();
                return;
            }
           if(((ComboBoxItem)genderCombobox.SelectedItem).Content.ToString().Length == 0){
                MessageBox.Show("Please Select correct Gender");
                genderCombobox.Focus();
                return;
            }
            if (((ComboBoxItem)typeCombobox.SelectedItem).Content.ToString().Length == 0)
            {
                MessageBox.Show("Please Select correct User Type");
                genderCombobox.Focus();
                return;
            }

            if (password.Password.Length == 0 || validpassword.Password.Length == 0)
            {
                MessageBox.Show("Please enter values");
                password.Focus();
                return;
            }
            if (password.Password.ToString() != validpassword.Password.ToString())
            {
                MessageBox.Show("Password not matching");
                validpassword.Focus();
                return;
            }

            gender = ((ComboBoxItem)genderCombobox.SelectedItem).Content.ToString();
            usertype = ((ComboBoxItem)typeCombobox.SelectedItem).Content.ToString();
            string query = "INSERT INTO user(firstName,lastName,age,gender,contact_number,email,userType,pw,address) VALUES ('" + f_name.Text + "','" + l_name.Text + "'," + Convert.ToInt32(age.Text) + ",'" + gender + "'," + Convert.ToInt32(contact.Text) + ",'" + email.Text + "','" + usertype + "','" + password.Password.ToString() + "','" + address.Text +"')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                // Succesfully updated
                MessageBox.Show("Successfully user added");
                databaseConnection.Close();

                
                
                User user = userViewModel.LastAddedRow();
                UserId.Text = Convert.ToString(user.GetUserId());
            }
            catch (Exception ex)
            {
                // Ops, maybe the id doesn't exists ?
                MessageBox.Show(ex.Message);
            }


        }
        private void NumberValidationAge(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void Clear() {

            f_name.Clear();
            l_name.Clear();
            age.Clear();
            contact.Clear();
            email.Clear();
            password.Clear();
            validpassword.Clear();
            address.Clear();
            genderCombobox.SelectedIndex = -1;
            typeCombobox.SelectedIndex = -1;
        }
    }
}
