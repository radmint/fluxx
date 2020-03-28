using System.Collections.Generic;

namespace Fluxx
{
    public interface IGameRepository
    {
        List<Game> Games { get; }
    }

    public class GameRepository : IGameRepository
    {
        public GameRepository()
        {
        }

        public List<Game> Games { get; } = new List<Game>();

    }
}
