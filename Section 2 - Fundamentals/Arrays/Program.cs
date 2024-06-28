// Arrays are created with new keyword and must be initialized with values before use.
// Arrays are collections of values of the same data type.
// Arrays are FIXED SIZE, once created it cannot be changed.
int[] numbers = new int[3];

for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] += i;
    Console.WriteLine(numbers[i]);
}

var firstFromEnd = numbers[^1];
var secondFromEnd = numbers[^2];

Console.WriteLine($"firstFromEnd: {firstFromEnd}");
Console.WriteLine($"secondFromEnd: {secondFromEnd}");

int[] knownArray = new int[] { 2, 4, 6, 8, 10 };
// var knownArrays = new int[] { 2, 4, 6, 8, 10 };
// int[] knownArray = [2, 4, 6, 8, 10];
// int[] knownArray = [2, 4, 6, 8, 10];

foreach (var item in knownArray)
{
    Console.WriteLine(item);
}
// Multi dimensional arrays

int[,] multiArray = new int[2, 3];
int[,] multiArray2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };

var rows = multiArray2.GetLength(0);
var columns = multiArray2.GetLength(1);
Console.WriteLine("Rows: {0}, Columns: {1}", rows, columns);

for (int i = 0; i < rows; i++)
{
    Console.WriteLine("Row: {0}", i);
    for (int j = 0; j < columns; j++)
    {
        Console.WriteLine("Column: {0}", j);
        Console.WriteLine("Element is {0}", multiArray2[i, j]);
    }
}



Console.ReadKey();