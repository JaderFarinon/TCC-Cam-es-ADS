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
            string strSql = "select * from mypet.dbo.usuario";

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
            string strSql = "select ds_usuario, ds_pass from mypet.dbo.usuario where ds_usuario='" + login + "' and ds_pass='" + senha + "'";

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
        }

        internal DataTable DadosUsuario(Conexao conex, string login, string senha)
        {
            string strSql = "select	 a.*," +
                                    "b.*," +
                                    "c.* " +
                            "from mypet.dbo.usuario a " +
                            "left join mypet.dbo.pessoa_fisica b on (b.id = a.id_cad and a.ie_tipo = 'PF')" +
                            "left join mypet.dbo.pessoa_juridica c on(c.id = a.id_cad and a.ie_tipo = 'PJ')" +
                            "where ds_usuario='" + login + "' and ds_pass='" + senha + "'";

            try
            {
                DataTable dt = new DataTable("DadosUsuario");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Desconectar();
            }
        }

        internal DataTable ListarProdutos(Conexao conex, int idUsuario)
        {
            string strSql = "select  a.id, " +
                                    "a.ds_produto, " +
                                    "b.ds_tipo, " +
                                    "a.vl_produto, " +
                                    "isnull(c.vl_promo,a.vl_produto) vl_promo " +
                            "from mypet.dbo.produto a " +
                            "inner join mypet.dbo.tipo b on b.id = a.id_tipo " +
                            "left join mypet.dbo.promocao c on(c.id_prod_serv = a.id and(getdate() between c.dt_inicial and c.dt_final or(c.dt_final is null))) "+
                            "where a.id_usuario='" + idUsuario + "'";
            try
            {
                DataTable dt = new DataTable("ListaProdutos");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Desconectar();
            }
        }

        internal DataTable GravarProduto(Conexao conex, string nome, int tipo, decimal valor, string ie_entrega, int id_usuario)
        {
            string strSql = "insert into mypet.dbo.produto (ds_produto, dt_inicio, dt_final, vl_produto, ie_entrega, id_tipo, id_usuario)" +
                            "values('"+ nome +"', getdate(), null, " + valor.ToString().Replace(',','.') + ", 'S', "+ tipo +", "+ id_usuario +")";
            try
            {
                DataTable dt = new DataTable("GravarProduto");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Desconectar();
            }
        }

        internal DataTable ListarProdServ(Conexao conex)
        {
            string strSql = "select * " +
                            "from mypet.dbo.produto " +
                            "union all " +
                            "select * " +
                            "from mypet.dbo.servico";
            try
            {
                DataTable dt = new DataTable("ListarProdServ");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (SqlException ex)
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