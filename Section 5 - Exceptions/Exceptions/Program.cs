using Exceptions.App;
using Exceptions.DataAccess;
using Exceptions.UserInteraction;
using Exceptions.Logging;

var userInteraction = new ConsoleInteraction();
var fileHandler = new FileHandler(userInteraction);
var app = new App(fileHandler, userInteraction);
var logger = new Logger("log.txt");

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Sorry! The application has experienced an unexpected error and will have to be closed.");

    logger.WriteToFile(ex);
}
