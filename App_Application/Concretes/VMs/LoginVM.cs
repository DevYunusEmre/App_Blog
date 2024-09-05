using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace App_Application.Concretes.VMs
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email can't be null.")]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password can't be null.")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
