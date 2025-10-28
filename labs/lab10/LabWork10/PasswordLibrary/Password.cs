using System.Text.RegularExpressions;

namespace PasswordLibrary
{
    public static class Password
    {
        public static bool IsPasswordValidate(string password)
            => password.Length >= 8 && Regex.IsMatch(password, @"(?=.*\d)(?=.*\W)(?=.*[a-z])(?=[A-Z])");

        public static bool IsVibe() => throw new NotImplementedException();
    }
}
