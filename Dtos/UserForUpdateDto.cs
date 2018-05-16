using System.ComponentModel.DataAnnotations;

namespace BaseBackend.API.Dtos
{
    public class UserForUpdateDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Company { get; set; }
        public string Telephone { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string AboutMe { get; set; }
    }
}