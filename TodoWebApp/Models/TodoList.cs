using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.ComponentModel;

namespace TodoWebApp.Models
{
    [Table("TodoLists")]
    public class TodoList
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "List ID")] 
        public int ListId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required!"),MaxLength(50)]
        [Display(Name = "List")]
        public string ListName { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; } 
        public User User { get; set; } //reference navigational property. A list can belong to only 1 user. 
        public ICollection<Task> Tasks { get; set; } //Collection navigational property.
    } 
}