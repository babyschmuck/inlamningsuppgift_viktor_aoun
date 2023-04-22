using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                using var http = new HttpClient();
                http.DefaultRequestHeaders.Add("X-Api-Key", "1a2f82c0-c1dd-4a4d-9a11-8fed4cfd3f2b");

                var result = await http.PostAsJsonAsync("https://localhost:7022/api/Contact/create", model);

                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }

            return View(model);
        }
    }
}
