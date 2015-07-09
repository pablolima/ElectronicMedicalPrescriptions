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
    /// Interaction logic for Medicamento.xaml
    /// </summary>
    public partial class Medicamento : Window
    {
        public DTOReceituario.Medicamento med;
        public bool isCrud = true;

        public Medicamento()
        {
            InitializeComponent();
            UpdateGrid();
        }
        public Medicamento(string nomeBotao)
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
            InserirMed insertmed = new InserirMed("Insert",med);
            insertmed.Closing += new System.ComponentModel.CancelEventHandler(insertmed_Closing);
            insertmed.ShowDialog();
        }

        private void insertmed_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateGrid();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            InserirMed insertmed = new InserirMed("Update",med);
            insertmed.Closing += new System.ComponentModel.CancelEventHandler(insertmed_Closing);
            insertmed.ShowDialog();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BLLMedicamento bllmed = new BLLMedicamento();
            string filtro = "";
            string valor = txtboxPesquisa.Text;

            if (bool.Parse(radioButtonCodigo.IsChecked.ToString()))
            {
                int value = 0;
                int.TryParse(valor, out value);
                valor = value.ToString();
                filtro = "id";
            }
            if (bool.Parse(radioButtonNome.IsChecked.ToString()))
            {
                filtro = "nome";
            }
            else if (bool.Parse(radioButtonDescricao.IsChecked.ToString()))
            {
                filtro = "desc";
            }
            dataGridMed.ItemsSource = bllmed.SelectAdvanced(filtro, valor);
        }

        private void dataGridMed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count > 0)
                {
                    med = new DTOReceituario.Medicamento();
                    med = (DTOReceituario.Medicamento)e.AddedItems[0];
                }
            }

            catch (Exception ex)
            {
 
            }
        }
        private void UpdateGrid()
        {
            BLLMedicamento bllmed = new BLLMedicamento();
            dataGridMed.ItemsSource = bllmed.SelectALL();
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            if (med != null)
            {
                if (med.Id_medicamento > 0)
                {
                    BLLMedicamento bllmed = new BLLMedicamento();
                    bllmed.Delete(med);
                    UpdateGrid();
                }
            }
        }

        private void txtboxPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnBuscar_Click(sender,e);
            }
        }

        private void dataGridMed_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(!isCrud)
            btnFechar_Click(sender, e);
        }

    }
}