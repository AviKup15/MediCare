namespace MediCare.Models
{
    internal abstract class UserModel
    {
        public bool IsRegistered => !string.IsNullOrWhiteSpace(Name);
        public string Name { get; set; } = string.Empty;
        public abstract void Register();
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public abstract bool Login();
    }
}
