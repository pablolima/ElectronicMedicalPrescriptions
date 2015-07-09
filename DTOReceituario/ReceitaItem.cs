using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOReceituario
{
    public class ReceitaItem
    {
        private string _posologia;

        public string Posologia
        {
            get { return _posologia; }
            set { _posologia = value; }
        }

        public TipoUso Uso
        {
            get { return Uso; }
            set { }
        }

        public Medicamento Medicamento
        {
            get
            {
                return Medicamento;
            }
            set
            {

            }
        }

    }
}
