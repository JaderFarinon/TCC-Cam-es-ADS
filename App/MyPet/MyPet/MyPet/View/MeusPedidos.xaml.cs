using MyPet.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPet.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeusPedidos : ContentPage
    {
        public MeusPedidos(int usuId)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            btnVoltar.Clicked += BtnVoltar_Clicked;
            ListarAgendamentos(usuId);
        }

        private async void BtnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void ListarAgendamentos(int usuId)
        {
            IDictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("usuId", usuId.ToString());
            string retorno = CallWS.ChamaWs(parametros, "ListarAgendamentos");
            XDocument xml = XDocument.Parse(retorno);
            var dados = (from s in xml.Descendants("Agendamentos")
                         select new
                         {
                             idGuia = s.Element("idGuia").Value,
                             agePagamento = s.Element("agePagamento").Value,
                             unidade = s.Element("unidade").Value,
                             parceiro = s.Element("parceiro").Value,
                             cidade = s.Element("cidade").Value,
                             endereco = s.Element("endereco").Value,
                             dataEmissao = s.Element("dataEmissao").Value,
                             dataGuia = s.Element("dataGuia").Value,
                             horarioGuia = s.Element("horarioGuia").Value,
                             valorGuia = Math.Round(Convert.ToDecimal(s.Element("valorGuia").Value.Replace(".", ",")), 2),
                             totalPago = s.Element("totalPago").Value,
                             procedimento = s.Element("procedimento").Value,
                             valorProcedimento = Math.Round(Convert.ToDecimal(s.Element("valorProcedimento").Value.Replace(".", ",")), 2)
                         }).ToList();

            //var agendamentos = new List<Agendamento> { };

            if (dados.Any())
            {
                for (int i = 0; i < dados.Count; i++)
                {
                    //agendamentos.Add(new Agendamento() { parceiro = dados[0].parceiro, data = dados[0].dataGuia, valor = dados[0].valorGuia });
                }
            }
            else
            {
                txtResult.Text = "Você ainda não realizou nenhum agendamento.";
                txtResult.IsVisible = true;
            }

            //listAgend.ItemsSource = agendamentos;


        }
    }
}