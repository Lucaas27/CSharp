using DiceRoll.GameLogic;

namespace DiceRoll;

public class Program
{
    public static void Main()
    {
        var random = new Random();
        var dice = new Dice(random);
        var game = new Game(dice);
        bool playAgain;
        do
        {
            var gameResult = game.Play();
            game.PrintResult(gameResult);
            playAgain = Game.RepeatGame();
        }
        while (playAgain);

    }
}
