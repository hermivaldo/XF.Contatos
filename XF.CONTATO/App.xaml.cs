using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.CONTATO.ViewModel;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF.CONTATO
{
    public partial class App : Application
    {
        public static ContatoViewModel ContatoVM { get; set; }

        public App()
        {
            this.InicializarApp();
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage() {BindingContext = App.ContatoVM});
        }

        private void InicializarApp(){
            if (ContatoVM == null) ContatoVM = new ContatoViewModel();
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
