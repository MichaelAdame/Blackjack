using Blackjack.Enums;
using System;

namespace Blackjack.Classes
{
    public class Match
    {
        public Player Player { get; private set; }
        public Dealer Dealer { get; private set; }
        public Deck Deck { get; private set; }
        public GameState GameState { get; private set; }
        public GameResult GameResult { get; private set; }
        public MatchResult Result { get; set; }

        public Match(Player player, Dealer dealer)
        {
            Player = player ?? throw new ArgumentNullException(nameof(player));
            Dealer = dealer ?? throw new ArgumentNullException(nameof(dealer));
            Deck = new Deck();
            GameState = GameState.InProgress;
        }

        public void Start()
        {
            Console.WriteLine($"Starting a new match between {Player.Name} and the Dealer.");
            Deck.Shuffle();
            Dealer.DealInitialCards(Player, Deck);
        }

        public void EndGame(GameResult result)
        {
            GameResult = result;
            GameState = GameState.Ended;
        }

        public void SwitchTurn()
        {
            GameState = GameState.DealerTurn;
        }
    }
}