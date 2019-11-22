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
        public async Task<IActionResult> Index()
        {
            if (db.Operations != null)
            {

                return View(await db.Operations.ToListAsync());
            }
            return View();
        }
        [HttpGet]
       public IActionResult AddOperation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOperation(Operation operation)
        {
            db.Operations.Add(operation);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}
