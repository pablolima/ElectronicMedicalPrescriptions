using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLReceituario
{
    class BLLTipoUso:IBLLCrud<DTOReceituario.TipoUso>
    {
        DALReceituario.DALTipoUso dalTipoUso;

        #region IBLLCrud<TipoUso> Members

        public List<DTOReceituario.TipoUso> SelectALL()
        {
            dalTipoUso = new DALReceituario.DALTipoUso();
            return dalTipoUso.SelectAll();
        }
        public List<DTOReceituario.TipoUso> SelectTexto()
        {
            dalTipoUso = new DALReceituario.DALTipoUso();
            return dalTipoUso.SelectTexto();
        }
        public bool Update(DTOReceituario.TipoUso t)
        {
            dalTipoUso = new DALReceituario.DALTipoUso();
            return dalTipoUso.Update(t);
        }

        public bool Insert(DTOReceituario.TipoUso t)
        {
            dalTipoUso = new DALReceituario.DALTipoUso();
            return dalTipoUso.Insert(t);
        }

        public bool Delete(DTOReceituario.TipoUso t)
        {
            dalTipoUso = new DALReceituario.DALTipoUso();
            return dalTipoUso.Delete(t);
        }

        #endregion

        public List<DTOReceituario.TipoUso> SelectAdvanced(string filtro, string texto)
        {
            DALReceituario.DALTipoUso dalTipoUso = new DALReceituario.DALTipoUso();
            return dalTipoUso.SelectAdvanced(filtro, texto);
        }
    }
}
