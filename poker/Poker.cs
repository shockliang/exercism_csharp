﻿using System;
using System.Linq;
using System.Collections.Generic;

public static class Poker
{
    public static IEnumerable<string> BestHands(IEnumerable<string> hands)
    {
        if (hands.Count() == 1)
            return hands;

        var bestHands = hands
            .Select(hand => new Hand(hand))
            .BestHands()
            .HighestSymbols()
            .Select(hand => hand.ToString());

        return bestHands;
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
    public char HighestSymbol { get; private set; }

    public Hand(string hand)
    {
        this.hand = hand;

        Cards = hand
            .Split(' ')
            .Select(card => new Card(card));

        Ranking = new RankingValidator().GetHighestRanking(this);
        HighestSymbol = Cards
            .Select(card => card.Symbol)
            .Select(symbol => (idx: "23456789TJQKA".IndexOf(symbol), symbol: symbol))
            .OrderByDescending(data => data.idx)
            .FirstOrDefault()
            .symbol;
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

    public static IEnumerable<Hand> HighestSymbols(this IEnumerable<Hand> hands)
    {
        var highestSymbol = hands
            .Select(hand => hand.HighestSymbol)
            .Select(symbol => (idx: "23456789TJQKA".IndexOf(symbol), symbol: symbol))
            .OrderByDescending(data => data.idx)
            .FirstOrDefault()
            .symbol;
        return hands.Where(hand => hand.HighestSymbol == highestSymbol);
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