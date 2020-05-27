using GlobalProjectWS.DataAccess;
//using SQLFuncoes;
using System;
using System.Data;

namespace GlobalProjectWS.BussinesLogic
{
    public class GlobalProjectBll
    {
        internal DataTable DadosUsuario(ConexaoMySql conex, string login, string senha)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.DadosUsuario(conex, login, senha);
        }

        internal DataTable DadosUsuario(ConexaoMySql conex, string cpf)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.DadosUsuario(conex, cpf);
        }

        internal string Login(ConexaoMySql conex, string login, string senha)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.Login(conex, login, senha);
        }

        internal DataTable ListarProcedimentos(ConexaoMySql conex, string keyword)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.ListarProcedimentos(conex, keyword);
        }

        internal DataTable ListarGrupos(ConexaoMySql conex)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.ListarGrupos(conex);
        }

        internal DataTable ListarGrupos(ConexaoMySql conex, int gruId)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.ListarGrupos(conex, gruId);
        }

        internal void ExcluirGrupo(ConexaoMySql conex, int gruId)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            globalProjectSql.ExcluirGrupo(conex, gruId);
        }

        internal DataTable ListarProcedimentos(ConexaoMySql conex, int parceiro)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.ListarProcedimentos(conex, parceiro);
        }

        internal DataTable ListarProcedimentos(ConexaoMySql conex, int parceiro, string procedimentos)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.ListarProcedimentos(conex, parceiro, procedimentos);
        }

        internal DataTable ListarLocalidades(ConexaoMySql conex, string procedimentos)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.ListarLocalidades(conex, procedimentos);
        }

        internal DataTable ListarParceiros(ConexaoMySql conex, string procedimentos, string localidade)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.ListarParceiros(conex, procedimentos, localidade);
        }

        internal DataTable ListarParceiros(ConexaoMySql conex)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.ListarParceiros(conex);
        }

        internal DataTable ListarUnidades(ConexaoMySql conex)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.ListarUnidades(conex);
        }

        internal int GravarUsuario(ConexaoMySql conex, int usuId, int idCadGobal, int unidade, string nome, string sexo, string CPF, string nascimento, int telefoneDDD, int telefone, int celularDDD, int celular, int cep, string rua, int numero, string complemento, string bairro, string cidade, string UF, string email, string senha)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.GravarUsuario(conex, usuId, idCadGobal, unidade, nome, sexo, CPF, nascimento, telefoneDDD, telefone, celularDDD, celular, cep, rua, numero, complemento, bairro, cidade, UF, email, senha);
        }

        internal int GravarGrupo(ConexaoMySql conex, int gruId, int parceiro, string descricao, int qtdProcedimentos, int usuId)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.GravarGrupo(conex, gruId, parceiro, descricao, qtdProcedimentos, usuId);
        }

        internal void GravarProcedimentosGrupo(ConexaoMySql conex, int gruId, int procedimento)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            globalProjectSql.GravarProcedimentosGrupo(conex, gruId, procedimento);
        }

        internal int GravarGuia(ConexaoMySql conex, int unidade, int parceiro, int associado, decimal valorTotal)
        {
            GlobalProjectBll globalProjectBll = new GlobalProjectBll();
            return GlobalProjectSql.GravarGuia(conex, unidade, parceiro, associado, valorTotal);
        }

        internal int GravarItem(ConexaoMySql conex, int idGuia, int procedimento, decimal valor)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.GravarItem(conex, idGuia, procedimento, valor);
        }

        internal DataTable ListarAgendamentos(ConexaoMySql conex, int usuId)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.ListarAgendamentos(conex, usuId);
        }

        internal int GravarCartao(ConexaoMySql conex, int usuId, string nome, Int64 numero, int mes, int ano, string bandeira)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.GravarCartao(conex, usuId, nome, numero, mes, ano, bandeira);
        }

        internal void ExcluirCartao(ConexaoMySql conex, int carId)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            globalProjectSql.ExcluirCartao(conex, carId);
        }

        internal DataTable ListarCartao(ConexaoMySql conex, int usuId)
        {
            GlobalProjectSql globalProjectSql = new GlobalProjectSql();
            return globalProjectSql.ListarCartao(conex, usuId);
        }

        //private bool CaixaAbertoUsuario(classConexao conex, int cxaUsuAtual)//carregar ddlCaixa 
        //{
        //    CaixaAditivoSql arquivoSql = new CaixaAditivoSql();
        //    return !arquivoSql.CaixaAberto(conex, cxaUsuAtual).Rows.Count.Equals(0);
        //}
    }
}