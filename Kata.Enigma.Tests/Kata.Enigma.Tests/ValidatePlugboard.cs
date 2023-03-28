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
        ValidateAmountOfConnections();

        ValidateEveryConnectionConnectsToTwoLetters();

        ValidateEveryLetterExistsOnlyOnce();
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