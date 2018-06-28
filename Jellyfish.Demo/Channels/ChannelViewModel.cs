using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Jellyfish.Demo.Channels
{
    public class ChannelViewModel : ViewModel
    {
        private MessageChannel<string> Channel { get; }

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

        public ChannelViewModel()
        {
            Channel = MessageChannel<string>.Channel;
            Messages = new ObservableCollection<string>();

            NotifyCommand = new RelayCommand(NotifyAction);
            Channel.MessageReceived += OnMessageReceived;
        }

        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }

        private void NotifyAction(object o)
        {
            Channel.Notify(CurrentMessage);
        }
    }
}
