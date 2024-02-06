using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using LinqPadSharp.Models.Enums;

namespace LinqPadSharp.Controls;

public class Editor : TemplatedControl
{
    public override void Render(DrawingContext context)
    {
        base.Render(context);
    }

    public static readonly StyledProperty<string> CodeProperty = AvaloniaProperty.Register<Editor, string>(
        "Code");

    public string Code
    {
        get => GetValue(CodeProperty);
        set => SetValue(CodeProperty, value);
    }

    public static readonly StyledProperty<Language> LanguageProperty = AvaloniaProperty.Register<Editor, Language>(
        "Language");

    public Language Language
    {
        get => GetValue(LanguageProperty);
        set => SetValue(LanguageProperty, value);
    }

    public static readonly StyledProperty<DotnetVersion> DotnetVersionProperty = AvaloniaProperty.Register<Editor, DotnetVersion>(
        "DotnetVersion");

    public DotnetVersion DotnetVersion
    {
        get => GetValue(DotnetVersionProperty);
        set => SetValue(DotnetVersionProperty, value);
    }
}