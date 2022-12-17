namespace SportNews.Data
{
    public class UserRepository
    {
        private List<User> users = new List<User>();
        public UserRepository()
        {
            users.Add(new User("Moderator_1") { Id = 1, Password = "1", Login = "1", Role = Role.Moderator });
            users.Add(new User("Common_1") { Id = 2, Password = "2", Login = "2", Role = Role.Common });
            users.Add(new User("Administrator_1") { Id = 3, Password = "3", Login = "3", Role = Role.Administrator });
        }
        public bool TryRegistrate(string name, string login, string password)
        {
            if (!users.Contains(users.FirstOrDefault(user => user.Login == login)))
            {
                users.Add(new User(name) { Id = users.Count + 1, Password = password, Login = login, Role = Role.Common });
                return true;
            }
            return false;
        }
        public bool Authentificate(string login, string password, out User user)
        {
            user = users.FirstOrDefault(x => x.Login == login && x.Password == password);

            if (user == null)
                return false;
            else
                return true;
        }
        public IEnumerable<User> GetUsers()
        {
            return users;
        }
        public User GetById(int id)
        {
            return users.Single(user => user.Id == id);
        }
    }
}