using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml;
using Avalonia.Stylet;

namespace LinqPadSharp.MarkupExtensions;

public class EnumSourceExtension : MarkupExtension
{
    private Type? _enumType;

    public Type? EnumType
    {
        get => _enumType;
        set
        {
            if (value != null)
            {
                var enumType = Nullable.GetUnderlyingType(value) ?? value;
                if (!enumType.IsEnum)
                {
                    throw new ArgumentException("必须是一个枚举类型");
                }
            }

            _enumType = value;
        }
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        if (_enumType == null)
        {
            return default!;
        }

        if (serviceProvider.GetService(typeof(IProvideValueTarget)) is IProvideValueTarget service)
            switch (service.TargetObject)
            {
                case ItemsControl itemsControl:
                    if (itemsControl.ItemTemplate == null)
                    {
                        itemsControl.ItemTemplate = new EnumItemDataTemplate();
                    }

                    break;
                case RoutedCommandBinding _:
                    break;
            }

        var actualEnumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;
        var enumValues = Enum.GetValues(actualEnumType);
        if (actualEnumType == _enumType)
        {
            return enumValues;
        }

        var tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
        enumValues.CopyTo(tempArray, 1);
        return tempArray;
    }

    private class EnumItemDataTemplate : IDataTemplate
    {
        public Control Build(object? param)
        {
            return new TextBlock { Text = ((Enum)param!).GetDescription() };
        }

        public bool Match(object? data)
        {
            return data is Enum;
        }
    }
}