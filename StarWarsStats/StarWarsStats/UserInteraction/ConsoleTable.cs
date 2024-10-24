namespace StarWarsStats.UserInteraction
{
    public static class ConsoleTable
    {
        public static void Print<T>(IEnumerable<T> data)
        {
            const int columnWidth = 20;
            var columnHeaders = typeof(T).GetProperties();
            Console.WriteLine(new string('-', columnHeaders.Length * (columnWidth + 2)));
            foreach (var header in columnHeaders)
            {
                Console.Write($"{{0, -{columnWidth}}}| ", header.Name);

            }
            Console.WriteLine();
            Console.WriteLine(new string('-', columnHeaders.Length * (columnWidth + 2)));

            foreach (var item in data)
            {
                foreach (var header in columnHeaders)
                {
                    Console.Write($"{{0, -{columnWidth}}}| ", header.GetValue(item));
                }
                Console.WriteLine();
            }
            // var headers = string.Join(" | ", headersCollection);

        }
    }
}