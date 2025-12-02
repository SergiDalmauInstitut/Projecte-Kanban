using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjecteKanban
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenerarColumnes();

            // test
            AfegirTasca(new Tasca("Titol")
            {
                Descripcio = "test",
                DataFi = DateTime.Now
            });
        }

        private void GenerarColumnes()
        {
            string[] nomsEstats = { "To Do", "In Progress", "Review", "Done" };
            int n_estats = nomsEstats.Length;

            for (int i = 0; i < n_estats; i++)
            {
                TaskGrid.ColumnDefinitions.Add(new ColumnDefinition());

                Border b = new Border
                {
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.LightGray,
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(5),
                    Background = new SolidColorBrush(Color.FromRgb(240, 240, 240))
                };

                StackPanel columnaPanel = new StackPanel
                {
                    Margin = new Thickness(5),
                    AllowDrop = true,
                    Tag = i,
                    Background = Brushes.Transparent
                };

                TextBlock titolColumna = new TextBlock
                {
                    Text = nomsEstats[i],
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 10)
                };

                columnaPanel.Children.Add(titolColumna);

                columnaPanel.Drop += Columna_Drop;
                columnaPanel.DragOver += Columna_DragOver;

                b.Child = columnaPanel;
                Grid.SetColumn(b, i);
                TaskGrid.Children.Add(b);
            }
        }

        private void Columna_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TascaVisual)))
            {
                e.Effects = DragDropEffects.Move;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        private void Columna_Drop(object sender, DragEventArgs e)
        {
            TascaVisual tascaArrossegada = e.Data.GetData(typeof(TascaVisual)) as TascaVisual;
            StackPanel panellDesti = sender as StackPanel;

            if (tascaArrossegada != null && panellDesti != null)
            {
                Panel pareAntic = VisualTreeHelper.GetParent(tascaArrossegada) as Panel;
                if (pareAntic != null)
                {
                    if (pareAntic != panellDesti)
                    {
                        pareAntic.Children.Remove(tascaArrossegada);
                        panellDesti.Children.Add(tascaArrossegada);
                    }
                }
            }
        }
        private void AfegirTascaClick(object sender, RoutedEventArgs e)
        {
            FinestraEditarTasca f = new FinestraEditarTasca();
            bool? result = f.ShowDialog();

            if (result == true)
            {
                if (f.Afegir)
                {
                    Tasca novaTasca = f.TascaResultat;

                    TascaVisual tItem = new TascaVisual
                    {
                        TascaData = novaTasca
                    };

                    if (TaskGrid.Children.Count > 0 && TaskGrid.Children[0] is Border b && b.Child is StackPanel sp)
                    {
                        sp.Children.Add(tItem);
                    }
                } else
                {
                    //
                }
            }
        }

        public void AfegirTasca(Tasca tasca)
        {
            if (TaskGrid.Children.Count > 0 && TaskGrid.Children[0] is Border b && b.Child is StackPanel sp)
            {

                TascaVisual t = new TascaVisual { TascaData = tasca };
                sp.Children.Add(t);
            }
        }

        public void EliminarTasca(Tasca tasca)
        {
            for (int i = 0; i < TaskGrid.Children.Count; i++)
            {
                if (TaskGrid.Children.Count > 0 && TaskGrid.Children[0] is Border b && b.Child is StackPanel sp)
                {
                    TascaVisual t = new TascaVisual { TascaData = tasca };
                    if (sp.Children.Contains(t))
                    {
                        sp.Children.Remove(t);
                    }
                }
            }
        }
    }
}