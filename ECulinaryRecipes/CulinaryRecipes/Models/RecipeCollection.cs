using CulinaryRecipes.Models;
using CulinaryRecipes.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CulinaryRecipes.Models;

public class RecipeCollection : ViewModelBase
{
    private ObservableCollection<Recipe> recipes;
    public ObservableCollection<Recipe> Recipes
    {
        get
        {
            return recipes;
        }
        set
        {
            recipes = value;
            OnPropertyChanged();
        }
    }
    private ObservableCollection<Recipe> searchedRecipes;
    public ObservableCollection<Recipe> SearchedRecipes
    {
        get
        {
            return searchedRecipes;
        }
        set
        {
            searchedRecipes = value;
            OnPropertyChanged();
        }
    }

    public RecipeCollection()
	{
		Recipes = new();
		SearchedRecipes = new();
    }

    public bool Conflicts()
	{
		if (Recipes == null)
			return true;
		return false;
	}
}
