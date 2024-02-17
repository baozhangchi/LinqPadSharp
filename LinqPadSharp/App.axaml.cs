#region

using System;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LinqPadSharp.ViewModels;
using Stylet;
using Stylet.Avalonia;

#endregion

namespace LinqPadSharp;

public class App : Stylet.StyletApplication
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        base.Initialize();
    }

    protected override Control DisplayRootView()
    {
        var viewManager = IoC.Get<IViewManager>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainViewModel = IoC.Get<ShellViewModel>();
            return viewManager.CreateAndBindViewForModelIfNecessary(mainViewModel) as TopLevel;
        }

        throw new NotSupportedException();
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