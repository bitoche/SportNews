using SportNews.Data;

namespace SportNews.WebApp
{
    public class PostService
    {
        private readonly PostRepository postRepository;

        public PostService(PostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public IEnumerable<Post> GetAllByDiscipline(Discipline discipline)
        {
            var posts = postRepository.GetPosts();
            return posts.Where(post => discipline.Id == post.Discipline.Id);
        }

        public IEnumerable<Post> GetAllByQuery(string query)
        {
            query = query.ToLower();
            if (Discipline.Disciplines.Where(x => x.Name.ToLower() == query).Count() != 0)
            {
                return postRepository.GetPosts().Where(post => post.Discipline.Name.ToLower() == query || post.Title.ToLower().Contains(query) || post.Description.ToLower().Contains(query));
            }
            var posts = postRepository.GetPosts();

            return posts.Where(post => post.Title.ToLower().Contains(query) || post.Description.ToLower().Contains(query));
        }
    }
}