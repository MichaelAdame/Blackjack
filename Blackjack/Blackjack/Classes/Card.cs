using Blackjack.Enums;
using System;

namespace Blackjack
{
    public class Card
    {
        public Rank Rank { get; }
        public Suit Suit { get; }
        public bool IsHidden { get; set; }

        public int Value => Rank switch
        {
            Rank.Ace => 11,
            Rank.King or Rank.Queen or Rank.Jack or Rank.Ten => 10,
            _ => (int)Rank + 1
        };

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public string Draw()
        {
            return IsHidden ? "???" : $"{Rank} of {Suit}";
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}
