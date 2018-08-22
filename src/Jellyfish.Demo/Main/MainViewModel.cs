using System;
using System.Threading;
using System.Windows.Input;
using Jellyfish.Attributes;
using Jellyfish.Demo.Feeds;
using Jellyfish.Demo.Injection;
using Jellyfish.Demo.User;
using Jellyfish.Extensions;
using Jellyfish.Feeds;

namespace Jellyfish.Demo.Main
{
    public class MainViewModel : ViewModel, INode<string>
    {
        private readonly Random _random = new Random();

        private ICommand _openFeedsCommand;

        private ICommand _openInjectionCommand;

        private ICommand _openUserCommand;

        private OperatingSystem _selectedOperatingSystem;

        public MainViewModel()
        {
            this.Register();
            OpenFeedsCommand = new RelayCommand(OpenFeedsAction);
            OpenUserCommand = new RelayCommand(OpenUserAction);
            OpenInjectionCommand = new RelayCommand(OpenInjectionAction);

            var _ = new Timer(TimerCallback, null, 0, 1000);

            // Save new preferences to %AppData%/.../...json
            var prefs = new DemoPreferences();
            Preferences.Save(prefs, Preferences.RecommendedPath);

            // Load and save preferences to %AppData%/.../...json
            var prefsLoaded = Preferences.Load<DemoPreferences>(Preferences.RecommendedPath);

            // Send to the `string` feed
            Feed.Notify("hello world!");
        }

        public OperatingSystem SelectedOperatingSystem
        {
            get => _selectedOperatingSystem;
            set => Set(ref _selectedOperatingSystem, value);
        }

        public ICommand OpenUserCommand
        {
            get => _openUserCommand;
            set => Set(ref _openUserCommand, value);
        }

        public ICommand OpenInjectionCommand
        {
            get => _openInjectionCommand;
            set => Set(ref _openInjectionCommand, value);
        }

        public ICommand OpenFeedsCommand
        {
            get => _openFeedsCommand;
            set => Set(ref _openFeedsCommand, value);
        }

        [Dependency]
        public IFeed<string> TestProperty { get; set; }

        private void OpenInjectionAction(object o)
        {
            new InjectionWindow().Show();
        }

        private void OpenUserAction(object o)
        {
            new UserWindow().Show();
        }

        private void OpenFeedsAction(object o)
        {
            new FeedWindow().Show();
        }


        private void TimerCallback(object state)
        {
            int random = _random.Next(1);
            //TestProperty = random == 0 ? "zero" : "one";
            //Console.WriteLine(TestProperty);
        }

        public void MessageReceived(string message)
        {
            Console.WriteLine(message);
        }
    }
}