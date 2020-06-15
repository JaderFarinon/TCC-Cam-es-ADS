using MyPetWS.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

        internal string Login(Conexao conex, string login, string senha)
        {
            string strSql = "SELECT ds_usuario, ds_pass FROM mypet.dbo.usuario WHERE ds_usuario='" + login + "' AND ds_pass='" + senha + "'";

            try
            {
                DbDataReader rd = conex.ExecuteReader(strSql);

                while (rd.Read())
                {
                    if (rd.HasRows)
                        return "true";
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Desconectar();
            }

            return "false";

            //Response.Redirect("/global/Dashboard/projeto/blank.aspx");
            //txtLogin.Text = reader["usuCpf"].ToString() + " " + reader["usuNome"].ToString();
            //txtSenha.Text = reader["usuNome"].ToString();
        }
    }
}