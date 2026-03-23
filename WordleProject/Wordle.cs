namespace WordleProject; 

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
        if (guessedWord.Length < 5) return "Invalid Guess: guess too short";
        if (guessedWord.Length > 5) return "Invalid Guess: guess too long";
        if (guessedWord.Any(char.IsDigit)) return "Invalid Guess: Word should have only letters";

        if (guessedWord == secretWordToTest) return "GGGGG";

        string yourGuess = "";

        for (var i = 0; i < guessedWord.Count(); i++)
        {
            if (guessedWord[i] == secretWordToTest[i]) 
            {
                yourGuess += 'G';
                continue;
            }
            
            if (secretWordToTest.Contains(guessedWord[i]))
            {
                // partial test
                var alreadyTested = guessedWord.Substring(0, i);
                var numberTotalOccurrances = secretWordToTest.Count(x => x == guessedWord[i]);
                var numberInAlreadyTested = alreadyTested.Count(x => x == guessedWord[i]);

                // Console.WriteLine(alreadyTested);
                // Console.WriteLine(numberGuessedOccurrances);
                // Console.WriteLine(numberInAlreadyTested);

                //If the number of occurrances of the letter is greater than the number of occurrances captured in the word, we should throw back.
                if ( numberTotalOccurrances <= numberInAlreadyTested )
                {
                    yourGuess += '-';
                }
                else
                {
                    yourGuess += 'Y';    
                }

                continue;
            }

            yourGuess += '-';               
        }

        return yourGuess;
    }

}