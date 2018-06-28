using System;
using System.Threading;
using System.Windows.Input;
using Jellyfish.Demo.Channels;
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

        private ICommand _openChannelsCommand;

        public ICommand OpenChannelsCommand
        {
            get => _openChannelsCommand;
            set => Set(ref _openChannelsCommand, value);
        }


        [Property]
        public string TestProperty { get; set; }

        public MainViewModel()
        {
            OpenChannelsCommand = new RelayCommand(OpenChannelsAction);
            OpenUserCommand = new RelayCommand(OpenUserAction);

            var timer = new Timer(TimerCallback);

            // Load preferences from %AppData%/.../...json
            var prefs = new DemoPreferences(Preferences.RecommendedPath);
            prefs.Save();

            // Load and save preferences to %AppData%/.../...json
            var prefsLoaded = Preferences.Load<DemoPreferences>(Preferences.RecommendedPath);
            prefsLoaded.Save();

            // Open the `string` channel
            var channel = MessageChannel<string>.Channel;
            channel.MessageReceived += OnMessageReceived;
            channel.Notify("hello world!");
        }

        private void OpenUserAction(object o)
        {
            new UserWindow().Show();
        }

        private void OpenChannelsAction(object o)
        {
            new ChannelWindow().Show();
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