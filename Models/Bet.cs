namespace BaseBackend.API.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int UserId { get; set; }
        public Team Team { get; set; }
        public User User { get; set; }
    }
}