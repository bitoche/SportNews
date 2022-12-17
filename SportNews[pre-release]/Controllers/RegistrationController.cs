using Microsoft.AspNetCore.Mvc;
using SportNews.Data;
using SportNews;
using SportNews.Web;

namespace SportNews_pre_release_.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserRepository userRepository;
        public RegistrationController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration(string name, string login, string password, string confirmPassword)
        {
            if (password == confirmPassword && userRepository.TryRegistrate(name, login, password))
            {
                if (userRepository.Authentificate(login, password, out User user))
                {
                    HttpContext.Session.Set(user);
                    return RedirectToAction("Index", "Home");
                }
                return View("Index");
            }
            else

                return View("Index");

        }
    }
}
