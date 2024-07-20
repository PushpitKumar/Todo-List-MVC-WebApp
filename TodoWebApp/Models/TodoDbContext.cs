using TodoWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace TodoWebApp.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext() : base("dbcon") { }
        public DbSet<User> Users { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskActivity> TaskActivities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
 
        }
    }
}