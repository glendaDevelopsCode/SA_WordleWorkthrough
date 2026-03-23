public class Wordle
{
    public string validateSecretWord(string SecretWordToTest)
    {
        if (SecretWordToTest == string.Empty) return "Invalid Secret Word: No Word Supplied";
        if (SecretWordToTest.Length < 5) return "Invalid Secret Word: Word too Short";
        if (SecretWordToTest.Length > 5) return "Invalid Secret Word: Word too long";
        if (SecretWordToTest.Any(char.IsDigit)) return "Invalid Secret Word: Word should have only letters";

        return "Let's Play!";
    }

    public string validateGuess (string guessedWord, string secretWordToTest)
    {
        if (guessedWord == string.Empty) return "Invalid Guess: No Word Supplied";
        
        //if (guessedWord == secretWordToTest) return "GGGGG";


        return "-----";
    }

}