using Microsoft.AspNetCore.Mvc;
using SportNews.Data;
using SportNews.Web;
using SportNews;
using SportNews_pre_release_.Models;
using System.Diagnostics;
using SportNews.WebApp;

namespace SportNews_pre_release_.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostRepository postRepository;
        private readonly PostService postService;
        private readonly UserRepository userRepository;

        public HomeController(PostRepository postRepository, UserRepository userRepository, PostService postService)
        {
            this.postRepository = postRepository;
            this.userRepository = userRepository;
            this.postService = postService;
        }

        public IActionResult Index(string? query, int page = 1, int disciplineId = 0)
        {
            if (HttpContext.Session.TryGetUser(out var user))
            {
                HttpContext.Session.Set(userRepository.GetById(user.Id));
            }

            var posts = query != null ? postService.GetAllByQuery(query).ToList() : disciplineId == 0 ? postRepository.GetPosts() : postRepository.GetPosts().Where(post => post.Discipline?.Id == disciplineId);
            var model = new PageModel<Post>(posts, page, disciplineId, query);

            return View(model);
        }

        public IActionResult Contacts()
        {
            return View();
        }
    }
}