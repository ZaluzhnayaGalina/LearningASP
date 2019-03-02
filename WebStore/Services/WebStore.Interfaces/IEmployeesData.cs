using System.Collections.Generic;
using WebStore.Models;
namespace WebStore.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> Get();
        Employee GetEmployee(int id);
        void AddEmployee(Employee newEmployee);
        void Delete(int id);
        void SaveChanges();
    }
}
