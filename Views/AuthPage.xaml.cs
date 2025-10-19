namespace MediCare.Views;

public partial class AuthPage : ContentPage
{
	public AuthPage()
	{
		InitializeComponent();
        BindingContext = new ViewModel.AuthPageVM();
    }
}