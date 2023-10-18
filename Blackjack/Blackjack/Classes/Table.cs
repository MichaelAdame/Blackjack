using System;
using System.Collections.Generic;

namespace Blackjack.Classes
{
    public class Table
    {
        public Dealer Dealer { get; }
        public List<Player> Players { get; } = new List<Player>();
        public int MaxPlayers { get; }

        public Table(Dealer dealer, int maxPlayers)
        {
            Dealer = dealer ?? throw new ArgumentNullException(nameof(dealer));
            MaxPlayers = maxPlayers > 0 ? maxPlayers : throw new ArgumentException("Max players must be greater than zero.");
        }

        public void AddPlayer(Player player)
        {
            if (Players.Count >= MaxPlayers) throw new InvalidOperationException("The table is full.");

            Players.Add(player ?? throw new ArgumentNullException(nameof(player)));
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player ?? throw new ArgumentNullException(nameof(player)));
        }
    }
}
