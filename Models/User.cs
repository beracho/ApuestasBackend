using System.Collections.Generic;

namespace BaseBackend.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public string AboutMe { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}