# ReSharper NPP Template
> Create a custom template `npp` for `INotifyPropertyChanged` properties.


1. Go to **ReSharper > Tools > Templates Explorer..**
2. Switch to **C#** on the left side
3. Click **New Template** in the top menu bar
4. Use the following code:
```cs
private $TYPE$ $FIELDNAME$;
public $TYPE$ $PROPERTY$
{
    get => $FIELDNAME$;
    set => Set(ref $FIELDNAME$, value);
}
```
5. On the right side, set:
    * **Shortcut**: `npp`
    * **Description:** INotifyPropertyChanged Backed Field Property
    * **TYPE:** _Choose Macro_
    * **FIELDNAME:** _Suggest name for a variable_
    * **PROPERTY:** _Value of FIELDNAME with the first letter in upper case_
    
    ![NPP Template](https://raw.githubusercontent.com/mrousavy/Jellyfish/master/Images/template.png)
6. Save to apply

In any `.cs` file you can write `npp` to insert the template at the current position (needs to be a class inheriting `ViewModelBase` to work)
