using inst_global_saude.Classes;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inst_global_saude.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class confirm_guia : ContentPage
    {
        public List<ProcLista> itens = new List<ProcLista>();
        String nrGuia;
        public confirm_guia(Guia guia, List<ProcLista> listaitens)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            itens = listaitens;
            InitializeComponent();
            GravarGuia(guia);
            GravarItem(nrGuia);
            ExibeAviso(nrGuia);
        }

        private async void ExibeAviso(string nrGuia)
        {
            await DisplayAlert("Obrigado! Sua guia: " + nrGuia, "Sua solicitação " +
                    "foi enviada com sucesso, em breve entraremos em " +
                    "contato para agendar um dia e horário para seus " +
                    "procedimentos!", "Ok");

            string cpf = Application.Current.Properties["SessionCpf"] as string;
            String senha = Application.Current.Properties["SessionPass"] as string;
            await Navigation.PushAsync(new home(cpf, senha, 2));
        }

        private async void RetornaHome()
        {

        }

        private async void GravarGuia(Guia guia)
        {
            try
            {
                IDictionary<string, string> parametros = new Dictionary<string, string>();
                parametros.Add("unidade", guia.idUnidade);
                parametros.Add("parceiro", guia.idParceiro);
                parametros.Add("associado", guia.idAssociado);
                parametros.Add("valorTotal", guia.vlTotal);
                string retorno = Callws.ChamaWs(parametros, "GravarGuia");
                nrGuia = retorno.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<int xmlns=\"http://tempuri.org/\">", "").Replace("</int>", "");
            }
            catch
            {
                await DisplayAlert("Desculpe", "Sua guia não foi processada, pedimos desculpas pelo incoveniente.", "Ok");
                string cpf = Application.Current.Properties["SessionCpf"] as string;
                String senha = Application.Current.Properties["SessionPass"] as string;
                await Navigation.PushAsync(new home(cpf, senha, 9));
            }
        }

        private async void GravarItem(String nrGuia)
        {
            try
            {
                for (int i = 0; i < itens.Count; i++)
                {
                    IDictionary<string, string> parametros = new Dictionary<string, string>();
                    parametros.Add("idGuia", nrGuia);
                    parametros.Add("procedimento", itens[0].idProc.ToString());
                    parametros.Add("valor", itens[0].vlProc.ToString());
                    string retorno = Callws.ChamaWs(parametros, "GravarItem");
                }
            }
            catch
            {
                await DisplayAlert("Desculpe", "Ñão foi possível adicionar procedimentos a sua guia, pedimos desculpas pelo incoveniente.", "Ok");
                await Navigation.PushAsync(new home(Application.Current.Properties["SessionCpf"] as string, Application.Current.Properties["SessionPass"] as string, 9));
            }
        }
    }
}