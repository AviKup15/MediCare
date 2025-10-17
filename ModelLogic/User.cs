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
        /*private void OnRegisterComplete(Task task)
        {
            // MainThread.InvokeOnMainThreadAsync(() =>
            if (task.IsCompletedSuccessfully)
            {
                SaveToPreferences();
                Shell.Current.DisplayAlert(Strings.Register, "Registration successful!", Strings.Ok);
            }
            else //if
            {
                //string msg = "Registration failed";
                //Toast.Make(msg, ToastDuration.Long).Show();
                Shell.Current.DisplayAlert(Strings.Error, task.Exception?.Message ?? "Registration failed", Strings.Ok);
            }
          /*  else
            {

            }*/

        /* private void OnLoginComplete(Task task, Action<bool, string> onComplete)
         {
             if (task.IsCompletedSuccessfully)
             {
                 // Login successful - save credentials and get display name
                 SaveToPreferences();
                 string displayName = fbd.DisplayName;
                 onComplete?.Invoke(true, displayName);
             }
             else
             {
                 // Login failed - return error message
                 string errorMessage = task.Exception?.Message ?? "Login failed";
                 onComplete?.Invoke(false, errorMessage);
             }
         }*/

        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email);
        }

        public bool IsValidForLogin()
        {
            return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
        }

        private void SaveToPreferences()
        {
            Preferences.Set(Keys.NameKey, Name);
            Preferences.Set(Keys.EmailKey, Email);
            Preferences.Set(Keys.PasswordKey, Password);
        }
    }
}