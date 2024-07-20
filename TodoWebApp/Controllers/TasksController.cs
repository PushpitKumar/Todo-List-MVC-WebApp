using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoWebApp.Models;

namespace TodoWebApp.Controllers
{
    public class TasksController : Controller
    {
        TodoDbContext context = new TodoDbContext();

        // GET: Tasks
        public ActionResult TaskIndex(int id) //ListId will be passed here.
        {
            if (Session["userId"] != null)
            {
                int listId = id;
                ViewBag.ListId = listId;
                Session["listId"] = listId; //Needed for back button in Activity Index
                List<Task> tasks = context.Tasks.Where(t => t.ListId == listId).ToList();
                int taskCompletion = 0;
                foreach(Task task in tasks)
                {
                    if (DateTime.Now > task.DueTime && task.Status != "Completed")
                    {
                        task.Status = "Overdue";
                        context.Entry(task).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    if (task.Status == "Completed")
                        taskCompletion++;
                }
                ViewBag.Completion = Math.Round(100f * (taskCompletion / (float)tasks.Count()));
                return View(tasks);
            }
            else
            {
                ViewBag.ErrorMessage = "User not logged in!";
                return View("Error");
            }
          
        }

        [HttpGet]
        public ActionResult CreateTask(int id)
        {
            Task task = new Task();
            task.ListId = id;
            return View(task);
        }

        [HttpPost]
        public ActionResult CreateTask(Task task)
        {
            //Lines 48 to 56 for image upload
            if (task.ImageFile != null) //If image exists
            {
                string fileName = Path.GetFileNameWithoutExtension(task.ImageFile.FileName);
                string extension = Path.GetExtension(task.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension; //Adding Datetime to filename to avoid duplicate file names
                task.ImagePath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);//exact path in server
                task.ImageFile.SaveAs(fileName);
            }

            task.TimeOfCreation = DateTime.Now;
            task.LastUpdated = DateTime.Now;
            if (ModelState.IsValid)
            {
                context.Tasks.Add(task);
                context.SaveChanges();
                return RedirectToAction("TaskIndex","Tasks",new { id = task.ListId});
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to create Task!";
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditTask(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Task task = context.Tasks.Find(id);
            ViewBag.ListId = task.ListId; //Needed for back button to work in EditTask View
            if (task == null)
                return HttpNotFound();
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTask(Task task)
        {
            if (task.ImageFile == null)  //Then do not modify the ImagePath
            {
                task.LastUpdated = DateTime.Now;
                ViewBag.ListId = task.ListId;
                context.Entry(task).State = EntityState.Modified;
                context.Entry(task).Property(t => t.ImagePath).IsModified = false;
                context.SaveChanges();
                ViewBag.SuccessMessage = "Updated Task Successfully!";
                return View(task);
            }
            else
            {
                string fileName = Path.GetFileNameWithoutExtension(task.ImageFile.FileName);
                string extension = Path.GetExtension(task.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension; //Adding Datetime to filename to avoid duplicate file names
                task.ImagePath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);//exact path in server
                task.ImageFile.SaveAs(fileName);
                task.LastUpdated = DateTime.Now;
                ViewBag.ListId = task.ListId;
                context.Entry(task).State = EntityState.Modified;
                context.SaveChanges();
                ViewBag.SuccessMessage = "Updated Task Successfully!";
                return View(task);
            }
        }

        [HttpGet]
        public ActionResult TaskDetails(int id)
        {
            Task task = context.Tasks.Find(id);
            return View(task);
        }

        [HttpGet]
        public ActionResult DeleteTask(int id)
        {
            Task task = context.Tasks.Find(id);
            int listId = task.ListId; //TaskIndex expects ListId parameter.
            context.Tasks.Remove(task);
            context.SaveChanges();
            return RedirectToAction("TaskIndex", "Tasks", new { id = listId });
        }
    }
}
