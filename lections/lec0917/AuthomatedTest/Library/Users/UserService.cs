namespace Library.Users
{
    public class UserService(IUserRepository repository)
    {
        private readonly IUserRepository _userRepository = repository;

        public User? GetUser(int id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}
