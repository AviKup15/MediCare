using Firebase.Auth;
using Firebase.Auth.Providers;
using MediCare.Models;
using Plugin.CloudFirestore;
using System.Text.RegularExpressions;

namespace MediCare.ModelLogic
{
    abstract class FbData : FbDataModel
    {
        
        public override async void CreateUserWithEmailAndPasswordAsync(string email, string password, string name, Action<System.Threading.Tasks.Task> OnComplete)
        {
            await facl.CreateUserWithEmailAndPasswordAsync(email, password, name).ContinueWith(OnComplete);
        }
        public override async void SignInWithEmailAndPasswordAsync(string email, string password, Action<System.Threading.Tasks.Task> OnComplete)
        {
            await facl.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(OnComplete);
        }

        public override string GetErrorMessage(string errMessage)
        {
            int start = errMessage.IndexOf(Keys.MessageKey),
                end = errMessage.IndexOf(Keys.ErrorsKey, start);
            string title = errMessage[(start + Keys.MessageKey.Length)..end]
                .Replace(Keys.Apostrophe, string.Empty)
                .Replace(Keys.Colon, string.Empty)
                .Replace(Keys.Comma, string.Empty)
                .Trim();
            title = string.Join(Keys.WordsDelimiter, title.Split(Keys.TitleDelimiter));
            errMessage = errMessage[(errMessage.IndexOf(Keys.ReasonKey) +
                Keys.ReasonKey.Length)..];
            errMessage = string.Join(Keys.WordsDelimiter,
                Regex.Split(errMessage, Keys.UpperCaseDelimiter)).Trim();
            return title + Keys.NewLine + Keys.ReasonKey +
                Keys.WordsDelimiter + errMessage[..^1];
        }
        public override string DisplayName
        {
            get
            {
                string dn = string.Empty;
                if (facl.User != null)
                    dn = facl.User.Info.DisplayName;
                return dn;
            }
        }
        public override string UserId
        {
            get
            {
                return facl.User.Uid;
            }
        }

    }
}

