using inst_global_saude.Classes;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inst_global_saude.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_card : ContentPage
    {
        public Add_card()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            btnSalvarCartao.Clicked += BtnSalvarCartao_Clicked;
            btnCancel.Clicked += BtnCancel_Clicked;

            var bandeiras = new List<string>();
            bandeiras.Add("Visa");
            bandeiras.Add("Mastercard");
            bandeiras.Add("American Express");
            bandeiras.Add("Elo");
            bandeiras.Add("Discover Network");
            pickerBandeira.ItemsSource = bandeiras;
        }

        private async void BtnCancel_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnSalvarCartao_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                IDictionary<string, string> parametros = new Dictionary<string, string>();
                parametros.Add("usuId", Application.Current.Properties["SessionUsuId"].ToString());
                parametros.Add("nome", entryName.Text);
                parametros.Add("numero", entryNum.Text.Replace(" ", ""));
                parametros.Add("mes", entryVal.Text.Substring(0, 2));
                parametros.Add("ano", entryVal.Text.Substring(3, 2));
                parametros.Add("bandeira", "Visa");
                string retorno = Callws.ChamaWs(parametros, "GravarCartao");

                string result = retorno.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<int xmlns=\"http://tempuri.org/\">", "").Replace("</int>", "");

                meus_cartoes refresh = new meus_cartoes();
                refresh.listarCartoes();

                if (int.Parse(result) > 0)
                {
                    await DisplayAlert("Excelente!", "Cartão cadastrado com sucesso!!", "Ok");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Aviso", "Erro ao cadastrar o cartão. Tente novamente mais tarde!", "Ok");
                }
            }
            catch
            {
                await DisplayAlert("Aviso", "Erro ao cadastrar o cartão. Tente novamente mais tarde!", "Ok");
            }
        }
    }
}