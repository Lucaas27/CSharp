namespace Exceptions.Logging
{
    public class Logger
    {
        private readonly string _filename;

        public Logger(string fileName)
        {
            _filename = fileName;
        }

        public void WriteToFile(Exception ex)
        {
            var message =
            $@"[{DateTime.Now}]
            Exception: {ex.Message}
            Stack Trace: {ex.StackTrace}

            ";

            File.AppendAllText(_filename, message);
        }

    }


}

