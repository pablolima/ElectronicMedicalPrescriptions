using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOReceituario
{
    public class AutoTexto
    {
        int _id_autotexto;

        public int Id_autotexto
        {
            get { return _id_autotexto; }
            set { _id_autotexto = value; }
        }
        string _texto;

        public string Texto
        {
            get { return _texto; }
            set { _texto = value; }
        }
    }
}
