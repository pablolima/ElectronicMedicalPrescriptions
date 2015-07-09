using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOReceituario
{
    public class Receita : ReceitaItem
    {
        private string _paciente;

        public string Paciente
        {
            get { return _paciente; }
            set { _paciente = value; }
        }

        public List<ReceitaItem> ReceitaItem
        {
            get { return ReceitaItem; }
            set { ReceitaItem = value; }
        }
    }
}
