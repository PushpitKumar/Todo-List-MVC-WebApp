using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Microsoft.Ajax.Utilities;
using System.ComponentModel;

namespace TodoWebApp.Models
{
    [Table("Users")]
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required!"), MaxLength(20)]
        [Display(Name = "User Name"),Index(IsUnique = true)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This Field is Required!"),Display(Name = "Admin")]
        public bool IsAdmin { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required!"), MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(50),Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [MaxLength(50),Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required!"), MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please Enter Valid Email Address!")]
        [EmailAddress,Display(Name = "Email ID")]
        public string EmailAddress { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required!"), MaxLength(25)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must be of minimum 8 characters and have a number, uppercase and special character!")]
        public string Password { get; set; } //Password

        [Required(AllowEmptyStrings = false, ErrorMessage = "This Field is Required!"), MaxLength(25)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "\"Password must be of minimum 8 characters and have a number, uppercase and special character!")]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage = "Passwords Do Not Match!")]
        public string ConfirmPassword { get; set; }  

        [DataType(DataType.PhoneNumber), MaxLength(15)]
        [Phone, Display(Name = "Phone Number")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please Enter Valid Phone Number!.")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(7), Column(TypeName = "VARCHAR")]
        public string Gender { get; set; }

        [MaxLength(20), Column(TypeName = "VARCHAR")]
        public string Country { get; set; }

        [Required, DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss tt}",ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss tt}",ApplyFormatInEditMode = true)]
        [Display(Name = "Last Active")]
        public DateTime? LastActive { get; set; }

        [MaxLength(300)]
        [Display(Name = "Profile Bio")]
        public string ProfileBio { get; set; }
        public ICollection<TodoList> TodoLists { get; set; } //Collection navigational property. 1 user can have multiple lists.
    }
}