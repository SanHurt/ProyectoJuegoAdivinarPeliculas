using System.Collections.ObjectModel;
using System.Windows;

namespace ProyectoJuegoAdivinarPeliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<CartelPelicula> listaPeliculas ;
        private int numActualCartel = 1;
        public enum CambiarCartel
        {
            Siguiente = 1,
            Anterior = -1,
            Actual = 0
        }
        public MainWindow()
        {
            InitializeComponent();
            listaPeliculas = CartelPelicula.GetSamples(@"F:\DAM\2DAM\DINT\UT5\RecursosProyecto\Assets\");
            listBox.DataContext = listaPeliculas;
            ActualizaLista((int)CambiarCartel.Actual);
        }
        private void ActualizaLista(CambiarCartel cartel)
        {
            numActualCartel += (int)cartel;
            numeroCartel.Text = numActualCartel + " / " + listaPeliculas.Count;
            dockPanelPelicula.DataContext = listaPeliculas[numActualCartel - 1];
        }
        private void AddCartelPelicula(CartelPelicula c)
        {
            listaPeliculas.Add(c);
            MessageBox.Show("Cartel añadido");
        }

        private void Anterior_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (1 < numActualCartel)
            {
                
                ActualizaLista(CambiarCartel.Anterior);
                dockPanel.DataContext = listaPeliculas[numActualCartel - 1];
            }
                
        }

        private void Siguiente_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (numActualCartel < listaPeliculas.Count)
            {
                
                ActualizaLista(CambiarCartel.Siguiente);
                dockPanel.DataContext = listaPeliculas[numActualCartel - 1];
            }
                
            
        }

        private void buttonValidar_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxAdivinarPelicula.Text == listaPeliculas[numActualCartel - 1].Nombre)
                MessageBox.Show("¡Has acertado!");
            else
                MessageBox.Show("¡Has perdido!");
        }

        private void checkBoxVerPista_Checked(object sender, RoutedEventArgs e)
        {
            textBlockPista.Visibility = Visibility.Visible;
        }

        private void checkBoxVerPista_Unchecked(object sender, RoutedEventArgs e)
        {
            textBlockPista.Visibility = Visibility.Collapsed;
        }
    }
}
