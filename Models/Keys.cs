namespace MediCare.Models
{
    internal static class Keys
    {
        public const string NameKey = "name";
        public const string EmailKey = "email";
        public const string PasswordKey = "password";
        public const string FbApiKey = "AIzaSyDtjYrL4eVjjLDMa90qChbSProXQ6cvD0s";
        public const string FbAppDomainKey = "medicare-12345.firebaseapp.com";
        public const string MessageKey = "\"message\":\"";
        public const string ErrorsKey = "\",\"errors\"";
        public const string ReasonKey = "\"reason\":\"";
        // Punctuation to Remove
        public const string Apostrophe = "'";
        public const string Colon = ":";
        public const string Comma = ",";
        // Delimiters
        public const string WordsDelimiter = " ";
        public const string TitleDelimiter = "\n";
        public const string NewLine = "\n";
        // Regex pattern for splitting on uppercase letters
        public const string UpperCaseDelimiter = @"(?=[A-Z])";
    }
}
