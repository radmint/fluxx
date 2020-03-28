namespace Fluxx.Models.Cards
{
    public class Card
    {
        public Card()
        {
        }

        public string CardTitle { get; set; }
        public string CardText { get; set; }
        public string CardImage { get; set; }
        public virtual CardType CardType { get; set; }
        public CardState CardState { get; set; }
    }
}
