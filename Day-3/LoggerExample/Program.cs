// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;

class Program
{
    static void Main()
    {
        Logger logger = new Logger();

        logger.Log("Application started");

        logger.Log("WARN", "Low disk space");

        logger.Log("User {0} logged in at {1}", "Tejashri", DateTime.Now);

        logger.Log("DEBUG", "Processing item {0} of {1}", 3, 10);

        try
        {
            int y=0;
            int x = 10 / y;
        }
        catch (Exception ex)
        {
            logger.Log(ex);
        }
    }
}
