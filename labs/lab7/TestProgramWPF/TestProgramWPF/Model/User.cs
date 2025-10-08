namespace TestProgramWPF.Model
{
    public class User
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Role Role { get; set; }
    }
}
