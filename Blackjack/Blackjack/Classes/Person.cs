using System;

namespace Blackjack.Classes
{
    public abstract class Person
    {
        public string Name { get; private set; }
        public Hand Hand { get; private set; } = new Hand();


        public Person(string name)
        {
            Name = name;
        }

        public int HandValue => Hand.Value;

        public void TakeCard(Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card), "Card cannot be null");
            }

            Hand.AddCard(card);
            Console.WriteLine($"{Name} takes a {card.Rank} of {card.Suit}. Current hand value: {HandValue}");
        }

        public abstract void HitOrStand(Deck deck);

        public void ClearHand()
        {
            Hand.Cards.Clear();
            Hand.RecalculateValue();
        }
    }
}
