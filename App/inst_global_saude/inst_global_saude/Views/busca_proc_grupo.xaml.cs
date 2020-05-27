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
    public partial class busca_proc_grupo : ContentPage
    {
        public List<ProcLista> listaAtualLoc;
        public ProcLista procSel = new ProcLista();
        public busca_proc_grupo(List<ProcLista> listaAtual)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            string listProcs = "";
            listaAtualLoc = listaAtual;
            listaProc.ItemSelected += ListaProc_ItemSelected;
            //btn_adic_proc.Clicked += Btn_adic_proc_Clicked;
            btn_voltar.Clicked += Btn_voltar_Clicked;

            //cria lista separada por virgula
            for (int i = 0; i < listaAtual.Count; i++)
            {
                listProcs += listaAtual[i].idProc + ",";
            }
            listProcs = listProcs.Substring(0, listProcs.Length - 1);

            IDictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("parceiro", Application.Current.Properties["idParcAtual"].ToString());
            parametros.Add("procedimentos", listProcs);
            string retorno = Callws.ChamaWs(parametros, "ListarProcedimentosGrupo");
            XDocument xml = XDocument.Parse(retorno);

            //Lista de procedimentos
            var dados = (from s in xml.Descendants("Procedimentos")
                         select new
                         {
                             nomeProc = s.Element("nome").Value.ToString(),
                             idProc = s.Element("id").Value.ToString(),
                             vlProc = decimal.Parse(s.Element("valor").Value.ToString())
                         }).ToList();

            var procedimentos = new List<ProcLista> { };

            if (dados.Any())
            {
                for (int i = 0; i < dados.Count; i++)
                {
                    procedimentos.Add(new ProcLista()
                    {
                        nomeProc = dados[i].nomeProc,
                        idProc = Convert.ToInt32(dados[i].idProc),
                        vlProc = dados[i].vlProc
                    });
                }
            }
            else
            {
                RetornaGuia();
            }

            listaProc.ItemsSource = procedimentos;

        }

        private async void RetornaGuia()
        {
            await DisplayAlert("Aviso", "O procedimento escolhido não pode ser agrupado com outros.", "Ok");
            await Navigation.PopAsync();
        }

        private async void Btn_voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void ListaProc_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var d = e.SelectedItem as ProcLista;
            //listaAtualLoc.Add(new ProcLista() {nomeProc = procSel.nomeProc, idProc = procSel.idProc, vlProc = procSel.vlProc});
            procSel.nomeProc = d.nomeProc;
            procSel.vlProc = d.vlProc;
            procSel.idProc = d.idProc;

            if (procSel.nomeProc == null)
            {
                await DisplayAlert("Aviso", "Selecione pelo menos um procedimento para prosseguir", "Selecionar");
            }
            else
            {
                listaAtualLoc.Add(new ProcLista() { nomeProc = procSel.nomeProc, idProc = procSel.idProc, vlProc = procSel.vlProc });
                await Navigation.PushAsync(new resumo_guia(listaAtualLoc));
            }
        }

        private async void Btn_adic_proc_Clicked(object sender, EventArgs e)
        {
            //
        }
    }
}