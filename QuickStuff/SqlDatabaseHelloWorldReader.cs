namespace QuickStuff;

public class SqlDatabaseHelloWorldReader : IDatabaseHelloWorldReader
{      
    public string ReadHelloWorldTextFromDatabase()
    {
        return "SQL HELLO WORLD";
    }
}