using SportNews;
using System.Text;

namespace SportNews.Web
{
    public static class SessionExtensions
    {
        private const string key = "User";

        public static void Set(this ISession session, User value)
        {
            if (value == null)
                return;
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
            {
                writer.Write(value.Id);
                writer.Write(value.Name);
                writer.Write(Convert.ToInt32(value.Role));

                session.Set(key, stream.ToArray());
            }
        }
        public static bool TryGetUser(this ISession session, out User value)
        {
            if(session.TryGetValue(key, out byte[] buffer))
            {
                using (var stream = new MemoryStream(buffer))
                using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    var userId = reader.ReadInt32();
                    var userName = reader.ReadString();
                    var userRole = reader.ReadInt32();

                    value = new User(userName)
                    {
                        Id = userId,
                        Role = (Role)userRole,
                        Name = userName
                    };
                    return true;
                }
            }
            value = null;
            return false;
        }
    }
}
