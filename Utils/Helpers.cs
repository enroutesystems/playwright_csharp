namespace PlaywrightTests.Utils;

public class Helpers
{
    public static int sequenceToIndexNumber(string sequence)
    {
        string[] possibleStrings = ["first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth", "tenth"];
        return Array.IndexOf(possibleStrings, sequence);
    }
}