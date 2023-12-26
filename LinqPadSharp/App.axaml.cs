#region

using Avalonia.Markup.Xaml;
using LinqPadSharp.ViewModels;
using Stylet;

#endregion

namespace LinqPadSharp;

public class App : StyletApplication<ShellViewModel>
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        base.Initialize();
    }

    //public override void OnFrameworkInitializationCompleted()
    //{
    //	if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    //	{
    //		// Line below is needed to remove Avalonia data validation.
    //		// Without this line you will get duplicate validations from both Avalonia and CT
    //		BindingPlugins.DataValidators.RemoveAt(0);
    //		desktop.MainWindow = new ShellView
    //		{
    //			DataContext = new ShellViewModel(),
    //		};
    //	}

    //	base.OnFrameworkInitializationCompleted();
    //}
}