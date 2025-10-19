//using Firebase.Auth;
//using System.Windows.Input;
//using MediCare.Models;
//using MediCare.ModelLogic;
//namespace MediCare.ViewModel
//{
//    internal partial class MainPageVM : ObservableObject
//    {
//        private MediCare.ModelLogic.User user = new();
//        public ICommand LoginCommand { get; }
//        public ICommand ToggleIsPasswordCommand { get; }
//        public bool IsBusy { get; set; } = false;
//        public string UserEmail
//        {
//            get => user.Email; // Using Email for login
//            set
//            {
//                user.Email = value;
//                (LoginCommand as Command)?.ChangeCanExecute();
//            }
//        }
//        public string UserName
//        {
//            get => user.Name; 
//            set
//            {
//                user.Name = value;
//                (LoginCommand as Command)?.ChangeCanExecute();
//            }
//        }
//        public string Password
//        {
//            get => user.Password;
//            set
//            {
//                user.Password = value;
//                (LoginCommand as Command)?.ChangeCanExecute();
//            }
//        }
//        public bool IsPassword { get; set; } = true;
//        public ICommand GoToReisterCommand { get; }
//        public MainPageVM()
//        {
//            LoginCommand = new Command(async () => await Login(), CanLogin);
//            ToggleIsPasswordCommand = new Command(ToggleIsPassword);
//            GoToReisterCommand = new Command(async () =>
//            {
//                await Application.Current!.MainPage!.Navigation.PushAsync(new RegisterPage());
//            });
//        }
//        private void ToggleIsPassword()
//        {
//            IsPassword = !IsPassword;
//            OnPropertyChanged(nameof(IsPassword));
//        }
//      /*  private async Task Login()
//        {
//            IsBusy = true;
//            OnPropertyChanged(nameof(IsBusy));

//            try
//            {
//                // Create a TaskCompletionSource to wait for Firebase callback
//                var tcs = new TaskCompletionSource<bool>();

//                user.Login((success, message) =>
//                {
//                    if (success)
//                    {
//                        // Login successful
//                        Shell.Current.DisplayAlert(Strings.LoginTitle, $"Welcome back, {message}!", Strings.Ok);
//                        // Navigate to main app page or perform other actions
//                        tcs.SetResult(true);
//                    }
//                    else
//                    {
//                        // Login failed - display error
//                        Shell.Current.DisplayAlert(Strings.Error, message, Strings.Ok);
//                        tcs.SetResult(false);
//                    }
//                });

//                await tcs.Task;
//            }
//            catch (Exception ex)
//            {
//                await Shell.Current.DisplayAlert(Strings.Error, ex.Message, Strings.Ok);
//            }
//            finally
//            {
//                IsBusy = false;
//                OnPropertyChanged(nameof(IsBusy));
//            }
//        } */
//        private bool CanLogin()
//        {
//            return (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && !IsBusy);
//        }
//    }
//}