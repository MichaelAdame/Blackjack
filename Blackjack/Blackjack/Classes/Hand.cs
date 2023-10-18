using System.Collections.Generic;
using Blackjack.Enums;
using System.Linq;
using System;

namespace Blackjack.Classes
{
    public class Hand
    {
        private List<Card> cards = new List<Card>();

        public List<Card> Cards => cards;

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int Count => cards.Count;

        public int Value
        {
            get
            {
                int value = cards.Sum(card => card.Value);
                int numberOfAces = cards.Count(card => card.Rank == Rank.Ace);

                while (value > 21 && numberOfAces > 0)
                {
                    value -= 10;
                    numberOfAces--;
                }

                return value;
            }
        }

        public void RecalculateValue()
        {

            Console.WriteLine($"Current hand value: {Value}");
        }

        public override string ToString()
        {
            return string.Join(", ", cards.Select(card => card.ToString()));
        }
    }
}
