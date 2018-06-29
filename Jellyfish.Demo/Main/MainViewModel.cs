using System;
using System.Threading;
using System.Windows.Input;
using Jellyfish.Demo.Feeds;
using Jellyfish.Demo.User;

namespace Jellyfish.Demo.Main
{
    public class MainViewModel : ViewModel
    {
        private readonly Random _random = new Random();

        private OperatingSystem _selectedOperatingSystem;

        public OperatingSystem SelectedOperatingSystem
        {
            get => _selectedOperatingSystem;
            set => Set(ref _selectedOperatingSystem, value);
        }

        private ICommand _openUserCommand;

        public ICommand OpenUserCommand
        {
            get => _openUserCommand;
            set => Set(ref _openUserCommand, value);
        }

        private ICommand _openFeedsCommand;

        public ICommand OpenFeedsCommand
        {
            get => _openFeedsCommand;
            set => Set(ref _openFeedsCommand, value);
        }


        [Property]
        public string TestProperty { get; set; }

        public MainViewModel()
        {
            OpenFeedsCommand = new RelayCommand(OpenFeedsAction);
            OpenUserCommand = new RelayCommand(OpenUserAction);

            var timer = new Timer(TimerCallback);

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
            TestProperty = random == 0 ? "zero" : "one";
        }

        private void OnMessageReceived(object message)
        {
            Console.WriteLine(message);
        }
    }
}