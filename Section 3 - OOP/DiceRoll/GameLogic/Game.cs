using DiceRoll.UserInput;
namespace DiceRoll.GameLogic;

public class Game
{
    private readonly Dice _dice;
    private int _currGuess; // Private field for storing user's guess
    private int _diceRollResult;
    private const int NumberOfGuessesAllowed = 3; // PascalCase for constants



    public Game(Dice dice)
    {
        _dice = dice;
    }

    public GameResult Play()
    {
        _diceRollResult = _dice.Roll();
        Console.WriteLine($"Dice rolled. Guess what number it shows in {NumberOfGuessesAllowed} tries.");


        for (int i = 1; i <= NumberOfGuessesAllowed; ++i)
        {
            _currGuess = ConsoleReader.ReadInteger("Enter number:");
            if (_currGuess == _diceRollResult)
            {
                return GameResult.Victory;
            }
            else
            {
                Console.WriteLine("Wrong Number. Try again.");
            }

        }

        return GameResult.Loss;
    }

    public void PrintResult(GameResult gameResult)
    {
        string message = gameResult == GameResult.Victory ? "You win :)" : $"You lost, the correct number was {_diceRollResult}";
        Console.WriteLine(message);
    }


    public static bool RepeatGame()
    {
        Console.WriteLine("Would you like to play again? (y/n)");
        if (Console.ReadLine()?.Trim().ToLower() == "y")
        {
            return true;
        }

        Console.WriteLine("Thanks for playing!");
        return false;
    }

}
