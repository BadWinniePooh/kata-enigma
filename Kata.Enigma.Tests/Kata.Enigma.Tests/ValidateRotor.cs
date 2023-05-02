namespace Kata.Enigma.Tests
{
    internal class ValidateRotor
    {
        private readonly string _configuration;

        public ValidateRotor(string configuration)
        {
            _configuration = configuration;
        }

        public void ValidateConfiguration()
        {
            var exception = false;
            var message = "";

            if (_configuration.Length != 26)
            {
                exception = true;
                message = "The configuration must contain a configuration for each letter, but it doesn't.";
            }

            if (_configuration.Distinct().Count() != _configuration.Length)
            {
                exception = true;
                message = "The configuration may not contain duplicates.";
            }

            var configToValidate = _configuration.ToUpperInvariant();
            var containsAE = configToValidate.Contains('Ä');
            var containsOE = configToValidate.Contains('Ö');
            var containsUE = configToValidate.Contains('Ü');
            var containsSS = configToValidate.Contains('ß');

            if (containsAE || containsOE || containsUE || containsSS)
            {
                exception = true;
                message = "The configuration may only contain letters between A-Z.";
            }


            if (exception)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
