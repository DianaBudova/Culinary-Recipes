using System.Collections.Generic;
using System.Windows;
using CulinaryRecipes.Models;
using CulinaryRecipes.Commands;
using CulinaryRecipes.Views;
using System.Collections.ObjectModel;

namespace CulinaryRecipes.ViewModels;

public class RecipesViewModel : ViewModelBase
{
    public CommandBase AddRecipeCommand { get; }
    public CommandBase EditRecipeCommand { get; }
    public CommandBase RemoveRecipeCommand { get; }
    public CommandBase SearchByCommand { get; }
    public CommandBase ExportToCommand { get; }
    public CommandBase ComeBackCommand { get; }
    public CommandBase ExitCommand { get; }
    private Recipe selectedRecipe;
    private ObservableCollection<Recipe> recipes;
    private ObservableCollection<Recipe> deletedRecipes;

    public RecipesViewModel()
    {
        this.recipes = new();
        //add items
        this.recipes.Add(new Recipe() { Name = "Cheese pasta", Description = "1.Some step\n2.Some step\n3.Some step", Type = "First Course", Kitchen = "Italian", FilePath = "\\Pictures\\Pasta1.jpg" });
        this.recipes.Add(new Recipe() { Name = "Moxito", Description = "1.Some step\n2.Some step", Type = "Drink", Kitchen = "Chinese", FilePath = "\\Pictures\\mojito.jpg" });
        //
        this.deletedRecipes = new();
        this.AddRecipeCommand = new(AddRecipe);
        this.EditRecipeCommand = new(EditRecipe);
        this.RemoveRecipeCommand = new(RemoveRecipe);
        this.SearchByCommand = new(SearchBy);
        this.ExportToCommand = new(ExportTo);
        this.ComeBackCommand = new(ComeBack);
        this.ExitCommand = new(Exit);
    }

    private void AddRecipe(object obj)
    {
        SingleRecipeView singleRecipeView = new();
        SingleRecipeViewModel singleRecipeViewModel = new(this.recipes);
        singleRecipeView.DataContext = singleRecipeViewModel;
        singleRecipeView.ShowDialog();
    }

    private void EditRecipe(object obj)
    {
        if (this.selectedRecipe == null)
        {
            MessageBox.Show("You didn't select a recipe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        SingleRecipeView singleRecipeView = new();
        SingleRecipeViewModel singleRecipeViewModel = new(this.recipes, this.selectedRecipe);
        singleRecipeView.DataContext = singleRecipeViewModel;
        singleRecipeView.ShowDialog();
    }

    private void RemoveRecipe(object obj)
    {
        if (this.selectedRecipe == null)
        {
            MessageBox.Show("You didn't select a recipe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        recipes.Remove(this.selectedRecipe);
    }

    private void SearchBy(object obj)
    {
        SearchByView searchByView = new();
        SearchByViewModel searchByViewModel = new(recipes, deletedRecipes);
        searchByView.DataContext = searchByViewModel;
        searchByView.ShowDialog();
    }

    private void ExportTo(object obj)
    {
        ExportToView exportToView = new();
        ExportToViewModel exportToViewModel = new(this.selectedRecipe);
        exportToView.DataContext = exportToViewModel;
        exportToView.ShowDialog();
    }

    private void ComeBack(object obj)
    {
        if (this.deletedRecipes.Count > 0)
        {
            foreach (var item in deletedRecipes)
                this.recipes.Add(item);
            this.deletedRecipes.Clear();
        }
    }

    private void Exit(object obj)
    {
        App.Current.Shutdown();
    }

    public IEnumerable<Recipe> Recipes
    {
        get
        {
            return recipes;
        }
        set
        {
            recipes = value as ObservableCollection<Recipe>;
            OnPropertyChanged();
        }
    }

    public Recipe SelectedRecipe
    {
        get
        {
            return this.selectedRecipe;
        }
        set
        {
            this.selectedRecipe = value;
            OnPropertyChanged();
        }
    }
}
