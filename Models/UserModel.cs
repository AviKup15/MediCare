using MediCare.ModelLogic;
namespace MediCare.Models
{
    internal abstract class UserModel
    {
        protected FbData fbd = new FirebaseData();
        public EventHandler? OnAuthComplete;
        public bool IsRegistered => !string.IsNullOrWhiteSpace(Name);
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public abstract void Register();
        public abstract void Login(Action<bool, string> onComplete);
        public abstract bool IsValid();
    }
}