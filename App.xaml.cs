using MediCare.ModelLogic;
using MediCare.ViewModel;
using MediCare.Views;
namespace MediCare
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AuthPage();
        }
    }
}
