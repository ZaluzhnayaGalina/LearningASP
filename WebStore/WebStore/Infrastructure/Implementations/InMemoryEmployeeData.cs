using System.Linq;
using System.Collections.Generic;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Implementations
{
    class InMemoryEmployeeData : IEmployeesData
    {
        private List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Name = "Галина",
                Patronymic="Александровна",
                Surname="Залужная",
                Age=23,
                Id=1
            },
            new Employee
            {
                Name = "Наталья",
                Patronymic = "Александровна",
                Surname = "Наумова",
                Age=26,
                Id=2
            }
        };
        public void AddEmployee(Employee newEmployee)
        {
            if (_employees.Contains(newEmployee))
                return;
            newEmployee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(newEmployee);           
        }

        public void Delete(int id)
        {
            var employee = GetEmployee(id);
            if (employee is null)
                return;
            _employees.Remove(employee);
        }

        public IEnumerable<Employee> Get()
        {
            return _employees;
        }

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
        }
    }
}
