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
}