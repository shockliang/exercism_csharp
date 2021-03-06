﻿using System;
using Xunit;

public class PalindromeTest
{
    [Theory()]
    [InlineData(1)]
    [InlineData(9)]
    [InlineData(11)]
    [InlineData(99)]
    [InlineData(101)]
    [InlineData(111)]
    [InlineData(121)]
    [InlineData(989)]
    [InlineData(1771)]
    public void There_numbers_should_be_palindrome_number(int num)
    {
        Assert.True(Palindrome.IsPalindromicNumber(num));
    }

    [Theory()]
    [InlineData(12)]
    [InlineData(998)]
    [InlineData(1234)]
    public void There_numbers_should_not_be_palindrome_number(int num)
    {
        Assert.False(Palindrome.IsPalindromicNumber(num));
    }

    [Fact]
    public void Largest_palindrome_from_single_digit_factors()
    {
        var actual = Palindrome.Largest(9);
        Assert.Equal(9, actual.Value);
        Assert.Equal(new[] { Tuple.Create(1, 9), Tuple.Create(3, 3) }, actual.Factors);
    }

    [Fact]
    public void Smallest_palindrome_from_single_digit_factors()
    {
        var actual = Palindrome.Smallest(9);
        Assert.Equal(1, actual.Value);
        Assert.Equal(new[] { Tuple.Create(1, 1) }, actual.Factors);
    }

    [Fact]
    public void Largest_palindrome_from_double_digit_actors()
    {
        var actual = Palindrome.Largest(10, 99);
        Assert.Equal(9009, actual.Value);
        Assert.Equal(new[] { Tuple.Create(91, 99) }, actual.Factors);
    }

    [Fact]
    public void Smallest_palindrome_from_double_digit_factors()
    {
        var actual = Palindrome.Smallest(10, 99);
        Assert.Equal(121, actual.Value);
        Assert.Equal(new[] { Tuple.Create(11, 11) }, actual.Factors);
    }

    [Fact]
    public void Largest_palindrome_from_triple_digit_factors()
    {
        var actual = Palindrome.Largest(100, 999);
        Assert.Equal(906609, actual.Value);
        Assert.Equal(new[] { Tuple.Create(913, 993) }, actual.Factors);
    }

    [Fact]
    public void Smallest_palindrome_from_triple_digit_factors()
    {
        var actual = Palindrome.Smallest(100, 999);
        Assert.Equal(10201, actual.Value);
        Assert.Equal(new[] { Tuple.Create(101, 101) }, actual.Factors);
    }

    [Fact]
    public void Largest_palindrome_from_four_digit_factors()
    {
        var actual = Palindrome.Largest(1000, 9999);
        Assert.Equal(99000099, actual.Value);
        Assert.Equal(new[] { Tuple.Create(9901, 9999) }, actual.Factors);
    }

    [Fact]
    public void Smallest_palindrome_from_four_digit_factors()
    {
        var actual = Palindrome.Smallest(1000, 9999);
        Assert.Equal(1002001, actual.Value);
        Assert.Equal(new[] { Tuple.Create(1001, 1001) }, actual.Factors);
    }
}