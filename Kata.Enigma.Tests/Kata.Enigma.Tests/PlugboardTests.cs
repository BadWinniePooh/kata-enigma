using FluentAssertions;

namespace Kata.Enigma.Tests
{
    public class PlugboardTests
    {
        [Theory]
        [InlineData("", 10, "because 0 connections were given")]
        [InlineData("AB", 9, "because 1 connection was given")]
        [InlineData("ABCD", 8, "because 2 connections were given")]
        [InlineData("ABCDEFGHIJKLMNOPQR", 1, "because 9 connections were given")]
        [InlineData("ABCDEFGHIJKLMNOPQRST", 0, "because 10 connections were given")]
        public void GivenAmountOfConnectionsShouldReduceConnectionsLeft(string input, int expected, string because)
        {
            var subject = new Plugboard(input);
            subject.ConnectionsLeft().Should().Be(expected);
        }

        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUV", "Too many connections configured. Due to the given configuration -1 connections are available.", "because only 10 connections are allowed, but 11 have been given.")]
        [InlineData("A", "Configuration must contain an even amount of letters.", "because letter A is not connected to anything.")]
        [InlineData("AA", "Configuration can't contain the same letter multiple times.", "because letter A is duplicate.")]
        [InlineData("ABCDEAFG", "Configuration can't contain the same letter multiple times.", "because letter A is duplicate.")]
        [InlineData("ABEDEAFG", "Configuration can't contain the same letter multiple times.", "because letter A and E are duplicate.")]
        public void WrongConfigurationShouldThrowException(string input, string expectedMessage, string because)
        {
            Action act = () => new Plugboard(input);
            act.Should().Throw<ArgumentException>(because).WithMessage(expectedMessage);
        }
    }
}