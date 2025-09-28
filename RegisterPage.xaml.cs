using System;

namespace MediCare
{
    public partial class RegisterPage : ContentPage
    {
        private bool isPasswordVisible = false;
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void OnTogglePasswordClicked(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            PasswordEntry.IsPassword = !isPasswordVisible;
            TogglePasswordBtn.Text = isPasswordVisible ? "??" : "??";
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }
            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }
            Preferences.Set("email", email);
            Preferences.Set("password", password);
            await DisplayAlert("Success", "Account created successfully!", "OK");
            await Navigation.PopAsync();
        }
        private async void OnGoToLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
