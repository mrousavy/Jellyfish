using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Jellyfish.Demo.Feeds
{
    public class FeedViewModel : ViewModel
    {
        private string _currentMessage;

        private ObservableCollection<string> _messages;

        private ICommand _notifyCommand;

        public FeedViewModel()
        {
            Feed = MessageFeed<string>.Feed;
            Messages = new ObservableCollection<string>();

            NotifyCommand = new RelayCommand(NotifyAction);
            Feed.MessageReceived += OnMessageReceived;
        }

        private IFeed<string> Feed { get; }

        public string CurrentMessage
        {
            get => _currentMessage;
            set => Set(ref _currentMessage, value);
        }

        public ICommand NotifyCommand
        {
            get => _notifyCommand;
            set => Set(ref _notifyCommand, value);
        }

        public ObservableCollection<string> Messages
        {
            get => _messages;
            set => Set(ref _messages, value);
        }

        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }

        private void NotifyAction(object o)
        {
            Feed.Notify(CurrentMessage);
        }
    }
}