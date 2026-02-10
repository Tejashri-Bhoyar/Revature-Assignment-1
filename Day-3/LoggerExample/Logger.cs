using System;

public class Logger
{
    public void Log(string message)
    {
        Write("INFO", message);
    }

    public void Log(string level, string message)
    {
        Write(level, message);
    }

    public void Log(Exception ex)
    {
        Write("ERROR", ex.Message);
    }

    public void Log(string format, params object[] args)
    {
        string message = string.Format(format, args);
        Write("INFO", message);
    }

    public void Log(string level, string format, params object[] args)
    {
        string message = string.Format(format, args);
        Write(level, message);
    }

    private void Write(string level, string message)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [{level}] {message}");
    }
}