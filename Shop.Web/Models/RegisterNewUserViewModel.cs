namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterNewUserViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }
    }

}
