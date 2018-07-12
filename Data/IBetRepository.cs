using System.Threading.Tasks;
using BaseBackend.API.Models;

namespace BaseBackend.API.Data
{
    public interface IBetRepository
    {
        Task<Bet> NewBet(Bet bet, string username);
        Task<Bet> CancelBet(Bet bet, string username);
    }
}