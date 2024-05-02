using EmployeeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWeb.Controllers
{
    public class EmployeeController : Controller
    {
        // Burası bizim sayfalarımızı kontrol edecek controller

        private readonly IEmployeeService _service;
        private readonly string _ApiBase;
        private readonly IWebHostEnvironment _environment; // iki uygulama arası geliş gidiş olacağı için konuldu.

        public EmployeeController(IEmployeeService service,IConfiguration configuration,IWebHostEnvironment environment)
        {
            _service= service;
            _ApiBase = configuration["APISection:BaseAddress"];
            _environment = environment;
        }

        // Tüm kayıtları listeleme kısmı
        public async Task<IActionResult> Index()
        {
            var employees= await _service.GetAll();

            return View(employees);
        }
    }
}
