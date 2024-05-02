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


    }
}
