using System.ComponentModel;

namespace LinqPadSharp.Models.Enums;

public enum Language
{
    [Description("C# Expression")]
    CSharpExpression,
    [Description("C# Statement(s)")]
    CSharpStatement,
    [Description("C# Program")]
    CSharpProgram
}