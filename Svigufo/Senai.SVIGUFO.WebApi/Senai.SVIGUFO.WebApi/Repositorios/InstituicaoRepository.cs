using Senai.SVIGUFO.WebApi.Domains;
using Senai.SVIGUFO.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.SVIGUFO.WebApi.Repositorios
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
            private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=SVIGUFO;user id=sa; pwd=132";

        public void Alterar(InstituicaoDomain Instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryAlt = "UPDATE INSTITUICOES SET NOME_FANTASIA = @NOME_FANTASIA, RAZAO_SOCIAL = @RAZAO_SOCIAL," +
                    " CNPJ = @CNPJ, LOGRADOURO = @LOGRADOURO, CEP = @CEP, UF, @UF, CIDADE = @CIDADE WHERE ID = @ID ";
                SqlCommand cmd = new SqlCommand(QueryAlt, con);
                cmd.Parameters.AddWithValue("@Nome_Fantasia", Instituicao.Nome_Fantasia);
                cmd.Parameters.AddWithValue("@Razao_Social", Instituicao.Razao_Social);
                cmd.Parameters.AddWithValue("@CNPJ", Instituicao.CNPJ);
                cmd.Parameters.AddWithValue("@Logradouro", Instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", Instituicao.CEP);
                cmd.Parameters.AddWithValue("@UF", Instituicao.UF);
                cmd.Parameters.AddWithValue("@Cidade", Instituicao.Cidade);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<InstituicaoDomain> Buscar()
        {
            List<InstituicaoDomain> instituicao = new List<InstituicaoDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryBusc = "SELECT * FROM INSTITUICOES WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(QueryBusc, con);
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand sqlcmd = new SqlCommand(QueryBusc, con))
                {
                    rdr = sqlcmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        InstituicaoDomain instDom = new InstituicaoDomain()
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome_Fantasia = rdr["NOME_FANTASIA"].ToString(),
                            Razao_Social = rdr["RAZAO_SOCIAL"].ToString(),
                            CNPJ = rdr["CNPJ"].ToString(),
                            Logradouro = rdr["LOGRADOURO"].ToString(),
                            CEP = rdr["CEP"].ToString(),
                            UF = rdr["UF"].ToString(),
                            Cidade = rdr["CIDADE"].ToString()
                        };

                        instituicao.Add(instDom);
                    }
                }
            }
            return instituicao;


        }

        public void Cadastrar(InstituicaoDomain Instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryCad = " INSERT INTO INSTITUICOES (Nome_Fantasia, Razao_Social, CNPJ, Logradouro, CEP, UF, Cidade) " +
                    "VALUES (@Nome_Fantasia, @Razao_Social, @CNPJ, @Logradouro, @CEP, @UF, @Cidade)";
                SqlCommand cmd = new SqlCommand(QueryCad, con);
                cmd.Parameters.AddWithValue("@Nome_Fantasia", Instituicao.Nome_Fantasia);
                cmd.Parameters.AddWithValue("@Razao_Social", Instituicao.Razao_Social);
                cmd.Parameters.AddWithValue("@CNPJ", Instituicao.CNPJ);
                cmd.Parameters.AddWithValue("@Logradouro", Instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", Instituicao.CEP);
                cmd.Parameters.AddWithValue("@UF", Instituicao.UF);
                cmd.Parameters.AddWithValue("@Cidade", Instituicao.Cidade);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void Delete(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryDel = "DELETE FROM INSTITUICOES WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(QueryDel, con);
                cmd.Parameters.AddWithValue("@ID", Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public List<InstituicaoDomain> Listar()
        {
            List<InstituicaoDomain> instituicao = new List<InstituicaoDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryList = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, UF, CIDADE FROM INSTITUICOES";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryList, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        InstituicaoDomain instDom = new InstituicaoDomain()                  
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome_Fantasia = rdr["NOME_FANTASIA"].ToString(),
                            Razao_Social = rdr["RAZAO_SOCIAL"].ToString(),
                            CNPJ = rdr["CNPJ"].ToString(),
                            Logradouro = rdr["LOGRADOURO"].ToString(),
                            CEP = rdr["CEP"].ToString(),
                            UF = rdr["UF"].ToString(),
                            Cidade = rdr["CIDADE"].ToString()
                        };

                        instituicao.Add(instDom);

                    }
                }
            }
            return instituicao;
        }
    }
}





/*
 
     using Senai.SVIGUFO.WebApi.Domains;
using Senai.SVIGUFO.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.SVIGUFO.WebApi.Repositorios
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
            private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=SVIGUFO;user id=sa; pwd=132";

        public void Alterar(InstituicaoDomain Instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryAlt = "UPDATE INSTITUICOES SET NOME_FANTASIA = @NOME_FANTASIA, RAZAO_SOCIAL = @RAZAO_SOCIAL," +
                    " CNPJ = @CNPJ, LOGRADOURO = @LOGRADOURO, CEP = @CEP, UF, @UF, CIDADE = @CIDADE WHERE ID = @ID ";
                SqlCommand cmd = new SqlCommand(QueryAlt, con);
                cmd.Parameters.AddWithValue("@Nome_Fantasia", Instituicao.Nome_Fantasia);
                cmd.Parameters.AddWithValue("@Razao_Social", Instituicao.Razao_Social);
                cmd.Parameters.AddWithValue("@CNPJ", Instituicao.CNPJ);
                cmd.Parameters.AddWithValue("@Logradouro", Instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", Instituicao.CEP);
                cmd.Parameters.AddWithValue("@UF", Instituicao.UF);
                cmd.Parameters.AddWithValue("@Cidade", Instituicao.Cidade);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<InstituicaoDomain> Buscar(InstituicaoDomain Instituicao)
        {
            List<InstituicaoDomain> instituicao = new List<InstituicaoDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryBusc = "SELECT * FROM INSTITUICOES WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(QueryBusc, con);
                con.Open();
                cmd.ExecuteReader();
                SqlDataReader rdr;
                rdr = MetodoDeSearch(instituicao, con, QueryBusc);
            }

            return Instituicao;
        }

        public void Cadastrar(InstituicaoDomain Instituicao)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryCad = " INSERT INTO INSTITUICOES (Nome_Fantasia, Razao_Social, CNPJ, Logradouro, CEP, UF, Cidade) " +
                    "VALUES (@Nome_Fantasia, @Razao_Social, @CNPJ, @Logradouro, @CEP, @UF, @Cidade)";
                SqlCommand cmd = new SqlCommand(QueryCad, con);
                cmd.Parameters.AddWithValue("@Nome_Fantasia", Instituicao.Nome_Fantasia);
                cmd.Parameters.AddWithValue("@Razao_Social", Instituicao.Razao_Social);
                cmd.Parameters.AddWithValue("@CNPJ", Instituicao.CNPJ);
                cmd.Parameters.AddWithValue("@Logradouro", Instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", Instituicao.CEP);
                cmd.Parameters.AddWithValue("@UF", Instituicao.UF);
                cmd.Parameters.AddWithValue("@Cidade", Instituicao.Cidade);
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void Delete(int Id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryDel = "DELETE FROM INSTITUICOES WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(QueryDel, con);
                cmd.Parameters.AddWithValue("@ID", Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public List<InstituicaoDomain> Listar()
        {
            List<InstituicaoDomain> instituicao = new List<InstituicaoDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryList = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, UF, CIDADE FROM INSTITUICOES";
                con.Open();
                SqlDataReader rdr;
                rdr = MetodoDeSearch(instituicao, con, QueryList);
            }
            return instituicao;
        }

        private static SqlDataReader MetodoDeSearch(List<InstituicaoDomain> instituicao, SqlConnection con, string QueryList)
        {
            SqlDataReader rdr;
            using (SqlCommand cmd = new SqlCommand(QueryList, con))
            {
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    InstituicaoDomain instDom = new InstituicaoDomain()
                    {
                        Id = Convert.ToInt32(rdr["ID"]),
                        Nome_Fantasia = rdr["NOME_FANTASIA"].ToString(),
                        Razao_Social = rdr["RAZAO_SOCIAL"].ToString(),
                        CNPJ = rdr["CNPJ"].ToString(),
                        Logradouro = rdr["LOGRADOURO"].ToString(),
                        CEP = rdr["CEP"].ToString(),
                        UF = rdr["UF"].ToString(),
                        Cidade = rdr["CIDADE"].ToString()
                    };

                    instituicao.Add(instDom);

                }
            }

            return rdr;
        }
    }
}

     
     */



