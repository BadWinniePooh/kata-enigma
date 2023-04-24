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
            subject.ConnectionsLeft().Should().Be(expected, because);
        }

        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUV", "Too many connections configured. Due to the given configuration -1 connections are available.", "because only 10 connections are allowed, but 11 have been given.")]
        [InlineData("A", "Configuration must contain an even amount of letters.", "because letter A is not connected to anything.")]
        [InlineData("AA", "Configuration can't contain the same letter multiple times.", "because letter A is duplicate.")]
        [InlineData("ABCDEAFG", "Configuration can't contain the same letter multiple times.", "because letter A is duplicate.")]
        [InlineData("ABEDEAFG", "Configuration can't contain the same letter multiple times.", "because letter A and E are duplicate.")]
        [InlineData("ABAB", "Configuration can't contain the same letter multiple times.", "because letter A and B are duplicate.")]
        public void WrongConfigurationShouldThrowException(string input, string expectedMessage, string because)
        {
            Action act = () => new Plugboard(input);
            act.Should().Throw<ArgumentException>(because).WithMessage(expectedMessage);
        }

        [Theory]
        [InlineData("AB", 'A', 'B', "because A is mapped to B")]
        [InlineData("AB", 'B', 'A', "because the mapping should be bidirectional")]
        [InlineData("ABCD", 'C', 'D', "because C is mapped to D")]
        [InlineData("ABCD", 'D', 'C', "because the mapping should be bidirectional")]
        [InlineData("ABCDEFGHIJKLMNOPQRST", 'M', 'N', "because M is mapped to N")]
        [InlineData("ABCDEFGHIJKLMNOPQRST", 'U', 'U', "because U is not mapped")]
        public void GivenConfigurationMapsAsExpected(
            string inputConfiguration,
            char input,
            char expectedOutput,
            string because
        )
        {
            var subject = new Plugboard(inputConfiguration);
            subject.Convert(input).Should().Be(expectedOutput, because);
        }

        [Theory]
        [InlineData("Ä", "Special characters are not supported.", "because with this implementation of a plugboard Umlauts are not considered.")]
        [InlineData("ä", "Special characters are not supported.", "because with this implementation of a plugboard Umlauts are not considered.")]
        [InlineData("Ö", "Special characters are not supported.", "because with this implementation of a plugboard Umlauts are not considered.")]
        [InlineData("ö", "Special characters are not supported.", "because with this implementation of a plugboard Umlauts are not considered.")]
        [InlineData("Ü", "Special characters are not supported.", "because with this implementation of a plugboard Umlauts are not considered.")]
        [InlineData("ü", "Special characters are not supported.", "because with this implementation of a plugboard Umlauts are not considered.")]
        [InlineData("ß", "Special characters are not supported.", "because with this implementation of a plugboard Umlauts are not considered.")]
        public void GivenUmlautShouldThrowDescriptiveException(
            string input,
            string expectedMessage,
            string because
        )
        {
            Action act = () => new Plugboard(input);
            act.Should().Throw<ArgumentException>(because).WithMessage(expectedMessage);
        }

        [Theory]
        [InlineData("ab", 'A', 'B')]
        [InlineData("ab", 'a', 'B')]
        [InlineData("AB", 'a', 'B')]
        [InlineData("Ab", 'a', 'B')]
        public void GivenLowerCaseShouldBeConsideredAsUpperCase(
            string inputConfiguration,
            char input,
            char output
        )
        {
            var subject = new Plugboard(inputConfiguration);
            subject.Convert(input).Should().Be(output);
        }
    }
}