using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using var http = new HttpClient();
                http.DefaultRequestHeaders.Add("X-Api-Key", "1a2f82c0-c1dd-4a4d-9a11-8fed4cfd3f2b");

                var result = await http.PostAsJsonAsync("https://localhost:7022/api/Auth/login", model);
                var token = await result.Content.ReadAsStringAsync();

                if(!(result.StatusCode == System.Net.HttpStatusCode.Unauthorized))
                {
                    HttpContext.Response.Cookies.Append("accessToken", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        Expires = DateTime.Now.AddHours(1)
                    });

                    return RedirectToAction("Index", "Home");
                }
                
            }
            ModelState.AddModelError("", "Incorrect email or password");

            return View(model);
        }
    }
}
