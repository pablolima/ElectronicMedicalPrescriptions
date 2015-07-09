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
    public partial class TipoUso : Window
    {
        public DTOReceituario.TipoUso tipoUso;

        public TipoUso()
        {
            InitializeComponent();
            UpdateGrid();
        }
        public TipoUso(string nomeBotao)
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
            InserirTipoUso insertmed = new InserirTipoUso("Insert", tipoUso);
            insertmed.Closing += new System.ComponentModel.CancelEventHandler(insertTipoUso_Closing);
            insertmed.ShowDialog();
        }

        private void insertTipoUso_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateGrid();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            InserirTipoUso TipoUso = new InserirTipoUso("Update", tipoUso);
            TipoUso.Closing += new System.ComponentModel.CancelEventHandler(insertTipoUso_Closing);
            TipoUso.ShowDialog();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            BLLTipoUso bllTipoUso = new BLLTipoUso();
            string filtro = "";
            if (bool.Parse(radioButtonNome.IsChecked.ToString()))
            {
                filtro = "nome";
            }
            else if (bool.Parse(radioButtonDescricao.IsChecked.ToString()))
            {
                filtro = "desc";
            }
            dataGridTipoUso.ItemsSource = bllTipoUso.SelectAdvanced(filtro, txtboxPesquisa.Text);
        }

        private void dataGridTipoUso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count > 0)
                {
                    tipoUso = new DTOReceituario.TipoUso();
                    tipoUso = (DTOReceituario.TipoUso)e.AddedItems[0];
                }
            }
            catch (Exception ex)
            {
 
            }
        }
        private void UpdateGrid()
        {
            BLLTipoUso bllTipoUso = new BLLTipoUso();
            dataGridTipoUso.ItemsSource = bllTipoUso.SelectALL();
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            if (tipoUso.Id_uso > 0)
            {
                BLLTipoUso bllTipoUso = new BLLTipoUso();
                bllTipoUso.Delete(tipoUso);
                UpdateGrid();
            }
        }

        private void txtboxPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

    }
}