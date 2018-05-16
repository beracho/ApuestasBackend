using System.Collections.Generic;

namespace BaseBackend.API.Models
{
    public class Team
    {
        public int id {get;set;}
        public string Name { get; set; }
        public string Group { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}