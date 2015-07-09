using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;
using DTOReceituario;
using System.IO;
using System.Collections;
using System.Windows.Documents;

namespace Receituario
{
    /// <summary>
    /// Interaction logic for EmissaoReceita.xaml
    /// </summary>
    public partial class EmissaoReceita : System.Windows.Window
    {
        //Document oDoc;
        DTOReceituario.Medicamento medicamento;
        Microsoft.Office.Interop.Word.Application wordApp;
        Receita receita;
        ReceitaItem RISelected;

        public EmissaoReceita()
        {
           //Key teste = (Key)Enum.Parse(typeof(Key),"F1");
            InitializeComponent();
            BLLReceituario.BLLTipoUso blllTipoUso = new BLLReceituario.BLLTipoUso();
            dropUso.ItemsSource = blllTipoUso.SelectTexto().ToList();
            /*
            Microsoft.Office.Interop.Word.Application oWord = Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application")) as Microsoft.Office.Interop.Word.Application;
            oDoc = oWord.Documents.Add();
            Table oTable1;
            Paragraph oPara1;
            oWord.Visible = true;
            int r;
            int c;
            /oTable1 = oDoc.Tables.Add(oDoc.Bookmarks.
             */
            
        }

        private void btnBuscaMed_Click(object sender, RoutedEventArgs e)
        {
            Medicamento med = new Medicamento("Selecionar");
            med.isCrud = false;
            med.Closing += new System.ComponentModel.CancelEventHandler(med_Closing);
            med.Show();
        }

        private void med_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (((Medicamento)sender).med != null)
            {
                medicamento = new DTOReceituario.Medicamento();
                medicamento = ((Medicamento)sender).med;

            this.txtboxMedicamento.Text = medicamento.Nome == null ? "" : medicamento.Nome;
            this.txtboxApresentacao.Text = medicamento.Desc == null ? "" : medicamento.Desc;

            }
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
           if (MessageBox.Show("Deseja realmente fechar?", "", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes, MessageBoxOptions.None) == MessageBoxResult.Yes)
            this.Close();
        }

        private void CreateWordDocument(object fileName, object saveAs, Receita receita)
        {
            object missing = System.Reflection.Missing.Value;

            //Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
             wordApp = Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application")) as Microsoft.Office.Interop.Word.Application;

            Document aDoc = null;

            if (File.Exists(fileName as String))
            {
                object readOnly = false;
                object isVisible = false;

                wordApp.Visible = false;

                aDoc = wordApp.Documents.Open(ref fileName, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);

                aDoc.Activate();

               // aDoc.Content.InsertBefore("This is at the beninning\r\n\r\n");

                this.FindAndReplace(wordApp, "<paciente>", receita.Paciente );

                foreach(ReceitaItem item in receita.ReceitaItem)
                {
                    aDoc.Content.InsertAfter("\r\n" + item.Uso.Texto);
                    aDoc.Content.InsertAfter("\r\n" + item.Medicamento.Nome.ToString().ToUpper());
                    aDoc.Content.InsertAfter("         " + item.Medicamento.Desc.ToString().ToUpper());
                    aDoc.Content.InsertAfter("\r\n" + item.Posologia.ToString().ToUpper());

                    aDoc.Content.InsertAfter("\r\n\r\n");
                }

                aDoc.Content.InsertAfter("\r\n\r\n Data da Emissão:  " + DateTime.Now.ToShortDateString());


            }
            else
            {
                
            }

            /* 
            aDoc.SaveAs(ref saveAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

            
            aDoc.Close(ref missing, ref missing, ref missing);
             */

        }

        private void FindAndReplace(Microsoft.Office.Interop.Word.Application WordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritcs = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            WordApp.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord, 
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward,
                ref wrap, ref format, ref replaceWithText, ref replace, ref matchKashida, 
                ref matchDiacritcs,ref matchAlefHamza, ref matchControl);


        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (receita == null)
                {
                    receita = new Receita();
                }

                ReceitaItem receitaitem = new ReceitaItem();
                receitaitem.Medicamento.Nome = txtboxMedicamento.Text;
                receitaitem.Medicamento.Desc = txtboxApresentacao.Text;
                receitaitem.Posologia = new TextRange(txtboxPosologia.Document.ContentStart,txtboxPosologia.Document.ContentEnd).Text;
                receitaitem.Uso.Texto = dropUso.Text == null ? "" : dropUso.Text;
                receitaitem.Uso.Id_uso = dropUso.SelectedValue == null ? 0 : (int)dropUso.SelectedValue;
                receitaitem.Index = receita.ReceitaItem.Count;
                
                /*
                Receita rec = new Receita();
                if (receita != null)
                {
                    rec = receita;
                }
                //rec.ReceitaItem = new List<ReceitaItem>();

                 */
                

                receita.Paciente = txtboxPaciente.Text;
                receita.ReceitaItem.Add(receitaitem);
                


              //  dataGridMed.ItemsSource = rec.ReceitaItem.ToList();
                //receita = rec;

                RefreshGrid(receita);
                

            }
            catch (Exception ex)
            {
 
            }
        }

        private void btnVisualizar_Click(object sender, RoutedEventArgs e)
        {
            CreateWordDocument(Path.GetFullPath(@"Data\layout.doc"), Path.GetFullPath(@"Data\layout.doc"), receita);
            /*
           Microsoft.Office.Interop.Word.Application oWord = Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application")) as Microsoft.Office.Interop.Word.Application;
           oDoc = oWord.Documents.Add();
           Table oTable1;
           Paragraph oPara1;
           oWord.Visible = true;

             */

           wordApp.Visible = true;
        }

        public void RefreshGrid(Receita receita)
        {
            dataGridMed.ItemsSource = receita.ReceitaItem.ToList();
        }

        private void txtboxPosologia_TextChanged(object sender, TextChangedEventArgs e)
        {
            string teste = e.Source.ToString();
        }

        private void txtboxPosologia_KeyUp(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                BLLReceituario.BLLAutoTexto bll = new BLLReceituario.BLLAutoTexto();
                txtboxPosologia.AppendText(((DTOReceituario.AutoTexto)bll.Select(e.Key.ToString())).Texto);
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (btnEditar.Content.ToString() == "Editar")
            {
                if (RISelected != null)
                {
                    txtboxMedicamento.Text = RISelected.Medicamento.Nome;
                    txtboxApresentacao.Text = RISelected.Medicamento.Desc;
                    txtboxPosologia.Document.Blocks.Clear();
                    txtboxPosologia.AppendText(RISelected.Posologia);
                    dropUso.SelectedValue = RISelected.Uso.Id_uso;
                    dropUso.Text = RISelected.Uso.Texto;

                    btnEditar.Content = "Atualizar";
                }
            }
            else if (btnEditar.Content.ToString() == "Atualizar")
            {
                if (RISelected != null)
                {
                    //TODO: Criar metodo para preenchimento automatico de ReceitaItem com dados preenchidos na tela 
                    RISelected.Medicamento.Nome = txtboxMedicamento.Text;
                    RISelected.Medicamento.Desc = txtboxApresentacao.Text;
                    RISelected.Posologia = new TextRange(txtboxPosologia.Document.ContentStart, txtboxPosologia.Document.ContentEnd).Text;
                    RISelected.Uso.Id_uso = dropUso.SelectedValue == null ? 0 : (int)dropUso.SelectedValue;
                    RISelected.Uso.Texto = dropUso.Text == null ? "" : dropUso.Text;

                    receita.ReceitaItem[RISelected.Index] = RISelected;
                    RefreshGrid(receita);
                }

                btnEditar.Content = "Editar";
            }
        }

        private void dataGridMed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count > 0)
                {
                    RISelected = new ReceitaItem();
                    RISelected = (ReceitaItem)e.AddedItems[0];
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            if (RISelected != null && dataGridMed.Items.Count > 0)
            {
                receita.ReceitaItem.RemoveAt(RISelected.Index);
                RefreshGrid(receita);
            }
        }

    }
}
