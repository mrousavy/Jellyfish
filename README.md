<p align="center">
  <img src="https://github.com/mrousavy/Jellyfish/raw/master/Images/jellyfish.png" height="120" />
  <h3 align="center">Jellyfish</h3>
  <p align="center">
	<a class="badge-align" href="https://www.codacy.com/app/mrousavy/Jellyfish?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=mrousavy/Jellyfish&amp;utm_campaign=Badge_Grade"><img src="https://api.codacy.com/project/badge/Grade/b677d8c1fa194835b42b7b6266a39b6b"/></a>
	<a href="https://ci.appveyor.com/project/mrousavy/jellyfish/"><img src="https://ci.appveyor.com/api/projects/status/o7nxq777rlqmr082?svg=true" alt="AppVeyor badge"></a>
	<a href="https://www.nuget.org/packages/Jellyfish/"><img src="https://img.shields.io/nuget/dt/Jellyfish.svg" alt="NuGet downloads badge"></a>
	<br/>
	<a href='https://ko-fi.com/F1F8CLXG' target='_blank'><img height='36' style='border:0px;height:36px;' src='https://az743702.vo.msecnd.net/cdn/kofi2.png?v=0' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a>
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

For description, documentation and usage, please view the [Jellyfish wiki 📖](https://github.com/mrousavy/Jellyfish/wiki) or the [Getting Started guide 📖](https://github.com/mrousavy/Jellyfish/wiki/Getting-started). For usage-example projects, please see [Jellyfish.Demo](https://github.com/mrousavy/Jellyfish/tree/master/Jellyfish.Demo) or [GameFinder](https://github.com/mrousavy/GameFinder).

## 📝 View Models

Every **ViewModel** needs to implement the [`ViewModel`](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/ViewModel.cs) class:

```cs
public class LoginViewModel : ViewModel
{
    private User _user;
    public User User
    {
        get => _user;
        set => Set(ref _user, value);
    }
}
```

> See [View Models 📖](https://github.com/mrousavy/Jellyfish/wiki/📝-View-Models)

## ⚡ Commands
The [`RelayCommand`](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/RelayCommand.cs) is an [`ICommand`](https://msdn.microsoft.com/en-us/library/system.windows.input.icommand(v=vs.110).aspx) implementation.

```xaml
<Window ...>
    <Button Command="{Binding LoginCommand}" />
</Window>
```

Initialize the `ICommand` with a non-generic `RelayCommand` instance and the given action/callback:
```cs
ICommand LoginCommand = new RelayCommand(LoginAction, CanLogin);
// ...
void LoginAction(object parameter)
{ ... }
bool CanLogin(object parameter)
{ ... }
```

> See [Commands 📖](https://github.com/mrousavy/Jellyfish/wiki/⚡-Commands)

## 💉 Dependency Injection
Provide dependencies for types using the [`IInjector`](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/DependencyInjection/IInjector.cs)

At app startup:
```cs
Injector.Register<IUser>(() => new User("John", "Smith"));
Injector.Register<IDatabaseService>(() => OpenDatabaseService(username, password));
```
Some ViewModel:
```cs
class LoginViewModel
{
    IUser User { get; set; }
    IDatabaseService _service;

    LoginViewModel()
    {
        this.Inject();
    }
}
```

> See [Dependency Injection 📖](https://github.com/mrousavy/Jellyfish/wiki/%F0%9F%92%89-Dependency-Injection)

## 💾 Enums
The enum binding source extension allows for better binding support on enums.

Just use the [`EnumBindingSource` extension](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/Extensions/EnumBindingSourceExtension.cs) to bind an enum to any `ItemsSource`:
```xaml
<ComboBox ItemsSource="{Binding Source={jellyfish:EnumBindingSource {x:Type local:Status}}}"
	  SelectedItem="{Binding SelectedStatus}" />
```

> See [Enums 📖](https://github.com/mrousavy/Jellyfish/wiki/💾-Enums)

## ⚙️ Preferences
An abstract class definition for any application [`Preferences`](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/Preferences.cs).

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

> See [Preferences 📖](https://github.com/mrousavy/Jellyfish/wiki/⚙️-Preferences)

## 🔔 Feeds
The [`IFeed<T>`](https://github.com/mrousavy/Jellyfish/blob/master/Jellyfish/Feeds/IFeed.cs) allows notifying any subscribers in this feed about sudden changes within the application domain in realtime.

```cs
Feed<string>.Instance.MessageReceived += OnMessageReceived;
Feed.Notify("Hello other ViewModels!");
Feed.Notify(NotifyReason.RefreshView);
```

> See [Feeds 📖](https://github.com/mrousavy/Jellyfish/wiki/🔔-Feeds)


# Results
### With Jellyfish
```cs
public class LoginViewModel : ViewModel
{
    private User _user;
    public User User
    {
        get => _user;
        set => Set(ref _user, value);
    }
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
