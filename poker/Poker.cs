using System;
using System.Linq;
using System.Collections.Generic;

public static class Poker
{
    public static readonly string SymbolOreder = "23456789TJQKA";
    public static readonly string SuitOreder = "DCHS";
    public static IEnumerable<string> BestHands(IEnumerable<string> hands)
    {
        if (hands.Count() == 1)
            return hands;

        var bestHands = hands
            .Select(hand => new Hand(hand))
            .BestHands();

        var bestSymbols = bestHands
            .BestSymbols();

        switch (bestHands.FirstOrDefault().Ranking)
        {
            case Ranking.HighCard:  // Only compare symbols
                var bestSymbolScore = bestSymbols.Max(hand => hand.SymbolScore);
                return bestSymbols
                    .Where(hand => hand.SymbolScore == bestSymbolScore)
                    .Select(hand => hand.ToString());

        }
        var bestSuits = bestSymbols
            .BestSuits();
        var result = bestSuits
            .Select(hand => hand.ToString());

        // return bestHands;
        return result;
    }
}

// public enum Suit : int
// {
//     Spade,
//     Hearts,
//     Diamond,
//     Club
// }

public enum Ranking : int
{
    StraightFlush = 0,
    FourOfAKind,
    FullHouse,
    Flush,
    Straight,
    ThreeOfAKind,
    TwoPair,
    OnePair,
    HighCard,
}

public class Hand : IComparable<Hand>
{
    private readonly string hand;

    public Ranking Ranking { get; private set; }
    public IEnumerable<Card> Cards { get; private set; }
    public char BestSymbol { get; private set; }
    public IEnumerable<char> Symbols { get; private set; }
    public int SymbolScore { get; private set; }
    public char BestSuit { get; private set; }
    public IEnumerable<char> Suits { get; private set; }

    public Hand(string hand)
    {
        this.hand = hand;

        Cards = hand
            .Split(' ')
            .Select(card => new Card(card));

        Ranking = new RankingValidator().GetHighestRanking(this);


        var sortSymbols = Cards
            .Select(card => card.Symbol)
            .Select(symbol => (idx: Poker.SymbolOreder.IndexOf(symbol), symbol: symbol))
            .OrderByDescending(data => data.idx);

        Symbols = sortSymbols.Select(data => data.symbol);
        SymbolScore = Cards.Sum(card => card.SymbolId());
        BestSymbol = sortSymbols
            .FirstOrDefault()
            .symbol;

        var sortSuits = Cards
            .Select(card => card.Suit)
            .Select(suit => (idx: Poker.SuitOreder.IndexOf(suit), suit: suit))
            .OrderByDescending(data => data.idx);

        Suits = sortSuits.Select(data => data.suit);
        BestSuit = sortSuits
            .FirstOrDefault()
            .suit;
    }

    public override string ToString() => hand;

    public int CompareTo(Hand other)
    {
        return this.Ranking.CompareTo(other.Ranking);
    }
}

public class Card
{
    private readonly string card;
    public char Suit { get; private set; }
    public char Symbol { get; private set; }
    public Card(string card)
    {
        Symbol = card.Length > 2 ? 'T' : card.FirstOrDefault();
        Suit = card.LastOrDefault();
        this.card = card;
    }

    public override string ToString() => card;
}

public class RankingValidator
{
    private Dictionary<Ranking, Func<Hand, bool>> validators;
    public RankingValidator()
    {
        validators = new Dictionary<Ranking, Func<Hand, bool>>()
        {
            [Ranking.StraightFlush] = IsStraightFlush,
            [Ranking.FourOfAKind] = IsFourOfAKind,
            [Ranking.FullHouse] = IsFullHouse,
            [Ranking.Flush] = IsFlush,
            [Ranking.Straight] = IsStraight,
            [Ranking.ThreeOfAKind] = IsThreeOfAKind,
            [Ranking.TwoPair] = IsTwoPair,
            [Ranking.OnePair] = IsOnePair,
            [Ranking.HighCard] = IsHighCard,
        };
    }

    public Ranking GetHighestRanking(Hand hand)
    {
        return validators.FirstOrDefault(kvp => kvp.Value.Invoke(hand)).Key;
    }

    public bool IsStraightFlush(Hand hand)
    {
        return IsFlush(hand) && IsStraight(hand);
    }

    public bool IsFourOfAKind(Hand hand)
    {
        return hand.Cards
            .GroupBy(card => card.Symbol)
            .Any(g => g.Count() == 4);
    }

    public bool IsFullHouse(Hand hand)
    {
        return hand.Cards
            .GroupBy(card => card.Symbol)
            .Select(g => g.Count())
            .OrderBy(x => x)
            .SequenceEqual(new int[] { 2, 3 });
    }

    public bool IsFlush(Hand hand)
    {
        return hand.Cards.All(card => card.Suit == hand.Cards.FirstOrDefault().Suit);
    }

    public bool IsStraight(Hand hand)
    {
        // T, J, Q, K, A
        if (hand.Cards.Select(card => card.Symbol).All(char.IsLetter))
            return true;

        var symbols = hand.Cards.Select(card => card.SymbolId()).OrderBy(x => x);
        var start = symbols.FirstOrDefault();
        var sequence = Enumerable.Range(start, 5);

        return symbols.SequenceEqual(sequence);
    }

    public bool IsThreeOfAKind(Hand hand)
    {
        return hand.Cards
            .GroupBy(card => card.Symbol)
            .Any(g => g.Count() == 3);
    }

    public bool IsTwoPair(Hand hand)
    {
        return hand.Cards
            .GroupBy(card => card.Symbol)
            .Select(g => g.Count())
            .OrderBy(x => x)
            .SequenceEqual(new int[] { 1, 2, 2 });
    }

    public bool IsOnePair(Hand hand)
    {
        return hand.Cards
            .GroupBy(card => card.Symbol)
            .Any(g => g.Count() == 2);
    }

    public bool IsHighCard(Hand hand) => true;
}

public static class Extensions
{
    public static IEnumerable<Hand> BestHands(this IEnumerable<Hand> hands)
    {
        var bestHands = hands
            .Select(hand => (ranking: hand.Ranking, card: hand.ToString()))
            .OrderBy(hand => hand.ranking);

        var best = bestHands.FirstOrDefault().ranking;

        return hands.Where(hand => hand.Ranking == best);
    }

    public static IEnumerable<Hand> BestSymbols(this IEnumerable<Hand> hands)
    {
        var bestSymbol = FindBestSymbol(hands);
        return hands.Where(hand => hand.BestSymbol == bestSymbol);
    }

    public static char FindBestSymbol(IEnumerable<Hand> hands)
    {
        return hands
            .Select(hand => hand.BestSymbol)
            .Select(symbol => (idx: Poker.SymbolOreder.IndexOf(symbol), symbol: symbol))
            .OrderByDescending(data => data.idx)
            .FirstOrDefault()
            .symbol;
    }

    public static IEnumerable<Hand> BestSuits(this IEnumerable<Hand> hands)
    {
        var bestSuit = FindBestSuit(hands);
        var bestSymbol = FindBestSymbol(hands);
        return hands.Where(hand => hand.BestSuit == bestSuit);
    }

    public static char FindBestSuit(IEnumerable<Hand> hands)
    {
        return hands
            .Select(hand => hand.BestSuit)
            .Select(suit => (idx: Poker.SuitOreder.IndexOf(suit), suit: suit))
            .OrderByDescending(data => data.idx)
            .FirstOrDefault()
            .suit;
    }

    public static int SymbolId(this Card card)
    {
        if (char.IsLetter(card.Symbol))
        {
            switch (card.Symbol)
            {
                case 'T': return 10;
                case 'J': return 11;
                case 'Q': return 12;
                case 'K': return 13;
                case 'A': return 1;
                default: return -1;
            }
        }
        else
        {
            return card.Symbol - '0';
        }
    }
}