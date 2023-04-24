namespace Kata.Enigma.Tests;

public class Plugboard
{
    private const int AvailableConnections = 10;
    private readonly string _configuration;
    private readonly ValidatePlugboard _validatePlugboard;

    public Plugboard(string configuration = "")
    {
        _configuration = configuration;
        _validatePlugboard = new ValidatePlugboard(this, _configuration);
        _validatePlugboard.ValidateConfiguration();
    }

    public int ConnectionsLeft()
    {
        var usedConnections = _configuration.Length / 2;
        return AvailableConnections - usedConnections;
    }

    internal char Convert(char input)
    {
        if (!_configuration.Contains(input))
        {
            return input;
        }
        var indexOfInputInConfiguration = _configuration.IndexOf(input);
        var previousIndex = indexOfInputInConfiguration - 1;
        var nextIndex = indexOfInputInConfiguration + 1;
        return indexOfInputInConfiguration % 2 == 0 ? _configuration[nextIndex] : _configuration[previousIndex];
    }
}