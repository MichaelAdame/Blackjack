using Blackjack.Enums;
using System;
using System.Linq;

namespace Blackjack.Classes
{
    public class DealerHand
    {
        public Dealer Owner { get; }
        public int Value => CalculateValue();
        public bool IsBusted => Value > 21;

        public DealerHand(Dealer owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner), "Owner cannot be null");
        }

        private int CalculateValue()
        {
            int value = Owner.Hand.Cards.Sum(card => card.Value);
            int aces = Owner.Hand.Cards.Count(card => card.Rank == Rank.Ace);

            while (value > 21 && aces > 0)
            {
                value -= 10;
                aces--;
            }

            return value;
        }
    }
}
