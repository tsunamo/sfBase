using System.ComponentModel.DataAnnotations;

namespace sfBase.Server.ViewModels
{
    public class UserNameViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
