using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLLReceituario;

namespace Receituario
{
    /// <summary>
    /// Interaction logic for AutoTexto.xaml
    /// </summary>
    public partial class AutoTexto : Window
    {
        public DTOReceituario.AutoTexto autoTexto;

        public AutoTexto()
        {
            InitializeComponent();
            UpdateGrid();
        }
        public AutoTexto(string nomeBotao)
        {
            InitializeComponent();
            UpdateGrid();
            btnFechar.Content = nomeBotao;
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            InserirAutoTexto insertAutoTexto = new InserirAutoTexto("Insert", autoTexto);
            insertAutoTexto.Closing += new System.ComponentModel.CancelEventHandler(insertAutoTexto_Closing);
            insertAutoTexto.ShowDialog();
        }

        private void insertAutoTexto_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateGrid();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

            InserirAutoTexto insertAutoTexto = new InserirAutoTexto("Update", autoTexto);
            insertAutoTexto.Closing += new System.ComponentModel.CancelEventHandler(insertAutoTexto_Closing);
            insertAutoTexto.ShowDialog();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BLLAutoTexto bllAutoTexto = new BLLAutoTexto();
            string filtro = "";
            string valor = txtboxPesquisa.Text;

            if (bool.Parse(radioButtonCodigo.IsChecked.ToString()))
            {
                int value = 0;
                int.TryParse(valor, out value);
                valor = value.ToString();
                filtro = "id";
            }
            if (bool.Parse(radioButtonTexto.IsChecked.ToString()))
            {
                filtro = "texto";
            }
            dataGridMed.ItemsSource = bllAutoTexto.SelectAdvanced(filtro, valor);
        }

        private void dataGridMed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count > 0)
                {
                    autoTexto = new DTOReceituario.AutoTexto();
                    autoTexto = (DTOReceituario.AutoTexto)e.AddedItems[0];
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private void UpdateGrid()
        {
            BLLAutoTexto bllautoTexto = new BLLAutoTexto();
            dataGridMed.ItemsSource = bllautoTexto.SelectALL();
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            if (autoTexto.Id_autotexto > 0)
            {
                BLLAutoTexto bllautoTexto = new BLLAutoTexto();
                bllautoTexto.Delete(autoTexto);
                UpdateGrid();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

    }
}