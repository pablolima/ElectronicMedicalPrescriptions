using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOReceituario
{
    public class ReceitaItem
    {
        private int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private string _posologia;

        public string Posologia
        {
            get { return _posologia; }
            set { _posologia = value; }
        }

        public TipoUso _uso = new TipoUso();
        public TipoUso Uso
        {
            get { return _uso; }
            set { _uso = value; }
        }

        private DTOReceituario.Medicamento _medicamento = new Medicamento();
        public DTOReceituario.Medicamento Medicamento
        {
            get
            {
                return _medicamento;
            }
            set
            {
                _medicamento = value;
            }
        }

    }
}
