using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeesData _employeesData;
        public EmployeeController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }
        public IActionResult Index()
        {
            return View(_employeesData.Get());
        }
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = _employeesData.GetEmployee(id.Value);
            if (employee is null)
                return NotFound();
            return View(employee);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = _employeesData.GetEmployee(id.Value);
            if (employee is null)
                return NotFound();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            if (!ModelState.IsValid)
                return View(e);
            if (e.Id == 0)
            {
                _employeesData.AddEmployee(e);
            }
            else
            {
                var employee = _employeesData.GetEmployee(e.Id);
                if (employee is null)
                    return NotFound();
                employee.Name = e.Name;
                employee.Surname = e.Surname;
                employee.Patronymic = e.Patronymic;
                employee.Age = e.Age;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = _employeesData.GetEmployee(id.Value);
            if (employee is null)
                return NotFound();
            _employeesData.Delete(id.Value);
            return RedirectToAction("Index");
        }

    }
}