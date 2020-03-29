using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Fluxx.Hubs
{
    public interface IGameClient
    {
        Task StartGame(string userName);
        Task JoinGame(string gameId, string userName);
        Task RenderBoard(Game board);
    }

    public class GameHub : Hub<IGameClient>
    {
        private IGameRepository _repository;

        public GameHub(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task StartGame(string username)
        {
            var game = new Game
            {
                Id = Guid.NewGuid().ToString()
            };

            try
            {
                game.AddPlayer(Context.ConnectionId, username);

                _repository.Games.Add(game);

                await Groups.AddToGroupAsync(Context.ConnectionId, game.Id);
                await Clients.Group(game.Id.ToString()).RenderBoard(game);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task JoinGame(string gameId, string username)
        {
            var game = _repository.Games.FirstOrDefault(x => x.Id == gameId);
            if(game is null)
            {
                throw new Exception();
            }

            try
            {
                game.AddPlayer(Context.ConnectionId, username);

                await Groups.AddToGroupAsync(Context.ConnectionId, game.Id);
                await Clients.Group(game.Id.ToString()).RenderBoard(game);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task BeginGame(string gameId)
        {
            var game = _repository.Games.FirstOrDefault(x => x.Id == gameId);
            if (game is null)
            {
                throw new Exception();
            }

            game.DealCards();
            await Clients.Group(game.Id.ToString()).RenderBoard(game);
        }

        //public async Task ColumnClick(int column)
        //{
        //    var game = _repository.Games.FirstOrDefault(g => g.HasPlayer(Context.ConnectionId));
        //    if (game is null)
        //    {
        //        //Ignore click if no game exists
        //        return;
        //    }

        //    if (Context.ConnectionId != game.CurrentPlayer.ConnectionId)
        //    {
        //        //Ignore player clicking if it's not their turn
        //        return;
        //    }

        //    //ignore games that havent started
        //    if (!game.InProgress) return;

        //    var result = game.TryGetNextOpenRow(column);

        //    // find first open spot in the column
        //    if (!result.exists)
        //    {
        //        //ignore clicks on full columns
        //        return;
        //    }

        //    await Clients.Group(game.Id.ToString()).RenderBoard(game.Board);

        //    // Check victory (only current player can win)
        //    if (game.CheckVictory(result.row, column))
        //    {
        //        if (game.CurrentPlayer == game.Player1)
        //        {
        //            UpdateHighScore(game.Player1, game.Player2);
        //        }
        //        else
        //        {
        //            UpdateHighScore(game.Player2, game.Player1);
        //        }

        //        await Clients.Group(game.Id).Victory(game.CurrentPlayer.Color, game.Board);
        //        _repository.Games.Remove(game);
        //        return;
        //    }

        //    game.NextPlayer();

        //    await Clients.Group(game.Id).Turn(game.CurrentPlayer.Color);
        //}

        //public override async Task OnConnectedAsync()
        //{
        //var game = new Game
        //{
        //    Id = Guid.NewGuid().ToString()
        //};

        //game.Players.Add(new Player()
        //{
        //    ConnectionId = Context.ConnectionId
        //});

        //_repository.Games.Add(game);

        //await Groups.AddToGroupAsync(Context.ConnectionId, game.Id);
        //await base.OnConnectedAsync();

        //if (game.InProgress)
        //{
        //    CoinToss(game);
        //    await Clients.Group(game.Id.ToString()).RenderBoard(game.Board);
        //}
        //}

        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    //If game is complete delete it
        //    _repository.Games.RemoveAll(x => x != null);

        //    await base.OnDisconnectedAsync(exception);
        //}
    }
}
