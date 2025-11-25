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

namespace ProjecteKanban
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int n_estats = 5;

            for (int i = 0; i < n_estats; i++)
            {
                Border b = new Border();
                b.BorderThickness = new Thickness(0.5);
                b.BorderBrush = Brushes.Gray;
                b.CornerRadius = new CornerRadius(10);
                b.Margin = new Thickness(5);

                TaskGrid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.SetColumn(b, i);
                TaskGrid.Children.Add(b);
            }

            TaskGrid.Margin = new Thickness(5);
        }

        private void AfegirTascaClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
