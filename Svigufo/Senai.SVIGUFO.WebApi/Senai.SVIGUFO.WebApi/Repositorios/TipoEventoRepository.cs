using Senai.SVIGUFO.WebApi.Domains;
using Senai.SVIGUFO.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.SVIGUFO.WebApi.Repositorios
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=SVIGUFO;user id=sa; pwd=132";

        public void Alterar (TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "UPDATE TIPO_EVENTOS SET TITULO = @TITULO WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                cmd.Parameters.AddWithValue("@ID", tipoEvento.Id);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))

            {
                string Query = "DELETE FROM TIPO_EVENTOS WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

         void Cadastrar(TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //string QuerySerExecutada = "INSERT INTO TIPO_EVENTOS(TITULO) VALUES ";
 
                string QuerySerExecutada = "INSET INTO TIPO_EVENTOS (TITULO) VALUES (@TITULO)";
                SqlCommand cmd = new SqlCommand(QuerySerExecutada, con);
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<TipoEventoDomain> Listar()
        {
            List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>();
            //declaro a sqlconnection passando a string de conexao
            using (SqlConnection con = new SqlConnection(StringConexao))

            {//declara a instrucao a ser executada
                string QueryaSerExecutada = "SELECT ID,TITULO FROM TIPO_EVENTOS";
                // abre o BD
                con.Open();
                // delcaro um sqlreader para percorre a lista
                SqlDataReader rdr;
                // declaro um command passando a ser executado e a conexao 
                using (SqlCommand cmd = new SqlCommand(QueryaSerExecutada, con))
                {
                    //executa a query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read()) {
                        TipoEventoDomain tipoEvento = new TipoEventoDomain
                        {
                            Id = Convert.ToInt32(rdr[" ID"]),
                            Nome = rdr["TITULO"].ToString()
                        };
                    }
                }
                  
            }
            return tiposEventos;
        }
    }
}
