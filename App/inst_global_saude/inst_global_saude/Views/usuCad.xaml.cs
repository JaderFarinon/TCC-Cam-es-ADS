using inst_global_saude.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Xamarin.Forms;

namespace inst_global_saude.Views
{
    public partial class usuCad : ContentPage
    {
        public int idGlobal, usuId, idUnidade;
        public string tipo;
        public List<Unidade> lstunidades;
        public Dictionary<int, int> unidOpt = new Dictionary<int, int>();

        public usuCad(string usuCpf, string dstipo)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            if (dstipo == "GLOBAL" || dstipo == "NOVO")
            {
                btnCadastro.Text = "Cadastrar";
                lblTitulo.Text = "Seja Bem Vindo!";
            }
            else if (dstipo == "APP")
            {
                btnCadastro.Text = "Atualizar";
                lblTitulo.Text = "Meu Perfil";
            }

            tipo = dstipo;
            btnCancel.Clicked += BtnCancel_Clicked;
            btnCadastro.Clicked += BtnCadastro_Clicked;
            entryRua.Focused += EntryRua_Focused;
            try
            {
                //Chamada Unidades
                IDictionary<string, string> parametros = new Dictionary<string, string>();
                string retorno = Callws.ChamaWs(parametros, "ListarUnidades");
                XDocument xml = XDocument.Parse(retorno);

                var unidades = (from s in xml.Descendants("Unidades")
                                select new
                                {
                                    id = s.Element("id").Value,
                                    nome = s.Element("nome").Value
                                }).ToList();

                lstunidades = new List<Unidade>();

                if (unidades.Any())
                {
                    for (int i = 0; i < unidades.Count; i++)
                    {
                        lstunidades.Add(new Unidade() { idUnidade = unidades[i].id, dsUnidade = unidades[i].nome });
                        unidOpt.Add(int.Parse(unidades[i].id), i);
                    }
                }
                pickerUnid.ItemsSource = lstunidades;
            }
            catch
            {
                DisplayAlert("Aviso", "Não foi possível carregar a lista de unidades, por favor tente mais tarde.", "Ok");
            }
            pickerUnid.SelectedIndexChanged += PickerUnid_SelectedIndexChanged;

            var listSexo = new List<string>();
            listSexo.Add("Feminino");
            listSexo.Add("Masculino");

            pickerSexo.ItemsSource = listSexo;
            entryCpf.Text = usuCpf;

            if (dstipo == "GLOBAL")
            {
                this.usuGlobalCad(usuCpf);
            }
            else if (dstipo == "APP")
            {

                this.usuAppCad(usuCpf);
            }
        }

        private void PickerUnid_SelectedIndexChanged(object sender, EventArgs e)
        {
            idUnidade = int.Parse(lstunidades[pickerUnid.SelectedIndex].idUnidade);
        }

        private async void usuGlobalCad(string usuCpf)
        {
            try
            {
                IDictionary<string, string> parametros = new Dictionary<string, string>();
                parametros.Add("cpf", usuCpf);
                string retorno = Callws.ChamaWs(parametros, "BuscarUsuario");
                XDocument xml = XDocument.Parse(retorno);

                var dados = (from s in xml.Descendants("DadosUsuario")
                             select new
                             {
                                 usuId = int.Parse(s.Element("usuId").Value),
                                 idUnidade = int.Parse(s.Element("idUnidade").Value),
                                 nomeUnidade = s.Element("nome").Value,
                                 idCadGlobal = int.Parse(s.Element("idCadGlobal").Value),
                                 usuNome = s.Element("usuNome").Value.TrimEnd(),
                                 usuNasc = s.Element("usuDtNascimento").Value,
                                 usuDDDTelefone = s.Element("usuTelefoneDDD").Value,
                                 usuTelefone = s.Element("usuTelefone").Value,
                                 usuDDDCelular = s.Element("usuCelularDDD").Value,
                                 usuCelular = s.Element("usuCelular").Value,
                                 usuCep = s.Element("usuCep").Value.Replace("-", "").Replace(".", "").Trim()
                             }).ToList();
                string usuNome = dados[0].usuNome;
                TextInfo confReg = new CultureInfo("en-US", false).TextInfo;
                string usuNameCC = confReg.ToTitleCase(usuNome.ToLower());

                entryName.Text = usuNameCC;
                entryCep.Text = dados[0].usuCep;
                pickerNasc.Date = Convert.ToDateTime(DateTime.Parse(dados[0].usuNasc).ToString("dd-MM-yyyy"));
                entryCel.Text = dados[0].usuDDDCelular + dados[0].usuCelular;
                entryTel.Text = dados[0].usuDDDTelefone + dados[0].usuTelefone;
                idGlobal = dados[0].idCadGlobal;
                usuId = dados[0].usuId;
                idUnidade = dados[0].idUnidade;
            }
            catch
            {
                await DisplayAlert("Erro", "Não foi possível conectar ao servidor, verifique se você possui uma conexão ativa com a internet.", "Ok");
            }
        }

        private async void usuAppCad(string usuCpf)
        {
            try
            {
                IDictionary<string, string> parametros = new Dictionary<string, string>();
                parametros.Add("cpf", usuCpf);
                string retorno = Callws.ChamaWs(parametros, "BuscarUsuario");
                XDocument xml = XDocument.Parse(retorno);

                var dados = (from s in xml.Descendants("DadosUsuario")
                             select new
                             {
                                 usuId = s.Element("usuId").Value.TrimEnd(),
                                 idGlobal = s.Element("idCadGlobal").Value.TrimEnd(),
                                 idUnidade = int.Parse(s.Element("idUnidade").Value),
                                 dsUnidade = s.Element("nome").Value.TrimEnd(),
                                 usuNome = s.Element("usuNome").Value.TrimEnd(),
                                 usuSexo = s.Element("usuSexo").Value.TrimEnd(),
                                 usuNasc = s.Element("usuDtNascimento").Value.TrimEnd(),
                                 usuDDDTelefone = s.Element("usuTelefoneDDD").Value.TrimEnd(),
                                 usuTelefone = s.Element("usuTelefone").Value.TrimEnd(),
                                 usuDDDCelular = s.Element("usuCelularDDD").Value.TrimEnd(),
                                 usuCelular = s.Element("usuCelular").Value.TrimEnd(),
                                 usuCep = s.Element("usuCep").Value.Replace("-", "").Replace(".", "").Trim(),
                                 usuRua = s.Element("usuRua").Value.TrimEnd(),
                                 usuNumero = s.Element("usuNumero").Value.TrimEnd(),
                                 usuComplemento = s.Element("usuComplemento").Value.TrimEnd(),
                                 usuBairro = s.Element("usuBairro").Value.TrimEnd(),
                                 usuCidade = s.Element("usuCidade").Value.TrimEnd(),
                                 usuUF = s.Element("usuUF").Value.TrimEnd(),
                                 usuEmail = s.Element("usuEmail").Value.TrimEnd(),
                                 usuDtCadastro = s.Element("usuDtCadastro").Value.TrimEnd(),
                                 usuDtAcesso = s.Element("usuDtAcesso").Value.TrimEnd(),
                             }).ToList();

                string usuNome = dados[0].usuNome;
                TextInfo confReg = new CultureInfo("en-US", false).TextInfo;
                string usuNameCC = confReg.ToTitleCase(usuNome.ToLower());

                Dictionary<string, int> sexoOpt = new Dictionary<string, int>()
                                                {
                                                    {"F",0},
                                                    {"M",1}
                                                };

                entryName.Text = usuNameCC;
                pickerNasc.Date = DateTime.Parse(dados[0].usuNasc);
                pickerSexo.SelectedIndex = sexoOpt[dados[0].usuSexo];
                pickerUnid.SelectedIndex = unidOpt[dados[0].idUnidade];
                entryCel.Text = dados[0].usuDDDCelular + dados[0].usuCelular;
                entryTel.Text = dados[0].usuDDDTelefone + dados[0].usuTelefone;
                entryCep.Text = dados[0].usuCep;
                entryRua.Text = dados[0].usuRua;
                entryNum.Text = dados[0].usuNumero;
                entryComp.Text = dados[0].usuComplemento;
                entryBairro.Text = dados[0].usuBairro;
                entryCid.Text = dados[0].usuCidade;
                entryUF.Text = dados[0].usuUF;
                entryEmail.Text = dados[0].usuEmail;
                usuId = int.Parse(dados[0].usuId);
                idGlobal = int.Parse(dados[0].idGlobal);
                entryPass.Text = Application.Current.Properties["SessionPass"] as string;
                entryPassVer.Text = Application.Current.Properties["SessionPass"] as string;
            }
            catch
            {
                await DisplayAlert("Erro", "Não foi possível conectar ao servidor, verifique se você possui uma conexão ativa com a internet.", "Ok");
            }
        }

        private async void EntryRua_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(entryCep.Text))
                {
                    string ws_uf, ws_cidade, ws_bairro, ws_tipo_lagradouro, ws_logradouro, ws_resultado, ws_resultato_txt, usuUf;

                    DataSet ds = new DataSet();
                    ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + entryCep.Text.Replace("-", "").Trim() + "&formato=xml");

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ws_resultado = ds.Tables[0].Rows[0]["resultado"].ToString();
                            switch (ws_resultado)
                            {
                                case "1":
                                    ws_uf = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                                    ws_cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                                    ws_bairro = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                                    ws_tipo_lagradouro = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString().Trim();
                                    ws_logradouro = ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                                    ws_resultato_txt = "CEP completo";
                                    entryRua.Text = ws_tipo_lagradouro + " " + ws_logradouro;
                                    entryBairro.Text = ws_bairro;
                                    entryCid.Text = ws_cidade;
                                    entryNum.Text = "";
                                    entryUF.Text = ws_uf;
                                    entryNum.PlaceholderColor = Color.Red;
                                    entryNum.Focus();
                                    break;
                                case "2":
                                    ws_uf = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                                    ws_cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                                    ws_bairro = "";
                                    ws_tipo_lagradouro = "";
                                    ws_logradouro = "";
                                    ws_resultato_txt = "CEP  único";
                                    entryRua.Text = ws_tipo_lagradouro + " " + ws_logradouro;
                                    entryBairro.Text = ws_bairro;
                                    entryCid.Text = ws_cidade;
                                    entryNum.Text = "";
                                    entryUF.Text = ws_uf;
                                    entryNum.PlaceholderColor = Color.Red;
                                    entryNum.Focus();
                                    break;
                                default:
                                    ws_uf = "";
                                    ws_cidade = "";
                                    ws_bairro = "";
                                    ws_tipo_lagradouro = "";
                                    ws_logradouro = "";
                                    ws_resultato_txt = "CEP não encontrado";
                                    entryRua.Text = ws_tipo_lagradouro + " " + ws_logradouro;
                                    entryBairro.Text = ws_bairro;
                                    entryCid.Text = ws_cidade;
                                    entryNum.Text = "";
                                    entryUF.Text = ws_uf;
                                    entryNum.PlaceholderColor = Color.Red;
                                    entryNum.Focus();
                                    break;
                            }
                        }
                    }
                }
            }
            catch
            {
                await DisplayAlert("Erro", "Não foi possível buscar seu endereço pelo CEP, por favor digite manualmente", "Ok");
            }
        }

        private async void BtnCadastro_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(entryCpf.Text))
            {
                await DisplayAlert("Aviso", "Você precisa digitar seu CPF", "Digitar");
                entryCpf.Focus();
                return;
            }
            if (string.IsNullOrEmpty(entryCel.Text))
            {
                await DisplayAlert("Aviso", "Preencha o número do seu celular.", "Ok");
                entryCel.Focus();
                return;
            }
            if (string.IsNullOrEmpty(entryCep.Text))
            {
                await DisplayAlert("Aviso", "Digite seu CEP para que possamos buscar seu endereço completo", "Ok");
                entryCep.Focus();
                return;
            }
            if (string.IsNullOrEmpty(entryRua.Text))
            {
                await DisplayAlert("Aviso", "Digite sua rua", "Ok");
                entryRua.Focus();
                return;
            }
            if (string.IsNullOrEmpty(entryNum.Text))
            {
                await DisplayAlert("Aviso", "Digite o número de sua residência", "Ok");
                entryNum.Focus();
                return;
            }
            if (string.IsNullOrEmpty(entryBairro.Text))
            {
                await DisplayAlert("Aviso", "Ops, o campo bairro ficou em branco", "Digitar");
                entryBairro.Focus();
                return;
            }
            if (string.IsNullOrEmpty(entryCid.Text))
            {
                await DisplayAlert("Aviso", "Qual cidade você mora?", "Digitar");
                entryCid.Focus();
                return;
            }
            if (string.IsNullOrEmpty(entryUF.Text))
            {
                await DisplayAlert("Aviso", "Em qual estado você mora?", "Digitar");
                entryUF.Focus();
                return;
            }
            if (string.IsNullOrEmpty(entryEmail.Text))
            {
                await DisplayAlert("Aviso", "Digite seu endereço de email", "Ok");
                entryEmail.Focus();
                return;
            }
            if (string.IsNullOrEmpty(entryPass.Text))
            {
                await DisplayAlert("Atenção", "Você precisa cadastrar uma senha.", "Ok");
                entryPass.Focus();
                return;
            }
            if (entryPass.Text != entryPassVer.Text)
            {
                await DisplayAlert("Atenção", "As senhas digitadas não são iguais, verifique por favor.", "Ok");
                entryPassVer.Focus();
                return;
            }

            IDictionary<string, string> parametros = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(idGlobal.ToString()))
            {
                parametros.Add("idCadGobal", idGlobal.ToString());
            }
            parametros.Add("usuId", usuId.ToString());
            parametros.Add("unidade", idUnidade.ToString());
            parametros.Add("nome", entryName.Text);
            parametros.Add("sexo", "M");
            parametros.Add("CPF", entryCpf.Text.Replace("-", "").Replace(".", ""));
            parametros.Add("nascimento", pickerNasc.Date.ToString("yyyy-MM-dd"));
            parametros.Add("telefoneDDD", entryTel.Text.Replace("(", "").Replace(")", "").Replace("-", "").Substring(0, 2));
            parametros.Add("telefone", entryTel.Text.Replace("(", "").Replace(")", "").Replace("-", "").Substring(3, 8));
            parametros.Add("celularDDD", entryCel.Text.Replace("(", "").Replace(")", "").Replace("-", "").Substring(0, 2));
            parametros.Add("celular", entryCel.Text.Replace("(", "").Replace(")", "").Replace("-", "").Substring(3, 9));
            parametros.Add("cep", entryCep.Text.Replace("-", "").Trim());
            parametros.Add("rua", entryRua.Text);
            parametros.Add("numero", entryNum.Text);
            parametros.Add("complemento", entryComp.Text);
            parametros.Add("bairro", entryBairro.Text);
            parametros.Add("cidade", entryCid.Text);
            parametros.Add("UF", entryUF.Text);
            parametros.Add("email", entryEmail.Text);
            parametros.Add("senha", entryPass.Text);
            string retorno = Callws.ChamaWs(parametros, "GravarUsuario");
            string retUsuId = retorno.Replace("\"", "").Replace("<?xml version=1.0 encoding=utf-8?>\r\n<int xmlns=http://tempuri.org/>", "").Replace("</int>", "");

            if (retUsuId != null)
            {
                if (int.Parse(retUsuId) > 0)
                {
                    if (tipo == "APP")
                    {
                        usuId = int.Parse(retUsuId);
                        await DisplayAlert("Parabéns", "Cadastro atualizado com sucesso!", "Ok");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        usuId = int.Parse(retUsuId);
                        await DisplayAlert("Parabéns", "Cadastro realizado com sucesso!", "Efetuar Login");
                        await Navigation.PopAsync();
                    }
                }
            }
        }

        private async void BtnCancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}