using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Reflection;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminViewModel _adminViewModel;

        public AdminController(AdminViewModel adminViewModel)
        {
            _adminViewModel = adminViewModel;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using var http = new HttpClient();
            http.DefaultRequestHeaders.Add("X-Api-Key", "1a2f82c0-c1dd-4a4d-9a11-8fed4cfd3f2b");
            var token = HttpContext.Request.Cookies["accessToken"];
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var result = await http.GetAsync("https://localhost:7022/api/Admin");
            
            if(!result.IsSuccessStatusCode)
            {
                _adminViewModel.IsAdmin = false;
            }

            return View(_adminViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminViewModel model)
        {
            model.IsAdmin = _adminViewModel.IsAdmin;
            if(ModelState.IsValid)
            {
                using var http = new HttpClient();
                http.DefaultRequestHeaders.Add("X-Api-Key", "1a2f82c0-c1dd-4a4d-9a11-8fed4cfd3f2b");
                var token = HttpContext.Request.Cookies["accessToken"];
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                ProductModel product = model;
                var result = await http.PostAsJsonAsync("https://localhost:7022/api/Products/create", product);

                if(result.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            
            return View(model);
        }
    }
}
