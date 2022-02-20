using FootballManager.ViewModels;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        bool AddPlayer(AddPlayerViewModel model, string id);
        IEnumerable<PlayerViewModel> GetPlayers();
        IEnumerable<PlayerViewModel> GetUserPlayers(string id);
        void RemovePlayer(int id, string userId);
        void AddPlayerToCollection(int playerId, string id);
    }
}
