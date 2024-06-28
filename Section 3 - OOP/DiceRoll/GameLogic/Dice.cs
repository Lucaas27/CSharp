namespace DiceRoll.GameLogic;

public class Dice(Random random)
{
    private readonly Random _random = random;
    private const int NumberOfSides = 6;

    public int Roll() => _random.Next(1, NumberOfSides + 1);


    public static void Describe() => Console.WriteLine($"This is a dice with {NumberOfSides} sides.");


}
