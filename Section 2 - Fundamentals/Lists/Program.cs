// A list is a collection of items that are ordered and can be changed
// Lists are created with new keyword.
// Lists are collections of values of the same data type.
// Lists are VARIABLE SIZE, once created it can be changed.

var numbers = new List<int>();
// List<int> numbers = new List<int>();
// List<int> numbers = new List<int> { 2, 4, 6, 8, 10 };


for (int i = 0; i < 5; ++i)
{
    numbers.Add(i);
    Console.WriteLine("Total records: {0}", numbers.Count);

}

Console.WriteLine("Adding all items to the end");
numbers.AddRange(numbers);
Console.WriteLine("Total records: {0}", numbers.Count);


Console.WriteLine("Last item: {0}", numbers[^1]);
Console.WriteLine("First item: {0}", numbers[0]);

Console.WriteLine("Removing first item: {0}", numbers[0]);
// numbers.Remove(0); // Removes specific item
numbers.RemoveAt(0);
Console.WriteLine("Contains 0: {0}", numbers.Contains(0));
Console.WriteLine("Contains 6: {0}", numbers.Contains(6));

Console.WriteLine("Index of 0: {0}", numbers.IndexOf(0));
Console.WriteLine("Index of 1: {0}", numbers.IndexOf(1));
Console.WriteLine("Index of 6: {0}", numbers.IndexOf(6));

foreach (var item in numbers)
{
    Console.WriteLine(item);
}

numbers.Clear();
Console.WriteLine("Total records after clearing: {0}", numbers.Count);

Console.ReadKey();
