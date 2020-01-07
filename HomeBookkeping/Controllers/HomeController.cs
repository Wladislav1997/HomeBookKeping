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
            IQueryable<Operation> operat = db.Operations.Include(c => c.User);
            operat = operat.Where(p => p.User.Email == User.Identity.Name);
            return View(operat);

        }   
        [HttpGet]
       public IActionResult AddOperation()
        {
            ViewBag.Type = new List<string> { "разово", "переодически" };
            ViewBag.NameAct = new List<string> { "доход", "расход" };
            return View();
        }
        [HttpPost]
        public IActionResult AddOperation(Operation operation)
        {
            //operation.User.Email = User.Identity.Name;
            db.Operations.Add(operation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Filter(Operation operation)
        {
            IQueryable<Operation> oper = db.Operations.Include(c => c.User);
            oper = oper.Where(p => p.User.Email == User.Identity.Name);
            oper = oper.Where(a => a.NameAct == operation.NameAct);
            //if (operation.Name != null)
            //{
            //    oper = oper.Where(a => a.Name == operation.Name);

            //    if (operation.Data != null)
            //    {
            //        oper = oper.Where(a => a.Data == operation.Data);
            //        if (operation.View != null)
            //        {
            //            oper = oper.Where(a => a.View == operation.View);
            //            if (operation.Type != null)
            //            {
            //                oper = oper.Where(a => a.Type == operation.Type);
            //                if (operation.Sum != null)
            //                {
            //                    oper = oper.Where(a => a.Sum == operation.Sum);
            //                    if (operation.Coment != null)
            //                    {
            //                        oper = oper.Where(a => a.Coment == operation.Coment);
            //                        return View(oper);
            //                    }
            //                    return View(oper);
            //                }
            //                if (operation.Coment != null)
            //                {
            //                    oper = oper.Where(a => a.Coment == operation.Coment);
            //                    return View(oper);
            //                }
            //                return View(oper);
            //            }
            //            if (operation.Sum != null)
            //            {
            //                oper = oper.Where(a => a.Sum == operation.Sum);
            //                if (operation.Coment != null)
            //                {
            //                    oper = oper.Where(a => a.Coment == operation.Coment);
            //                    return View(oper);
            //                }
            //                return View(oper);
            //            }
            //            if (operation.Coment != null)
            //            {
            //                oper = oper.Where(a => a.Coment == operation.Coment);
            //                return View(oper);
            //            }
            //            return View(oper);
            //        }
            //        if (operation.Type != null)
            //        {
            //            oper = oper.Where(a => a.Type == operation.Type);
            //            if (operation.Sum != null)
            //            {
            //                oper = oper.Where(a => a.Sum == operation.Sum);
            //                if (operation.Coment != null)
            //                {
            //                    oper = oper.Where(a => a.Coment == operation.Coment);
            //                    return View(oper);
            //                }
            //                return View(oper);
            //            }
            //            if (operation.Coment != null)
            //            {
            //                oper = oper.Where(a => a.Coment == operation.Coment);
            //                return View(oper);
            //            }
            //            return View(oper);
            //        }
            //        if (operation.Sum != null)
            //        {
            //            oper = oper.Where(a => a.Sum == operation.Sum);
            //            if (operation.Coment != null)
            //            {
            //                oper = oper.Where(a => a.Coment == operation.Coment);
            //                return View(oper);
            //            }
            //            return View(oper);
            //        }
            //        if (operation.Coment != null)
            //        {
            //            oper = oper.Where(a => a.Coment == operation.Coment);
            //            return View(oper);
            //        }
            //        return View(oper);
            //    }
            //    if (operation.View != null)
            //    {
            //        oper = oper.Where(a => a.View == operation.View);
            //        if (operation.Type != null)
            //        {
            //            oper = oper.Where(a => a.Type == operation.Type);
            //            if (operation.Sum != null)
            //            {
            //                oper = oper.Where(a => a.Sum == operation.Sum);
            //                if (operation.Coment != null)
            //                {
            //                    oper = oper.Where(a => a.Coment == operation.Coment);
            //                    return View(oper);
            //                }
            //                return View(oper);
            //            }
            //            if (operation.Coment != null)
            //            {
            //                oper = oper.Where(a => a.Coment == operation.Coment);
            //                return View(oper);
            //            }
            //            return View(oper);
            //        }
            //        if (operation.Sum != null)
            //        {
            //            oper = oper.Where(a => a.Sum == operation.Sum);
            //            if (operation.Coment != null)
            //            {
            //                oper = oper.Where(a => a.Coment == operation.Coment);
            //                return View(oper);
            //            }
            //            return View(oper);
            //        }
            //        if (operation.Coment != null)
            //        {
            //            oper = oper.Where(a => a.Coment == operation.Coment);
            //            return View(oper);
            //        }
            //        return View(oper);
            //    }
            //    if (operation.Type != null)
            //    {
            //        oper = oper.Where(a => a.Type == operation.Type);
            //        if (operation.Sum != null)
            //        {
            //            oper = oper.Where(a => a.Sum == operation.Sum);
            //            if (operation.Coment != null)
            //            {
            //                oper = oper.Where(a => a.Coment == operation.Coment);
            //                return View(oper);
            //            }
            //            return View(oper);
            //        }
            //        if (operation.Coment != null)
            //        {
            //            oper = oper.Where(a => a.Coment == operation.Coment);
            //            return View(oper);
            //        }
            //        return View(oper);
            //    }
            //    if (operation.Sum != null)
            //    {
            //        oper = oper.Where(a => a.Sum == operation.Sum);
            //        if (operation.Coment != null)
            //        {
            //            oper = oper.Where(a => a.Coment == operation.Coment);
            //            return View(oper);
            //        }
            //        return View(oper);
            //    }
            //    if (operation.Coment != null)
            //    {
            //        oper = oper.Where(a => a.Coment == operation.Coment);
            //        return View(oper);
            //    }
            //    return View(oper);
            //}
            //if (operation.Data != null)
            //{
            //    oper = oper.Where(a => a.Data == operation.Data);
            //    if (operation.View != null)
            //    {
            //        oper = oper.Where(a => a.View == operation.View);
            //        if (operation.Type != null)
            //        {
            //            oper = oper.Where(a => a.Type == operation.Type);
            //            if (operation.Sum != null)
            //            {
            //                oper = oper.Where(a => a.Sum == operation.Sum);
            //                if (operation.Coment != null)
            //                {
            //                    oper = oper.Where(a => a.Coment == operation.Coment);
            //                    return View(oper);
            //                }
            //                return View(oper);
            //            }
            //            if (operation.Coment != null)
            //            {
            //                oper = oper.Where(a => a.Coment == operation.Coment);
            //                return View(oper);
            //            }
            //            return View(oper);
            //        }
            //        if (operation.Sum != null)
            //        {
            //            oper = oper.Where(a => a.Sum == operation.Sum);
            //            if (operation.Coment != null)
            //            {
            //                oper = oper.Where(a => a.Coment == operation.Coment);
            //                return View(oper);
            //            }
            //            return View(oper);
            //        }
            //        if (operation.Coment != null)
            //        {
            //            oper = oper.Where(a => a.Coment == operation.Coment);
            //            return View(oper);
            //        }
            //        return View(oper);
            //    }
            //    if (operation.Type != null)
            //    {
            //        oper = oper.Where(a => a.Type == operation.Type);
            //        if (operation.Sum != null)
            //        {
            //            oper = oper.Where(a => a.Sum == operation.Sum);
            //            if (operation.Coment != null)
            //            {
            //                oper = oper.Where(a => a.Coment == operation.Coment);
            //                return View(oper);
            //            }
            //            return View(oper);
            //        }
            //        if (operation.Coment != null)
            //        {
            //            oper = oper.Where(a => a.Coment == operation.Coment);
            //            return View(oper);
            //        }
            //        return View(oper);
            //    }
            //    if (operation.Sum != null)
            //    {
            //        oper = oper.Where(a => a.Sum == operation.Sum);
            //        if (operation.Coment != null)
            //        {
            //            oper = oper.Where(a => a.Coment == operation.Coment);
            //            return View(oper);
            //        }
            //        return View(oper);
            //    }
            //    if (operation.Coment != null)
            //    {
            //        oper = oper.Where(a => a.Coment == operation.Coment);
            //        return View(oper);
            //    }
            //    return View(oper);
            //}
            //if (operation.View != null)
            //{
            //    oper = oper.Where(a => a.View == operation.View);
            //    if (operation.Type != null)
            //    {
            //        oper = oper.Where(a => a.Type == operation.Type);
            //        if (operation.Sum != null)
            //        {
            //            oper = oper.Where(a => a.Sum == operation.Sum);
            //            if (operation.Coment != null)
            //            {
            //                oper = oper.Where(a => a.Coment == operation.Coment);
            //                return View(oper);
            //            }
            //            return View(oper);
            //        }
            //        if (operation.Coment != null)
            //        {
            //            oper = oper.Where(a => a.Coment == operation.Coment);
            //            return View(oper);
            //        }
            //        return View(oper);
            //    }
            //    if (operation.Sum != null)
            //    {
            //        oper = oper.Where(a => a.Sum == operation.Sum);
            //        if (operation.Coment != null)
            //        {
            //            oper = oper.Where(a => a.Coment == operation.Coment);
            //            return View(oper);
            //        }
            //        return View(oper);
            //    }
            //    if (operation.Coment != null)
            //    {
            //        oper = oper.Where(a => a.Coment == operation.Coment);
            //        return View(oper);
            //    }
            //    return View(oper);
            //}
            //if (operation.Type != null)
            //{
            //    oper = oper.Where(a => a.Type == operation.Type);
            //    if (operation.Sum != null)
            //    {
            //        oper = oper.Where(a => a.Sum == operation.Sum);
            //        if (operation.Coment != null)
            //        {
            //            oper = oper.Where(a => a.Coment == operation.Coment);
            //            return View(oper);
            //        }
            //        return View(oper);
            //    }
            //    if (operation.Coment != null)
            //    {
            //        oper = oper.Where(a => a.Coment == operation.Coment);
            //        return View(oper);
            //    }
            //    return View(oper);
            //}
            //if (operation.Sum != null)
            //{
            //    oper = oper.Where(a => a.Sum == operation.Sum);
            //    if (operation.Coment != null)
            //    {
            //        oper = oper.Where(a => a.Coment == operation.Coment);
            //        return View(oper);
            //    }
            //    return View(oper);
            //}
            //if (operation.Coment != null)
            //{
            //    oper = oper.Where(a => a.Coment == operation.Coment);
            //    return View(oper);
            //}
            return View(oper);

        }



    }
}
