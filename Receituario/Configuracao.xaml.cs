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
using System.Diagnostics;

namespace Receituario
{
    /// <summary>
    /// Interaction logic for Configuracao.xaml
    /// </summary>
    public partial class Configuracao : Window
    {
        public Configuracao()
        {
            InitializeComponent();
            Config.Configuracao config = Config.Configuracao.Instance;
           // label1.Content = config.GetDataDirectory();
        }

        private void btnLayout_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("winword.exe", @"Data\layout.doc");
        }
    }
}
