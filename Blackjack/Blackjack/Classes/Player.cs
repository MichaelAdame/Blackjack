using System;
using System.Globalization;

namespace Blackjack.Classes
{
    public class Player : Person
    {
        public decimal Chips { get; private set; }
        public decimal Bankroll { get; set; }
        public int WinCount { get; private set; }
        public int LossCount { get; private set; }
        public int PushCount { get; private set; }
        public int BlackjackCount { get; private set; }

        public Player(string name, decimal initialChips) : base(name)
        {
            Chips = initialChips >= 0 ? initialChips : throw new ArgumentOutOfRangeException(nameof(initialChips), "Initial chips cannot be negative");
            Bankroll = initialChips;
        }

        public void Win(decimal amount)
        {
            Chips += amount;
            WinCount++;
        }

        public void Lose(decimal amount)
        {
            Chips = Math.Max(0, Chips - amount); // Ensure chips do not go below zero
            LossCount++;
        }

        public void Push()
        {
            PushCount++;
        }

        public void Blackjack()
        {
            BlackjackCount++;
            WinCount++;
        }

        public override void HitOrStand(Deck deck)
        {
            Console.WriteLine($"{Name}, do you want to Hit or Stand? (h/s)");
            while (true)
            {
                string? choice = Console.ReadLine()?.ToLower();
                if (choice == "h")
                {
                    TakeCard(deck.DrawCard());
                    Console.WriteLine($"{Name} hits.");
                    break;
                }
                else if (choice == "s")
                {
                    Console.WriteLine($"{Name} stands.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 'h' to hit or 's' to stand.");
                }
            }
        }

        public void ResetStats() 
        {
            WinCount = 0;
            LossCount = 0;
            PushCount = 0;
            BlackjackCount = 0;
            ClearHand();  
        }

        public override string ToString()
        {
            return $"{Name}: {Chips.ToString("C", CultureInfo.CurrentCulture)}";
        }
    }
}
