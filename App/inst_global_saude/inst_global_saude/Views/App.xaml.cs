using inst_global_saude.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace inst_global_saude
{
    public partial class App : Application
    {
        public App()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            MainPage = new NavigationPage(new login());
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
