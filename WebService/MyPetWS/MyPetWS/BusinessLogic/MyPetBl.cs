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
    }
}