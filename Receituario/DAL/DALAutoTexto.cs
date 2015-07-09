using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTOReceituario;
using Util.Database;
using System.Data;

namespace DALReceituario
{
    public class DALAutoTexto :DataWorker,IDAL<AutoTexto>
    {
        public List<AutoTexto> SelectAll()
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Select * From AutoTexto");

                using (IDbCommand command = database.CreateCommand(sb.ToString(), conn))
                {
                    List<AutoTexto> autoTextos = new List<AutoTexto>();

                    using (IDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            AutoTexto autoTexto = new AutoTexto();

                            autoTexto.Id_autotexto = int.Parse(dr["id_autotexto"].ToString());
                            autoTexto.Texto = dr["texto"].ToString();
                            autoTexto.Comando = dr["comando"].ToString();

                            autoTextos.Add(autoTexto);
                        }
                    }

                    return autoTextos;
                }
            }

        }
        public List<AutoTexto> SelectAdvanced(string filtro,string texto)
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * From AutoTexto ");
                sb.Append("WHERE 1 = 1 ");

                if (filtro == "id")
                {
                    sb.AppendFormat("AND id_autotexto = {0}", texto);
                }
                else if (filtro == "texto")
                {
                    sb.AppendFormat("AND texto LIKE '{0}%'", texto);
                }


                using (IDbCommand command = database.CreateCommand(sb.ToString(), conn))
                {
                    List<AutoTexto> autoTextos = new List<AutoTexto>();

                    using (IDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            AutoTexto autoTexto = new AutoTexto();

                            autoTexto.Id_autotexto = int.Parse(dr["id_autotexto"].ToString());
                            autoTexto.Texto = dr["texto"].ToString();
                            autoTexto.Comando = dr["comando"].ToString();

                            autoTextos.Add(autoTexto);
                        }
                    }

                    return autoTextos;
                }
            }

        }

        public bool Insert(AutoTexto t)
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO AutoTexto ");
                sb.Append("(texto,comando) ");
                sb.AppendFormat("VALUES ('{0}','{1}')", t.Texto.Replace("'", "''"), t.Comando.Replace("'", "''"));

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

        public bool Update(AutoTexto t)
        {
           
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE AutoTexto SET ");
                sb.AppendFormat("Comando = '{0}', ", t.Comando.Replace("'","''"));
                sb.AppendFormat("Texto = '{0}' ", t.Texto.Replace("'", "''"));
                sb.AppendFormat("WHERE id_autotexto = {0}", t.Id_autotexto);

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

        public bool Delete(AutoTexto t)
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("DELETE FROM AutoTexto ");
                sb.AppendFormat("WHERE id_autotexto = {0}",t.Id_autotexto);

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

        public AutoTexto Select(string key)
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * From AutoTexto ");
                sb.Append("WHERE 1 = 1 ");

                if (key != null)
                {
                    sb.AppendFormat("AND comando = '{0}'", key);
                }


                using (IDbCommand command = database.CreateCommand(sb.ToString(), conn))
                {
                    AutoTexto autoTexto = new AutoTexto();

                    using (IDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            autoTexto.Id_autotexto = int.Parse(dr["id_autotexto"].ToString());
                            autoTexto.Texto = dr["texto"].ToString();
                            autoTexto.Comando = dr["comando"].ToString();
                        }
                    }

                    return autoTexto;
                }
            }

        }
    }
}
