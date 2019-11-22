using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeBookkeping.Models;
using Microsoft.AspNetCore.Authorization;

namespace HomeBookkeping.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        UserContext db;
        public HomeController(UserContext user)
        {
            db = user;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
       public IActionResult AddOperation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddOperation(Operation operation)
        {
            db.Operations.Add(operation);
            db.SaveChanges();
            return Index();
        }
        
    }
}
