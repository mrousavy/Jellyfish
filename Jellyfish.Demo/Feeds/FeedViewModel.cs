using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Jellyfish.Demo.Feeds
{
    public class FeedViewModel : ViewModel
    {
        private IFeed<string> Feed { get; }

        private string _currentMessage;
        public string CurrentMessage
        {
            get => _currentMessage;
            set => Set(ref _currentMessage, value);
        }

        private ICommand _notifyCommand;
        public ICommand NotifyCommand
        {
            get => _notifyCommand;
            set => Set(ref _notifyCommand, value);
        }

        private ObservableCollection<string> _messages;
        public ObservableCollection<string> Messages
        {
            get => _messages;
            set => Set(ref _messages, value);
        }

        public FeedViewModel()
        {
            Feed = Model.FeedFor<string>();
            Messages = new ObservableCollection<string>();

            NotifyCommand = new RelayCommand(NotifyAction);
            Feed.MessageReceived += OnMessageReceived;
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
