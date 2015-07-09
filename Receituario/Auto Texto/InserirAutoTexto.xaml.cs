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
    public partial class InserirAutoTexto : Window
    {
        string tipo;
        int id_autotexto;
        string key;

        public InserirAutoTexto(string InsertOrUpdate,DTOReceituario.AutoTexto autoTexto)
        {
            InitializeComponent();
            txtComando.Text = "Pressione uma tecla para atalho...";

            if (InsertOrUpdate == "Update")
            {
                id_autotexto = autoTexto.Id_autotexto;
                tipo = InsertOrUpdate;
                btnInserirAtualizar.Content = "Atualizar";
                txtboxNome.AppendText(autoTexto.Texto);
                lblComando.Content = autoTexto.Comando.ToString();
            }
            else if (InsertOrUpdate == "Insert")
            {
                tipo = InsertOrUpdate;
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
                DTOReceituario.AutoTexto autotexto = new DTOReceituario.AutoTexto();
                autotexto.Texto = new TextRange(txtboxNome.Document.ContentStart, txtboxNome.Document.ContentEnd).Text;
                autotexto.Id_autotexto = id_autotexto;
                autotexto.Comando = lblComando.Content.ToString();

                BLLAutoTexto bllAutoTexto = new BLLAutoTexto();
                bllAutoTexto.Update(autotexto);
            }
            else if (tipo == "Insert")
            {
                DTOReceituario.AutoTexto autotexto = new DTOReceituario.AutoTexto();
                autotexto.Texto = new TextRange(txtboxNome.Document.ContentStart, txtboxNome.Document.ContentEnd).Text;
                autotexto.Comando = lblComando.Content.ToString();

                BLLAutoTexto bllAutoTexto = new BLLAutoTexto();
                bllAutoTexto.Insert(autotexto);
            }
            this.Close();
        }

        private void txtComando_KeyUp(object sender, KeyEventArgs e)
        {
            lblComando.Content = e.Key.ToString();
        }

        private void txtComando_GotFocus(object sender, RoutedEventArgs e)
        {
            txtComando.Text = "";
        }
    }
}
