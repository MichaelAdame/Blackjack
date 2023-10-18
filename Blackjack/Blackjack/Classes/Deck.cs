using Blackjack.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new List<Card>();
            InitializeDeck();
            Shuffle();
        }

        private void InitializeDeck()
        {
            Cards = Enum.GetValues(typeof(Rank))
                        .Cast<Rank>()
                        .SelectMany(rank => Enum.GetValues(typeof(Suit))
                        .Cast<Suit>()
                        .Select(suit => new Card(rank, suit)))
                        .ToList();
        }

        public void Shuffle()
        {
            var rng = new Random();
            Cards = Cards.OrderBy(x => rng.Next()).ToList();
        }

        public Card DrawCard()
        {
            if (Cards.Count == 0) 
            {
                Console.WriteLine("The deck is empty. Reshuffling...");
                InitializeDeck();
                Shuffle();
            }

            var card = Cards.First();
            Cards.RemoveAt(0);
            return card;
        }
    }
}
