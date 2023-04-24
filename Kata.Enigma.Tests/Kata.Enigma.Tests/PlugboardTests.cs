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
    }

    public class Plugboard
    {
        private const int AvailableConnections = 10;
        private readonly string _configuration;
        private readonly ValidatePlugboard _validatePlugboard;

        public Plugboard(string configuration = "")
        {
            _configuration = configuration;
            _validatePlugboard = new ValidatePlugboard(this, _configuration);
            _validatePlugboard.ValidateConfiguration();
        }

        public int ConnectionsLeft()
        {
            var usedConnections = _configuration.Length / 2;
            return AvailableConnections - usedConnections;
        }

        internal char Convert(char input)
        {
            var indexOfInputInConfiguration = _configuration.IndexOf(input);
            var previousIndex = indexOfInputInConfiguration - 1;
            var nextIndex = indexOfInputInConfiguration + 1;
            return indexOfInputInConfiguration % 2 == 0 ? _configuration[nextIndex] : _configuration[previousIndex];
        }
    }
}