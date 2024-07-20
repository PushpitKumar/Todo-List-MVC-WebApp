using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoWebApp.Models;  

namespace TodoWebApp.Controllers
{ 
    public class HomeController : Controller
    {
        TodoDbContext context = new TodoDbContext();

        [HttpGet] 
        public ActionResult Register(int id = 1) //To start Primary Key with 1. i.e UserId
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(User user)  
        {
            try
            {
                if (context.Users.Any(u => u.UserName == user.UserName))
                {
                    ViewBag.ErrorMessage = "User Name Already Exists! Please Try Again.";
                    return View(user);

                }
                else if (user.IsAdmin == true && context.Users.Any(u => u.IsAdmin == true)) //Check if there exists an admin!
                {
                    ViewBag.AdminErrorMessage = "Admin Already Exists!";
                    return View(user);
                }
                else if (ModelState.IsValid)
                {
                    user.RegistrationDate = DateTime.Now;
                    user.LastActive = DateTime.Now;
                    context.Users.Add(user);
                    context.SaveChanges();
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Registration Successfull!";
                }
                return View(new User()); //Returning new user so that Form Fields are emptied and Registration Successfull is displayed!.
            }
            catch(Exception ex)
            {
                ViewBag.Exception = "Error Occured!" + ex.Message;
                return View("Error");
            }
            
        }

        [HttpGet]
        public ActionResult Login()
        {
            User user = new User();
            return View(user);
        } 
         
        [HttpPost]   
        public ActionResult Login(User model) //user data coming after form submission. This model data has to compared with user details stored in the database to validate credentials.
        {
            try
            {
                User user = context.Users.Where(u => u.UserName == model.UserName && u.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    Session["userName"] = user.UserName; //Can also write Session.Add("userName",user.UserName);
                    Session.Add("signinTime", DateTime.Now);
                    Session["userId"] = user.UserId;
                    if (user.IsAdmin)
                        return RedirectToAction("AdminHome", "Admin"); //Login to AdminHome via AdminController
                    else
                        return RedirectToAction("UserHome", "User"); //Login to UserHome via UserController
                }
                else
                {
                    ViewBag.LoginErrorMessage = "Incorrect User Name or Password!";
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Exception = "Error Occured!" + ex.Message;
                return View("Error");
            }
            
        }
    
        public ActionResult LogOut()
        {
            try
            {
                string userName = (string)Session["userName"];
                User user = context.Users.Where(u => u.UserName == userName).FirstOrDefault();
                if (user != null)
                {
                    user.LastActive = DateTime.Now;
                    context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    Session.Abandon();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "User not logged in!";
                    return View("Error");
                }
              
            }
            catch(Exception ex)
            {
                ViewBag.Exception = "Error Occured!" + ex.Message;
                return View("Error");
            } 
       
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
        
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}