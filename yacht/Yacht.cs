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

    private static int GetOneToSixCategoryScore(int[] dice, int number)
        => dice.Where(val => val == number).Sum();

}

