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
using System.Security.Cryptography;

namespace Receituario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                //TODO: Fazer a criptografia
                #region Criptografia Usar a DES: http://msdn.microsoft.com/en-us/library/system.security.cryptography.des.aspx
                string encryptedText = string.Empty;
                string decryptedText = string.Empty;
                string hashedText = string.Empty;
                string plainText = "Lisiano Hacker";
                string key = "adNasaPabloMachadoDelima";
                byte[] keybyte = new byte[key.Length];

                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(plainText);
                byte[] hash = md5.ComputeHash(inputBytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }

               
            }
            catch (Exception ex)
            {

            }
            /*
        Crypt _crypt = new Crypt(CryptProvider.TripleDES);
        _crypt.Key = key;
        encryptedText = _crypt.Encrypt(plainText);
        decryptedText = _crypt.Decrypt(encryptedText);

        Hash _hash = new Hash(HashProvider.SHA1);
        hashedText = _hash.GetHash(plainText); 
             */
                #endregion

            InitializeComponent();
            Application app = Application.Current;
            app.Dispatcher.UnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(Dispatcher_UnhandledException);
        }

        void Dispatcher_UnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("Erro na applicação. Por favor, entre em contato com o adminstrador");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMedicamentos_Click(object sender, RoutedEventArgs e)
        {
            Medicamento med = new Medicamento();
            med.ShowDialog();
        }

        private void btnAutoTexto_Click(object sender, RoutedEventArgs e)
        {
            AutoTexto autotexto = new AutoTexto();
            autotexto.ShowDialog();
        }

        private void btnTipoUso_Click(object sender, RoutedEventArgs e)
        {
            TipoUso tipouso = new TipoUso();
            tipouso.ShowDialog();
        }

        private void menuItemEmissaoReceita_Click(object sender, RoutedEventArgs e)
        {
            EmissaoReceita em = new EmissaoReceita();
            em.ShowDialog();
        }

        private void menuItemConfiguracoes_Click(object sender, RoutedEventArgs e)
        {
            Configuracao config = new Configuracao();
            config.ShowDialog();
        }

        private void menuItemAjuda_Click(object sender, RoutedEventArgs e)
        {
            Ajuda ajuda = new Ajuda();
                ajuda.ShowDialog();
        }
    }
}
