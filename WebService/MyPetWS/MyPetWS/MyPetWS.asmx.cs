using MyPetWS.BusinessLogic;
using MyPetWS.SQL;
using System;
using System.Collections.Generic;
using System.Data;
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
    // [System.Web.Script.Services.ScriptService]
    public class MyPetWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Olá, Mundo";
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
    }
}
