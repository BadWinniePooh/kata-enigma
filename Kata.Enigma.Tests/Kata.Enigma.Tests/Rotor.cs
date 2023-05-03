namespace Kata.Enigma.Tests
{
    internal class Rotor
    {
        private readonly string _configuration;
        private int _startingPosition;

        public Rotor(string configuration, int startingPosition)
        {
            _configuration = configuration;
            _startingPosition = startingPosition;
            var validate = new ValidateRotor(configuration, startingPosition);
            validate.ValidateConfiguration();
            validate.ValidateOffset();
        }

        internal void ChangeCurrentPositionTo(int newPosition)
        {
            _startingPosition = newPosition;
        }

        internal (int, char) CurrentState()
        {
            return (_startingPosition, _configuration[_startingPosition-1]);
        }
    }
}
