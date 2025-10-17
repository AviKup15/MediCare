using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using MediCare.Models;
namespace MediCare.ModelLogic
{
    internal class User : UserModel
    {
        public override void Register()
        {
            fbd.CreateUserWithEmailAndPasswordAsync(Email, Password, Name, OnComplete);
        }
        public override void Login(Action<bool, string> onComplete)
        {
            fbd.SignInWithEmailAndPasswordAsync(Email, Password, OnComplete);
        }
        public User()
        {
            Name = Preferences.Get(Keys.NameKey, string.Empty);
            Email = Preferences.Get(Keys.EmailKey, string.Empty);
            Password = Preferences.Get(Keys.PasswordKey, string.Empty);
        }
        private void OnComplete(Task task)
        {
            MainThread.InvokeOnMainThreadAsync(() =>
            {
                if (task.IsCompletedSuccessfully)
                {
                    SaveToPreferences();
                    OnAuthComplete?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    ShowAlert(Strings.EmailOrPasswordIncorrect);
                }
            });
        }
        private static void ShowAlert(string message)
        {
            MainThread.InvokeOnMainThreadAsync(() =>
            {
                Toast.Make(message, ToastDuration.Long).Show();
            });
        }
        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email);
        }
        private void SaveToPreferences()
        {
            Preferences.Set(Keys.NameKey, Name);
            Preferences.Set(Keys.EmailKey, Email);
            Preferences.Set(Keys.PasswordKey, Password);
        }
    }
}