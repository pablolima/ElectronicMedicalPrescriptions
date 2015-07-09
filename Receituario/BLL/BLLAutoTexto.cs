using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALReceituario;
using DTOReceituario;

namespace BLLReceituario
{
    public class BLLAutoTexto : IBLLCrud<DTOReceituario.AutoTexto>
    {
        public List<AutoTexto> SelectALL()
        {
            DALAutoTexto at = new DALAutoTexto();
            return at.SelectAll();
        }
        public AutoTexto Select(string key)
        {
            DALAutoTexto at = new DALAutoTexto();
            return at.Select(key);
        }
        public List<AutoTexto> SelectAdvanced(string filtro, string texto)
        {
            DALAutoTexto at = new DALAutoTexto();
            return at.SelectAdvanced(filtro, texto);
        }
        public bool Update(AutoTexto t)
        {
            DALAutoTexto at = new DALAutoTexto();
            return at.Update(t);
        }

        public bool Insert(AutoTexto t)
        {
            DALAutoTexto at = new DALAutoTexto();
            return at.Insert(t);
        }

        public bool Delete(AutoTexto t)
        {
            DALAutoTexto at = new DALAutoTexto();
            return at.Delete(t);
        }

    }
}
