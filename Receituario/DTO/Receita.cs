using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOReceituario
{
    public class Receita
    {
        private string _paciente;

        public string Paciente
        {
            get { return _paciente; }
            set { _paciente = value; }
        }

        private DateTime _data;

        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }


        private List<ReceitaItem> _receitaItem = new List<ReceitaItem>();
        public List<ReceitaItem> ReceitaItem
        {
            get { return _receitaItem; }
            set { _receitaItem = value; }
        }
    }
}
