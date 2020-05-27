using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inst_global_saude.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class dados_assoc : ContentPage
    {
        public string usuCpf;
        public dados_assoc(string tempCpf)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            usuCpf = tempCpf;
            btn_cad.Clicked += Btn_cad_Clicked;
            btn_card.Clicked += Btn_card_Clicked;
            btnVoltar.Clicked += BtnVoltar_Clicked;
        }

        private async void BtnVoltar_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Btn_card_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new meus_cartoes());
        }

        private async void Btn_cad_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new usuCad(usuCpf, "APP"));
        }
    }
}