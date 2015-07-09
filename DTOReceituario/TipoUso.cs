using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOReceituario
{
    public class TipoUso
    {
        int _id_uso;

        public int Id_uso
        {
            get { return _id_uso; }
            set { _id_uso = value; }
        }
        string _texto;

        public string Texto
        {
            get { return _texto; }
            set { _texto = value; }
        }
    }
}
