using CulinaryRecipes.Models;
using CulinaryRecipes.Commands;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace CulinaryRecipes.ViewModels;

public class SingleRecipeViewModel : ViewModelBase
{
    private Recipe currentRecipe;
    private Recipe oldRecipe;
    public CommandBase OkCommand { get; }
    public CommandBase CancelCommand { get; }
    public CommandBase ChooseImageCommand { get; }
    private ObservableCollection<Recipe> recipes;

    public SingleRecipeViewModel(ObservableCollection<Recipe> recipes)
    {
        this.recipes = recipes;
        this.currentRecipe = new();
        this.OkCommand = new(Ok);
        this.CancelCommand = new(Cancel);
        this.ChooseImageCommand = new(ChooseImage);
    }

    public SingleRecipeViewModel(ObservableCollection<Recipe> recipes, Recipe oldRecipe)
    {
        this.oldRecipe = oldRecipe;
        this.recipes = recipes;
        this.currentRecipe = new();
        this.currentRecipe.Name = oldRecipe.Name;
        this.currentRecipe.Description = oldRecipe.Description;
        this.currentRecipe.Type = oldRecipe.Type;
        this.currentRecipe.Kitchen = oldRecipe.Kitchen;
        this.currentRecipe.FilePath = oldRecipe.FilePath;
        this.OkCommand = new(Ok);
        this.CancelCommand = new(Cancel);
        this.ChooseImageCommand = new(ChooseImage);
    }

    public void Ok(object obj)
    {
        if (currentRecipe.Conflicts() == false)
            recipes.Add(currentRecipe);
        if (this.oldRecipe != null)
            recipes.Remove(this.oldRecipe);
        App.Current.Windows[1].Close();
    }

    public void Cancel(object obj)
    {
        App.Current.Windows[1].Close();
    }

    public void ChooseImage(object obj)
    {
        OpenFileDialog openFileDialog = new();
        openFileDialog.Filter = "BMP|*.bmp" +
            "|GIF|*.gif" +
            "|JPG|*.jpg;*.jpeg" +
            "|PNG|*.png" +
            "|TIFF|*.tif;*.tiff";
        if (openFileDialog.ShowDialog() == true)
        {
            this.currentRecipe.FilePath = openFileDialog.FileName;
        }
    }

    public string Name
    {
        get
        {
            return currentRecipe.Name;
        }
        set
        {
            currentRecipe.Name = value;
            OnPropertyChanged();
        }
    }

    public string Description
    {
        get
        {
            return currentRecipe.Description;
        }
        set
        {
            currentRecipe.Description = value;
            OnPropertyChanged();
        }
    }

    public string Type
    {
        get
        {
            return currentRecipe.Type;
        }
        set
        {
            currentRecipe.Type = value;
            OnPropertyChanged();
        }
    }

    public string Kitchen
    {
        get
        {
            return currentRecipe.Kitchen;
        }
        set
        {
            currentRecipe.Kitchen = value;
            OnPropertyChanged();
        }
    }

    public string FilePath
    {
        get
        {
            return currentRecipe.FilePath;
        }
        set
        {
            currentRecipe.FilePath = value;
            OnPropertyChanged();
        }
    }
}
