using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class Shoe
    {
        private List<Card> Cards { get; set; }

        public Shoe(IEnumerable<Deck> decks)
        {
            Cards = decks.SelectMany(deck => deck.Cards).ToList();
            Shuffle();
        }

        public Card DrawCard()
        {
            var card = Cards.First();
            Cards.RemoveAt(0);
            return card;
        }

        public void Shuffle()
        {
            var rng = new Random();
            Cards = Cards.OrderBy(x => rng.Next()).ToList();
        }

        public bool IsEmpty => !Cards.Any();
    }
}
