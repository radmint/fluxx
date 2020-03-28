using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Fluxx.Models.Cards;

namespace Fluxx.Loaders
{
    public class CardLoader
    {
        private JsonSerializerOptions options = new JsonSerializerOptions();

        public CardData LoadCards()
        {
            options.Converters.Add(new JsonStringEnumConverter());

            //var cardFiles = new[]
            //{
            //    new { filePath = "CardData/GoalCards.json", type = typeof(GoalCard) },
            //    new { filePath = "CardData/RuleCards.json", type = typeof(RuleCard) },
            //    new { filePath = "CardData/KeeperCards.json", type = typeof(KeeperCard) }
            //};

            try
            {
                var goalCardsJson = File.ReadAllText("CardData/GoalCards.json");
                var goalCards = JsonSerializer.Deserialize<List<GoalCard>>(goalCardsJson, options);

                var ruleCardsJson = File.ReadAllText("CardData/RuleCards.json");
                var ruleCards = JsonSerializer.Deserialize<List<RuleCard>>(ruleCardsJson, options);

                var keeperCardsJson = File.ReadAllText("CardData/KeeperCards.json");
                var keeperCards = JsonSerializer.Deserialize<List<KeeperCard>>(keeperCardsJson, options);

                var cards = new CardData()
                {
                    GoalCards = goalCards,
                    RuleCards = ruleCards,
                    KeeperCards = keeperCards
                };

                return cards;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<List<ICard>> DeserializeCardsAsync(string cardFile)
        //{
        //    var cardsJson = await File.ReadAllTextAsync(cardFile);
        //    var cards = JsonSerializer.Deserialize<List<ICard>>(cardsJson, options);
        //    return cards;
        //}
    }
}
