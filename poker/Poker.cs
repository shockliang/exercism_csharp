using System;
using System.Linq;
using System.Collections.Generic;

public static class Poker
{
    public static IEnumerable<string> BestHands(IEnumerable<string> hands)
    {
        if (hands.Count() == 1)
            return hands;

        var pokerHands = hands.Select(hand => new Hand(hand));

        return new string[] { };
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

public class Hand
{
    public Ranking Ranking { get; private set; }
    public IEnumerable<Card> Cards { get; private set; }
    public Hand(string hand)
    {
        Cards = hand
            .Split(' ')
            .Select(card => new Card(card));
    }
}

public class Card
{
    public char Suit { get; private set; }
    public char Symbol { get; private set; }
    public Card(string card)
    {
        Symbol = card.FirstOrDefault();
        Suit = card.LastOrDefault();
    }
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

    public bool IsStraightFlush(Hand hand)
    {
        return IsFlush(hand) && IsStraight(hand);
    }

    public bool IsFourOfAKind(Hand hand)
    {
        return true;
    }

    public bool IsFullHouse(Hand hand)
    {
        return true;
    }

    public bool IsFlush(Hand hand)
    {
        return hand.Cards.All(card => card.Suit == hand.Cards.FirstOrDefault().Suit);
    }

    public bool IsStraight(Hand hand)
    {
        var symbols = hand.Cards.Select(card => card.SymbolId()).OrderBy(x => x);
        var start = symbols.FirstOrDefault();
        var sequence = Enumerable.Range(start, 5);

        return symbols.SequenceEqual(sequence);
    }

    public bool IsThreeOfAKind(Hand hand)
    {
        return true;
    }

    public bool IsTwoPair(Hand hand)
    {
        return true;
    }

    public bool IsOnePair(Hand hand)
    {
        return true;
    }

    public bool IsHighCard(Hand hand) => true;


}

public static class Extensions
{
    public static int SymbolId(this Card card)
    {
        if (char.IsLetter(card.Symbol))
        {
            switch (card.Symbol)
            {
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