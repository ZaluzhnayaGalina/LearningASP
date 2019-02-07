using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Name = "Галина",
                Patronymic="Александровна",
                Surname="Залужная",
                Age=23,
                Id=0
            },
            new Employee
            {
                Name = "Наталья",
                Patronymic = "Александровна",
                Surname = "Наумова",
                Age=26,
                Id=1
            }
        };
        public IActionResult Index()
        {
            return View(_employees);
        }
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = _employees.FirstOrDefault(x => x.Id == id);
            if (employee is null)
                return NotFound();
            return View(employee);

        }
        [HttpGet]
        public IActionResult EditEmployee(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = _employees.FirstOrDefault(x => x.Id == id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee e)
        {
            if (!ModelState.IsValid)
                return View(e);
            if (e.Id == 0)
            {
                e.Id = _employees.Max(x => x.Id) + 1;
                _employees.Add(e);
            }
            else
            {
                var employee = _employees.FirstOrDefault(x => x.Id == e.Id);
                if (employee is null)
                    return NotFound();
                employee.Name = e.Name;
                employee.Surname = e.Surname;
                employee.Patronymic = e.Patronymic;
                employee.Age = e.Age;
            }
            return RedirectToAction("Index");
        }

    }
}