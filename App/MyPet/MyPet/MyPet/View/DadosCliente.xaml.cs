
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPet.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DadosCliente : ContentPage
    {
        public DadosCliente(int idCliente)
        {
            InitializeComponent();
        }
    }
}