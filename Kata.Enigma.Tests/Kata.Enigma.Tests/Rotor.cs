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
            if(newPosition > 26)
            {
                newPosition -= 26;
            }
            _startingPosition = newPosition;
        }

        internal (int, char) CurrentState()
        {
            return (_startingPosition, _configuration[_startingPosition-1]);
        }

        private char EncryptChar(char input)
        {
            ChangeCurrentPositionTo(_startingPosition + 1);

            var charOffsetToA = Char.ToUpperInvariant(input) - 'A';
            var zeroIndexedStartingPosition = _startingPosition - 1;
            var conversionIndex = zeroIndexedStartingPosition + charOffsetToA;
            conversionIndex = PreventConversionIndexFromOverflowing(conversionIndex);
            return _configuration[conversionIndex];
        }

        private static int PreventConversionIndexFromOverflowing(int conversionIndex)
        {
            if (conversionIndex >= 26)
            {
                conversionIndex -= 26;
            }

            return conversionIndex;
        }

        internal object EncryptString(string input)
        {
            var encryptedOutput = "";
            for(var index = 0; index < input.Length; index++)
            {
                var charToEncrypt = input[index];
                if(char.ToUpperInvariant(charToEncrypt) < 'A' || 'Z' < char.ToUpperInvariant(charToEncrypt))
                {
                    if(charToEncrypt == ' ')
                    {
                        encryptedOutput += charToEncrypt;
                    }
                    continue;
                }
                encryptedOutput += EncryptChar(charToEncrypt);
            }
            return encryptedOutput;
        }
    }
}
