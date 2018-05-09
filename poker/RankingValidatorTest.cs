using Xunit;
public class RankingValidatorTest
{
    [Theory]
    [InlineData("3S 4D 2S 6D 5C")]
    public void IsStraight_should_be_true(string pokerHand)
    {
        // Arrange 
        var hand = new Hand(pokerHand);
        var validator = new RankingValidator();

        // Act & Assert
        Assert.True(validator.IsStraight(hand));
    }

    [Theory]
    [InlineData("2S 4S 5S 6S 7S")]
    public void IsFlush_should_be_true(string pokerHand)
    {
        // Arrange 
        var hand = new Hand(pokerHand);
        var validator = new RankingValidator();

        // Act & Assert
        Assert.True(validator.IsFlush(hand));
    }

    [Theory]
    [InlineData("4H 6H 7H 8H 5H")]
    [InlineData("7S 8S 9S 6S 10S")]
    public void IsStraightFlush_should_be_true(string pokerHand)
    {
        // Arrange 
        var hand = new Hand(pokerHand);
        var validator = new RankingValidator();

        // Act & Assert
        Assert.True(validator.IsStraightFlush(hand));
    }

    [Theory]
    [InlineData("2S 2H 2C 8D 2D")]
    [InlineData("4S 5H 5S 5D 5C")]
    public void IsFourOfAKind_should_be_true(string pokerHand)
    {
        // Arrange 
        var hand = new Hand(pokerHand);
        var validator = new RankingValidator();

        // Act & Assert
        Assert.True(validator.IsFourOfAKind(hand));
    }

    [Theory]
    [InlineData("4S 5H 4D 5D 4H")]
    [InlineData("5H 5S 5D 9S 9D")]
    public void IsFullHouse_should_be_true(string pokerHand)
    {
        // Arrange 
        var hand = new Hand(pokerHand);
        var validator = new RankingValidator();

        // Act & Assert
        Assert.True(validator.IsFullHouse(hand));
    }

    [Theory]
    [InlineData("4S 5H 4C 8S 4H")]
    [InlineData("2S 2H 2C 8D JH")]
    public void IsThreeOfAKind_should_be_true(string pokerHand)
    {
        // Arrange 
        var hand = new Hand(pokerHand);
        var validator = new RankingValidator();

        // Act & Assert
        Assert.True(validator.IsThreeOfAKind(hand));
    }

    [Theory]
    [InlineData("4S 5H 4C 8C 5C")]
    [InlineData("2S QS 2C QD JH")]
    [InlineData("JD QH JS 8D QC")]
    public void IsTwoPair_should_be_true(string pokerHand)
    {
        // Arrange 
        var hand = new Hand(pokerHand);
        var validator = new RankingValidator();

        // Act & Assert
        Assert.True(validator.IsTwoPair(hand));
    }

    [Theory]
    [InlineData("2S 4H 6S 4D JH")]
    [InlineData("2S 8H 6S 8D JH")]
    public void IsOnePair_should_be_true(string pokerHand)
    {
        // Arrange 
        var hand = new Hand(pokerHand);
        var validator = new RankingValidator();

        // Act & Assert
        Assert.True(validator.IsOnePair(hand));
    }

    [Fact]
    public void FullHouse_should_be_highest_ranking_than_three_of_a_kind()
    {
        // Arrange
        var hand = new Hand("4S 5H 4C 5D 4H");
        var rankingValidator = new RankingValidator();

        // Act
        var actual = rankingValidator.GetHighestRanking(hand);
        
        // Assert
        Assert.Equal(Ranking.FullHouse, actual);
    }

    [Fact]
    public void StraightFlush_should_be_highest_ranking_than_straight()
    {
        // Arrange
        var hand = new Hand("7S 8S 9S 6S 10S");
        var rankingValidator = new RankingValidator();

        // Act
        var actual = rankingValidator.GetHighestRanking(hand);
        
        // Assert
        Assert.Equal(Ranking.StraightFlush, actual);
    }
}