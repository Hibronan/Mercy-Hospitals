using mercy.Model;
using mercy.ViewModel;
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
    /// Interaction logic for ResultUser.xaml
    /// </summary>
    public partial class ResultUser : UserControl
    {
        public ResultUser()
        {
            InitializeComponent();
            this.printData();
        }
        public void printData() {

            UserViewModel userViewModel = new UserViewModel();
            User user = userViewModel.LastAddedRow();

            UserId.Content = Convert.ToString( user.GetUserId());
            f_name.Content = Convert.ToString(user.GetFirstName());
            age.Content = Convert.ToString(user.GetAge());
            l_name.Content = Convert.ToString(user.GetLast_name());
            contact.Content = Convert.ToString(user.GetContactNumber());
            email.Content = Convert.ToString(user.GetEmail());
            address.Content = Convert.ToString(user.GetAddress());
            password.Content = Convert.ToString(user.GetPassWord());
            typeCombobox.Content = Convert.ToString(user.GetUserType());
            genderCombobox.Content = Convert.ToString(user.GetGender());
        }

        private void Back_btn_click(object sender, RoutedEventArgs e)
        {
            //var backWindow = new Window1();
            //backWindow.Show();
            //backWindow.DataContext = new ViewModel1();
            //CloseWindow();
        }

        private void Submit_btn_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
