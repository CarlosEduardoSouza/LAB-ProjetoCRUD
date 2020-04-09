using Projeto_BRQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Projeto_BRQ.DAO
{
    public class ContatoDAO : Conexao
    {

        public bool CadastrarContato(Contato contato)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("STP_INS_CONTATO", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@NOME", contato.Nome));
                    cmd.Parameters.Add(new SqlParameter("@EMAIL", contato.Email));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONE", contato.Telefone));

                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool EditarContato(Contato contato)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("STP_UPD_CONTATO", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ID", contato.Id));
                    cmd.Parameters.Add(new SqlParameter("@NOME", contato.Nome));
                    cmd.Parameters.Add(new SqlParameter("@EMAIL", contato.Email));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONE", contato.Telefone));

                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        



        public bool ExcluirContato(Contato contato)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("STP_DEL_CONTATO", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ID", contato.Id));

                    if (cmd.ExecuteNonQuery() == 0)
                        return false;
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }


        public List<Contato> ConsultarContato(Contato contato)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("STP_SEL_CONTATO", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@NOME", contato.Nome));
                    cmd.Parameters.Add(new SqlParameter("@EMAIL", contato.Email));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONE", contato.Telefone));
                

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Contato> ltab_Contato = new List<Contato>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ltab_Contato.Add(
                                    new Contato()
                                    {
                                        Id = Convert.ToInt32(reader["ID"]),
                                        Nome = Convert.ToString(reader["NOME"]),
                                        Email = Convert.ToString(reader["EMAIL"]),
                                        Telefone = Convert.ToString(reader["TELEFONE"]),
                                        
                                    }
                                );
                            }
                        }
                        return ltab_Contato;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public Contato ConsultarContatoByID(Contato contato)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("STP_SEL_CONTATO_ByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ID", contato.Id));


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Contato obj = new Contato();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                obj.Id = Convert.ToInt32(reader["ID"]);
                                obj.Nome = Convert.ToString(reader["NOME"]);
                                obj.Email = Convert.ToString(reader["EMAIL"]);
                                obj.Telefone = Convert.ToString(reader["TELEFONE"]);
                            }
                        }
                        return obj;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}