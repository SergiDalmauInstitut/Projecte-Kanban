using System;
using System.Diagnostics;
using System.Windows;

namespace ProjecteKanban
{
    public partial class FinestraEditarTasca : Window
    {
        public Tasca TascaResultat { get; private set; }
        public bool Afegir { get; private set; }

        public FinestraEditarTasca()
        {
            InitializeComponent();

            TascaResultat = new Tasca("Nova Tasca");
            this.DataContext = TascaResultat;
            this.Title = "Crear Nova Tasca";
        }

        public FinestraEditarTasca(Tasca tascaExistents)
        {
            InitializeComponent();

            TascaResultat = tascaExistents;
            this.DataContext = TascaResultat;
            this.Title = "Editar Tasca: " + tascaExistents.Nom;
        }

        private void Afegir_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TascaResultat.Nom))
            {
                MessageBox.Show("El nom de la tasca no pot estar buit.", "Error de validació", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MainWindow W = new MainWindow();
            W.AfegirTasca(TascaResultat);
            this.DialogResult = true;
            this.Afegir = true;
            this.Close();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow W = new MainWindow();
            W.EliminarTasca(TascaResultat);
            this.DialogResult = true;
            this.Afegir = false;
            this.Close();
        }
    }
}