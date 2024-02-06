using System;
using System.ComponentModel;
using System.Reflection;

namespace LinqPadSharp.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum @enum)
    {
        var type = @enum.GetType();
        var field = type.GetField(@enum.ToString());
        var attribute = field!.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? @enum.ToString();
    }
}