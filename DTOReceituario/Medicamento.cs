using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOReceituario
{
    public class Medicamento
    {
        int _id_medicamento;

        public int Id_medicamento
        {
            get { return _id_medicamento; }
            set { _id_medicamento = value; }
        }
        string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        string _desc;

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
    }
}
