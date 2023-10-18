using System;

namespace Blackjack.Enums
{
    public enum Suit
    {
        Spades, Hearts, Diamonds, Clubs
    }

    /// <summary>
    /// Provides extension methods for the Suit enum.
    /// </summary>
    public static class SuitExtensions
    {
        /// <summary>
        /// Gets the symbol associated with a suit.
        /// </summary>
        /// <param name="suit">The suit.</param>
        /// <returns>The symbol of the suit.</returns>
        public static char GetSymbol(this Suit suit) => suit switch
        {
            Suit.Spades => '♠',
            Suit.Hearts => '♥',
            Suit.Diamonds => '♦',
            Suit.Clubs => '♣',
            _ => throw new ArgumentOutOfRangeException(nameof(suit), suit, null)
        };

        /// <summary>
        /// Gets the color associated with a suit.
        /// </summary>
        /// <param name="suit">The suit.</param>
        /// <returns>The console color of the suit.</returns>
        public static ConsoleColor GetColor(this Suit suit) => suit switch
        {
            Suit.Spades => ConsoleColor.Black,
            Suit.Clubs => ConsoleColor.Black,
            _ => ConsoleColor.Red
        };
    }
}
