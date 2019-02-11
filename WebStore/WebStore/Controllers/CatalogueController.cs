using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class CatalogueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Shop() => View();
        public IActionResult ProductDetails() => View();
    }
}