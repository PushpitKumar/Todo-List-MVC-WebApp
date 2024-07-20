using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoWebApp.Models;

namespace TodoWebApp.Controllers
{
    public class TaskActivitiesController : Controller
    {
        TodoDbContext context = new TodoDbContext();

        // GET: TaskActivities
        public ActionResult ActivityIndex(int id) //TaskId will be passed here.
        {
            if (Session["userId"] != null)
            {
                int taskId = id;
                ViewBag.TaskId = taskId;
                List<TaskActivity> activities = context.TaskActivities.Where(a => a.TaskId == taskId).ToList();

                int completeCount = 0; //for progress bar
                foreach(TaskActivity activity in activities)
                {
                    if (activity.isCompleted)
                        completeCount++;
                }
                ViewBag.Percent = Math.Round(100f * (completeCount / (float)activities.Count()));
                return View(activities);
            }
            else
            {
                ViewBag.ErroMessage = "User not logged in!";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult CreateActivity(int id)
        {
            TaskActivity activity = new TaskActivity();
            activity.TaskId = id;
            return View(activity);
        }

        [HttpPost]
        public ActionResult CreateActivity(TaskActivity activity)
        {
            activity.isCompleted = false;
            if (ModelState.IsValid)
            {
                context.TaskActivities.Add(activity);
                context.SaveChanges();
                return RedirectToAction("ActivityIndex", "TaskActivities", new { id = activity.TaskId });
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to create Activity!";
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditActivity(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TaskActivity activity = context.TaskActivities.Find(id);

            ViewBag.TaskId = activity.TaskId; //Needed for back button to work in EditActivity
            if (activity == null)
                return HttpNotFound();
            return View(activity);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditActivity(TaskActivity activity)
        {
            if (ModelState.IsValid)
            {
                context.Entry(activity).State = EntityState.Modified;
                context.SaveChanges();
                ViewBag.SuccessMessage = "Updated Activity Successfully!";
                return View(activity);
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to update Activity!";
                return View(activity);
            }
        }

        [HttpGet]
        public ActionResult DeleteActivity(int id)
        {
            TaskActivity activity = context.TaskActivities.Find(id);
            int taskId = activity.TaskId; //ActivityIndex expects TaskId as parameter
            context.TaskActivities.Remove(activity);
            context.SaveChanges();
            return RedirectToAction("ActivityIndex", "TaskActivities", new { id = taskId });
        }

    }
}
