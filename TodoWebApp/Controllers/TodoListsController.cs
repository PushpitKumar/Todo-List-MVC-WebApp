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
    public class TodoListsController : Controller
    {
        TodoDbContext context = new TodoDbContext();

        public ActionResult TodoListIndex()
        {
            if (Session["userId"] != null)
            {
                int userId = (int)Session["userId"];
                List<TodoList> todoLists = context.TodoLists.Where(t =>  t.UserId == userId).ToList();
                return View(todoLists);
            }
            else
            {
                ViewBag.ErrorMessage = "User not logged in!";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult CreateTodoList() 
        {
            int userId = (int)Session["userId"];
            TodoList todoList = new TodoList();
            todoList.UserId = userId;
            return View(todoList);
        }

        [HttpPost]
        public ActionResult CreateTodoList(TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                context.TodoLists.Add(todoList); 
                context.SaveChanges();
                return RedirectToAction("TodoListIndex");
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to create Todo-List";
                return View();
            }       
        }

        [HttpGet]
        public ActionResult EditList(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            TodoList todoList = context.TodoLists.Find(id);
            if (todoList == null)
                return HttpNotFound();
            return View(todoList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditList(TodoList todoList)
        {
            if (ModelState.IsValid)
            {
                context.Entry(todoList).State = EntityState.Modified;
                context.SaveChanges();
                ViewBag.SuccessMessage = "Updated List Successfully!";
                return View(todoList);
            }
            else
            {
                ViewBag.ErrorMessage = "Unable to update List!"
;               return View(todoList);
            }
        }

        public ActionResult DeleteList(int id)
        {
            TodoList todoList = context.TodoLists.Find(id);
            context.TodoLists.Remove(todoList);
            context.SaveChanges();
            return RedirectToAction("TodoListIndex", "TodoLists");
        }

    }
}
