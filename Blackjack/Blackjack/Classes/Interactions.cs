using System;
using Blackjack.Enums;

namespace Blackjack.Classes
{
    public class Interactions
    {
        public Player WelcomePlayer()
        {
            Console.Write("Welcome to the casino! What's your name? ");
            var name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty. Please enter a valid name:");
                name = Console.ReadLine();
            }

            decimal bankroll;
            while (true)
            {
                Console.Write($"Hello {name}, how much are you willing to play with today? ");
                if (decimal.TryParse(Console.ReadLine(), out bankroll) && bankroll > 0)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid positive amount.");
            }

            return new Player(name, bankroll);
        }

        public bool MorePlayers() => YesNo("Are there more players joining? ");

        public bool PlayAgain() => YesNo("Do you want to play another match? ");

        public PlayerAction GetPlayerAction(Player player)
        {
            Console.WriteLine($"{player.Name}, do you want to Hit or Stand?");
            string action = Console.ReadLine()?.ToLower();

            while (action != "hit" && action != "stand")
            {
                Console.WriteLine("Invalid choice. Please choose Hit or Stand:");
                action = Console.ReadLine()?.ToLower();
            }

            return action == "hit" ? PlayerAction.Hit : PlayerAction.Stand;
        }

        public void DisplayMatchResult(Match match)
        {
            switch (match.Result)
            {
                case MatchResult.Win:
                    Console.WriteLine($"{match.Player.Name} wins the match!");
                    break;
                case MatchResult.Loss:
                    Console.WriteLine($"{match.Player.Name} loses the match!");
                    break;
                case MatchResult.Push:
                    Console.WriteLine("It's a push! No one wins.");
                    break;
            }
        }

        private bool YesNo(string message)
        {
            while (true)
            {
                Console.Write(message + "(y/n): ");
                var response = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (response == 'y' || response == 'Y')
                {
                    return true;
                }
                else if (response == 'n' || response == 'N')
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no.");
                }
            }
        }
    }
}