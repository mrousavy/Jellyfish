using Jellyfish.Forms;
using System;

namespace Jellyfish.Demo.User
{
    public class UserViewModel : ObservableObject
    {

        private string _username;

        [TextInput("Username")]
        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        private bool _receiveUpdates;

        [CheckInput("Receive daily updates")]
        public bool ReceiveUpdates
        {
            get => _receiveUpdates;
            set => Set(ref _receiveUpdates, value);
        }

        private DateTime _birthday;

        [DateInput("Birthday")]
        public DateTime Birthday
        {
            get => _birthday;
            set => Set(ref _birthday, value);
        }
    }
}
