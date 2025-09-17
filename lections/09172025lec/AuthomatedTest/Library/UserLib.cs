namespace Library
{
    public class UserLib
    {
        public static string GetUserString(User user)
        {
            return $"{user.Name} {user.Email}";
        }
    }
}
