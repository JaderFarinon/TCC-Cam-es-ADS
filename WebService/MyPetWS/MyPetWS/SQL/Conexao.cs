using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Common;

namespace MyPetWS.SQL
{
    public class Conexao
    {
        public SqlConnection conn = new SqlConnection();
        public bool Conectado = false;

        public Conexao()
        {
            conn.ConnectionString = "Data Source=DESKTOP-9MV0DRM\\SQLSERVER;Initial Catalog=mypet;Integrated Security=True";
        }

        public bool Conectar() 
        {
            try
            {
                conn.Open();
                Conectado = true;
            }
            catch 
            {
                Conectado = false;
            }
            return Conectado;
        }

        public void Desconectar()
        {
            conn.Close();
        }

        public DbDataReader ExecuteReader(string comandoSql)
        {
            //ExecuteReader retorna objeto
            if (Conectado) //bdConn.State == ConectrionState.Open
            {
                //armazena o comando SQL
                SqlCommand cmd = new SqlCommand(comandoSql, conn);
                return cmd.ExecuteReader();

            }

            return null;
        }
    }
}