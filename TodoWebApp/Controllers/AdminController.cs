using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoWebApp.Models;
using System.Web.UI.WebControls;

namespace TodoWebApp.Controllers
{
    public class AdminController : Controller
    {
        TodoDbContext context = new TodoDbContext();
        // GET: Admin
        public ActionResult AdminHome()
        {
            try
            {
                int userId = (int)Session["userId"];
                User user = context.Users.Find(userId);
                if (user != null)
                    return View(user);
                else
                {
                    ViewBag.ErrorMessage = "Admin not logged in!";
                    return View("Error");
                }
            }
            catch(Exception ex)
            {
                ViewBag.Exception = "Error Occured!" + ex.Message;
                return View("Error");
            }
         
        }

        [HttpGet]
        public ActionResult AllUsers(int pageNumber = 1) //start at page1
        {
            try
            {
                List<User> users = context.Users.ToList();
                ViewBag.TotalPages = (int)Math.Ceiling(users.Count() / 5.0); //For Pagination. We want to display 5 records per page.
                ViewBag.PageNumber = pageNumber;
                users = users.Skip((pageNumber - 1) * 5).Take(5).ToList();  //By deault page number is 1. So skip 0 records and take 5 records. For second page, pageNumber = 2, so skip first 5 records and display next 5 records. And so on.
                return View(users);
            }
            catch(Exception ex)
            {
                ViewBag.Exception = "Error Occured!" + ex.Message;
                return View("Error");
            }
         
        }

        [HttpPost]
        public ActionResult AllUsers(string search, int pageNumber = 1)
        {
            try
            {
                List<User> users = context.Users.ToList();
                if (search != null)
                {
                    users = context.Users.Where(u => u.UserName.Contains(search)).ToList();  //Search by UserName. Contains() for likely matches. Equals() for exact match
                }
                ViewBag.TotalPages = (int)Math.Ceiling(users.Count() / 5.0);
                ViewBag.PageNumber = pageNumber;
                users = users.Skip((pageNumber - 1) * 5).Take(5).ToList();
                return View(users);
            }
            catch(Exception ex)
            {
                ViewBag.Exception = "Error Occured!" + ex.Message;
                return View("Error");
            }
        }

        public ActionResult UserDetails(int id)
        {
            User user = context.Users.Find(id);
            return View(user);
        }
        public ActionResult DeleteUser(int id)
        {
            User user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("AllUsers", "Admin");
        }
        public ActionResult AdminAccount()
        {
            int userId = (int)Session["userId"];
            User user = context.Users.Find(userId);
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int? id) //Action Link will pass the userId to this method.
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
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                    ViewBag.SuccessMessage = "Updated Details Successfull!";
                    return View(user);
                }
                else
                {
                    ViewBag.ErrorMessage = "Unable To Update Details!";
                    return View(user);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Exception = "Error Occured!" + ex.Message;
                return View("Error");
            }
   
        }
    }
}