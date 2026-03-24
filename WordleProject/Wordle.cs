namespace WordleProject; 

public class Wordle
{
    public string ValidateSecretWord(string SecretWordToTest)
    {
        if (SecretWordToTest == string.Empty) return "Invalid Secret Word: No Word Supplied";
        if (SecretWordToTest.Length < 5) return "Invalid Secret Word: Word too Short";
        if (SecretWordToTest.Length > 5) return "Invalid Secret Word: Word too long";
        if (SecretWordToTest.Any(char.IsDigit)) return "Invalid Secret Word: Word should have only letters";

        return "Let's Play!";
    }

    public string ValidateGuess (string guessedWord, string secretWordToTest)
    {
        if (guessedWord == string.Empty) return "Invalid Guess: No Word Supplied";
        if (guessedWord.Length < 5) return "Invalid Guess: guess too short";
        if (guessedWord.Length > 5) return "Invalid Guess: guess too long";
        if (guessedWord.Any(char.IsDigit)) return "Invalid Guess: Word should have only letters";

        if (guessedWord == secretWordToTest) return "GGGGG";

        string yourGuess = "";
        List<char> goodGuesses = [];

        for (var i = 0; i < guessedWord.Length; i++)
        {

            if (guessedWord[i] == secretWordToTest[i]) 
            {                
                yourGuess += 'G';
                goodGuesses.Add(guessedWord[i]);
                continue;
            }
            yourGuess += '-'; 
        }

        for (var i = 0; i < guessedWord.Length; i++)
        {
            if (yourGuess[i] == 'G') continue;

            if (secretWordToTest.Contains(guessedWord[i]))
            {
                //This variable stores a partial word, it's everything that we have already tried.
                var alreadyTested = guessedWord.Substring(0, i);

                //This is the number of times the letter has already come up.                                
                var numberInAlreadyTested = alreadyTested.Count(x => x == guessedWord[i]);
                int numberOfClearedCorrectInstances = goodGuesses.Count(x=>x == guessedWord[i]); 
                               
                //This is the total number of times the guessed letter occurs in the word.
                var numberTotalOccurrances = secretWordToTest.Count(x => x == guessedWord[i]);

                if (!( (numberTotalOccurrances - numberOfClearedCorrectInstances) <= numberInAlreadyTested )) yourGuess = yourGuess.Remove(i, 1).Insert(i,"Y"); 
            }
        }
        return yourGuess;
    }

}