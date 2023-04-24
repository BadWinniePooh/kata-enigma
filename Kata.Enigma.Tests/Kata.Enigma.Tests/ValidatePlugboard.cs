namespace Kata.Enigma.Tests;

public class ValidatePlugboard
{
    private readonly Plugboard _plugboard;
    private string _configuration;

    public ValidatePlugboard(Plugboard plugboard, string configuration)
    {
        _plugboard = plugboard;
        _configuration = configuration;
    }

    public void ValidateConfiguration()
    {
        ValidateConnectionContainsNoSpecialCharacters();

        ValidateAmountOfConnections();

        ValidateEveryConnectionConnectsToTwoLetters();

        ValidateEveryLetterExistsOnlyOnce();
    }

    private void ValidateConnectionContainsNoSpecialCharacters()
    {
        var configToValidate = _configuration.ToUpperInvariant();
        var containsAE = configToValidate.Contains('Ä');
        var containsSS = configToValidate.Contains('ß');
        var containsOE = configToValidate.Contains('Ö');
        var containsUE = configToValidate.Contains('Ü');
        if (containsAE || containsSS || containsOE || containsUE)
        {
            throw new ArgumentException("Special characters are not supported.");
        }
    }

    private void ValidateEveryLetterExistsOnlyOnce()
    {
        if (_configuration.Distinct().Count() != _configuration.Length)
        {
            throw new ArgumentException(
                "Configuration can't contain the same letter multiple times."
            );
        }
    }

    private void ValidateEveryConnectionConnectsToTwoLetters()
    {
        if (_configuration.Length % 2 != 0)
        {
            throw new ArgumentException(
                "Configuration must contain an even amount of letters."
            );
        }
    }

    private void ValidateAmountOfConnections()
    {
        var connectionsLeft = _plugboard.ConnectionsLeft();
        if (connectionsLeft < 0)
        {
            throw new ArgumentException(
                $"Too many connections configured. Due to the given configuration {connectionsLeft} connections are available."
            );
        }
    }
}