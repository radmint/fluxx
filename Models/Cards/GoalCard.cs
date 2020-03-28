namespace Fluxx.Models.Cards
{
    public class GoalCard : Card
    {
        public GoalCard()
        {
            CardType = CardType.Goal;
        }

        public string[] WinningSet { get; set; }
    }
}
