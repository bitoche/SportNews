using Microsoft.AspNetCore.Mvc;
using SportNews.Data;
using SportNews.Web;
using SportNews;

namespace SportNews_pre_release_.Controllers
{
    public class AuthentificationController : Controller
    {
        private readonly UserRepository userRepository;
        public AuthentificationController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Auth(string login, string password)
        {

            if (userRepository.Authentificate(login, password, out User user))
            {
                HttpContext.Session.Set(user);
                return RedirectToAction("Index", "Home");
            }
            else
                return View("Index");
        }
        public IActionResult Deauth()
        {
            if (HttpContext.Session.TryGetUser(out User user))
            {
                HttpContext.Session.Remove("User");
                return RedirectToAction("Index", "Home");
            }
            return null;
        }
    }
}
