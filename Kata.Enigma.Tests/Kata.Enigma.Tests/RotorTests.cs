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
    }
}
