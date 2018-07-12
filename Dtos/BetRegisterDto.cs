using System.ComponentModel.DataAnnotations;

namespace BaseBackend.API.Dtos
{
    public class BetRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public int TeamId { get; set; }
        
    }
}