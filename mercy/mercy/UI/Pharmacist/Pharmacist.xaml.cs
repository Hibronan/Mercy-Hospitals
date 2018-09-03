using mercy.UI.Pharmacist;
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
using System.Windows.Shapes;

namespace mercy
{
    /// <summary>
    /// Interaction logic for Pharmacist.xaml
    /// </summary>
    public partial class Pharmacist : Window
    {
        public Pharmacist()
        {
            InitializeComponent();
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new PharmacyBilling());

        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListviewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new PharmacyBilling());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new PharmacyProducts());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new PharmacyReport());
                    break;
               /* case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Pharmacist());
                    break;*/
                default:
                    break;
            }
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void MoveCursorMenu(int index)
        {
            TriansitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (177 + (50 * index)), 0, 0);
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
