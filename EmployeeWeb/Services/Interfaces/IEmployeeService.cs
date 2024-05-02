using EmployeeWeb.Models;

namespace EmployeeWeb.Services.Interfaces
{
    public interface IEmployeeService
    {
        // DB üzerinde tüm kayıtları getirecek olan metot/task
        Task<IEnumerable<Employee>> GetAll();

        // DB üzerinde id bilgisi ile istenen bir kayıdı bulan metot/Task
        Task<Employee> GetById(int id);


    }
}
