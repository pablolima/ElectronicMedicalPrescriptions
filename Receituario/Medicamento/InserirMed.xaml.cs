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
    public partial class InserirMed : Window
    {
        string tipo;
        int id_medicamento;

        public InserirMed(string isInsertOrUpdate,DTOReceituario.Medicamento med)
        {
            InitializeComponent();
            
            if (isInsertOrUpdate == "Update")
            {
                id_medicamento = med.Id_medicamento;
                tipo = isInsertOrUpdate;
                btnInserirAtualizar.Content = "Atualizar";
                txtboxNome.Text = med.Nome;
                txtboxDescricao.Text = med.Desc;
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
                DTOReceituario.Medicamento med = new DTOReceituario.Medicamento();
                med.Nome = txtboxNome.Text;
                med.Desc = txtboxDescricao.Text;
                med.Id_medicamento = id_medicamento;

                BLLMedicamento bllmed = new BLLMedicamento();
                bllmed.Update(med);
            }
            else if (tipo == "Insert")
            {
                DTOReceituario.Medicamento med = new DTOReceituario.Medicamento();
                med.Nome = txtboxNome.Text;
                med.Desc = txtboxDescricao.Text;

                BLLMedicamento bllmed = new BLLMedicamento();
                bllmed.Insert(med);
            }
            this.Close();
        }
    }
}
