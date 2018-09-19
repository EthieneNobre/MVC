using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dal
{
    public class ClienteDao : Intermediacao<Cliente>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public ClienteDao()
        {
            objConexaoDB = ConexaoDB.EstadoConexao();

        }
        //-----------------------------------------------------------------------------------------------------------------------
        public void create(Cliente objCliente)
        {
            string create = "INSERT INTO tb_Fin_Cliente (NomeCliente,  Endereco, Cpf, Email, Senha, Ativo) VALUES (" + objCliente.NomeCliente + "," + objCliente.Endereco + "," + objCliente.Cpf + "," + objCliente.Email + "," + objCliente.Senha + ",1)";

            try
            {
                comando = new SqlCommand(create, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            finally
            {
                objConexaoDB.GetCon().Close();
                objConexaoDB.CloseDB();
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------
        public void createProcedure(Cliente objCliente)
        {
            string create = "sp_InsereCliente" + objCliente.NomeCliente + "," + objCliente.Endereco + "," + objCliente.Cpf + "," + objCliente.Email + "," + objCliente.Senha;

            try
            {
                comando = new SqlCommand(create, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            finally
            {
                objConexaoDB.GetCon().Close();
                objConexaoDB.CloseDB();
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------
        public void delete(Cliente objCliente)
        {
            string delete = "sp_ExcluiCliente" + objCliente.idCliente;

            try
            {
                comando = new SqlCommand(delete, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            finally
            {
                objConexaoDB.GetCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------
        public bool find(Cliente objCliente)
        {
            bool Registro;

            string find = "SELECT * FROM tb_Fin_Cliente WHERE idCliente = " + objCliente.idCliente + "  AND Ativo = 1";

            try
            {
                comando = new SqlCommand(find, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();

                SqlDataReader reader = comando.ExecuteReader();

                Registro = reader.Read();

                if (Registro)
                {
                    objCliente.NomeCliente = reader[1].ToString();
                    objCliente.Endereco = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                    objCliente.Email = reader[5].ToString();
                    objCliente.Senha = reader[6].ToString();
                    objCliente.Estado = 99;
                }
                else
                {
                    objCliente.Estado = 1;
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            finally
            {
                objConexaoDB.GetCon().Close();
                objConexaoDB.CloseDB();
            }

            return Registro;

        }
        //-----------------------------------------------------------------------------------------------------------------------
        public List<Cliente> findAll()
        {

            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "SELECT * FROM tb_Fin_Cliente WHERE Ativo = 1 ORDER BY NomeCliente";

            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();

                SqlDataReader reader = comando.ExecuteReader();



                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();

                    objCliente.idCliente = Convert.ToInt32(reader[0].ToString());
                    objCliente.NomeCliente = reader[1].ToString();
                    objCliente.Endereco = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                    objCliente.Email = reader[5].ToString();
                    objCliente.Senha = reader[6].ToString();

                    listaClientes.Add(objCliente);
                }

                return listaClientes;

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            finally
            {
                objConexaoDB.GetCon().Close();
                objConexaoDB.CloseDB();
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------
        public List<Cliente> findAllCliente(Cliente objCLiente)
        {

            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "SELECT * FROM tb_Fin_Cliente WHERE Ativo = 1 ORDER BY NomeCliente";

            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();

                SqlDataReader reader = comando.ExecuteReader();



                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();

                    objCliente.idCliente = Convert.ToInt32(reader[0].ToString());
                    objCliente.NomeCliente = reader[1].ToString();
                    objCliente.Endereco = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                    objCliente.Email = reader[5].ToString();
                    objCliente.Senha = reader[6].ToString();

                    listaClientes.Add(objCliente);
                }

                return listaClientes;

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            finally
            {
                objConexaoDB.GetCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public List<Cliente> findAllId(int id)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "SELECT * FROM tb_Fin_Cliente WHERE idCliente = " + id + " AND Ativo = 1 ORDER BY NomeCliente";

            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();

                SqlDataReader reader = comando.ExecuteReader();



                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();

                    objCliente.idCliente = Convert.ToInt32(reader[0].ToString());
                    objCliente.NomeCliente = reader[1].ToString();
                    objCliente.Endereco = reader[3].ToString();
                    objCliente.Cpf = reader[4].ToString();
                    objCliente.Email = reader[5].ToString();
                    objCliente.Senha = reader[6].ToString();

                    listaClientes.Add(objCliente);
                }

                return listaClientes;

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            finally
            {
                objConexaoDB.GetCon().Close();
                objConexaoDB.CloseDB();
            }
        }



        //-----------------------------------------------------------------------------------------------------------------------
        public void update(Cliente objCliente)
        {
            string update = "sp_AlteraCliente" + objCliente.idCliente + "," + objCliente.NomeCliente + "," + objCliente.Endereco + "," + objCliente.Cpf + "," + objCliente.Email + "," + objCliente.Senha;

            try
            {
                comando = new SqlCommand(update, objConexaoDB.GetCon());
                objConexaoDB.GetCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            finally
            {
                objConexaoDB.GetCon().Close();
                objConexaoDB.CloseDB();
            }
        }
    }
}

