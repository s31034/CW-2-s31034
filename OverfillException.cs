namespace Task1;

public class OverfillException : Exception
{
    public OverfillException(string message)
    {
        Console.WriteLine(message);
    }
}