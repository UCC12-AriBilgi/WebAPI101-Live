using EmployeeWeb.Helpers;
using EmployeeWeb.Models;
using EmployeeWeb.Services.Interfaces;

namespace EmployeeWeb.Services
{
    public class EmployeeService : IEmployeeService
    {
        // Bu MVC uygulaması client/server mimarisi yapısında client(istekçi/müşteri) görevi görecek. O yüzden buraya bazı kütüphaneleri tanımlamak gerekmekte.
        public readonly HttpClient _client;
        public readonly string _ApiBase; // http://localhost:5172.. Server

        // constructor
        public EmployeeService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _ApiBase = configuration["APISection:BaseAddress"]; // appsettings.json dosyasından gelen bilgiler
        }



        public async Task<IEnumerable<Employee>> GetAll()
        {
            // Burada karşı tarafa(API tarafına) ulaşmamı sağlayacak olan tanımı oluşturuyoruz(link oluşturuyoruz)
            string ApiPath = _ApiBase + "api/Employee";

            var response=await _client.GetAsync(ApiPath);

            return await response.ReadContentAsync<List<Employee>>();
            // karşı taraftan gelecek olan bilgiyi okuyacak olan metot


        }

        public async Task<Employee> GetById(int id)
        {
            string ApiPath= _ApiBase + "api/Employee/" + id;// gelen id bilgisi Api tarafına gönderilecek

            var response= await _client.GetAsync(ApiPath);

            return await response.ReadContentAsync<Employee>();
        }
    }
}
