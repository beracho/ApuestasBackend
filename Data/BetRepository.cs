using System;
using System.Threading.Tasks;
using BaseBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseBackend.API.Data
{
    public class BetRepository : IBetRepository
    {
        private readonly DataContext _context;
        public BetRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<Bet> NewBet(Bet bet, string username)
        {
            var UserToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            bet.UserId = UserToUpdate.Id;

            await _context.Bets.AddAsync(bet);
            await _context.SaveChangesAsync();
            return bet;
        }

        public async Task<Bet> CancelBet(Bet bet, string username)
        {
            var UserToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            var BetToDelete = await _context.Bets.FirstOrDefaultAsync(x => x.UserId == UserToUpdate.Id && x.TeamId == bet.TeamId);

            await _context.Bets.AddAsync(BetToDelete);
            _context.Bets.Update(BetToDelete);
            await _context.SaveChangesAsync();
            return BetToDelete;
        }
    }
}