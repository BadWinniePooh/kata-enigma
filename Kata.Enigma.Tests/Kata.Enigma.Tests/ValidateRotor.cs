namespace Kata.Enigma.Tests
{
    internal class ValidateRotor
    {
        private readonly string _configuration;
        private string message;

        public ValidateRotor(string configuration)
        {
            _configuration = configuration;
        }

        public void ValidateConfiguration()
        {
            var exception = false;
            exception = ValidateConfigurationLength(exception);
            exception = ValidateDistinctLettersInConfiguration(exception);
            exception = ValidateConfigurationContainsNoSpecialCharacters(exception);

            if (exception)
            {
                throw new ArgumentException(message);
            }
        }

        private bool ValidateConfigurationContainsNoSpecialCharacters(bool exception)
        {
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

            return exception;
        }

        private bool ValidateDistinctLettersInConfiguration(bool exception)
        {
            if (_configuration.Distinct().Count() != _configuration.Length)
            {
                exception = true;
                message = "The configuration may not contain duplicates.";
            }

            return exception;
        }

        private bool ValidateConfigurationLength(bool exception)
        {
            if (_configuration.Length != 26)
            {
                exception = true;
                message = "The configuration must contain a configuration for each letter, but it doesn't.";
            }
            return exception;
        }
    }
}
