namespace Kata.Enigma.Tests
{
    internal class Rotor
    {
        private readonly string _configuration;

        public Rotor(string configuration)
        {
            _configuration = configuration;
            var validate = new ValidateRotor(configuration);
            validate.ValidateConfiguration();
        }
    }
}
