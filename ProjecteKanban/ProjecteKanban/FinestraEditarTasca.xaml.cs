using System;
using System.Windows;

namespace ProjecteKanban
{
    /// <summary>
    /// Lógica de interacción para FinestraEditarTasca.xaml
    /// </summary>
    public partial class FinestraEditarTasca : Window
    {
        public FinestraEditarTasca()
        {
            InitializeComponent();
            DataContext = this;
        }

        public static readonly DependencyProperty NomProperty =
                    DependencyProperty.Register(
                        "Nom",
                        typeof(string),
                        typeof(MainWindow),
                        new PropertyMetadata(""));

        public static readonly DependencyProperty DescripcioProperty =
            DependencyProperty.Register(
                "Descripcio",
                typeof(string),
                typeof(MainWindow),
                new PropertyMetadata(""));

        public static readonly DependencyProperty EtiquetesProperty =
            DependencyProperty.Register(
                "Etiquetes",
                typeof(string),
                typeof(MainWindow),
                new PropertyMetadata(""));

        public static readonly DependencyProperty DataIniciProperty =
            DependencyProperty.Register(
                "DataInici",
                typeof(DateTime?),
                typeof(MainWindow),
                new PropertyMetadata(null));

        public static readonly DependencyProperty DataFiProperty =
            DependencyProperty.Register(
                "DataFi",
                typeof(DateTime?),
                typeof(MainWindow),
                new PropertyMetadata(null));

        public string Nom
        {
            get => (string)GetValue(NomProperty);
            set => SetValue(NomProperty, value);
        }

        public string Descripcio
        {
            get => (string)GetValue(DescripcioProperty);
            set => SetValue(DescripcioProperty, value);
        }

        public string Etiquetes
        {
            get => (string)GetValue(EtiquetesProperty);
            set => SetValue(EtiquetesProperty, value);
        }

        public DateTime? DataInici
        {
            get => (DateTime?)GetValue(DataIniciProperty);
            set => SetValue(DataIniciProperty, value);
        }

        public DateTime? DataFi
        {
            get => (DateTime?)GetValue(DataFiProperty);
            set => SetValue(DataFiProperty, value);
        }

        private void Finalitzar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                $"Nom: {Nom}\n" +
                $"Descripció: {Descripcio}\n" +
                $"Etiquetes: {Etiquetes}\n" +
                $"Data Inici: {DataInici}\n" +
                $"Data Fi: {DataFi}"
            );
        }
    }
}