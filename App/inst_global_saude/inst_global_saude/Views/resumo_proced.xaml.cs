using inst_global_saude.Classes;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inst_global_saude.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class resumo_proced : ContentPage
    {
        public resumo_proced(ProcAtual procAtual)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            btn_adiciona_item.Clicked += Btn_adiciona_item_Clicked;
            btn_voltar.Clicked += Btn_voltar_Clicked;

            //ProcAtual proc = new ProcAtual();
            nomeProc.Text = procAtual.nomeProc;
            nomeParc.Text = procAtual.nomePar;
            enderecoParc.Text = procAtual.enderecoPar;
            contatoParc.Text = procAtual.contatoPar;
            vlProc.Text = "R$ " + procAtual.vlProc.ToString().Replace(".", ",");

            int idProc = procAtual.idProc;
            int idPar = procAtual.idPar;
            int idParGlobal = procAtual.id_globalPar;

            if (procAtual.contatoPar == "0")
            {
                rowContato.Opacity = 0;
            }
            else
            {
                rowContato.Opacity = 1;
            }

            txtHorarioInd.Text = "Assim que finalizar sua solicitação nossa equipe " +
                "entrará em contato para agendar o horário que melhor " +
                "lhe atenda!";

            async void Btn_adiciona_item_Clicked(object sender, System.EventArgs e)
            {
                if (Application.Current.Properties.ContainsKey("qtd_proc_lista"))
                {
                    Application.Current.Properties["qtd_proc_lista"] = Convert.ToInt32(Application.Current.Properties["qtd_proc_lista"] as string) + 1;
                }
                else
                {
                    Application.Current.Properties.Add("qtd_proc_lista", 1);
                }

                if (Application.Current.Properties.ContainsKey("idParcAtual"))
                {
                    Application.Current.Properties["idParcAtual"] = procAtual.id_globalPar.ToString();
                }
                else
                {
                    Application.Current.Properties.Add("idParcAtual", procAtual.id_globalPar.ToString());
                }

                var listaAtual = new List<ProcLista> { };

                listaAtual.Add(new ProcLista() { nomeProc = procAtual.nomeProc, vlProc = procAtual.vlProc, idProc = procAtual.idProc });

                await Navigation.PushAsync(new resumo_guia(listaAtual));
            }
        }

        private async void Btn_voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
