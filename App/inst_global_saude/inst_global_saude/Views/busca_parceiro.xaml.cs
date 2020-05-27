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
    public partial class busca_parceiro : ContentPage
    {
        public string selectedProc, selectedLoc;
        public ProcAtual proc = new ProcAtual();
        //public List<ProcAtual> selectedPar = new List<ProcAtual> { };
        public busca_parceiro(string procedimento, string localidade)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            //btnNoParc.Clicked += BtnNoCity_Clicked;
            //btn_resumo.Clicked += Btn_resumo_Clicked;
            btn_cancela_parc.Clicked += Btn_cancela_proc_Clicked;
            listaParc.ItemSelected += ListaParc_ItemSelected;
            selectedLoc = localidade;
            selectedProc = procedimento;
            IDictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("procedimento", procedimento);
            parametros.Add("localidade", localidade);
            string retorno = Callws.ChamaWs(parametros, "ListarParceiros");
            XDocument xml = XDocument.Parse(retorno);

            //Lista de procedimentos
            var dados = (from s in xml.Descendants("Parceiros")
                         select new
                         {
                             nome = s.Element("nome").Value.ToString(),
                             cidade = s.Element("cidade").Value.ToString(),
                             endereco = s.Element("endereco").Value.ToString(),
                             bairro = s.Element("bairro").Value.ToString(),
                             contato = s.Element("contato").Value.ToString(),
                             idParc = int.Parse(s.Element("id").Value.ToString()),
                             idProc = int.Parse(s.Element("procedimentoId").Value.ToString()),
                             vlProc = Math.Round(Convert.ToDecimal(s.Element("valor").Value.Replace(".", ",")), 2)
                         }).ToList();

            var parceiros = new List<Parceiro> { };

            if (dados.Any())
            {
                for (int i = 0; i < dados.Count; i++)
                {
                    parceiros.Add(new Parceiro()
                    {
                        nome = dados[i].nome,
                        cidade = dados[i].cidade,
                        endereco = dados[i].endereco,
                        bairro = dados[i].bairro,
                        contato = dados[i].contato,
                        id = dados[i].idParc,
                        idProc = dados[i].idProc,
                        valor = dados[i].vlProc
                    });
                }
            }

            listaParc.ItemsSource = parceiros;
        }


        private async void ListaParc_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var parceiro = e.SelectedItem as Parceiro;
            proc.nomePar = parceiro.nome;
            proc.cidadePar = parceiro.cidade;
            proc.enderecoPar = parceiro.endereco;
            proc.bairroPar = parceiro.bairro;
            proc.nomeProc = selectedProc;
            proc.idProc = parceiro.idProc;
            proc.id_globalPar = parceiro.id;
            proc.contatoPar = parceiro.contato;
            proc.vlProc = parceiro.valor;

            if (proc.nomePar == null)
            {
                await DisplayAlert("Aviso", "Por favor selecione pelo menos um de nosso parceiros para prosseguir.", "Selecionar");
            }
            else
            {
                await Navigation.PushAsync(new resumo_proced(proc));
            }

        }

        private async void Btn_cancela_proc_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Btn_resumo_Clicked(object sender, System.EventArgs e)
        {
            //Botão avança
        }

        private void BtnNoCity_Clicked(object sender, System.EventArgs e)
        {
            entryNoParc.IsVisible = true;
            btnNoParcSend.IsVisible = true;
            dsNoParc.IsVisible = true;
            //btnNoParc.Opacity = 0;
        }
    }
}