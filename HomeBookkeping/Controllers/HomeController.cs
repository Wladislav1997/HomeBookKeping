using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeBookkeping.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using HomeBookkeping.ViewModels;


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
            var operations = db.Users.Include(c => c.Operations);
            return View(operations.ToList());
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

        public IActionResult Filter(Operation operation)
        {
            var oper = db.Operations.Include(c => c.User).ToList();
            List<Operation> op = new List<Operation>();
            for (int i = 0; i < oper.Count; i++)
            {
                if (operation.Name == oper[i].Name | operation.Name == null)
                {

                    if (operation.Data == oper[i].Data | operation.Data == null)
                    {
                        if (operation.Action == oper[i].Action | operation.Action == null)
                        {
                            if (operation.Type == oper[i].Type | operation.Type == null)
                            {
                                if (operation.View == oper[i].View | operation.View == null)
                                {
                                    if (operation.Sum == oper[i].Sum | operation.Sum == null)
                                    {
                                        if (operation.Coment == oper[i].Coment | operation.Coment == null)
                                        {
                                            op.Add(oper[i]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return View(op.ToList());
        }



    }
}
