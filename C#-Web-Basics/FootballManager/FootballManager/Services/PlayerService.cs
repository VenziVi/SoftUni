using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IValidationService validationService;
        private readonly IRepository repo;

        public PlayerService(IValidationService _validationService,
            IRepository _repo)
        {
            validationService = _validationService;
            repo = _repo;
        }

        public bool AddPlayer(AddPlayerViewModel model, string id)
        {
            bool isCreated = false;

            (bool isVald, string error) = validationService.ValidateModel(model);

            if (!isVald)
            {
                return isCreated;
            }

            User owner = repo.All<User>().Where(u => u.Id == id).FirstOrDefault();

            if (owner == null)
            {
                return isCreated;
            }

            Player player = new Player()
            {
                FullName = model.FullName,
                Position = model.Position,
                ImageUrl = model.ImageUrl,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description
            };

            UserPlayer up = new UserPlayer()
            {
                User = owner,
                Player = player,
            };

            try
            {
                repo.Add(player);
                repo.Add(up);
                repo.SaveChanges();
                isCreated = true;
            }
            catch (Exception)
            {
            }

            return isCreated;
        }

        public void AddPlayerToCollection(int playerId, string id)
        {
            Player player = repo.All<Player>()
                .FirstOrDefault(p => p.Id == playerId);

            User user = repo.All<User>()
                .FirstOrDefault(u => u.Id == id);

            UserPlayer up = new UserPlayer()
            {
                Player = player,
                PlayerId = playerId,
                User = user,
                UserId = user.Id
            };

            try
            {
                repo.Add(up);
                repo.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public IEnumerable<PlayerViewModel> GetPlayers()
        {
            return repo.All<Player>()
                .Select(p => new PlayerViewModel()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    Position = p.Position,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                }).ToList();
        }

        public IEnumerable<PlayerViewModel> GetUserPlayers(string id)
        {
            User user = repo.All<User>().Where(u => u.Id == id).FirstOrDefault();

            return repo.All<UserPlayer>()
                .Where(u => u.UserId == user.Id)
                .Include(p => p.Player)
                .Select(u => new PlayerViewModel()
                {
                    Id = u.PlayerId,
                    FullName = u.Player.FullName,
                    Position = u.Player.Position,
                    Description = u.Player.Description,
                    ImageUrl = u.Player.ImageUrl,
                    Speed = u.Player.Speed,
                    Endurance = u.Player.Endurance,
                }).ToList();
        }

        public void RemovePlayer(int id, string userId)
        {
            var pl = repo
                .All<Player>()
                .FirstOrDefault(x => x.Id == id);

            var up = repo.All<UserPlayer>()
                .FirstOrDefault(u => u.PlayerId == id && u.UserId == userId);

            try
            {
                repo.Delete(up);
                repo.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
    }
}
