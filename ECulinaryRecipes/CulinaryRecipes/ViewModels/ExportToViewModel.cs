using CulinaryRecipes.Commands;
using System.IO;
using CulinaryRecipes.Models;

namespace CulinaryRecipes.ViewModels;

public class ExportToViewModel : ViewModelBase
{
    public CommandBase SaveCommand { get; }
    public CommandBase CancelCommand { get; }
    private Recipe writedRecipe;
    private string extFile;
    public string ExtFile
    {
        get
        {
            return extFile;
        }
        set
        {
            extFile = value;
            OnPropertyChanged();
        }
    }

    public ExportToViewModel(Recipe recipe)
    {
        this.extFile = extFile;
        this.writedRecipe = recipe;
        SaveCommand = new(Save);
        CancelCommand = new(Cancel);
    }

    public void Save(object obj)
    {
        string str = $"{writedRecipe.Name}\n" +
            $"{writedRecipe.Description}\n" +
            $"{writedRecipe.Type}\n" +
            $"{writedRecipe.Kitchen}\n";
        File.WriteAllText($"Recipe{this.extFile}", str);
        App.Current.Windows[1].Close();
    }

    public void Cancel(object obj)
    {
        App.Current.Windows[1].Close();
    }
}
