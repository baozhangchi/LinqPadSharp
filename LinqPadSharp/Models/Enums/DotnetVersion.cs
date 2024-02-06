using System.ComponentModel;

namespace LinqPadSharp.Models.Enums;

public enum DotnetVersion
{
    Auto,
    [Description("6.0")] Net6,
    [Description("7.0")] Net7,
    [Description("8.0")] Net8,
}