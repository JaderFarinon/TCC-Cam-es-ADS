
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

namespace GlobalProjectWS
{
    /// <summary>
    /// Classe para conexão com Mysql
    /// </summary>
    public class ConexaoMySql
    {
        //private string Server = "node1897-env-4825984.jelastic.saveincloud.net";
        private string Server = "10.100.17.109"; //localização do servidor (IP) --Produção
        private string Database = "global_app";  //nome do database (schema)
        private string Usuario = "app_global";   //identificação do usuário
        private string Senha = "ASDf1ad61f5";    //password
        private string Porta = "3306";           //porta --Produção
        //private string Porta = "11017";

        //string de conexão
        private string strCnx = "";
        //conexão com MySQL
        private MySqlConnection bdConn;

        /// <summary>
        /// Status da conexão
        /// </summary>
        public bool Conectado = false;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="database">Nome do database</param>
        /// <param name="user">Usuário válido</param>
        /// <param name="password">Senha</param>
        /// <param name="server">Nome do servidor (default = localhost)</param>
        public ConexaoMySql()
        {
            strCnx = string.Format("server={0}; user id={2}; pwd='{3}'; database={1}; port={4}; Connect Timeout=28800; Command Timeout=2880; SslMode=none; convert zero datetime=True", this.Server, this.Database, this.Usuario, this.Senha, this.Porta);
        }

        /// <summary>
        /// Abre a conexão com o MySql
        /// </summary>
        /// <returns>se a conexão foi aberta com sucesso</returns>
        public bool Open()
        {
            //Define string de conexão
            bdConn = new MySqlConnection(strCnx);

            //tenta abrir conexão com o MySql
            try
            {
                bdConn.Open();
                Conectado = true;
            }
            catch (MySqlException ex) //Exception ex
            {
                Conectado = false;
            }

            return Conectado;
        }

        /// <summary>
        /// Fecha conexão com o Banco de Dados
        /// </summary>
        public void Close()
        {
            bdConn.Close();
            bdConn.Dispose();
        }

        /// <summary>
        /// Executar um comando SQL que retorna um DataTable
        /// </summary>
        /// <param name="comandoSql">Comando SQL</param>
        /// <returns>DataTable contendo o resultado da consulta</returns>
        public DataTable ExecuteQuery(string comandoSql)
        {
            //ExecuteQuery retorna datatable
            if (Conectado) //bdConn.State == ConectrionState.Open
            {
                //armazena o comando SQL
                MySqlCommand cmd = new MySqlCommand(comandoSql, bdConn);
                //cmd.CommandType = System.Data.CommandType.Text;

                //cria um datatable
                DataTable dt = new DataTable();
                //interface de dados
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                //armazenar dados da interface no datatable
                da.Fill(dt);
                //preencher o datagridview com os dados do datatable
                return dt;
            }

            return null;
        }

        /// <summary>
        /// Executar um comando SQL que retorna um objeto
        /// </summary>
        /// <param name="comandoSql">Comando SQL</param>
        /// <returns>Objeto contendo o resultado da consulta</returns>
        public object ExecuteScalar(string comandoSql)
        {
            //ExecuteScalar retorna objeto
            if (Conectado) //bdConn.State == ConectrionState.Open
            {
                //armazena o comando SQL
                MySqlCommand cmd = new MySqlCommand(comandoSql, bdConn);
                return cmd.ExecuteScalar();
            }

            return null;
        }

        /// <summary>
        /// Executar um comando SQL que retorna um objeto
        /// </summary>
        /// <param name="comandoSql">Comando SQL</param>
        /// <returns>DbDataReader contendo o resultado da consulta</returns>
        public DbDataReader ExecuteReader(string comandoSql)
        {
            //ExecuteReader retorna objeto
            if (Conectado) //bdConn.State == ConectrionState.Open
            {
                //armazena o comando SQL
                MySqlCommand cmd = new MySqlCommand(comandoSql, bdConn);
                return cmd.ExecuteReader(CommandBehavior.Default);

                /*
                MySqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    if (rd.HasRows)
                        return "true";
                }
                */
            }

            //MySqlDataReader rd = cmd.ExecuteReader();
            //dt.Load(rd);
            //return dt;

            return null;
        }

        /// <summary>
        /// Executar um comando SQL que retorna registros afetados
        /// </summary>
        /// <param name="comandoSql">Comando SQL</param>
        /// <returns>registros afetados</returns>
        public int ExecuteNonQuery(string comandoSql)
        {
            //ExecuteNonQuery retorna afetados
            if (Conectado) //bdConn.State == ConectrionState.Open
            {
                //armazena o comando SQL
                MySqlCommand cmd = new MySqlCommand(comandoSql, bdConn);
                return cmd.ExecuteNonQuery();
            }

            return 0;
        }

        public void preencher()
        {
            ConexaoMySql cnx = new ConexaoMySql();

            if (cnx.Open())
            {
                cnx.ExecuteQuery("select");
                //dgv.DataSource = cnx.ExecuteQuery("select");
            }
        }

        public void preencher2()
        {
            ConexaoMySql cnx = new ConexaoMySql();

            if (cnx.Open())
            {
                // cria comando sql
                string cmd = "select";

                // executa comando sql
                cnx.ExecuteQuery(cmd);


            }
        }
    }
}

// Log
// Fechar conexão
// Transação
// Rollback