using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fluxx.Models;
using Fluxx.Models.Cards;
using Fluxx.Loaders;
using System.Collections.Generic;
using Fluxx.Hubs;

namespace Fluxx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CardData _cardData;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            CardLoader cardLoader = new CardLoader();
            _cardData = cardLoader.LoadCards();
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                CardData = _cardData
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GameBoard()
        {
            var shuffledCards = new List<Card>();
            shuffledCards.AddRange(_cardData.GoalCards);
            shuffledCards.AddRange(_cardData.KeeperCards);
            shuffledCards.AddRange(_cardData.RuleCards);

            var connectedIds = ChatHub.ConnectedIds;

            var viewModel = new GameBoardViewModel(shuffledCards);
            return View(viewModel);
        }
    }
}
