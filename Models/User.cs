using System.ComponentModel.DataAnnotations;

namespace DeveloperTask.Models
{
    public class User
    {
        [Key] 
        [Required(ErrorMessage ="Please Enter User Id")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please Enter Email Id")]

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Correct Password")]
        public string Password { get; set; }
    }
}
