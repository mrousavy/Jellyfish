using System.Collections.ObjectModel;
using System.Windows.Input;
using Jellyfish.Feeds;

namespace Jellyfish.Demo.Feeds
{
    public class FeedViewModel : ViewModel
    {
        private string _currentMessage;

        private ObservableCollection<string> _messages;

        private ICommand _notifyCommand;

        public FeedViewModel()
        {
            Messages = new ObservableCollection<string>();
            Feed<string>.Instance.MessageReceived += MessageReceived;

            NotifyCommand = new RelayCommand(NotifyAction);
        }

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

        private void MessageReceived(string message)
        {
            Messages.Add(message);
        }

        private void NotifyAction(object o)
        {
            Feed.Notify(CurrentMessage);
        }
    }
}