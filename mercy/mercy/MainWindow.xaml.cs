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
            string userName1 = userName.Text;
            string PW = password.Text;
            Console.WriteLine(userName1);
            Console.WriteLine(PW);

            if ((userName1=="Admin")&&(PW=="1234")) {
                AdminWindow win1 = new AdminWindow();
                win1.Show();
                this.Close();

            } else if ((userName1 == "Account") && (PW == "1234")) {
                AssistantAccountant win1 = new AssistantAccountant();
                win1.Show();
                this.Close();

            } else if ((userName1 == "OPD") && (PW == "1234")) {
                OPDAssistance win1 = new OPDAssistance();
                win1.Show();
                this.Close();

            } else if ((userName1 == "MLT") && (PW == "1234")) {
                MLTAssistance win1 = new MLTAssistance();
                win1.Show();
                this.Close();

            } else if ((userName1 == "EmployeeAssistant") && (PW == "1234")) {
                EmployeeAssistant win1 = new EmployeeAssistant();
                win1.Show();
                this.Close();

            }
            else if ((userName1 == "Manager") && (PW == "1234")){
                Manager win1 = new Manager();
                win1.Show();
                this.Close();

            }
            else if ((userName1 == "Pharmacist") && (PW == "1234")){
                Pharmacist win1 = new Pharmacist();
                win1.Show();
                this.Close();

            }
            else if ((userName1 == "Receptionist") && (PW == "1234")){
                Receptionist win1 = new Receptionist();
                win1.Show();
                this.Close();

            }
            else if ((userName1 == "StoreManager") && (PW == "1234")){
                StoreManager win1 = new StoreManager();
                win1.Show();
                this.Close();

            }
            else{
                MainWindow win1 = new MainWindow();
                win1.Show();
                this.Close();

            }
        }
    }
}
