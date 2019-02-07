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
                Id=0,
                Hobbies = new List<string>{"Вязание", "Матбои"}
            },
            new Employee
            {
                Name = "Наталья",
                Patronymic = "Александровна",
                Surname = "Наумова",
                Age=26,
                Id=1,
                Hobbies = new List<string> {"Викторины"}
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
        [HttpPost]
        public IActionResult EditEmployee(Employee e)
        {
            var employee = _employees.FirstOrDefault(x => x.Id == e.Id);
            if (!(employee is null))
            {
                _employees.Remove(employee);
                _employees.Add(e);
                }
            return RedirectToAction("Index");
        }

    }
}