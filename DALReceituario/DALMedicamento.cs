using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTOReceituario;
using Util;
using Util.Database;
using System.Data;

namespace DALReceituario
{
    public class DALMedicamento: DataWorker,IDAL<Medicamento>
    {
        public List<Medicamento> SelectAll()
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Select * From Medicamento");

                using (IDbCommand command = database.CreateCommand(sb.ToString(), conn))
                {
                    List<Medicamento> medicamentos = new List<Medicamento>();

                    using (IDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Medicamento med = new Medicamento();

                            med.Id_medicamento = int.Parse(dr["id_medicamento"].ToString());
                            med.Nome = dr["nome"].ToString();
                            med.Desc = dr["descricao"].ToString();

                            medicamentos.Add(med);
                        }
                    }

                    return medicamentos;
                }
            }

        }
        public List<Medicamento> SelectAdvanced(string filtro,string texto)
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * From MEDICAMENTO ");
                sb.Append("WHERE 1 = 1 ");

                if (filtro == "id")
                {
                    sb.AppendFormat("AND id_medicamento = {0}", texto);
                }
                else if (filtro == "nome")
                {
                    sb.AppendFormat("AND nome LIKE '{0}%'", texto);
                }
                else if (filtro == "desc")
                {
                    sb.AppendFormat("AND descricao LIKE '{0}%'", texto);
                }

                using (IDbCommand command = database.CreateCommand(sb.ToString(), conn))
                {
                    List<Medicamento> medicamentos = new List<Medicamento>();

                    using (IDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Medicamento med = new Medicamento();

                            med.Id_medicamento = int.Parse(dr["id_medicamento"].ToString());
                            med.Nome = dr["nome"].ToString();
                            med.Desc = dr["descricao"].ToString();

                            medicamentos.Add(med);
                        }
                    }

                    return medicamentos;
                }
            }

        }

        public bool Insert(Medicamento t)
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO Medicamento ");
                sb.Append("(nome , ");
                sb.Append("descricao) ");
                sb.AppendFormat("VALUES ('{0}' , '{1}')", t.Nome.Replace("'", "''"), t.Desc.Replace("'", "''"));

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

        public bool Update(Medicamento t)
        {
           
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE Medicamento SET ");
                sb.AppendFormat("nome = '{0}', ", t.Nome.Replace("'","''"));
                sb.AppendFormat("descricao = '{0}' ", t.Desc.Replace("'", "''"));
                sb.AppendFormat("WHERE id_medicamento = {0}", t.Id_medicamento);

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

        public bool Delete(Medicamento t)
        {
            using (IDbConnection conn = database.CreateOpenConnection())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("DELETE FROM Medicamento ");
                sb.AppendFormat("WHERE id_medicamento = {0}",t.Id_medicamento);

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

    }
}
