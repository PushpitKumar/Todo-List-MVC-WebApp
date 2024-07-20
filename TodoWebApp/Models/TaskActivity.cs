using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Data.SqlTypes;
using Microsoft.Ajax.Utilities;

namespace TodoWebApp.Models
{
    [Table("Activities")]
    public class TaskActivity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Activity ID")]
        public int ActivityId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required!"),MaxLength(100)]
        [Display(Name = "Activity")]
        public string ActivityName { get; set; }

        [Required(ErrorMessage = "This Field is Required!")]
        [Display(Name = "Done?")]
        public bool isCompleted { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public Task Task { get; set; } //Reference navigational property. 1 activity can belong to a single task.

    }
} 