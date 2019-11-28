using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeBookkeping.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


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
            var operations = db.Operations.Include(c => c.User);
            return View( operations.ToList());
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
            return RedirectToAction("Index");
        }
        
    }
}
