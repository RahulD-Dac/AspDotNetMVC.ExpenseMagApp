using System.ComponentModel.DataAnnotations;

namespace ExpenseMangementApp.Models
{
    public class UserProfile
    {
        [Key]
        public int UsertId { get; set; }

        [Required(ErrorMessage = "Please enter Firstname")]
        [MinLength(3, ErrorMessage = "The first Name  is to short ")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Lastname")]
        [MinLength(3, ErrorMessage = "The Last Name  is to short ")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Email Address")]
        [MinLength(3, ErrorMessage = "The Email Address  is to short ")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Please enter Password")]

        public string  Password { get; set; }

    }
}
