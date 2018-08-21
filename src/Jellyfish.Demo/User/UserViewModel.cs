using System;
using Jellyfish.Extensions;
using Jellyfish.Feeds;
using Jellyfish.Wpf.Forms;

namespace Jellyfish.Demo.User
{
    public class UserViewModel : ObservableObject, INode<string>
    {
        private DateTime _birthday;

        private bool _receiveUpdates;
        private string _username;

        public UserViewModel()
        {
            this.Register();
            // Send to the `string` feed
            Feed.Notify("hello world!");
        }

        [TextInput("Username")]
        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        [CheckInput("Receive daily updates")]
        public bool ReceiveUpdates
        {
            get => _receiveUpdates;
            set => Set(ref _receiveUpdates, value);
        }

        [DateInput("Birthday")]
        public DateTime Birthday
        {
            get => _birthday;
            set => Set(ref _birthday, value);
        }

        public void MessageReceived(string message)
        {
            Console.WriteLine(message);
        }
    }
}