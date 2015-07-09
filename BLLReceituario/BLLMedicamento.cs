using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALReceituario;
using DTOReceituario;

namespace BLLReceituario
{
    public class BLLMedicamento
    {
        public List<Medicamento> SelectALL()
        {
            DALMedicamento med = new DALMedicamento();
            return med.SelectAll();
        }
        public List<Medicamento> SelectAdvanced(string filtro, string texto)
        {
            DALMedicamento med = new DALMedicamento();
            return med.SelectAdvanced(filtro,texto);
        }
        public bool Update(Medicamento t)
        {
            DALMedicamento med = new DALMedicamento();
            return med.Update(t);
        }

        public bool Insert(Medicamento t)
        {
            DALMedicamento med = new DALMedicamento();
            return med.Insert(t);
        }

        public bool Delete(Medicamento t)
        {
            DALMedicamento med = new DALMedicamento();
            return med.Delete(t);
        }

    }
}
