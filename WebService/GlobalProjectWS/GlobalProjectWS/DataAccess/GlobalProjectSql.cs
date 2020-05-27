using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;

namespace GlobalProjectWS.DataAccess
{
    public class GlobalProjectSql
    {
        internal DataTable DadosUsuario(ConexaoMySql conex, string login, string senha)
        {
            string strSql = "SELECT " +
                "usuId, idCadGlobal, idUnidade, uni.nome, usuNome, usuIniciais, usuSexo, usuCpf, usuDtNascimento, " +
                "usuTelefone, usuCep, usuRua, usuNumero, usuComplemento, usuEmail, usuSenha, usuDtCadastro, usuDtAcesso " +
                "FROM global_app.usuario usu " +
                "INNER JOIN global_producao_utf8.unidades uni ON uni.id = usu.idUnidade " +
                "WHERE usuCpf='" + login + "' AND usuSenha='" + senha + "'";

            try
            {
                DataTable dt = new DataTable("DadosUsuario");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal DataTable DadosUsuario(ConexaoMySql conex, string cpf)
        {
            string strSql = "SELECT CASE usuId WHEN NULL THEN 'null' ELSE 'APP' END AS dsTipo, usuId, " +
                "idCadGlobal, idUnidade, uni.nome, usuNome, usuSexo, usuCpf, usuDtNascimento, " +
                "usuTelefoneDDD, usuTelefone,  usuCelularDDD, usuCelular, usuCep, usuRua, usuNumero, " +
                "usuComplemento, usuBairro, usuCidade, usuUF, usuEmail, usuSenha, usuDtCadastro, usuDtAcesso " +
                "FROM global_app.usuario usu " +
                "INNER JOIN global_producao_utf8.unidades uni ON uni.id = usu.idUnidade WHERE usuCpf = '" + cpf + "'";

            try
            {
                DataTable dt = new DataTable("DadosUsuario");
                dt.Load(conex.ExecuteReader(strSql));


                if (dt.Rows.Count == 0)
                {
                    strSql = "SELECT CASE ass.id WHEN NULL THEN 'null' ELSE 'GLOBAL' END AS dsTipo, 0 usuId, ass.id AS idCadGlobal, " +
                        "unidade_id AS idUnidade, uni.nome, ass.nome AS usuNome, '' usuSexo, cpf usuCpf, data_nascimento usuDtNascimento, " +
                        "SUBSTRING(ass.fone, 2, 2) AS usuTelefoneDDD, " +
                        "CONCAT(SUBSTRING(REPLACE(ass.fone, CHAR(32), ''), 5, 4), " +
                        "SUBSTRING(REPLACE(ass.fone, CHAR(32), ''), 10, 4)) AS usuTelefone, " +
                        "SUBSTRING(ass.fone2, 2, 2) AS usuCelularDDD, " +
                        "CONCAT(SUBSTRING(REPLACE(ass.fone2, CHAR(32), ''), 5, 4), " +
                        "SUBSTRING(REPLACE(ass.fone2, CHAR(32), ''), 10, 4)) AS usuCelular, REPLACE(IFNULL(ass.cep, ''), CHAR(45), '') usuCep, ass.endereco usuRua, " +
                        "0 usuNumero, '' usuComplemento, ass.bairro AS usuBairro, ass.cidade AS usuCidade, ass.uf AS usuUF, IFNULL(ass.email,'') usuEmail, '' usuSenha, data_cadastro usuDtCadastro, '1900-01-01' usuDtAcesso " +
                        "FROM global_producao_utf8.associados ass " +
                        "INNER JOIN global_producao_utf8.unidades uni ON uni.id = ass.unidade_id WHERE cpf = '" + cpf + "'";

                    dt = new DataTable("DadosUsuario");
                    dt.Load(conex.ExecuteReader(strSql));
                }


                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal DataTable ListarProcedimentos(ConexaoMySql conex, string keyword)
        {
            string strSql = "SELECT pro.nome, COUNT(par.id) qt_parceiros " +
                "FROM global_producao_utf8.procedimentos pro " +
                "INNER JOIN global_producao_utf8.parceiros par ON par.id = pro.parceiro_id " +
                "WHERE pro.status = 1 " +
                "AND UPPER(pro.nome) LIKE UPPER('%" + keyword + "%') " +
                "AND par.status = 1 " +
                "AND(par.unidade_id LIKE '%11%' OR par.unidade_id LIKE '%1%' OR par.unidade_id LIKE '%5%' OR par.unidade_id LIKE '%16%') " +
                "GROUP BY nome " +
                "ORDER BY nome";

            //SELECT nome FROM global_producao_utf8.procedimentos WHERE status = 1 ORDER BY nome LIMIT 200

            try
            {
                DataTable dt = new DataTable("Procedimentos");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal DataTable ListarGrupos(ConexaoMySql conex)
        {
            string strSql = "SELECT gru.gruId, par.nome Parceiro, gruDescricao Descrição, " +
                "(SELECT COUNT(*) FROM grupoProcedimentos WHERE gruId=gru.gruId) Quantidade " +
                "FROM grupo gru " +
                "INNER JOIN global_producao_utf8.parceiros par ON par.id = gru.parceiroId " +
                "INNER JOIN grupoProcedimentos grp ON grp.gruId = gru.gruId " +
                "WHERE gruDtExclusao IS NULL " +
                "GROUP BY gru.gruId; ";

            //SELECT nome FROM global_producao_utf8.procedimentos WHERE status = 1 ORDER BY nome LIMIT 200

            try
            {
                DataTable dt = new DataTable("Procedimentos");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal DataTable ListarGrupos(ConexaoMySql conex, int gruId)
        {
            string strSql = "SELECT gru.gruId, par.id, par.nome Parceiro, gruDescricao Descrição, pro.Id, pro.nome " +
                "FROM grupo gru " +
                "INNER JOIN global_producao_utf8.parceiros par ON par.id = gru.parceiroId " +
                "INNER JOIN grupoProcedimentos grp ON grp.gruId = gru.gruId " +
                "INNER JOIN global_producao_utf8.procedimentos pro ON pro.id = grp.procedimentoId " +
                "WHERE gru.gruId = " + gruId;

            //SELECT nome FROM global_producao_utf8.procedimentos WHERE status = 1 ORDER BY nome LIMIT 200

            try
            {
                DataTable dt = new DataTable("Procedimentos");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal void ExcluirGrupo(ConexaoMySql conex, int gruId)
        {
            try
            {
                string strSql = "UPDATE grupo SET gruDtExclusao = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', gruUsuIdExclusao = 1 WHERE gruId=" + gruId;
                conex.ExecuteNonQuery(strSql);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            finally
            {
                conex.Close();
            }
        }

        internal DataTable ListarProcedimentos(ConexaoMySql conex, int parceiro)
        {
            string strSql = "SELECT id, nome " +
                "FROM global_producao_utf8.procedimentos " +
                "WHERE status = 1 AND parceiro_id=" + parceiro + " ORDER BY nome"; // LIMIT 200

            //SELECT nome FROM global_producao_utf8.procedimentos WHERE status = 1 ORDER BY nome LIMIT 200

            try
            {
                DataTable dt = new DataTable("Procedimentos");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal DataTable ListarProcedimentos(ConexaoMySql conex, int parceiro, string procedimentos)
        {
            string strSql = "SELECT id, nome, pro.valor_final valor FROM ( " +
                "SELECT DISTINCT gru.gruId FROM grupo gru " +
                "INNER JOIN grupoProcedimentos grp ON grp.gruId = gru.gruId " +
                "WHERE parceiroId = " + parceiro + " AND procedimentoId IN(" + procedimentos + ")) AS A " +
                "INNER JOIN grupoProcedimentos grp ON grp.gruId = A.gruId " +
                "INNER JOIN global_producao_utf8.procedimentos pro ON pro.id = grp.procedimentoId " +
                "WHERE grp.procedimentoId NOT IN(" + procedimentos + ") AND status = 1 ORDER BY nome";


            //SELECT nome FROM global_producao_utf8.procedimentos WHERE status = 1 ORDER BY nome LIMIT 200

            try
            {
                DataTable dt = new DataTable("Procedimentos");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal DataTable ListarLocalidades(ConexaoMySql conex, string procedimento)
        {
            string strSql = "SELECT par.cidade, COUNT(par.id) qt_parceiros " +
                "FROM global_producao_utf8.procedimentos AS pro " +
                "INNER JOIN global_producao_utf8.parceiros par ON par.id = pro.parceiro_id " +
                "WHERE pro.status = 1 " +
                "AND UPPER(pro.nome) LIKE UPPER('" + procedimento + "') " +
                "AND par.status = 1 " +
                "AND(par.unidade_id LIKE '%11%' OR par.unidade_id LIKE '%1%' OR par.unidade_id LIKE '%5%' OR par.unidade_id LIKE '%16%') " +
                "GROUP BY par.cidade " +
                "ORDER BY par.cidade";

            try
            {
                DataTable dt = new DataTable("Localidades");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal DataTable ListarParceiros(ConexaoMySql conex, string procedimento, string localidade)
        {
            string strSql = "SELECT DISTINCT " +
                "par.id, par.nome, par.cidade, par.endereco, " +
                "IFNULL(CONCAT(par.fone, ' / ', par.fone2, ' / ', par.fone3), 0) contato, par.bairro, " +
                "pro.id AS procedimentoId, pro.valor_final valor " +
                "FROM global_producao_utf8.procedimentos AS pro " +
                "INNER JOIN global_producao_utf8.parceiros par ON par.id = pro.parceiro_id " +
                "WHERE pro.status = 1 " +
                "AND UPPER(pro.nome) LIKE UPPER('" + procedimento + "') " +
                "AND UPPER(par.cidade) LIKE UPPER('" + localidade + "') " +
                "AND par.status = 1 " +
                "AND(par.unidade_id LIKE '%11%' OR par.unidade_id LIKE '%1%' OR par.unidade_id LIKE '%5%' OR par.unidade_id LIKE '%16%') " +
                "ORDER BY par.nome";

            try
            {
                DataTable dt = new DataTable("Parceiros");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal DataTable ListarParceiros(ConexaoMySql conex)
        {
            string strSql = "SELECT id, nome FROM global_producao_utf8.parceiros WHERE status=1 AND parceiro_id IS NULL";

            try
            {
                DataTable dt = new DataTable("Parceiros");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal DataTable ListarUnidades(ConexaoMySql conex)
        {
            string strSql = "SELECT * FROM global_producao_utf8.unidades WHERE status=1";

            try
            {
                DataTable dt = new DataTable("Unidades");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal int GravarUsuario(ConexaoMySql conex, int usuId, int idCadGobal, int unidade, string nome, string sexo, string CPF, string nascimento, int telefoneDDD, int telefone, int celularDDD, int celular, int cep, string rua, int numero, string complemento, string bairro, string cidade, string UF, string email, string senha)
        {
            string strSql = "";

            try
            {
                if (idCadGobal == 0)
                {
                    //INSERT GLOBAL
                    strSql = "INSERT INTO global_homologacao.associados ";
                    strSql += "(unidade_id, nome, cpf, cpf_OFF, data_nascimento, fone, fone2, cep, endereco, bairro, cidade, uf, email, senha, ";
                    strSql += "data_cadastro, atendente) VALUES (";
                    strSql += unidade + ", '" + nome + "', " + CPF + ", '" + CPF + "', '" + nascimento + "', '(" + telefoneDDD + ") " + telefone + "', '(" + celularDDD + ") " + celular + "', ";
                    strSql += "'" + cep.ToString().Substring(0, 5) + "-" + cep.ToString().Substring(5, 3) + "', '" + rua + ", " + numero + "', '" + bairro + "', '" + cidade + "', '" + UF + "', '" + email + "', '" + senha + "', ";
                    strSql += "CURDATE(), 'APP'); ";

                    strSql += "SELECT LAST_INSERT_ID();";

                    idCadGobal = Convert.ToInt32(conex.ExecuteScalar(strSql));
                }

                else
                {
                    //UPDATE GLOBAL
                    strSql = "UPDATE global_homologacao.associados SET ";
                    strSql += "unidade_id=" + unidade + ", nome='" + nome + "', cpf=" + CPF + ", cpf_OFF='" + CPF + "', data_nascimento='" + nascimento + "', fone='(" + telefoneDDD + ") " + telefone + "', fone2='(" + celularDDD + ") " + celular + "', ";
                    strSql += "cep='" + cep.ToString().Substring(0, 5) + "-" + cep.ToString().Substring(5, 3) + "', endereco='" + rua + ", " + numero + "', bairro='" + bairro + "', cidade='" + cidade + "', ";
                    strSql += "uf ='" + UF + "', email='" + email + "', senha='" + senha + "', data_atualizacao=CURDATE(), atendente='APP' WHERE id=" + idCadGobal;

                    conex.ExecuteNonQuery(strSql);
                }

                if (usuId == 0)
                {
                    //INSERT APP
                    strSql = "INSERT INTO global_app.usuario ";
                    strSql += "(idUnidade, idCadGlobal, usuNome, usuSexo, usuCpf, usuDtNascimento, ";
                    strSql += "usuTelefoneDDD, usuTelefone, usuCelularDDD, usuCelular, usuCep, usuRua, usuNumero, usuComplemento, usuBairro, ";
                    strSql += "usuCidade, usuUF, usuEmail, usuSenha, usuDtCadastro) VALUES( ";
                    strSql += unidade + ", " + idCadGobal + ", '" + nome + "', '" + sexo + "', '" + CPF + "', '" + nascimento + "', ";
                    strSql += telefoneDDD + ", " + telefone + ", " + celularDDD + ", " + celular + ", " + cep + ", '" + rua + "', " + numero + ", '" + complemento + "', ";
                    strSql += "'" + bairro + "', '" + cidade + "', '" + UF + "', '" + email + "', '" + senha + "', NOW());";

                    strSql += "SELECT LAST_INSERT_ID();";

                    usuId = Convert.ToInt32(conex.ExecuteScalar(strSql));
                }

                else
                {
                    //UPDATE APP
                    strSql = "UPDATE global_app.usuario SET ";
                    strSql += "idUnidade=" + unidade + ", idCadGlobal=" + idCadGobal + ", usuNome='" + nome + "', usuSexo='" + sexo + "', usuCpf='" + CPF + "', usuDtNascimento='" + nascimento + "', ";
                    strSql += "usuTelefoneDDD=" + telefoneDDD + ", usuTelefone=" + telefone + ", usuCelularDDD=" + celularDDD + ", usuCelular=" + celular + ", usuCep=" + cep + ", usuRua='" + rua + "', usuNumero=" + numero + ", usuComplemento='" + complemento + "', usuBairro='" + bairro + "', ";
                    strSql += "usuCidade='" + cidade + "', usuUF='" + UF + "', usuEmail='" + email + "', usuSenha='" + senha + "' WHERE usuId=" + usuId;

                    conex.ExecuteNonQuery(strSql);
                }
            }

            catch (MySqlException ex)
            {
                throw ex;
            }

            finally
            {
                conex.Close();
            }

            return usuId;
        }

        internal string Login(ConexaoMySql conex, string login, string senha)
        {
            string strSql = "SELECT usunome FROM global_app.usuario WHERE usuCpf='" + login + "' AND usuSenha='" + senha + "'";

            try
            {
                DbDataReader rd = conex.ExecuteReader(strSql);

                while (rd.Read())
                {
                    if (rd.HasRows)
                        return "true";
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }

            return "false";

            //Response.Redirect("/global/Dashboard/projeto/blank.aspx");
            //txtLogin.Text = reader["usuCpf"].ToString() + " " + reader["usuNome"].ToString();
            //txtSenha.Text = reader["usuNome"].ToString();
        }

        internal int GravarGrupo(ConexaoMySql conex, int gruId, int parceiro, string descricao, int qtdProcedimentos, int usuId)
        {
            string strSql = "";
            try
            {
                if (gruId == 0)
                {
                    strSql = "INSERT INTO global_app.grupo (parceiroId, gruDescricao, gruQtdProcessos, gruDtCadastro, gruUsuIdCadastro) VALUES " +
                            "(" + parceiro + ", '" + descricao + "', " + qtdProcedimentos + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', 1); "; //usuId

                    strSql += "SELECT LAST_INSERT_ID();";
                }

                else
                {
                    strSql = " UPDATE grupo SET gruDescricao = '" + descricao + "', gruQtdProcessos = " + qtdProcedimentos + ", gruDtAlteracao = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', gruUsuIdAlteracao = " + usuId + " WHERE gruId = " + gruId + ";";
                    strSql += "DELETE FROM global_app.grupoProcedimentos WHERE gruId=" + gruId + "; ";
                    strSql += "SELECT " + gruId + ";";
                }
                return Convert.ToInt32(conex.ExecuteScalar(strSql));
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            finally
            {
                conex.Close();
            }
        }

        internal void GravarProcedimentosGrupo(ConexaoMySql conex, int gruId, int procedimento)
        {
            try
            {
                string strSql = "INSERT INTO global_app.grupoProcedimentos (gruId, procedimentoId) values(" + gruId + ", " + procedimento + ")";
                conex.ExecuteNonQuery(strSql);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            finally
            {
                conex.Close();
            }
        }

        internal static int GravarGuia(ConexaoMySql conex, int unidade, int parceiro, int associado, decimal valorTotal)
        {
            string strSql = "";
            try
            {
                strSql += "INSERT INTO global_homologacao.guias (unidade_id, parceiro_id, associado_id, dependente_id, ";
                strSql += "NOME_DEPENDENTE, data_emissao, data_guia, valor_custo, valor_total, valor_final, atendente, usuario_id, status) ";
                strSql += "VALUES(" + unidade + ", " + parceiro + ", " + associado + ", null, null, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', null, null, " + valorTotal + "," + valorTotal + ", 'APP', 1, 1); ";

                strSql += "SELECT LAST_INSERT_ID();";

                int idGuia = Convert.ToInt32(conex.ExecuteScalar(strSql));

                strSql = "INSERT INTO global_app.agendamento(usuId, idGuia, ageOrigem) VALUES(1, " + idGuia + ", 'APP'); ";
                strSql += "SELECT " + idGuia + ";";

                return Convert.ToInt32(conex.ExecuteScalar(strSql));
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            finally
            {
                conex.Close();
            }
        }

        internal int GravarItem(ConexaoMySql conex, int idGuia, int procedimento, decimal valor) //int quantidade
        {
            string strSql = "";
            try
            {
                strSql += "INSERT INTO global_homologacao.guias_itens (guia_id, procedimento_id, descricao, qtde, valor_custo, valor_final) ";
                strSql += "VALUES (" + idGuia + "," + procedimento + ", ";
                strSql += "(SELECT nome FROM global_producao_utf8.procedimentos where id = " + procedimento + "), 1, " + valor + ", " + valor + "); ";
                strSql += "SELECT LAST_INSERT_ID();";
                return Convert.ToInt32(conex.ExecuteScalar(strSql));
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            finally
            {
                conex.Close();
            }
        }

        internal DataTable ListarAgendamentos(ConexaoMySql conex, int usuId)
        {
            string strSql = "SELECT idGuia, agePagamento, uni.nome unidade, " +
                "par.nome parceiro, par.cidade, par.endereco, IFNULL(CONCAT(par.fone, ' / ', par.fone2, ' / ', par.fone3), 0) contato, par.bairro, " +
                "data_emissao, data_guia, horario_guia, gui.valor_final valorGuia, total_pago, pro.nome procedimento, pro.valor_final 'valorProcedimento'" +
                "FROM global_app.agendamento age " +
                "INNER JOIN global_homologacao.guias gui ON gui.id = age.idGuia " +
                "INNER JOIN global_homologacao.guias_itens ite ON ite.guia_id = gui.id " +
                "INNER JOIN global_homologacao.unidades uni ON uni.id = gui.unidade_id " +
                "INNER JOIN global_homologacao.parceiros par ON par.id = gui.parceiro_id " +
                "INNER JOIN global_homologacao.procedimentos pro ON pro.id = ite.procedimento_id " +
                "WHERE usuId = " + usuId;

            try
            {
                DataTable dt = new DataTable("Agendamentos");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }

        internal int GravarCartao(ConexaoMySql conex, int usuId, string nome, Int64 numero, int mes, int ano, string bandeira)
        {
            string strSql = "";
            try
            {
                strSql += "INSERT INTO global_app.cartao (usuId, carNome, carNumero, carMes, carAno, carBandeira, carDtCadastro) ";
                strSql += "VALUES (" + usuId + ", '" + nome + "', " + numero + ", " + mes + ", " + ano + ", '" + bandeira + "', NOW()); ";

                strSql += "SELECT LAST_INSERT_ID();";

                return Convert.ToInt32(conex.ExecuteScalar(strSql));
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            finally
            {
                conex.Close();
            }
        }

        internal void ExcluirCartao(ConexaoMySql conex, int carId)
        {
            try
            {
                string strSql = "UPDATE global_app.cartao SET carDtExclusao = NOW() WHERE carId=" + carId;
                conex.ExecuteNonQuery(strSql);
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            finally
            {
                conex.Close();
            }
        }

        internal DataTable ListarCartao(ConexaoMySql conex, int usuId)
        {
            string strSql = "SELECT carId, carNome Nome, carNumero Numero, carMes Mes, carAno Ano, carBandeira Bandeira FROM global_app.cartao WHERE usuId=" + usuId + " AND carDtExclusao IS NULL";

            try
            {
                DataTable dt = new DataTable("Cartao");
                dt.Load(conex.ExecuteReader(strSql));
                return dt;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conex.Close();
            }
        }
    }
}