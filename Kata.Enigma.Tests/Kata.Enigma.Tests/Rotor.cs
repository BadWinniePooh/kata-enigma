namespace Kata.Enigma.Tests
{
    internal class Rotor
    {
        private readonly string _configuration;
        private readonly int _startingPosition;

        public Rotor(string configuration, int startingPosition)
        {
            _configuration = configuration;
            _startingPosition = startingPosition;
            var validate = new ValidateRotor(configuration, startingPosition);
            validate.ValidateConfiguration();
            validate.ValidateOffset();
        }

        internal (int, char) CurrentState()
        {
            return (_startingPosition, _configuration[_startingPosition-1]);
        }
    }
}
