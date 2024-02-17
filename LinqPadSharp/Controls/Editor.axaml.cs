using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Interactivity;
using Avalonia.Media;
using AvaloniaEdit;
using AvaloniaEdit.TextMate;
using LinqPadSharp.Models.Enums;
using TextMateSharp.Grammars;
using Language = LinqPadSharp.Models.Enums.Language;

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

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        var textEditor = this.GetTemplateChildren().FirstOrDefault(x => x is TextEditor) as TextEditor;
        var registryOptions = new RegistryOptions(ThemeName.Dark);
        var textMateInstallation = textEditor.InstallTextMate(registryOptions);
        textMateInstallation.SetGrammar(registryOptions.GetScopeByLanguageId(registryOptions.GetLanguageByExtension(".cs").Id));
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);


    }
}