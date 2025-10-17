using System;

namespace MediCare
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new ViewModel.RegisterPageVM();
        }
       
    }
}
