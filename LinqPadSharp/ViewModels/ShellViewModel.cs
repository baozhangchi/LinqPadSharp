#region

using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using LinqPadSharp.Models;

#endregion

namespace LinqPadSharp.ViewModels;

public class ShellViewModel : ViewModelBase
{
    private Query? _currentQuery;
    private int _index = 1;
    public ObservableCollection<Query> Queries { get; set; } = new();

    public Query? CurrentQuery
    {
        get => _currentQuery;
        set
        {
            if (SetProperty(ref _currentQuery, value)) OnPropertyChanged(nameof(CanClose));
        }
    }

    public bool CanClose => CurrentQuery != null;

    public void Exit()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime
            desktopStyleApplication)
        {
            desktopStyleApplication.Shutdown();
        }
        else if (Application.Current?.ApplicationLifetime is ISingleViewApplicationLifetime singleViewApplication)
        {
        }
    }

    public void NewQuery()
    {
        Queries.Add(new Query { Title = $"Query{_index++}" });
        CurrentQuery = Queries.Last();
    }

    public void Run(Query query)
    {

    }

    public void CloseQuery(Query query)
    {
        var index = Queries.IndexOf(CurrentQuery!);
        Queries.RemoveAt(index);
        if (Queries.Count == 0)
            NewQuery();
        else
            CurrentQuery = index == 0 ? Queries.First() : Queries[index - 1];
    }
}