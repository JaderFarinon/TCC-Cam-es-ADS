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
    public partial class busca_proc : ContentPage
    {
        public string selectedProc;
        public busca_proc()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            listaProc.ItemSelected += ListaProc_ItemSelected;
            btnBusca.Clicked += BtnBusca_Clicked;
            btn_cancela_proc.Clicked += Btn_cancela_Clicked;
            //btn_avanc_proc.Clicked += Btn_avanc_proc_Clicked;

            if (Application.Current.Properties.ContainsKey("session_start"))
            {
                Application.Current.Properties["session_start"] = DateTime.Now;
            }
            else
            {
                Application.Current.Properties.Add("session_start", DateTime.Now);
            }
        }

        public void BtnBusca_Clicked(object sender, EventArgs e)

        {
            string keyword = entryBusca.Text;
            IDictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("keyword", keyword);
            string retorno = Callws.ChamaWs(parametros, "ListarProcedimentos");
            XDocument xml = XDocument.Parse(retorno);

            //Lista de procedimentos
            var dados = (from s in xml.Descendants("Procedimentos")
                         select new
                         {
                             nomeProc = s.Element("nome").Value.ToString(),
                             qtParceiros = s.Element("qt_parceiros").Value.ToString()
                         }).ToList();

            var procedimentos = new List<Procedimento> { };

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
                    procedimentos.Add(new Procedimento() { nomeProc = dados[i].nomeProc, qtParceiros = dados[i].qtParceiros + txtCompl });
                }
            }

            listaProc.ItemsSource = procedimentos;

            if (dados.Count > 0)
            {
                txtResult.Text = "Lista de procedimentos disponíveis:";
                txtIndisp.IsVisible = false;
                //btn_avanc_proc.IsVisible = true;
            }
            else
            {
                txtResult.Text = "";
                txtIndisp.Text = "Infelizmente não temos esse tipo de atendimento agora :( \n\n" +
                    "Mas fique tranquilo que nossa equipe acabou de receber sua solicitação " +
                    "e já está trabalhando para que esteja disponível o quanto antes! \n\nAgradecemos a compreensão.";
                //btn_avanc_proc.IsVisible = false;
                this.relBuscaProc();
            }
        }

        private void relBuscaProc()
        {
        }

        private async void ListaProc_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var procedimento = e.SelectedItem as Procedimento;
            //await DisplayAlert("Aviso", procedimento.nomeProc, "Ok"); //teste nome proc com alert
            //await Navigation.PushAsync(new busca_localidade(procedimento.nomeProc));
            selectedProc = procedimento.nomeProc;

            if (selectedProc == null)
            {
                await DisplayAlert("Aviso", "Você deve selecionar um procedimento antes de prosseguir!", "Selecionar");
            }
            else
            {
                await Navigation.PushAsync(new busca_localidade(selectedProc));
            }
        }

        private async void Btn_avanc_proc_Clicked(object sender, EventArgs e)
        {
            //botão desativado
        }

        private async void Btn_cancela_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}