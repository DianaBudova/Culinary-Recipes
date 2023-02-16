using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CulinaryRecipes.Models;

public class Recipe : INotifyPropertyChanged
{
    private string name;
    private string description;
    private string type;
    private string kitchen;
    private string filePath;

    public bool Conflicts()
    {
        if (this.name == null)
            if (this.description == null)
                if (this.type == null)
                    if (this.kitchen == null)
                        if (this.filePath == null)
                            return true;
        return false;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
            OnPropertyChanged();
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
            OnPropertyChanged();
        }
    }

    public string Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
            OnPropertyChanged();
        }
    }

    public string Kitchen
    {
        get
        {
            return kitchen;
        }
        set
        {
            kitchen = value;
            OnPropertyChanged();
        }
    }

    public string FilePath
    {
        get
        {
            return filePath;
        }
        set
        {
            filePath = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
