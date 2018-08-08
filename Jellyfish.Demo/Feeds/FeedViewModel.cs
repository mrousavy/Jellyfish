using System.Collections.ObjectModel;
using System.Windows.Input;
using Jellyfish.Extensions;
using Jellyfish.Feeds;

namespace Jellyfish.Demo.Feeds
{
    public class FeedViewModel : ViewModel, INode<string>
    {
        private string _currentMessage;

        private ObservableCollection<string> _messages;

        private ICommand _notifyCommand;

        public FeedViewModel()
        {
            this.Register();
            Messages = new ObservableCollection<string>();

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

        public void MessageReceived(string message)
        {
            Messages.Add(message);
        }

        private void NotifyAction(object o)
        {
            Feed.Notify(CurrentMessage);
        }
    }
}