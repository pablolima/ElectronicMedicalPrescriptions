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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using Util.Database;

namespace Receituario.Controls
{
    /// <summary>
    /// Interaction logic for ucCaminhoBd.xaml
    /// </summary>
    public partial class ucCaminhoBd : UserControl
    {
        string banco;

        public ucCaminhoBd()
        {
            InitializeComponent();
            RetornaCaminho();
        }

        private void btnDefault_Click(object sender, RoutedEventArgs e)
        {
            banco = Util.Database.Util.TipoBanco();

            if (banco == "Access")
            {
               if (Util.Database.Util.SetaCaminho())
                   MessageBox.Show("Banco default de aplicação ativado com sucesso! Para ter as alterações salvas, reinicie a aplicação.", "Mensagem", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Util.Database.Util.SetaCaminho();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            banco = Util.Database.Util.TipoBanco();

            string caminhobd = txtCaminhoBd.Text;

            if (banco == "Access")
            {
                Util.Database.Util.SetaCaminho(caminhobd);

                if (Util.Database.Util.TestConnectionDb())
                {
                    MessageBox.Show("Caminho de dados alterado com sucesso! Para ter as alterações salvas, reinicie a aplicação.", "Mensagem", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                Util.Database.Util.SetaCaminho();
                MessageBox.Show("Falha ao conectar ao banco de dados, por favor tente novamente.", "Erro", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }


            RetornaCaminho();
        }

        private void RetornaCaminho()
        {
            //txtCaminhoBd.Text = Util.Database.Util.RetornaCaminhoBanco();
        }

        private void txtCaminhoBd_Loaded(object sender, RoutedEventArgs e)
        {
            RetornaCaminho();
        }
    }
}
