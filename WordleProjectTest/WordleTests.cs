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
        wordle.validateSecretWord(secretWordToTest);
        var result = wordle.validateGuess(guessedWord, secretWordToTest);

        //Assert
        Assert.Equal("Invalid Guess: No Word Supplied", result);
     }

    // public void Should_ReturnInvalid_ShortGuess()
    // {
    //     //Arrange
    //     var secretWordToTest = "plane";
    //     var guessedWord = "";
    //     //Act
    //     //Assert

    //  }

    // public void Should_ReturnInvalid_LongGuess()
    // {
    //     //Arrange
    //     var secretWordToTest = "plane";
    //     var guessedWord = "";

    //     //Act
    //     //Assert
    //  }

    // public void Should_ReturnInvalid_DigitGuess()
    // {
    //     //Arrange
    //     var secretWordToTest = "plane";
    //     var guessedWord = "";
    //     //Act
    //     //Assert

    // }

    // public void Should_ReturnInvalid_Guess()
    // {
    //    //Arrange
    //     var secretWordToTest = "plane";
    //     var guessedWord = "";

    //     //Act

    //     //Assert

    // }

    // public void Should_ReturnValid_CorrectGuess()
    // {
    //     //Arrange

    //     //Act

    //     //Assert       
    // }

    // public void Should_ReturnValid_IncorrectGuess()
    // {
    //     //Arrange

    //     //Act

    //     //Assert        
    // }

    // public void Should_ReturnValid_PartialCorrectGuess()
    // {
    //      //Arrange

    //     //Act

    //     //Assert       
    // }

    // public void Should_ReturnValid_PartialCorrectMultiLetterGuess()
    // {
    //     //Arrange

    //     //Act

    //     //Assert        
    // }

    // public void Should_ReturnValid_PartialCorrectLetterMutlipledGuess()
    // {
    //     //Arrange

    //     //Act

    //     //Assert        
    // }
    #endregion
}