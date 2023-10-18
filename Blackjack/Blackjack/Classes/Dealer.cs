using Blackjack.Enums;
using System;
using System.Linq;
using System.Threading;

namespace Blackjack.Classes
{
    public class Dealer : Person
    {
        public Card? HiddenCard { get; private set; }

        public Dealer() : base("Dealer") { }

        public override void HitOrStand(Deck deck)
        {
            Console.WriteLine("Dealer reveals hidden card.");
            RevealHiddenCard();

            while (HandValue < 17 || (HandValue == 17 && Hand.Cards.Any(card => card.Rank == Rank.Ace)))
            {
                Console.WriteLine("Dealer hits.");
                var card = deck.DrawCard();
                if (card != null)
                {
                    TakeCard(card);
                }
                else
                {
                    Console.WriteLine("The deck is empty.");
                    break;
                }
                Thread.Sleep(500);
            }

            Console.WriteLine("Dealer stands.");
        }

        public void DealInitialCards(Player player, Deck deck)
        {
            player.TakeCard(deck.DrawCard());
            TakeHiddenCard(deck.DrawCard());
            player.TakeCard(deck.DrawCard());
            TakeCard(deck.DrawCard());
        }

        public void RevealHiddenCard()
        {
            if (HiddenCard != null)
            {
                TakeCard(HiddenCard); 
                Console.WriteLine($"Dealer's hidden card is {HiddenCard}");
                HiddenCard = null;
            }
        }

        private void TakeHiddenCard(Card card)
        {
            HiddenCard = card;
        }

        public new void ClearHand()
        {
            Hand.Cards.Clear();
            HiddenCard = null;
        }
    }
}
