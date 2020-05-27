using inst_global_saude.Classes;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inst_global_saude.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class resumo_guia : ContentPage
    {
        public List<ProcLista> listaAtual;
        private Guia guia = new Guia();
        private decimal vlGuia = 0;
        private int qtItens = 0;
        public resumo_guia(List<ProcLista> procAtual)
        {
            listaAtual = procAtual;
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            btn_adiciona_item.Clicked += Btn_adiciona_item_Clicked;
            btn_voltar.Clicked += Btn_voltar_Clicked;
            btn_finaliza_guia.Clicked += Btn_finaliza_guia_Clicked;




            listaProcGuia.ItemsSource = procAtual;
            listaProcGuia.ItemSelected += ListaProcGuia_ItemSelected;

            for (int i = 0; i < procAtual.Count; i++)
            {
                vlGuia = vlGuia + procAtual[i].vlProc;
                qtItens++;
            }

            txtValor.Text = "R$ " + vlGuia.ToString();

            String txtCompl;
            if (qtItens == 1)
            {
                txtCompl = " Parceiro";
            }
            else
            {
                txtCompl = " Parceiros";
            }
            txtQtProc.Text = qtItens.ToString() + txtCompl;
        }

        private async void Btn_finaliza_guia_Clicked(object sender, System.EventArgs e)
        {
            guia.idAssociado = Application.Current.Properties["SessionAssoc"] as string;
            guia.idUnidade = Application.Current.Properties["SessionUnid"] as string;
            guia.idParceiro = Application.Current.Properties["idParcAtual"] as string;
            guia.vlTotal = vlGuia.ToString();
            await Navigation.PushAsync(new confirm_guia(guia, listaAtual));
        }

        private async void Btn_voltar_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void ListaProcGuia_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listaProcGuia.SelectedItem = null;
        }

        private async void Btn_adiciona_item_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new busca_proc_grupo(listaAtual));
        }
    }
}