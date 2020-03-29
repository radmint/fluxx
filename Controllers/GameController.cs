using Fluxx.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fluxx.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;

        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }
    }
}
