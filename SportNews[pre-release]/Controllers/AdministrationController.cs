using Microsoft.AspNetCore.Mvc;
using SportNews;
using SportNews.Data;
using SportNews.Web;

namespace SportNews_pre_release_.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly UserRepository userRepository;
        private readonly PostRepository postRepository;
        public AdministrationController(PostRepository postRepository, UserRepository userRepository)
        {
            this.postRepository = postRepository;
            this.userRepository = userRepository;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetUser(out User user))
            {
                if (user.Role != Role.Common)
                {
                    return View("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AddPost(string title, string description, string imageLink, int disciplineId)
        {
            HttpContext.Session.TryGetUser(out User user);
            postRepository.CreatePost(title, description, imageLink, user, disciplineId);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AdministrateUsers()
        {
            if (HttpContext.Session.TryGetUser(out User user))
            {
                if (user.Role == Role.Administrator)
                {
                    var model = userRepository.GetUsers();
                    return View("Users", model.ToArray());
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        public IActionResult SwapRole(int userId, int roleId)
        {
            if (HttpContext.Session.TryGetUser(out User user))
            {
                if (user.Role == Role.Administrator)
                {
                    userRepository.GetById(userId).Role = (Role)roleId;
                    return View("Users", userRepository.GetUsers().ToArray());
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult RemovePost(int postId)
        {
            if (HttpContext.Session.TryGetUser(out User user))
            {
                if (user.Role != Role.Common)
                {
                    postRepository.RemovePost(postId);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
