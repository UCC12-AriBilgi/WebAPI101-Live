using EmployeeApi.Data;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Buranın bir API giriş noktası olduğunu belirtiyor.
    public class EmployeeController : ControllerBase
    {

        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Employees kayıtlarını JSON formatı şeklinde DB tarafından getirme
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        // 2. Employees kayıtları arasından Id si belirlenmiş bir kayıdı getirme işlemi
        // GET: api/<EmployeeController>/5 --> Id=5 olan kaydı getir.
        [HttpGet("id")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            // Üzerine gelen id bilgisine göre ilgili tablodan istenen kayıdı bulma işlemi
            var employee= await _context.Employees.FindAsync(id);

            if (employee == null) 
            {
                // herhangi bir sekilde employee içerği oluşmamışsa(kayıt bulunamamışsa)
                return BadRequest("Employee kaydı bulunamadı....");
            }

            return Ok(employee); // 200 kodu - başarılı işlem

        }

        // 3. Employee tablosu üzerinde yeni bir kayıt ekleme işlemi
        // POST: api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee); // EF sağolsun..

            await _context.SaveChangesAsync(); // db tablosu üzerinde kalıcı olması için

            return Ok(await _context.Employees.ToListAsync());
        }

    }
}
