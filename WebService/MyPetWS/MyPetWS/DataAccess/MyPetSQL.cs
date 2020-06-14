using MyPetWS.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyPetWS.DataAccess
{
    public class MyPetSQL
    {
        internal DataTable Usuarios(Conexao conex)
        {
            string strSql = "SELECT * FROM mypet.dbo.usuario";

            try
            {
                DataTable dt = new DataTable("Usuario");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Desconectar();
            }
        }
    }
}