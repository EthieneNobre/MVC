using System.Data.SqlClient;

namespace Model.Dal
{
    class ConexaoDB
    {
        private static ConexaoDB objCobnexaiDb = null;
        private SqlConnection con;

        private ConexaoDB() // CONEXAO COM BANCO DE DADOS
        {
            try
            {
                con = new SqlConnection(@"Data Source=gruporai2.clientes.ananke.com.br;Initial Catalog=testes_Eric;User ID=testes_Eric;Password=Bagzqjai;");
            }
            catch (System.Exception)
            {

                throw;
            } 
        }

        public static ConexaoDB EstadoConexao() // VERIFICA ESTADO DA CONEXAO SE ESTA ABERTA OU FECHADA
        {
            try
            {
                if (objCobnexaiDb == null)
                {
                    objCobnexaiDb = new ConexaoDB();
                }

                return objCobnexaiDb;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public SqlConnection GetCon()
        {
            try
            {
                return con;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public void CloseDB()
        {
            try
            {
                objCobnexaiDb = null; 
            }
            catch (System.Exception)
            {

                throw;
            }
        }
          
    }
}
