using System.Collections.Generic;

namespace Fluxx.Models.Cards
{
    public class CardData
    {
        public List<GoalCard> GoalCards { get; set; }
        public List<RuleCard> RuleCards { get; set; }
        public List<KeeperCard> KeeperCards { get; set; }
    }
}
