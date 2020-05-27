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
    public partial class busca_localidade : ContentPage
    {
        public string selectedProc, selectedLoc;
        public busca_localidade(string dsProced)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            listaLoc.ItemSelected += ListaLoc_ItemSelected;
            //btnNoCity.Clicked += BtnNoCity_Clicked;
            //btn_avanc_parc.Clicked += Btn_avanc_parc_Clicked;
            btn_cancela.Clicked += Btn_cancela_Clicked;
            selectedProc = dsProced;
            //string dsProc = dsProced;
            IDictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("procedimento", dsProced);

            string retorno = Callws.ChamaWs(parametros, "ListarLocalidades");

            XDocument xml = XDocument.Parse(retorno);

            //Lista de procedimentos
            var dados = (from s in xml.Descendants("Localidades")
                         select new
                         {
                             dslocalidade = s.Element("cidade").Value.ToString(),
                             qtParceiros = s.Element("qt_parceiros").Value.ToString()
                         }).ToList();

            var localidades = new List<Localidade> { };

            if (dados.Any())
            {
                for (int i = 0; i < dados.Count; i++)
                {
                    String txtCompl;
                    if (int.Parse(dados[i].qtParceiros) == 1)
                    {
                        txtCompl = " Parceiro";
                    }
                    else
                    {
                        txtCompl = " Parceiros";
                    }
                    localidades.Add(new Localidade() { dsLocalidade = dados[i].dslocalidade, qtParceiros = dados[i].qtParceiros + txtCompl });
                }
            }

            listaLoc.ItemsSource = localidades;
        }

        private async void ListaLoc_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var localidade = e.SelectedItem as Localidade;
            //await DisplayAlert("Aviso", procedimento.nomeProc, "Ok"); //teste nome proc com alert
            //await Navigation.PushAsync(new busca_localidade(procedimento.nomeProc));
            selectedLoc = localidade.dsLocalidade;

            if (selectedLoc == null)
            {
                //Utilizado quando o layout continha um botão para avançar, agora o app avança automaticamente ao selecionar um item
                await DisplayAlert("Aviso", "Você deve selecionar uma cidade antes de prosseguir!", "Selecionar");
            }
            else
            {
                await Navigation.PushAsync(new busca_parceiro(selectedProc, selectedLoc));
            }
        }

        private async void Btn_cancela_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Btn_avanc_parc_Clicked(object sender, System.EventArgs e)
        {
            //botão avança
        }

        private void BtnNoCity_Clicked(object sender, System.EventArgs e)
        {
            entryNoCity.IsVisible = true;
            btnNoCitySend.IsVisible = true;
            dsNoCity.IsVisible = true;
            //btnNoCity.Opacity = 0;
        }
    }
}