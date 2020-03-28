using System;
using System.Collections.Generic;
using System.Linq;
using Fluxx.Loaders;
using Fluxx.Models.Cards;

namespace Fluxx
{
    public class Game
    {
        public Game()
        {
            InitializeBoard();
            Players = new List<Player>();
        }

        public string Id { get; set; }
        public bool InProgress { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Player> Players { get; private set; }
        private int MaxPlayers { get; } = 5;

        public List<Card> DrawPile { get; set; }
        public List<Card> DiscardPile { get; set; }
        public List<RuleCard> ActiveRules { get; set; }
        public List<GoalCard> ActiveGoals { get; set; }

        public void AddPlayer(string connectionId, string username)
        {
            if (Players.Count < MaxPlayers)
            {
                Player newPlayer = new Player()
                {
                    ConnectionId = connectionId,
                    Name = username,
                    Color = GeneratePlayerColor(),
                    Hand = new List<Card>(),
                    PlayedKeepers = new List<Card>()
                };

                Player prevPlayer = Players.LastOrDefault();
                if(prevPlayer != null) { 
                    prevPlayer._nextPlayer = newPlayer;
                }
                newPlayer._previousPlayer = prevPlayer ?? null;

                Players.Add(newPlayer);
            }
            else
            {
                throw new Exception("Game has reached max group size");
            }
        }

        public Player GetPlayer(string connectionId)
        {
            var player = Players.FirstOrDefault(x => x.ConnectionId == connectionId);
            if(player != null)
            {
                return player;
            }

            return null;
        }

        public void NextPlayer()
        {
            CurrentPlayer = CurrentPlayer._nextPlayer;
        }

        public void DealCards()
        {
            foreach(Player player in Players)
            {
                IEnumerable<Card> playerHand = DrawPile.Take(3);
                DrawPile.RemoveRange(0, 3);
                player.Hand = playerHand;
            }
        }

        private void InitializeBoard()
        {
            CardLoader cardLoader = new CardLoader();
            var _cardData = cardLoader.LoadCards();

            var shuffledCards = new List<Card>();
            shuffledCards.AddRange(_cardData.GoalCards);
            shuffledCards.AddRange(_cardData.KeeperCards);
            shuffledCards.AddRange(_cardData.RuleCards);

            DrawPile = shuffledCards;
            DiscardPile = new List<Card>();
            ActiveRules = new List<RuleCard>();
            ActiveGoals = new List<GoalCard>();
        }



        public bool CheckVictory(int row, int column)
        {
            //var playerColor = Board[row][column];

            //if (CheckHorizontally(row, column, playerColor))
            //{
            //    return true;
            //}

            //if (CheckVertically(row, column, playerColor))
            //{
            //    return true;
            //}

            //if (CheckDiagonally(row, column, playerColor))
            //{
            //    return true;
            //}

            return false;
        }

        private string GeneratePlayerColor()
        {
            var random = new Random();
            var color = string.Format("#{0:X6}", random.Next(0x1000000));
            return color;
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public string ConnectionId { get; set; }
        public string Color { get; set; }
        public IEnumerable<Card> Hand { get; set; }
        public IEnumerable<Card> PlayedKeepers { get; set; }
        public Player _nextPlayer { get; set; }
        public Player _previousPlayer { get; set; }
    }
}
