using LinqPadSharp.Models.Enums;

namespace LinqPadSharp.Models;

public class Query
{
    public string? Title { get; set; }

    public Language Language { get; set; }

    public DotnetVersion DotnetVersion { get; set; }

    public string? Content { get; set; }
}