using MediCare.Models;

namespace MediCare.ModelLogic
{
    internal class User : UserModel
    {
        public override void Register()
        {
            Preferences.Set(Keys.NameKey, Name);
        }
        public User()
        {
            Name = Preferences.Get(Keys.NameKey, string.Empty);
        }
        public override bool Login()
        {
            return true;
        }

        private void OnComplete(Task task)
        {
            if (task.IsCompletedSuccessfully)
                SaveToPreferences();
            else
            {
                Shell.Current.DisplayAlert(Strings.Error, task.Exception?.Message, Strings.Ok);
            }
        }

        private void SaveToPreferences()
        {
            Name = Preferences.Set(Keys.NameKey, Name);
            Email = Preferences.Set(Keys.EmailKey, Email);
            Password = Preferences.Set(Keys.PasswordKey, Password);
        }
    }
}
