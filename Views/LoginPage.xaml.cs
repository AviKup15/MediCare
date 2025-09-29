using System;
using Microsoft.Maui.Storage;

namespace MediCare
{
    public partial class LoginPage : ContentPage
    {
        private bool isPasswordVisible = false;

        public LoginPage()
        {
            InitializeComponent();
            if (Preferences.ContainsKey("email") && Preferences.ContainsKey("password"))
            {
                EmailEntry.Text = Preferences.Get("email", "");
                PasswordEntry.Text = Preferences.Get("password", "");
                RememberCheckBox.IsChecked = true;
            }
        }
        private void OnTogglePasswordClicked(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            PasswordEntry.IsPassword = !isPasswordVisible;
            TogglePasswordBtn.Text = isPasswordVisible ? "??" : "??";
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }
            if (RememberCheckBox.IsChecked)
            {
                Preferences.Set("email", email);
                Preferences.Set("password", password);
            }
            else
            {
                Preferences.Remove("email");
                Preferences.Remove("password");
            }
            await Navigation.PushAsync(new MainPage());
        }
        private async void OnGoToRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
