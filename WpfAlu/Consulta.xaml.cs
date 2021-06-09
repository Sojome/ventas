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
using EN;
using BL;

namespace WpfAlu
{
    /// <summary>
    /// Lógica de interacción para Consulta.xaml
    /// </summary>
    public partial class Consulta : Window
    {
        public Consulta()
        {
            InitializeComponent();
        }

        Ventas _en = new Ventas();
        VentasBL _bl = new VentasBL();

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            if (!(txtmostrar.Text == ""))
            {
                _en.Nombre = txtmostrar.Text;
                dgdatos.ItemsSource = _bl.MostrarVentasPorNombre(_en);
            }
        }

        private void dgdatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _en = dgdatos.SelectedItem as Ventas;
            if (_en != null)
            {
                txtnombre.Text = _en.Nombre;
                txtventas.Text = Convert.ToString(_en.TotalVentas);
                txtestado.Text = _en.Estado;
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtnombre.Text != "" && txtventas.Text != "" && txtestado.Text != "")
            {
                MessageBoxResult r = MessageBox.Show("Estas seguro eliminar este registro?", "Alerta!", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (r == MessageBoxResult.OK)
                {
                    _bl.Eliminar(_en);
                    dgdatos.Items.Refresh();
                    dgdatos.ItemsSource = _bl.MostrarVentas();
                }
                if (r == MessageBoxResult.Cancel)
                {
                }
            } else
            {
                MessageBox.Show("No puede utilizar este botón, primero seleccione un registro", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _ver = new MainWindow();
            this.Close();
            _ver.ShowDialog();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtnombre.Text != "" && txtventas.Text != "" && txtestado.Text != "")
            {
                _en.Nombre = txtnombre.Text;
                _en.TotalVentas = Convert.ToInt64(txtventas.Text);
                _en.Estado = txtestado.Text;
                if (_bl.ModificarVentas(_en) > 0)
                {
                    MessageBox.Show("El registro se modificó correctamente...", "Éxito!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    dgdatos.Items.Refresh();
                    dgdatos.ItemsSource = _bl.MostrarVentas();
                }
                else
                {
                    MessageBox.Show("No se pudo modificar...", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro...", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
