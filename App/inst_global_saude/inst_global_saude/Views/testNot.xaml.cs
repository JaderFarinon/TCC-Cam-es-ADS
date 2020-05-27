using Plugin.LocalNotifications;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace inst_global_saude.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class testNot : ContentPage
    {
        public testNot()
        {
            InitializeComponent();
        }

        public void Start_Notification(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("Title", "Text");
        }
    }
}