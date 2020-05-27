using inst_global_saude.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inst_global_saude.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public string temp_cpf, temp_senha;
        Mensagens msg = new Mensagens();
        public login()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            // Define o binding context
            this.BindingContext = this;
            // Define a propriedade
            btn_acessar.Clicked += Btn_acessar_Clicked;
            btn_cadastrar.Clicked += Btn_cadastrar_clicked;
            //btn_lembrar.Clicked += Btn_lembrar_Clicked;
            //swt_grv_dados.Toggled += Swt_grv_dados_Toggled;
            entrycpf.Text = "05286020984";
            entrypass.Text = "jader";

            // Define o binding context
            this.BindingContext = this;
            // Define a propriedade
            this.IsBusy = false;

            //carrega dados usuário
            if (Application.Current.Properties.ContainsKey("usu_cpf"))
            {
                entrycpf.Text = Application.Current.Properties["usu_cpf"] as string;
            }

            if (Application.Current.Properties.ContainsKey("usu_senha"))
            {
                entrypass.Text = Application.Current.Properties["usu_senha"] as string;
            }

            if (Application.Current.Properties.ContainsKey("switch_dados"))
            {
                if (Application.Current.Properties["switch_dados"] as string == "1")
                {
                    swt_grv_dados.IsToggled = true;
                }
                else
                {
                    swt_grv_dados.IsToggled = false;
                }
            }

            if (entrycpf.Text != string.Empty && entrypass.Text != string.Empty && swt_grv_dados.IsToggled == true)
            {
                IDictionary<string, string> parametros = new Dictionary<string, string>();
                parametros.Add("login", entrycpf.Text.Replace("-", "").Replace(".", ""));
                parametros.Add("senha", entrypass.Text);
                this.Login(parametros);
            }
        }

        private async void Btn_lembrar_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new testNot());
        }

        private async void Btn_acessar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entrycpf.Text))
            {
                await DisplayAlert("Aviso", "Ops, Algo errado, campo CPF vazio.", "Ok");
                entrycpf.Focus();
                return;
            }
            if (string.IsNullOrEmpty(entrypass.Text))
            {
                await DisplayAlert("Aviso", "Ops, Algo errado, campo senha vazio.", "Ok");
                entrypass.Focus();
                return;
            }
            this.IsBusy = true;
            await Delay(200);
            IDictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("login", entrycpf.Text.Replace("-", "").Replace(".", ""));
            parametros.Add("senha", entrypass.Text);
            this.Login(parametros);
        }

        private async void Login(IDictionary<string, string> parametros)
        {
            try
            {
                string retorno = Callws.ChamaWs(parametros, "Login");

                if (retorno == "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<string xmlns=\"http://tempuri.org/\">true</string>")
                {
                    if (swt_grv_dados.IsToggled)
                    {
                        //Armazena dados usuário
                        if (Application.Current.Properties.ContainsKey("usu_cpf"))
                        {
                            Application.Current.Properties["usu_cpf"] = entrycpf.Text;
                        }
                        else
                        {
                            Application.Current.Properties.Add("usu_cpf", entrycpf.Text);
                        }

                        if (Application.Current.Properties.ContainsKey("usu_senha"))
                        {
                            Application.Current.Properties["usu_senha"] = entrypass.Text;
                        }
                        else
                        {
                            Application.Current.Properties.Add("usu_senha", entrypass.Text);
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
                    await Navigation.PushAsync(new home(entrycpf.Text.Replace("-", "").Replace(".", ""), entrypass.Text, 1));
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
            if (string.IsNullOrEmpty(entrycpf.Text))
            {
                await DisplayAlert("Aviso", "Olá, para efetuar um novo cadastro digite um CPF", "Ok");
                entrycpf.Focus();
                return;
            }
            else
            {
                IDictionary<string, string> cpf_buscar = new Dictionary<string, string>();
                cpf_buscar.Add("cpf", entrycpf.Text.Replace("-", "").Replace(".", ""));
                this.BuscarUsuario(cpf_buscar);
            }
        }

        private async void BuscarUsuario(IDictionary<string, string> cpf_buscar)
        {
            try
            {
                string retorno = Callws.ChamaWs(cpf_buscar, "BuscarUsuario");

                XDocument xml = XDocument.Parse(retorno);
                var dados = (from s in xml.Descendants("DadosUsuario")
                             select new
                             {
                                 dsTipo = s.Element("dsTipo").Value
                             }).ToList();

                if (dados.Count == 0)
                {
                    await Navigation.PushAsync(new usuCad(entrycpf.Text.Replace("-", "").Replace(".", ""), "NOVO"));
                }
                else
                {
                    if (dados[0].dsTipo == "APP")
                    {
                        await DisplayAlert("Alerta", "Bem vindo novamente, esse CPF já está cadastrado, " +
                        "digite sua senha para acessar sua conta", "Aceitar");
                        entrypass.Focus();
                    }
                    else
                    {
                        await Navigation.PushAsync(new usuCad(entrycpf.Text.Replace("-", "").Replace(".", ""), dados[0].dsTipo));
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