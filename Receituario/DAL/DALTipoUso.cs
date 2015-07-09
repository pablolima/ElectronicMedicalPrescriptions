using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTOReceituario;
using System.Data;
using Util.Database;

namespace DALReceituario
{
    class DALTipoUso:DataWorker,IDAL<TipoUso>
    {
        #region IDAL<DALTipoUso> Members

        public List<TipoUso> SelectAll()
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Select * From Uso");

                using (IDbCommand command = database.CreateCommand(sb.ToString(), conn))
                {
                    List<TipoUso> tipoUsos = new List<TipoUso>();

                    using (IDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            TipoUso tipoUso = new TipoUso();

                            tipoUso.Id_uso = int.Parse(dr["id_uso"].ToString());
                            tipoUso.Texto = dr["texto"].ToString();

                            tipoUsos.Add(tipoUso);
                        }
                    }

                    return tipoUsos;
                }
            }

        }
        public List<TipoUso> SelectTexto()
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Select * From Uso");

                using (IDbCommand command = database.CreateCommand(sb.ToString(), conn))
                {
                    List<TipoUso> tipoUsos = new List<TipoUso>();

                    using (IDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            TipoUso tipoUso = new TipoUso();

                            tipoUso.Texto = dr["texto"].ToString();
                            tipoUso.Id_uso = int.Parse(dr["id_uso"].ToString());

                            tipoUsos.Add(tipoUso);
                        }
                    }

                    return tipoUsos;
                }
            }

        }
        public bool Insert(TipoUso t)
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO Uso ");
                sb.Append("(texto)");
                sb.AppendFormat("VALUES ('{0}')", t.Texto.Replace("'", "''"));

                using (IDbCommand command = database.CreateCommand(sb.ToString(), conn))
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool Update(TipoUso t)
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE Uso SET ");
                sb.AppendFormat("texto = '{0}' ", t.Texto.Replace("'", "''"));
                sb.AppendFormat("WHERE id_uso = {0}", t.Id_uso);

                using (IDbCommand command = database.CreateCommand(sb.ToString(), conn))
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        public bool Delete(TipoUso t)
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("DELETE FROM Uso ");
                sb.AppendFormat("WHERE id_uso = {0}", t.Id_uso);

                using (IDbCommand command = database.CreateCommand(sb.ToString(), conn))
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }

        #endregion

        public List<DTOReceituario.TipoUso> SelectAdvanced(string filtro, string texto)
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * From USO ");
                sb.Append("WHERE 1 = 1 ");

                if (filtro == "id")
                {
                    sb.AppendFormat("AND id_medicamento = {0}", texto);
                }
                else if (filtro == "nome")
                {
                    sb.AppendFormat("AND texto LIKE '{0}%'", texto);
                }

                using (IDbCommand command = database.CreateCommand(sb.ToString(), conn))
                {
                    List<DTOReceituario.TipoUso> tipoUsos = new List<DTOReceituario.TipoUso>();

                    using (IDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DTOReceituario.TipoUso tipoUso = new DTOReceituario.TipoUso();

                            tipoUso.Id_uso = int.Parse(dr["id_uso"].ToString());
                            tipoUso.Texto = dr["texto"].ToString();

                            tipoUsos.Add(tipoUso);
                        }
                    }

                    return tipoUsos;
                }
            }
        }
    }
}
