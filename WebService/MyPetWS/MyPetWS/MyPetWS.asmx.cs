using MyPetWS.BusinessLogic;
using MyPetWS.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyPetWS
{
    /// <summary>
    /// Descrição resumida de MyPetWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    [System.Web.Script.Services.ScriptService]
    public class MyPetWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Olá, Mundo";
        }

        [WebMethod]
        public string TesteConexao()
        {
            Conexao conex = new Conexao();

            if (conex.Conectar())
            {
                return "Conectado!";
            }

            return "Erro Conexão!";
        }

        [WebMethod]
        public DataTable ListarUsuarios()
        {
            Conexao conex = new Conexao();

            if (conex.Conectar())
            {
                MyPetBl myPetBl = new MyPetBl();
                return (myPetBl.Usuario(conex));
            }

            return null;
        }

        [WebMethod]
        public string Login(string login, string senha)
        {
            Conexao conex = new Conexao();

            if (conex.Conectar())
            {
                MyPetBl myPetBl = new MyPetBl();
                return (myPetBl.Login(conex, login, senha));
            }

            return null;
        }

        [WebMethod]
        public DataTable DadosUsuario(string login, string senha)
        {
            Conexao conex = new Conexao();

            if (conex.Conectar())
            {
                MyPetBl myPetBl = new MyPetBl();
                return (myPetBl.DadosUsuario(conex, login, senha));
            }

            return null;
        }

        [WebMethod]
        public DataTable ListarProdutos(int idUsuario)
        {
            Conexao conex = new Conexao();

            if (conex.Conectar())
            {
                MyPetBl myPetBl = new MyPetBl();
                return (myPetBl.ListarProdutos(conex, idUsuario));
            }

            return null;
        }

        [WebMethod]
        public DataTable GravarProduto(string nome, int tipo, decimal valor, string ie_entrega, int id_usuario)
        {
            Conexao conex = new Conexao();

            if (conex.Conectar())
            {
                MyPetBl myPetBl = new MyPetBl();
                return (myPetBl.GravarProduto(conex, nome, tipo, valor, ie_entrega, id_usuario));
            }

            return null;
        }

        [WebMethod]
        public DataTable ListarProdServ()
        {
            Conexao conex = new Conexao();

            if (conex.Conectar())
            {
                MyPetBl myPetBl = new MyPetBl();
                return (myPetBl.ListarProdServ(conex));
            }

            return null;
        }
    }
}
