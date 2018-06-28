<p align="center">
  <img src="https://github.com/mrousavy/Jellyfish/raw/master/Images/jellyfish.png" height="120" />
  <h3 align="center">Jellyfish</h3>
  <p align="center">
	<a class="badge-align" href="https://www.codacy.com/app/mrousavy/Jellyfish?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=mrousavy/Jellyfish&amp;utm_campaign=Badge_Grade"><img src="https://api.codacy.com/project/badge/Grade/b677d8c1fa194835b42b7b6266a39b6b"/></a>
	<a href="https://ci.appveyor.com/project/mrousavy/jellyfish/"><img src="https://ci.appveyor.com/api/projects/status/o7nxq777rlqmr082?svg=true" alt="AppVeyor badge"></a>
	<a href="https://www.nuget.org/packages/Jellyfish/"><img src="https://img.shields.io/nuget/dt/Jellyfish.svg" alt="NuGet downloads badge"></a>
	<h3 align="center">🐟</h3>
  </p>
  <blockquote align="center">
  	<p align="center">
  		An incredibly <strong>light</strong> and type safe <strong>MVVM library</strong> for .NET WPF, Silverlight, Xamarin and UWP
	  </p>
  </blockquote>
</p>

Jellyfish is on [NuGet](https://www.nuget.org/packages/Jellyfish/):
```pm
PM> Install-Package Jellyfish
```

Compared to other **MVVM Frameworks** like [MVVM Light](http://www.mvvmlight.net/), [Prism](https://github.com/PrismLibrary/Prism) or [Caliburn.Micro](https://caliburnmicro.com/), this framework is
* as light as possible
* using modern best-practices
* using modern code style
* exactly fitting my needs


# Usage

For description, documentation and usage, please view the [Jellyfish wiki 📖](https://github.com/mrousavy/Jellyfish/wiki) or the [Getting Started guide 📖](https://github.com/mrousavy/Jellyfish/wiki/Getting-started).

## View Models [📖](https://github.com/mrousavy/Jellyfish/wiki/ViewModels)
Every **ViewModel** needs to implement the [`ViewModel`](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/ViewModel.cs) class:

```cs
public class LoginViewModel : ViewModel
{
    ...
}
```

The `ViewModel` base class inherits from [`ObservableObject`](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/ObservableObject.cs) (see: [View Models or Observable Objects 📖](https://github.com/mrousavy/Jellyfish/wiki/ViewModels-or-ObservableObjects)).

Using the `ObservableObject` base class [`Set`](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/ObservableObject.cs#L37) function allows for quick notifying properties:

```cs
private User _user;
public User User
{
    get => _user;
    set => Set(ref _user, value);
}
```

> If you are using [ReSharper](https://www.jetbrains.com/resharper/) you can define a [notify-property-changed-property template](https://github.com/mrousavy/Jellyfish/wiki/ReSharper-NPP-Template).

## Commands [📖](https://github.com/mrousavy/Jellyfish/wiki/Commands)
The [`RelayCommand`](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/RelayCommand.cs) is an [`ICommand`](https://msdn.microsoft.com/en-us/library/system.windows.input.icommand(v=vs.110).aspx) implementation.

```xaml
<Window ...>
    <Button Command="{Binding LoginCommand}" />
</Window>
```

Initialize the `ICommand` with a non-generic `RelayCommand` instance and the given action/callback:
```cs
ICommand LoginCommand = new RelayCommand(LoginAction);
// ...
void LoginAction(object parameter)
{ ... }
```

## Enums [📖](https://github.com/mrousavy/Jellyfish/wiki/Enums)
The enum binding source extension allows for better binding support on enums.

Just use the [EnumBindingSource extension](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/Extensions/EnumBindingSourceExtension.cs) to bind an enum to any `ItemsSource`:
```xaml
<ComboBox ItemsSource="{Binding Source={jellyfish:EnumBindingSource {x:Type local:Status}}}"
	  SelectedItem="{Binding SelectedStatus}" />
```

It even allows [Description](https://msdn.microsoft.com/en-us/library/system.componentmodel.descriptionattribute(v=vs.110).aspx) support:
```cs
[TypeConverter(typeof(EnumDescriptionTypeConverter))]
enum Status
{
    [Description("Everything went fine")]
    Ok,
    [Description("Everything went horribly wrong")]
    Error
}
```

## Preferences [📖](https://github.com/mrousavy/Jellyfish/wiki/Preferences)
An abstract class definition for any application preferences.

Create a new class that will hold your app preferences which inherits from the [`Preferences`](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/Preferences.cs) class:
```cs
public class DemoPreferences : Preferences
{
    public int SomeInt { get; set; } = 400;
    public string SomeString { get; set; } = "test string";
    public bool SomeBool { get; set; } = false;

    public object SomeObject { get; set; } = new
    {
        Name = "Marc",
        IsValid = true
    };
}
```

The generated `config.json` file looks like this:
```json
{
   "SomeInt":400,
   "SomeString":"test string",
   "SomeBool":false,
   "SomeObject":{
      "Name":"Marc",
      "IsValid":true
   }
}
```

## Message Channels [📖](https://github.com/mrousavy/Jellyfish/wiki/Message-Channels)
The [`MessageChannel`](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/MessageChannel.cs) allows sending objects within the current application domain.

```cs
var channel = MessageChannel<string>.Channel;
channel.Notify("Hello other ViewModels!");
```


# Results
### With Jellyfish
```cs
public class LoginViewModel : ObservableObject
{
    [Property]
    public string Username { get; set; }
}
```

### Without Jellyfish
```cs
public class LoginViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
          PropertyChangedEventHandler handler = PropertyChanged;
          if (handler != null)
          {
              handler(this, new PropertyChangedEventArgs(propertyName));
          }
    }

    private string _username;
    public string Username
    {
        get
	{
	    return _username;
	}
	set
	{
	    _username = value;
	    OnPropertyChanged("Username");
	}
    }
}
```
