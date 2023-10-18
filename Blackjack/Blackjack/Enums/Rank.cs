namespace Blackjack.Enums
{
    public enum Rank
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }

    public static class RankExtensions
    {
        public static int[] GetValue(this Rank rank) => rank switch
        {
            Rank.Ace => new[] { 1, 11 },
            Rank.Two => new[] { 2 },
            Rank.Three => new[] { 3 },
            Rank.Four => new[] { 4 },
            Rank.Five => new[] { 5 },
            Rank.Six => new[] { 6 },
            Rank.Seven => new[] { 7 },
            Rank.Eight => new[] { 8 },
            Rank.Nine => new[] { 9 },
            Rank.Ten => new[] { 10 },
            Rank.Jack => new[] { 10 },
            Rank.Queen => new[] { 10 },
            Rank.King => new[] { 10 },
            _ => throw new ArgumentOutOfRangeException(nameof(rank), rank, null)
        };
    }
}
