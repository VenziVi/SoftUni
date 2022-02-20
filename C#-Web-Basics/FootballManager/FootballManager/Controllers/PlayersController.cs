using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        public PlayersController(Request request,
            IPlayerService _playerService) 
            : base(request)
        {
            playerService = _playerService;
        }

        [Authorize]
        public Response All()
        {
            IEnumerable<PlayerViewModel> players = playerService.GetPlayers();

            return View(new 
            { 
                IsAuthenticated = true,
                Players = players
            });
        }

        [Authorize]
        public Response Add() => View(new { IsAuthenticated = true });

        [HttpPost]
        public Response Add(AddPlayerViewModel model)
        {
            bool isCreated = playerService.AddPlayer(model, User.Id);

            if (!isCreated)
            {
                return View(new { IsAuthenticated = true });
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response Collection()
        {
            IEnumerable<PlayerViewModel> players = playerService.GetUserPlayers(User.Id);

            return View(new
            {
                IsAuthenticated = true,
                Players = players
            });

        }

        [Authorize]
        public Response RemoveFromCollection(int playerId)
        {
            playerService.RemovePlayer(playerId, User.Id);

            return Redirect("/Players/Collection");
        }

        [Authorize]
        public Response AddToCollection(int playerId)
        {
            playerService.AddPlayerToCollection(playerId, User.Id);

            return Redirect("/Players/All");
        }
    }
}
