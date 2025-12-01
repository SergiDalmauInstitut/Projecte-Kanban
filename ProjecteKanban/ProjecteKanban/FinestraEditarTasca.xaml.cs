using System;
using System.Windows;

namespace ProjecteKanban
{
    public partial class FinestraEditarTasca : Window
    {
        public Tasca TascaResultat { get; private set; }

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

        private void Finalitzar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TascaResultat.Nom))
            {
                MessageBox.Show("El nom de la tasca no pot estar buit.", "Error de validació", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            this.DialogResult = true;
            this.Close();
        }
    }
}