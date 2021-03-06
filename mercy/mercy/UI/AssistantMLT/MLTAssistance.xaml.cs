﻿using mercy.UI.AssistantMLT;
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
    /// Interaction logic for MLTAssistance.xaml
    /// </summary>
    public partial class MLTAssistance : Window
    {
        public MLTAssistance()
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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListviewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new MLT1());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new MLT2());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new MLT3());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new MLT4());
                    break;
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
