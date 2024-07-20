using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoWebApp.Models;

namespace TodoWebApp.Controllers
{
    public class UserController : Controller
    {
        TodoDbContext context = new TodoDbContext();

        //GET: User 
        public ActionResult UserHome() 
        {
            int userId = (int)Session["userId"];
            User user = context.Users.Find(userId);
            return View(user);
        }
         
        public ActionResult Account()
        {
            int userId = (int)Session["userId"];
            User user = context.Users.Find(userId);
            return View(user);
        }

        [HttpGet]
        public ActionResult EditDetails(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            User user = context.Users.Find(id);
            if (user == null)
                return HttpNotFound();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetails (User user)
        {
            if (ModelState.IsValid)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                ViewBag.SuccessMessage = "Updated Details Successfully!";
                return View(user);
            }
            else
            {
                ViewBag.ErrorMessage = "Unable To Update Details!";
                return View(user);
            }
        }
    }
}