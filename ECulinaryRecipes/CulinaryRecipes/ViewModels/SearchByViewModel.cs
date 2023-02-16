using CulinaryRecipes.Commands;
using CulinaryRecipes.Models;
using System.Collections.ObjectModel;

namespace CulinaryRecipes.ViewModels;

public class SearchByViewModel : ViewModelBase
{
    private readonly Recipe templateRecipe;
    public CommandBase SearchCommand { get; }
    public CommandBase CancelCommand { get; }
    private ObservableCollection<Recipe> recipes;
    private ObservableCollection<Recipe> deletedRecipes;

    public SearchByViewModel(ObservableCollection<Recipe> recipes, ObservableCollection<Recipe> deletedRecipes)
    {
        this.templateRecipe = new();
        this.SearchCommand = new(Search);
        this.CancelCommand = new(Cancel);
        this.recipes = recipes;
        this.deletedRecipes = deletedRecipes;
    }

    public void Search(object obj)
    {
        if (this.deletedRecipes.Count > 0)
        {
            foreach (var item in deletedRecipes)
                this.recipes.Add(item);
            this.deletedRecipes.Clear();
        }
        ObservableCollection<Recipe> temp = new(recipes);
        foreach (Recipe item in temp)
        {
            if (templateRecipe.Name != null)
                if (this.templateRecipe.Name != item.Name)
                    if (recipes.Contains(item))
                    {
                        recipes.Remove(item);
                        deletedRecipes.Add(item);
                    }
            if (templateRecipe.Description != null)
                if (this.templateRecipe.Description != item.Description)
                    if (recipes.Contains(item))
                    {
                        recipes.Remove(item);
                        deletedRecipes.Add(item);
                    }
            if (templateRecipe.Type != null)
                if (this.templateRecipe.Type != item.Type)
                    if (recipes.Contains(item))
                    {
                        recipes.Remove(item);
                        deletedRecipes.Add(item);
                    }
            if (templateRecipe.Kitchen != null)
                if (this.templateRecipe.Kitchen != item.Kitchen)
                    if (recipes.Contains(item))
                    {
                        recipes.Remove(item);
                        deletedRecipes.Add(item);
                    }
        }
        App.Current.Windows[1].Close();
    }

    public void Cancel(object obj)
    {
        App.Current.Windows[1].Close();
    }

    public string Name
    {
        get
        {
            return templateRecipe.Name;
        }
        set
        {
            templateRecipe.Name = value;
            OnPropertyChanged();
        }
    }

    public string Description
    {
        get
        {
            return templateRecipe.Description;
        }
        set
        {
            templateRecipe.Description = value;
            OnPropertyChanged();
        }
    }

    public string Type
    {
        get
        {
            return templateRecipe.Type;
        }
        set
        {
            templateRecipe.Type = value;
            OnPropertyChanged();
        }
    }

    public string Kitchen
    {
        get
        {
            return templateRecipe.Kitchen;
        }
        set
        {
            templateRecipe.Kitchen = value;
            OnPropertyChanged();
        }
    }
}
