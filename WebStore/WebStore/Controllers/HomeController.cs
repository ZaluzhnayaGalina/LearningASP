using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private List<Employee> _employees = new List<Employee>
        {
            new Employee
            {
                Name = "Галина",
                Patronymic="Александровная",
                Surname="Залужная",
                Age=23,
                Id=0
            },
            new Employee
            {
                Name = "Наталья",
                Patronymic = "Александровная",
                Surname = "Наумова",
                Age=26,
                Id=1
            }
        };
        public IActionResult Index()
        {
            return View(_employees);
        }
    }
}