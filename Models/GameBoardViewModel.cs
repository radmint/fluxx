using System.Collections.Generic;
using Fluxx.Models.Cards;

namespace Fluxx.Models
{
    public class GameBoardViewModel
    {
        public GameBoardViewModel(List<Card> drawPile)
        {
            DrawPile = drawPile;
            DiscardPile = new List<Card>();
            ActiveRules = new List<RuleCard>();
            ActiveGoals = new List<GoalCard>();
        }

        public List<Card> DrawPile { get; set; }
        public List<Card> DiscardPile { get; set; }
        public List<RuleCard> ActiveRules { get; set; }
        public List<GoalCard> ActiveGoals { get; set; }
    }
}
