using AspCoreSession.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspCoreSession.Controllers
{
    public class UserController : Controller
    {
        public const string SessionKeyName = "_Name";
 
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            HttpContext.Session.SetString(SessionKeyName, JsonConvert.SerializeObject(user));
            return RedirectToAction("Info");
        }

        public IActionResult Info()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                return Redirect("~/User/Login");
            }
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString(SessionKeyName));
            return View(user);
        }
    }
}