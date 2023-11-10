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

namespace tuniversCinema
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboBoxIdioma.SelectedIndex = 0;
            comboBoxEntradas.SelectedIndex = 0;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                salidaTextoPelicula.Text = "Pelicula: "+radioButton.Content.ToString();
            }
        }
        private void RadioButton_Hora_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                salidaTextoHora.Text = "Hora: " + radioButton.Content.ToString();
            }
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateResultText();
        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            UpdateResultText();
        }
        private void UpdateResultText()
        {
            salidaTextoAperitivos.Clear();
            
            salidaTextoAperitivos.Text += "Aperitivos: \n";
            foreach (var child in aperitivosStackPanel.Children)
            {
                if (child is CheckBox checkBox)
                {
                    
                    if (checkBox.IsChecked == true)
                    {
                        salidaTextoAperitivos.Text += checkBox.Content + "\n";
                    }
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxIdioma.SelectedItem is ComboBoxItem selectedItem)
            {
                if (selectedItem.Content.ToString() == "Español")
                {
                    traducirAperitivos.Text = "Aperitivos";
                    traducirNumeroEntradas.Text = "Número Entradas";
                    traducirHora.Text = "Hora: ";
                    checkboxPalomitasPequeñas.Content = "Palomitas Pequeñas";
                    checkboxPalomitasGrandes.Content = "Palomitas Grandes";
                    checkboxRefresco.Content = "Refresco";
                    checkboxBotellaAgua.Content = "Botella de Agua";
                    traducirVengadores.Content = "Los Vengadores";
                    traducirAnillos.Content = "El señor de los anillos";
                    botonFinalizarCompra.Content = "Finalizar Compra";
                }
                else if(selectedItem.Content.ToString() == "Ingles")
                {
                    traducirAperitivos.Text = "Aperitive";
                    traducirNumeroEntradas.Text = "Entradium Number";
                    traducirHora.Text = "Hour: ";
                    checkboxPalomitasPequeñas.Content = "Chiquen Popcorn";
                    checkboxPalomitasGrandes.Content = "Grand Popcorn";
                    checkboxRefresco.Content = "Inglish Refrescus";
                    checkboxBotellaAgua.Content = "Water in bottle";
                    traducirVengadores.Content = "Advengers";
                    traducirAnillos.Content = "Anillus of the senior";
                    botonFinalizarCompra.Content = "Acabeison compreison";
                }
              
            }
        }
        private void ComboBox_NumeroEntradas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxEntradas.SelectedItem is ComboBoxItem selectedItem)
            {
                salidaTextoNumeroEntradas.Text= "Número de entradas: "+selectedItem.Content.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
                string datosSeleccionados = "COMPRA CINE:";
                //Nombre de pelicula
                foreach (var child in peliculaStackPanel.Children)
                {
                    if (child is RadioButton radioButton && radioButton.IsChecked == true)
                    {
                    count++;
                        datosSeleccionados += "\nPelicula: " + radioButton.Content + ".";
                    }
                }
                //Hora de la pelicula
                foreach (var child in horaStackPanel.Children)
                {
                    if (child is RadioButton radioButton && radioButton.IsChecked == true)
                    {
                    count++;
                    datosSeleccionados += "\nHora: " + radioButton.Content + ".";
                    }
                }
                //Numero entradas combobox
                if (comboBoxEntradas.SelectedItem is ComboBoxItem selectedPais)
                {
                    count++;
                    datosSeleccionados += "\nNumero Entradas: " + selectedPais.Content;
                }
                datosSeleccionados += "\nAperitivos:  ";
                //Aperitivos
                foreach (var child in aperitivosStackPanel.Children)
                {

                    if (child is CheckBox checkBox && checkBox.IsChecked == true)
                    {
                    count++;
                    datosSeleccionados += "\n -" + checkBox.Content;
                    }
                }
            if (count >= 4) { MessageBox.Show(datosSeleccionados, "Compra", MessageBoxButton.OK, MessageBoxImage.Information); }                
            }       
    }
}
