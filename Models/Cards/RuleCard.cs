namespace Fluxx.Models.Cards
{
    public class RuleCard : Card
    {
        public RuleCard()
        {
            CardType = CardType.Rule;
        }

        public string CardSubtitle { get; set; }
        public int RuleAlteration { get; set; }
        public RuleType RuleType { get; set; }
    }
}
