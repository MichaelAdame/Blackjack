using System;
using System.Collections.Generic;
using Blackjack.Enums;

namespace Blackjack.Classes
{
    public class GameArea
    {
        public List<Player> Players { get; private set; } = new List<Player>();
        public Dealer Dealer { get; private set; }
        private Interactions Interactions { get; set; }

        public GameArea()
        {
            Dealer = new Dealer();
            Interactions = new Interactions();
            WelcomePlayers();
            GameLoop();
        }

        public void WelcomePlayers()
        {
            do
            {
                var player = Interactions.WelcomePlayer();
                Players.Add(player);
            } while (Interactions.MorePlayers());
        }

        public void GameLoop()
        {
            do
            {
                foreach (var player in Players)
                {
                    var match = new Match(player, Dealer);
                    match.Start();

                    while (match.GameState == GameState.InProgress)
                    {
                        var action = Interactions.GetPlayerAction(player);
                        PerformAction(match, action, player);

                        if (match.GameState == GameState.InProgress)
                        {
                            PerformDealerAction(match);
                        }
                    }

                    Interactions.DisplayMatchResult(match);
                    player.ClearHand();
                    Dealer.ClearHand();
                }
            } while (Interactions.PlayAgain());
        }

        private void PerformAction(Match match, PlayerAction action, Player player)
        {
            if (action == PlayerAction.Hit)
            {
                player.TakeCard(match.Deck.DrawCard());
                if (player.HandValue > 21)
                {
                    match.EndGame(GameResult.Loss);
                }
            }
            else if (action == PlayerAction.Stand)
            {
                match.SwitchTurn();
            }
        }

        private void PerformDealerAction(Match match)
        {
            Dealer.HitOrStand(match.Deck);
            if (Dealer.HandValue > 21 || Dealer.HandValue < match.Player.HandValue)
            {
                match.EndGame(GameResult.Win);
            }
            else if (Dealer.HandValue > match.Player.HandValue)
            {
                match.EndGame(GameResult.Loss);
            }
            else
            {
                match.EndGame(GameResult.Push);
            }
        }
    }
}
