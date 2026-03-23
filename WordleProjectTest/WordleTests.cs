namespace WordleProjectTest;

public class WordleProjectTest
{

    #region "SecretWord Validation"
     [Fact]
    public void Should_ReturnInvalid_NoSecretWord()
    {
        //Arrange
        var secretWordToTest = "";
        Wordle wordle = new();

        //Act
        var result = wordle.validateSecretWord(secretWordToTest);

        //Assert
        Assert.Equal("Invalid Secret Word: No Word Supplied", result);
    }

    [Fact]
    public void Should_ReturnInvalid_TooShortSecretWord()
    {
        //Arrange
        var secretWordToTest = "no";
        Wordle wordle = new();

        //Act
        var result = wordle.validateSecretWord(secretWordToTest);

        //Assert
        Assert.Contains("Invalid Secret Word: Word too Short", result);
    }

    [Fact]
    public void Should_ReturnInvalid_TooLongSecretWord()
    {
        //Arrange
        var secretWordToTest = "thisisnotrighteither";
        Wordle wordle = new();

        //Act
        var result = wordle.validateSecretWord(secretWordToTest);

        //Assert
        Assert.Contains("Invalid Secret Word: Word too long", result);

    }

    [Fact]
    public void Should_ReturnInvalid_NoDigitsInSecretWord()
    {
        //Arrange
        var secretWordToTest = "stop1";
        Wordle wordle = new();

        //Act
        var result = wordle.validateSecretWord(secretWordToTest);

        //Assert
        Assert.Contains("Invalid Secret Word: Word should have only letters", result);
    }

    [Fact]
    public void Should_ReturnValid_SecretWord()
    {
        //Arrange
        var secretWordToTest = "plane";
        Wordle wordle = new();

        //Act
        var result = wordle.validateSecretWord(secretWordToTest);

        //Assert
        Assert.Contains("Let's Play!", result);
    }
    
    #endregion

    #region "Game Logic"

     [Fact]
    public void Should_ReturnInvalid_NoGuess()
    {
        //Arrange
        var secretWordToTest = "plane";
        var guessedWord = "";
        Wordle wordle = new();

        //Act
        //refactored slightly to remove secretWord handling. I suspect in a reality situation I would have designed this to hold the secret word somewhere and it'd be handed in.
        var result = wordle.validateGuess(guessedWord, secretWordToTest);

        //Assert
        Assert.Equal("Invalid Guess: No Word Supplied", result);
     }

    [Fact]
    public void Should_ReturnInvalid_ShortGuess()
    {
        //Arrange
        var secretWordToTest = "plane";
        var guessedWord = "plan";
        Wordle wordle = new();

        //Act
        var result = wordle.validateGuess(guessedWord, secretWordToTest);

        //Assert
        Assert.Equal("Invalid Guess: guess too short", result);
     }

    [Fact]
    public void Should_ReturnInvalid_LongGuess()
    {
        //Arrange
        var secretWordToTest = "plane";
        var guessedWord = "planet";
        Wordle wordle = new();

        //Act
        var result = wordle.validateGuess(guessedWord, secretWordToTest);

        //Assert
        Assert.Equal("Invalid Guess: guess too long" , result);
     }

    [Fact]
    public void Should_ReturnInvalid_DigitGuess()
    {
        //Arrange
        var secretWordToTest = "plane";
        var guessedWord = "p1ane";
        Wordle wordle = new();

        //Act
        var result = wordle.validateGuess(guessedWord, secretWordToTest);

        //Assert
        Assert.Equal("Invalid Guess: Word should have only letters", result);

    }

    [Fact]
    public void Should_ReturnValid_CorrectGuess()
    {
        //Arrange
        var secretWordToTest = "plane";
        var guessedWord = "plane";
        Wordle wordle = new();

        //Act
        var result = wordle.validateGuess(guessedWord, secretWordToTest);

        //Assert  
        Assert.Equal("GGGGG", result);
    }

    [Fact]
    public void Should_ReturnValid_PartialCorrectGuess()
    {
        //Arrange
        var secretWordToTest = "plane";
        var guessedWord = "plans";
        Wordle wordle = new();

        //Act
        var result = wordle.validateGuess(guessedWord, secretWordToTest);

        //Assert
        Assert.Equal("GGGG-", result);
    }

    [Fact]
    public void Should_ReturnValid_PartialCorrectLetterPoorlyPlacedGuess()
    {
        //Arrange
        var secretWordToTest = "plane";
        var guessedWord = "lanes";
        Wordle wordle = new();

        //Act
        var result = wordle.validateGuess(guessedWord, secretWordToTest);

        //Assert        
        Assert.Equal("YYYY-", result);
    }

    // public void Should_ReturnValid_IncorrectGuess()
    // {
    //     //Arrange

    //     //Act

    //     //Assert        
    // }



    // public void Should_ReturnValid_PartialCorrectMultiLetterGuess()
    // {
    //     //Arrange

    //     //Act

    //     //Assert        
    // }

    #endregion
}