using System.Text;

namespace TestProject1.Utilities;

public class RandomGenerator
{
    private static readonly Random _random = new Random();

    public static string GenerateRandomString(int size)
    {
        char offset = 'a';
        const int lettersOffset = 26;
        var builder = new StringBuilder();
        for (var i = 0; i < size; i++)
        {
            var @char = (char)_random.Next(offset, offset + lettersOffset);
            builder.Append(@char);
        }

        return builder.ToString();
    }
}