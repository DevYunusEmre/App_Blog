using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App_Application.Concretes.VMs
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Email can't be null.")]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password can't be null.")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Email can't be null.")]
        [EmailAddress]
        [DisplayName("Confirm Email")]
        public string ConfirmedEmail { get; set; }

        public bool RememberMe { get; set; } = false;

    }
}
