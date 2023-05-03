namespace Kata.Enigma.Tests
{
    internal class Rotor
    {
        private readonly string _configuration;
        private readonly int _offset;

        public Rotor(string configuration, int offset)
        {
            _configuration = configuration;
            _offset = offset;
            var validate = new ValidateRotor(configuration);
            validate.ValidateConfiguration();
        }
    }
}
