using inst_global_saude.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inst_global_saude.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class meus_cartoes : ContentPage
    {
        public meus_cartoes()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            btnVoltar.Clicked += BtnVoltar_Clicked;
            btnNewCard.Clicked += BtnNewCard_Clicked;
            listaCards.ItemSelected += ListaCards_ItemSelected;
            listarCartoes();

        }

        public void listarCartoes()
        {
            IDictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("usuId", Application.Current.Properties["SessionUsuId"].ToString());
            string retorno = Callws.ChamaWs(parametros, "ListarCartao");
            XDocument xml = XDocument.Parse(retorno);

            //Lista de procedimentos
            var dados = (from s in xml.Descendants("Cartao")
                         select new
                         {
                             carId = s.Element("carId").Value,
                             nome = s.Element("Nome").Value,
                             numero = s.Element("Numero").Value,
                             mes = s.Element("Mes").Value,
                             ano = s.Element("Ano").Value,
                             bandeira = s.Element("Bandeira").Value
                         }).ToList();

            var cartoes = new List<Cartao> { };

            if (dados.Any())
            {
                for (int i = 0; i < dados.Count; i++)
                {
                    cartoes.Add(new Cartao
                    {
                        carId = int.Parse(dados[i].carId),
                        nome = dados[i].nome,
                        numero = dados[i].numero,
                        mesano = dados[i].mes + "/" + dados[i].ano,
                        bandeira = dados[i].bandeira
                    });
                }
            }
            else
            {
                txtNocards.IsVisible = true;
                txtNocards.Text = "Você não possui nenhum cartão cadastrado!";
            }

            listaCards.ItemsSource = cartoes;

            if (dados.Count > 0)
            {
                //Caso existam cartões
            }
            else
            {
                //Caso não existam cartões
            }
        }

        private async void ListaCards_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var cartao = e.SelectedItem as Cartao;
            string numero = cartao.numero.Substring(0, 4) + " **** **** " + cartao.numero.Substring(12, 4);

            bool resposta = await DisplayAlert("", "Deseja excluir o cartão com o número de final " + cartao.numero.Substring(12, 4) + "?", "Sim", "Não");
            if (resposta)
            {
                excluirCartao(cartao.carId);
            }

        }

        private async void BtnNewCard_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Add_card());
        }

        private async void BtnVoltar_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void excluirCartao(int carId)
        {
            try
            {
                IDictionary<string, string> parametros = new Dictionary<string, string>();
                parametros.Add("carId", carId.ToString());
                Callws.ChamaWs(parametros, "ExcluirCartao");
                await DisplayAlert("", "Cartão excluído com sucesso!", "Ok");
                listarCartoes();
            }
            catch
            {
                await DisplayAlert("", "Erro ao excluir o cartão, tente novamente mais tarde!", "Ok");
            }

        }
    }
}