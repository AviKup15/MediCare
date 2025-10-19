//using MediCare.ModelLogic;
//using MediCare.Models;
//using System.Windows.Input;

//namespace MediCare.ViewModel
//{
//    internal partial class RegisterPageVM : ObservableObject
//    {
//        private readonly User user = new();

//        public ICommand RegisterCommand { get; }
//        public ICommand ToggleIsPasswordCommand { get; }

//        public bool IsBusy { get; set; }

//        public string Name
//        {
//            get => user.Name;
//            set
//            {
//                if (user.Name != value)
//                {
//                    user.Name = value;
//                    OnPropertyChanged();
//                    (RegisterCommand as Command)?.ChangeCanExecute();
//                }
//            }
//        }

//        public string Email
//        {
//            get => user.Email;
//            set
//            {
//                if (user.Email != value)
//                {
//                    user.Email = value;
//                    OnPropertyChanged();
//                    (RegisterCommand as Command)?.ChangeCanExecute();
//                }
//            }
//        }

//        public string Password
//        {
//            get => user.Password;
//            set
//            {
//                if (user.Password != value)
//                {
//                    user.Password = value;
//                    OnPropertyChanged();
//                    (RegisterCommand as Command)?.ChangeCanExecute();
//                }
//            }
//        }

//        public string ConfirmPassword
//        {
//            get => _confirmPassword;
//            set
//            {
//                if (_confirmPassword != value)
//                {
//                    _confirmPassword = value;
//                    OnPropertyChanged();
//                    (RegisterCommand as Command)?.ChangeCanExecute();
//                }
//            }
//        }
//        private string _confirmPassword = string.Empty;

//        public bool IsPassword { get; set; } = true;

//        public RegisterPageVM()
//        {
//            //AuthCommand = user.IsRegistered ? new Command(Login, CanAuth) : new Command(Register, CanAuth);
//            RegisterCommand = new Command(async () => await Register(), CanRegister);
//            ToggleIsPasswordCommand = new Command(ToggleIsPassword);
//        }

//        private bool CanRegister()
//        {
//            return user.IsValid() && !IsBusy && Password == ConfirmPassword;
//        }

//        private async Task Register()
//        {
//            IsBusy = true;

//            try
//            {
//                var tcs = new TaskCompletionSource<bool>();

//                user.Register();

//                // Registration result handled in User.OnRegisterComplete
//                // If you want to handle errors here, you can refactor User.Register to use a callback

//                tcs.SetResult(true);
//                await tcs.Task;

//                // Navigate back to login page after successful registration
//                await Shell.Current.Navigation.PopAsync();
//            }
//            catch (Exception ex)
//            {
//                await Shell.Current.DisplayAlert(Strings.Error, ex.Message, Strings.Ok);
//            }
//            finally
//            {
//                IsBusy = false;
//            }
//        }

//        private void ToggleIsPassword()
//        {
//            IsPassword = !IsPassword;
//            OnPropertyChanged(nameof(IsPassword));
//        }
//    }
//}