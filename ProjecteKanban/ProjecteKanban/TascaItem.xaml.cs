using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjecteKanban
{
    public partial class TascaItem : UserControl
    {
        public static readonly DependencyProperty TascaDataProperty =
            DependencyProperty.Register("TascaData", typeof(Tasca), typeof(TascaItem), new PropertyMetadata(null));

        public Tasca TascaData
        {
            get => (Tasca)GetValue(TascaDataProperty);
            set => SetValue(TascaDataProperty, value);
        }

        public TascaItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Tasca_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is DependencyObject dragSource)
            {
                DragDrop.DoDragDrop(dragSource, this, DragDropEffects.Move);
            }
        }

        private void EditarTasca_Click(object sender, RoutedEventArgs e)
        {
            FinestraEditarTasca f = new FinestraEditarTasca(this.TascaData);
            f.ShowDialog();
        }
    }
}