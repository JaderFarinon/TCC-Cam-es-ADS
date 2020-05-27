using GlobalProjectWS.BussinesLogic;
using System;
using System.Data;
using System.Web.Services;

namespace GlobalProjectWS
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(true)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    [System.Web.Script.Services.ScriptService]
    public class GlobalProjectWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Olá, Mundo";
        }

        [WebMethod]
        public DataTable DadosUsuario(string login, string senha)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.DadosUsuario(conex, login, senha));
            }

            return null;
        }

        [WebMethod]
        public DataTable BuscarUsuario(string cpf)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.DadosUsuario(conex, cpf));
            }

            return null;
        }

        [WebMethod]
        public string Login(string login, string senha)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.Login(conex, login, senha));
            }

            return null;
        }

        [WebMethod]
        public DataTable ListarProcedimentos(string keyword)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.ListarProcedimentos(conex, keyword));
            }

            return null;
        }

        [WebMethod]
        public DataTable ListarGrupos()
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.ListarGrupos(conex));
            }

            return null;
        }

        [WebMethod]
        public DataTable ListarGrupoId(int gruId)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.ListarGrupos(conex, gruId));
            }

            return null;
        }

        [WebMethod]
        public void ExcluirGrupo(int gruId)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                globalProjectBll.ExcluirGrupo(conex, gruId);
            }
        }

        [WebMethod]
        public DataTable ListarProcedimentosParc(int parceiro)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.ListarProcedimentos(conex, parceiro));
            }

            return null;
        }

        [WebMethod]
        public DataTable ListarLocalidades(string procedimento)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.ListarLocalidades(conex, procedimento));
            }

            return null;
        }

        [WebMethod]
        public DataTable ListarParceiros(string procedimento, string localidade)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.ListarParceiros(conex, procedimento, localidade));
            }

            return null;
        }

        [WebMethod]
        public DataTable ListarParceirosAll()
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.ListarParceiros(conex));
            }

            return null;
        }

        [WebMethod]
        public DataTable ListarUnidades()
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.ListarUnidades(conex));
            }

            return null;
        }

        [WebMethod]
        public int GravarUsuario(int usuId, int idCadGobal, int unidade, string nome, string sexo, string CPF, string nascimento, int telefoneDDD, int telefone, int celularDDD, int celular, int cep, string rua, int numero, string complemento, string bairro, string cidade, string UF, string email, string senha)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.GravarUsuario(conex, usuId, idCadGobal, unidade, nome, sexo, CPF, nascimento, telefoneDDD, telefone, celularDDD, celular, cep, rua, numero, complemento, bairro, cidade, UF, email, senha));
            }

            return 0;
        }

        [WebMethod]
        public DataTable ListarProcedimentosGrupo(int parceiro, string procedimentos)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.ListarProcedimentos(conex, parceiro, procedimentos));
            }

            return null;
        }

        [WebMethod]
        public int GravarGrupo(int gruId, int parceiro, string descricao, int qtdProcedimentos, int usuId)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return globalProjectBll.GravarGrupo(conex, gruId, parceiro, descricao, qtdProcedimentos, usuId);
            }

            return 0;
        }

        [WebMethod]
        public void GravarProcedimentosGrupo(int gruId, int procedimento)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                globalProjectBll.GravarProcedimentosGrupo(conex, gruId, procedimento);
            }
        }

        [WebMethod]
        public int GravarGuia(int unidade, int parceiro, int associado, decimal valorTotal)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return globalProjectBll.GravarGuia(conex, unidade, parceiro, associado, valorTotal);
            }

            return 0;
        }

        [WebMethod]
        public int GravarItem(int idGuia, int procedimento, decimal valor)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return globalProjectBll.GravarItem(conex, idGuia, procedimento, valor);
            }

            return 0;
        }

        [WebMethod]
        public DataTable ListarAgendamentos(int usuId)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.ListarAgendamentos(conex, usuId));
            }

            return null;
        }

        [WebMethod]
        public int GravarCartao(int usuId, string nome, Int64 numero, int mes, int ano, string bandeira)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return globalProjectBll.GravarCartao(conex, usuId, nome, numero, mes, ano, bandeira);
            }

            return 0;
        }

        [WebMethod]
        public void ExcluirCartao(int carId)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                globalProjectBll.ExcluirCartao(conex, carId);
            }
        }

        [WebMethod]
        public DataTable ListarCartao(int usuId)
        {
            ConexaoMySql conex = new ConexaoMySql();

            if (conex.Open())
            {
                GlobalProjectBll globalProjectBll = new GlobalProjectBll();
                return (globalProjectBll.ListarCartao(conex, usuId));
            }

            return null;
        }
    }
}
