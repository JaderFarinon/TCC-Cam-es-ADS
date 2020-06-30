using MyPetWS.DataAccess;
using MyPetWS.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyPetWS.BusinessLogic
{
    public class MyPetBl
    {
        internal DataTable Usuario(Conexao conex)
        {
            MyPetSQL myPetSql = new MyPetSQL();
            return myPetSql.Usuarios(conex);
        }

        internal string Login(Conexao conex, string login, string senha)
        {
            MyPetSQL myPetSql = new MyPetSQL();
            return myPetSql.Login(conex, login, senha);
        }

        internal DataTable DadosUsuario(Conexao conex, string login, string senha)
        {
            MyPetSQL myPetSql = new MyPetSQL();
            return myPetSql.DadosUsuario(conex, login, senha);
        }

        internal DataTable ListarProdutos(Conexao conex, int idUsuario)
        {
            MyPetSQL myPetSql = new MyPetSQL();
            return myPetSql.ListarProdutos(conex, idUsuario);
        }

        internal DataTable GravarProduto(Conexao conex, string nome, int tipo, decimal valor, string ie_entrega, int id_usuario)
        {
            MyPetSQL myPetSql = new MyPetSQL();
            return myPetSql.GravarProduto(conex, nome, tipo, valor, ie_entrega, id_usuario);
        }

        internal DataTable ListarProdServ(Conexao conex)
        {
            MyPetSQL myPetSql = new MyPetSQL();
            return myPetSql.ListarProdServ(conex);
        }
    }
}