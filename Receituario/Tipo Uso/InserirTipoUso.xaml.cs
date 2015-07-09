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
    /// Interaction logic for InserirMed.xaml
    /// </summary>
    public partial class InserirTipoUso : Window
    {
        string tipo;
        int id_tipoUso;

        public InserirTipoUso(string isInsertOrUpdate, DTOReceituario.TipoUso tipoUso)
        {
            InitializeComponent();
            
            if (isInsertOrUpdate == "Update")
            {
                id_tipoUso = tipoUso.Id_uso;
                tipo = isInsertOrUpdate;
                btnInserirAtualizar.Content = "Atualizar";
                txtboxNome.Text = tipoUso.Texto;
            }
            else if (isInsertOrUpdate == "Insert")
            {
                tipo = isInsertOrUpdate;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInserirAtualizar_Click(object sender, RoutedEventArgs e)
        {
            if (tipo == "Update")
            {
                DTOReceituario.TipoUso tipoUso = new DTOReceituario.TipoUso();
                tipoUso.Texto = txtboxNome.Text;
                tipoUso.Id_uso = id_tipoUso;

                BLLTipoUso bllTipoUso = new BLLTipoUso();
                bllTipoUso.Update(tipoUso);
            }
            else if (tipo == "Insert")
            {
                DTOReceituario.TipoUso tipoUso = new DTOReceituario.TipoUso();
                tipoUso.Texto = txtboxNome.Text;

                BLLTipoUso bllTipoUso = new BLLTipoUso();
                bllTipoUso.Insert(tipoUso);
            }
            this.Close();
        }
    }
}
