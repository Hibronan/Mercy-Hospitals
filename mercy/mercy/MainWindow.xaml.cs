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

namespace mercy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
          
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

      

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
           
        }

      

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (userName.Text.Length == 0 || password.Password.Length == 0)
            {
                MessageBox.Show ("Enter an email.");
                userName.Focus();
            }
            
            int userName1 =Convert.ToInt32(userName.Text);
            String PW = password.Password.ToString();
            Console.WriteLine(userName1);
            Console.WriteLine(PW);

            User user = new User();
            User userRes = new User();
            UserViewModel userViewModel = new UserViewModel();

            user.SetUserId(Convert.ToInt32(userName.Text));
            userRes = userViewModel.SearchUserById(user);

            Console.WriteLine(userRes.GetFirstName());
            Console.WriteLine(userRes.GetUserId());


            if ((userRes.GetUserType() == "Admin") &&(PW== userRes.GetPassWord())) {
                AdminWindow win1 = new AdminWindow();
                win1.Show();
                this.Close();

            } else if ((userRes.GetUserType() == "Accountant") && (PW == userRes.GetPassWord())) {
                AssistantAccountant win1 = new AssistantAccountant();
                win1.Show();
                this.Close();

            } else if ((userRes.GetUserType() == "OPD") && (PW == userRes.GetPassWord())) {
                OPDAssistance win1 = new OPDAssistance();
                win1.Show();
                this.Close();

            } else if ((userRes.GetUserType() == "MLT") && (PW == userRes.GetPassWord())) {
                MLTAssistance win1 = new MLTAssistance();
                win1.Show();
                this.Close();

            } else if ((userRes.GetUserType() == "Employee Assistant") && (PW == userRes.GetPassWord())) {
                EmployeeAssistant win1 = new EmployeeAssistant();
                win1.Show();
                this.Close();

            }
            else if ((userRes.GetUserType() == "Manager") && (PW == userRes.GetPassWord())){
                Manager win1 = new Manager();
                win1.Show();
                this.Close();

            }
            else if ((userRes.GetUserType() == "Pharmacist") && (PW == userRes.GetPassWord())){
                Pharmacist win1 = new Pharmacist();
                win1.Show();
                this.Close();

            }
            else if ((userRes.GetUserType() == "Receptionist") && (PW == userRes.GetPassWord())){
                Receptionist win1 = new Receptionist();
                win1.Show();
                this.Close();

            }
            else if ((userRes.GetUserType() == "Sttore Manager") && (PW == userRes.GetPassWord())){
                StoreManager win1 = new StoreManager();
                win1.Show();
                this.Close();

            }
            else{
                //MainWindow win1 = new MainWindow();
                //win1.Show();
                //this.Close();
                MessageBox.Show("Invalid Username OR Password");
                password.Clear();
                userName.Clear();
            }
        }
    }
}
