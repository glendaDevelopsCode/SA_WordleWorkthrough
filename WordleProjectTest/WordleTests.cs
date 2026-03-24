namespace WordleProjectTest;
using WordleProject;

public class WordleProjectTest
{

    #region "SecretWord Validation"
     [Fact]
    public void Should_ReturnInvalid_NoSecretWord()
    {
        
        var secretWordToTest = "";
        Wordle wordle = new();

        
        var result = wordle.ValidateSecretWord(secretWordToTest);

        
        Assert.Equal("Invalid Secret Word: No Word Supplied", result);
    }

    [Fact]
    public void Should_ReturnInvalid_TooShortSecretWord()
    {
        
        var secretWordToTest = "no";
        Wordle wordle = new();

        
        var result = wordle.ValidateSecretWord(secretWordToTest);

        
        Assert.Contains("Invalid Secret Word: Word too Short", result);
    }

    [Fact]
    public void Should_ReturnInvalid_TooLongSecretWord()
    {
        
        var secretWordToTest = "thisisnotrighteither";
        Wordle wordle = new();

        
        var result = wordle.ValidateSecretWord(secretWordToTest);

        
        Assert.Contains("Invalid Secret Word: Word too long", result);

    }

    [Fact]
    public void Should_ReturnInvalid_NoDigitsInSecretWord()
    {
        
        var secretWordToTest = "stop1";
        Wordle wordle = new();

        
        var result = wordle.ValidateSecretWord(secretWordToTest);

        
        Assert.Contains("Invalid Secret Word: Word should have only letters", result);
    }

    [Fact]
    public void Should_ReturnValid_SecretWord()
    {
        
        var secretWordToTest = "plane";
        Wordle wordle = new();

        
        var result = wordle.ValidateSecretWord(secretWordToTest);

        
        Assert.Contains("Let's Play!", result);
    }
    
    #endregion

    #region "Game Logic"

     [Fact]
    public void Should_ReturnInvalid_NoGuess()
    {
        
        var secretWordToTest = "plane";
        var guessedWord = "";
        Wordle wordle = new();

        
        //refactored slightly to remove secretWord handling. I suspect in a reality situation I would have designed this to hold the secret word somewhere and it'd be handed in.
        var result = wordle.ValidateGuess(guessedWord, secretWordToTest);

        
        Assert.Equal("Invalid Guess: No Word Supplied", result);
     }

    [Fact]
    public void Should_ReturnInvalid_ShortGuess()
    {
        
        var secretWordToTest = "plane";
        var guessedWord = "plan";
        Wordle wordle = new();

        
        var result = wordle.ValidateGuess(guessedWord, secretWordToTest);

        
        Assert.Equal("Invalid Guess: guess too short", result);
     }

    [Fact]
    public void Should_ReturnInvalid_LongGuess()
    {
        
        var secretWordToTest = "plane";
        var guessedWord = "planet";
        Wordle wordle = new();

        
        var result = wordle.ValidateGuess(guessedWord, secretWordToTest);

        
        Assert.Equal("Invalid Guess: guess too long" , result);
     }

    [Fact]
    public void Should_ReturnInvalid_DigitGuess()
    {
        
        var secretWordToTest = "plane";
        var guessedWord = "p1ane";
        Wordle wordle = new();

        
        var result = wordle.ValidateGuess(guessedWord, secretWordToTest);

        
        Assert.Equal("Invalid Guess: Word should have only letters", result);

    }

    [Fact]
    public void Should_ReturnGGGGG_CorrectGuess()
    {
        
        var secretWordToTest = "plane";
        var guessedWord = "plane";
        Wordle wordle = new();

        
        var result = wordle.ValidateGuess(guessedWord, secretWordToTest);

          
        Assert.Equal("GGGGG", result);
    }

    [Fact]
    public void Should_ReturnNNNNN_IncorrectGuess()
    {
        
        var secretWordToTest = "plane";
        var guessedWord = "ditch";
        Wordle wordle = new();
        
        
        var result = wordle.ValidateGuess(guessedWord,secretWordToTest);

                
        Assert.Equal("-----", result);
    }

    [Fact]
    public void Should_ReturnNNNYN_PartialCorrectLetterPoorlyPlacedGuess()
    {
        
        var secretWordToTest = "plane";
        var guessedWord = "world";
        Wordle wordle = new();

        
        var result = wordle.ValidateGuess(guessedWord, secretWordToTest);

                
        Assert.Equal("---Y-", result);
    }

    [Fact]
    public void Should_ReturnYYNNN_PartialCorrectMultiLetterGuess()
    {
        
        var secretWordToTest = "plane";
        var guessedWord = "lever";
        Wordle wordle = new();

        
        var result = wordle.ValidateGuess(guessedWord, secretWordToTest);

        
        Assert.Equal("YY---", result);
    }

    [Fact]
    public void Should_ReturnValid_PartialCorrectGuess()
    {
        
        var secretWordToTest = "plane";
        var guessedWord = "elate";
        Wordle wordle = new();

        
        var result = wordle.ValidateGuess(guessedWord, secretWordToTest);

        
        Assert.Equal("-GG-G", result);
    }

    #endregion
}