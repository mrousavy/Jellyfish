using System;
using System.Threading;
using System.Windows.Input;
using Jellyfish.Attributes;
using Jellyfish.Demo.Feeds;
using Jellyfish.Demo.Injection;
using Jellyfish.Demo.User;

namespace Jellyfish.Demo.Main
{
    public class MainViewModel : ViewModel
    {
        private readonly Random _random = new Random();

        private ICommand _openFeedsCommand;

        private ICommand _openInjectionCommand;

        private ICommand _openUserCommand;

        private OperatingSystem _selectedOperatingSystem;

        public MainViewModel()
        {
            OpenFeedsCommand = new RelayCommand(OpenFeedsAction);
            OpenUserCommand = new RelayCommand(OpenUserAction);
            OpenInjectionCommand = new RelayCommand(OpenInjectionAction);

            var _ = new Timer(TimerCallback, null, 0, 1000);

            // Load preferences from %AppData%/.../...json
            var prefs = new DemoPreferences(Preferences.RecommendedPath);
            prefs.Save();

            // Load and save preferences to %AppData%/.../...json
            var prefsLoaded = Preferences.Load<DemoPreferences>(Preferences.RecommendedPath);
            prefsLoaded.Save();

            // Open the `string` feed
            var feed = MessageFeed<string>.Feed;
            feed.MessageReceived += OnMessageReceived;
            feed.Notify("hello world!");
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

        [Dependency(typeof(MessageFeed<string>))]
        public IFeed<string> TestProperty { get; set; }

        [Dependency(typeof(MessageFeed<string>))]
        private IFeed<string> TestField;

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

        private void OnMessageReceived(object message)
        {
            Console.WriteLine(message);
        }
    }
}