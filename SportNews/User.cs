
namespace SportNews
{
    public class User
    {
        public string Name { get; set; }
        public Role Role { get; set; } = Role.Common;
        public int Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public User(string name)
        {
            Name = name;
        }

        public User(string name, string password, string login) : this(name)
        {
            Password = password;
            Login = login;
        }

    }
    public enum Role { Moderator, Common, Administrator }
}
