using inst_global_saude.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inst_global_saude.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class cateirinha : ContentPage
    {
        public cateirinha(string usu_cpf, string usu_senha)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            busca_dados(usu_cpf, usu_senha);
            btnCancel.Clicked += BtnCancel_Clicked;
        }

        private async void BtnCancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        public void busca_dados(string cpf, string senha)
        {
            IDictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("login", cpf);
            parametros.Add("senha", senha);
            string retorno = Callws.ChamaWs(parametros, "DadosUsuario");
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

            usuNome.Text = dados[0].usuNome.ToString();
            usuNasc.Text = DateTime.Parse(dados[0].usuNasc).ToString("dd/MM/yyyy");
            usuUnidade.Text = dados[0].nomeUnidade.ToString();
            usuEmail.Text = dados[0].usuEmail.ToString();
            usuCpf.Text = dados[0].usuCpf.Substring(0, 3) + "." + dados[0].usuCpf.Substring(3, 3) + "." + dados[0].usuCpf.Substring(6, 3) + "-" + dados[0].usuCpf.Substring(9, 2);
        }
    }
}