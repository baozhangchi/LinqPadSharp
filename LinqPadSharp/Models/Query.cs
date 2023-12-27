namespace LinqPadSharp.Models;

public class Query
{
    public string? Title { get; set; }

    public QueryType Type { get; set; }

    public DotnetVersion DotnetVersion { get; set; }

    public string? Content { get; set; }
}

public enum DotnetVersion
{
    Auto,
    Dotnet8,
    Dotnet7,
    Dotnet6,
    Dotnet5
}

public enum QueryType
{
    Expression,
    Statements,
    Program
}