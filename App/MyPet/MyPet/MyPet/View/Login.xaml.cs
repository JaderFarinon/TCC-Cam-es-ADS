using MyPet.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPet.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public string TempLogin, TempSenha;
        //Mensagens msg = new Mensagens();
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            // Define o binding context
            this.BindingContext = this;
            // Define a propriedade
            BtnAcessar.Clicked += Btn_acessar_Clicked;
            BtnCadastrar.Clicked += Btn_cadastrar_clicked;
            //btn_lembrar.Clicked += Btn_lembrar_Clicked;
            //SwtGravaDados.Toggled += SwtGravaDados_Toggled;
            TxtLogin.Text = "jader.farinon";
            TxtPass.Text = "123456*";

            // Define o binding context
            this.BindingContext = this;
            // Define a propriedade
            this.IsBusy = false;

            //carrega dados usuário
            if (Application.Current.Properties.ContainsKey("usu_cpf"))
            {
                TxtLogin.Text = Application.Current.Properties["usu_cpf"] as string;
            }

            if (Application.Current.Properties.ContainsKey("usu_senha"))
            {
                TxtPass.Text = Application.Current.Properties["usu_senha"] as string;
            }

            if (Application.Current.Properties.ContainsKey("switch_dados"))
            {
                if (Application.Current.Properties["switch_dados"] as string == "1")
                {
                    SwtGravaDados.IsToggled = true;
                }
                else
                {
                    SwtGravaDados.IsToggled = false;
                }
            }

            if (TxtLogin.Text != string.Empty && TxtPass.Text != string.Empty && SwtGravaDados.IsToggled == true)
            {
                IDictionary<string, string> parametros = new Dictionary<string, string>();
                parametros.Add("login", TxtLogin.Text.Replace("-", "").Replace(".", ""));
                parametros.Add("senha", TxtPass.Text);
                this.Logar(parametros);
            }
        }

        private async void Btn_lembrar_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new testNot());
        }

        private async void Btn_acessar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtLogin.Text))
            {
                await DisplayAlert("Aviso", "Ops, Algo errado, campo CPF vazio.", "Ok");
                TxtLogin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TxtPass.Text))
            {
                await DisplayAlert("Aviso", "Ops, Algo errado, campo senha vazio.", "Ok");
                TxtPass.Focus();
                return;
            }
            this.IsBusy = true;
            await Delay(200);
            IDictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("login", TxtLogin.Text.Replace("-", "").Replace(".", ""));
            parametros.Add("senha", TxtPass.Text);
            this.Logar(parametros);
        }

        private async void Logar(IDictionary<string, string> parametros)
        {
            try
            {
                string retorno = CallWS.ChamaWs(parametros, "Login");

                if (retorno == "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<string xmlns=\"http://tempuri.org/\">true</string>")
                {
                    if (SwtGravaDados.IsToggled)
                    {
                        //Armazena dados usuário
                        if (Application.Current.Properties.ContainsKey("usu_cpf"))
                        {
                            Application.Current.Properties["usu_cpf"] = TxtLogin.Text;
                        }
                        else
                        {
                            Application.Current.Properties.Add("usu_cpf", TxtLogin.Text);
                        }

                        if (Application.Current.Properties.ContainsKey("usu_senha"))
                        {
                            Application.Current.Properties["usu_senha"] = TxtPass.Text;
                        }
                        else
                        {
                            Application.Current.Properties.Add("usu_senha", TxtPass.Text);
                        }
                        //Armazena status switch toogle
                        if (Application.Current.Properties.ContainsKey("switch_dados"))
                        {
                            Application.Current.Properties["switch_dados"] = "1";
                        }
                        else
                        {
                            Application.Current.Properties.Add("switch_dados", "1");
                        }
                    }
                    await Delay(300);
                    await Navigation.PushAsync(new Home(TxtLogin.Text.Replace("-", "").Replace(".", ""), TxtPass.Text, 1));
                }
                else
                {
                    await DisplayAlert("Alerta", "Ops... Algo deu errado, confira seus dados por favor!!", "Conferir");
                    this.IsBusy = false;
                }
            }
            catch
            {
                await DisplayAlert("Erro", "Erro ao conectar com o servidor, por favor tente novamente mais tarde!", "Ok");
                this.IsBusy = false;
            }
        }

        private async void Btn_cadastrar_clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtLogin.Text))
            {
                await DisplayAlert("Aviso", "Olá, para efetuar um novo cadastro digite um CPF", "Ok");
                TxtLogin.Focus();
                return;
            }
            else
            {
                IDictionary<string, string> cpf_buscar = new Dictionary<string, string>();
                cpf_buscar.Add("cpf", TxtLogin.Text.Replace("-", "").Replace(".", ""));
                this.BuscarUsuario(cpf_buscar);
            }
        }

        private async void BuscarUsuario(IDictionary<string, string> cpf_buscar)
        {
            try
            {
                string retorno = CallWS.ChamaWs(cpf_buscar, "BuscarUsuario");

                XDocument xml = XDocument.Parse(retorno);
                var dados = (from s in xml.Descendants("DadosUsuario")
                             select new
                             {
                                 dsTipo = s.Element("dsTipo").Value
                             }).ToList();

                if (dados.Count == 0)
                {
                    await Navigation.PushAsync(new usuCad());
                }
                else
                {
                    if (dados[0].dsTipo == "APP")
                    {
                        await DisplayAlert("Alerta", "Bem vindo novamente, esse CPF já está cadastrado, " +
                        "digite sua senha para acessar sua conta", "Aceitar");
                        TxtPass.Focus();
                    }
                    else
                    {
                        await Navigation.PushAsync(new usuCad());
                    }
                }
            }
            catch
            {
                await DisplayAlert("Erro", "Não foi possível iniciar um novo cadastro agora!", "OK");
            }
        }

        //Delay
        async Task Delay(int valor)
        {
            await Task.Delay(valor);
        }
    }
}