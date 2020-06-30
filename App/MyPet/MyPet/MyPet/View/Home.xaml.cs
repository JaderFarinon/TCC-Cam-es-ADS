using MyPet.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPet.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        string temp_cpf, temp_senha;
        //List<Associado> usuDados;
        int usuId;

        public Home(string cpf, string senha, int origem) //string cpf, string senha
        {

            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //Session CPF
            if (Application.Current.Properties.ContainsKey("SessionCpf"))
            {
                Application.Current.Properties["SessionCpf"] = cpf;
            }
            else
            {
                Application.Current.Properties.Add("SessionCpf", cpf);
            }
            //Session Senha
            if (Application.Current.Properties.ContainsKey("SessionPass"))
            {
                Application.Current.Properties["SessionPass"] = senha;
            }
            else
            {
                Application.Current.Properties.Add("SessionPass", senha);
            }

            //exibeAviso(origem);

            IDictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("login", cpf);
            parametros.Add("senha", senha);
            string retorno = CallWS.ChamaWs(parametros, "DadosUsuario");
            XDocument xml = XDocument.Parse(retorno);
            var dados = (from s in xml.Descendants("DadosUsuario")
                         select new
                         {
                             usuId = int.Parse(s.Element("usuId").Value),
                             idUnidade = int.Parse(s.Element("idUnidade").Value),
                             nomeUnidade = s.Element("nome").Value,
                             idCadGlobal = s.Element("idCadGlobal").Value,
                             usuNome = s.Element("usuNome").Value,
                             usuSexo = s.Element("usuSexo").Value,
                             usuCpf = s.Element("usuCpf").Value,
                             usuNasc = s.Element("usuDtNascimento").Value,
                             usuTelefone = s.Element("usuTelefone").Value,
                             usuCep = s.Element("usuCep").Value,
                             usuRua = s.Element("usuRua").Value,
                             usuNumero = s.Element("usuNumero").Value,
                             usuComplemento = s.Element("usuComplemento").Value,
                             usuEmail = s.Element("usuEmail").Value,
                             usuSenha = s.Element("usuSenha").Value
                         }).ToList();
            //Session Associado
            if (Application.Current.Properties.ContainsKey("SessionAssoc"))
            {
                Application.Current.Properties["SessionAssoc"] = dados[0].idCadGlobal;
            }
            else
            {
                Application.Current.Properties.Add("SessionAssoc", dados[0].idCadGlobal);
            }
            //Session AssociadoApp
            if (Application.Current.Properties.ContainsKey("SessionUsuId"))
            {
                Application.Current.Properties["SessionUsuId"] = dados[0].usuId;
            }
            else
            {
                Application.Current.Properties.Add("SessionUsuId", dados[0].usuId);
            }
            //Session Unidade
            if (Application.Current.Properties.ContainsKey("SessionUnid"))
            {
                Application.Current.Properties["SessionUnid"] = dados[0].idUnidade.ToString();
            }
            else
            {
                Application.Current.Properties.Add("SessionUnid", dados[0].idUnidade.ToString());
            }
            lbl_bem_vindo.Text = "Olá " + dados[0].usuNome.ToString();
            temp_cpf = dados[0].usuCpf.ToString();
            temp_senha = dados[0].usuSenha.ToString();
            usuId = int.Parse(dados[0].idCadGlobal);
            btn_novo.Clicked += Btn_Novo_Clicked;
            btn_ag.Clicked += Btn_Ag_Clicked;
            btn_usu.Clicked += Btn_Usu_Clicked;
            btn_logout.Clicked += Btn_logout_Clicked;



        }

        private async void exibeAviso(int origem)
        {
            if (origem == 1)
            { //Origem Login
                //await DisplayAlert("Aviso", "Bem Vindo!", "Ok");
            }
            else if (origem == 2) //Origem Finalização de Guia
            {
                await DisplayAlert("Obrigado!", "Sua solicitação " +
                    "foi enviada com sucesso, em breve entraremos em " +
                    "contato para agendar um dia e horário para seus " +
                    "procedimentos!", "Ok");
            }
            else if (origem == 9) //Origem Erro
            {
                //Guia não finalizada
            }
        }

        private async void Btn_logout_Clicked(object sender, EventArgs e)
        {
            //Application.Current.Properties["usu_cpf"] = null;
            Application.Current.Properties["usu_senha"] = null;
            Application.Current.Properties.Remove("usu_senha");
            Application.Current.Properties["switch_dados"] = "1";
            //await Navigation.PopToRootAsync (false);
            await Navigation.PushAsync(new Login());
        }

        private async void Btn_Novo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuscaProcProd());
        }

        private async void Btn_Ag_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MeusPedidos(usuId));
        }

        private async void Btn_Usu_Clicked(object sender, EventArgs e)
        {
            int idCliente = 0;
            await Navigation.PushAsync(new DadosCliente(idCliente));
        }
    }
}