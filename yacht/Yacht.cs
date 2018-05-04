using System;
using System.Linq;
using System.Collections.Generic;

public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12,
}

public static class YachtGame
{
    private static Dictionary<YachtCategory, Func<int[], int>> methods = new Dictionary<YachtCategory, Func<int[], int>>()
    {
        [YachtCategory.Yacht] = IsYacht,
        [YachtCategory.Ones] = IsOnes,
        [YachtCategory.Twos] = IsTwos,
        [YachtCategory.Threes] = IsThrees,
        [YachtCategory.Fours] = IsFours,
        [YachtCategory.Fives] = IsFives,
        [YachtCategory.Sixes] = IsSixes,
        [YachtCategory.FullHouse] = IsFullHouse,
        [YachtCategory.FourOfAKind] = IsFourOfAKind,
        [YachtCategory.LittleStraight] = IsLittleStraight,
        [YachtCategory.BigStraight] = IsBigStraight,
        [YachtCategory.Choice] = IsChoice,
    };

    public static int Score(int[] dice, YachtCategory category)
        => methods[category].Invoke(dice);

    private static int IsYacht(int[] dice)
        => dice.Distinct().Count() == 1 ? 50 : 0;

    private static int IsOnes(int[] dice)
        => GetOneToSixCategoryScore(dice, 1);

    private static int IsTwos(int[] dice)
        => GetOneToSixCategoryScore(dice, 2);

    private static int IsThrees(int[] dice)
        => GetOneToSixCategoryScore(dice, 3);

    private static int IsFours(int[] dice)
        => GetOneToSixCategoryScore(dice, 4);

    private static int IsFives(int[] dice)
        => GetOneToSixCategoryScore(dice, 5);

    private static int IsSixes(int[] dice)
        => GetOneToSixCategoryScore(dice, 6);

    private static int IsLittleStraight(int[] dice)
        => dice.OrderBy(x => x).SequenceEqual(new int[] { 1, 2, 3, 4, 5 }) ? 30 : 0;

    private static int IsBigStraight(int[] dice)
        => dice.OrderBy(x => x).SequenceEqual(new int[] { 2, 3, 4, 5, 6 }) ? 30 : 0;

    private static int IsChoice(int[] dice)
        => dice.Sum();

    private static int GetOneToSixCategoryScore(int[] dice, int number)
        => dice.Where(val => val == number).Sum();

    private static int IsFullHouse(int[] dice)
    {
        var groups = dice.GroupBy(x => x);
        var three = groups.Where(g => g.Count() == 3);
        var two = groups.Where(g => g.Count() == 2);
        var isFullHouse = three.Count() == 1 && two.Count() == 1;
        return isFullHouse ? dice.Sum() : 0;
    }

    private static int IsFourOfAKind(int[] dice)
    {
        var groups = dice.GroupBy(x => x);
        var four = groups.Where(g => g.Count() >= 4);
        return four.Count() == 1 ? four.Single().Take(4).Sum() : 0;
    }
}

