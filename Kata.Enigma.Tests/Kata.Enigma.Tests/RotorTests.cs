using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Kata.Enigma.Tests
{
    public class RotorTests
    {
        [Theory]
        [InlineData("", "The configuration must contain a configuration for each letter, but it doesn't.", "No configuration was provided")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXY", "The configuration must contain a configuration for each letter, but it doesn't.", "Configuration for only 25 letters was provided")]
        [InlineData("AABCDEFGHIJKLMNOPQRSTUVWX", "The configuration may not contain duplicates.", "Two A's contained in configuration")]
        [InlineData("äöüß", "The configuration may only contain letters between A-Z.", "Special characters are contained")]
        public void WrongConfiguratioShouldThrowException(string input, string expectedMessage, string because)
        {
            Action act = () => new Rotor(input, 1);
            act.Should().Throw<ArgumentException>(because).WithMessage(expectedMessage);
        }

        [Theory]
        [InlineData(0, "Offset is supposed to be between 1 and 26.")]
        [InlineData(27, "Offset is supposed to be between 1 and 26.")]
        public void GivenValidConfigurationAndWrongStartingPositionShouldThrow(int startingPosition, string expectedMessage)
        {
            Action act = () => new Rotor("ABCDEFGHIJKLMNOPQRSTUVWXYZ", startingPosition);
            act.Should().Throw<ArgumentException>(expectedMessage).WithMessage(expectedMessage);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(13)]
        [InlineData(26)]
        public void GivenValidConfigurationAndValidStartingPositionShouldValidate(int startingPosition)
        {
            Action act = () => new Rotor("ABCDEFGHIJKLMNOPQRSTUVWXYZ", startingPosition);
            act.Should().NotThrow();
        }

        [Theory]
        [InlineData(1, 1, 'Q')]
        [InlineData(2, 2, 'W')]
        [InlineData(15, 15, 'G')]
        [InlineData(26, 26, 'M')]
        public void GivenStartingPositionAndConfigurationShouldReturnCorrectStateOfRotor(int inputOffset, int expectedOffset, char expectedConfigurationCharacter)
        {
            var subject = new Rotor("QWERTZUIOPASDFGHJKLYXCVBNM", inputOffset);
            var (actualOffset, actualConfigurationChar) = subject.CurrentState();
            actualOffset.Should().Be(expectedOffset);
            actualConfigurationChar.Should().Be(expectedConfigurationCharacter);
        }

        [Fact]
        public void RotorStartingPositionCanBeChanged()
        {
            var subject = new Rotor("QWERTZUIOPASDFGHJKLYXCVBNM", 1);
            var (_, actualConfigurationChar) = subject.CurrentState();
            actualConfigurationChar.Should().Be('Q');

            subject.ChangeCurrentPositionTo(3);
            (_, actualConfigurationChar) = subject.CurrentState();
            actualConfigurationChar.Should().Be('E');
            
            subject.ChangeCurrentPositionTo(26);
            (_, actualConfigurationChar) = subject.CurrentState();
            actualConfigurationChar.Should().Be('M');
        }

    }
}
