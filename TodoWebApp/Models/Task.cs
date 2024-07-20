using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Security.Permissions;

namespace TodoWebApp.Models
{
    [Table("Tasks")]
    public class Task
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required!"),MaxLength(50)]
        [Display(Name = "Task")]
        public string TaskName { get; set; }

        [Required,DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss tt}",ApplyFormatInEditMode = true)]
        [Display(Name = "Created At")]
        public DateTime TimeOfCreation { get; set; }

        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }

        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Due Time")]
        public DateTime DueTime { get; set; } 

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required!"), MaxLength(6)]
        [Column(TypeName="VARCHAR")]
        public string Priority { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required!"), MaxLength(15)]
        [Column(TypeName = "VARCHAR")]
        public string Status { get; set; }

        [Display(Name = "Task Image")] 
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [ForeignKey("TodoList")] 
        public int ListId { get; set; }  
        public TodoList TodoList { get; set; } //Reference navigational property. A task can belong to only 1 list.
        public ICollection<TaskActivity> TaskActivities { get; set; } //Collection navigational property.

    }
}  