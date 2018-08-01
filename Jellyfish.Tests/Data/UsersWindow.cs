using System.Collections.Generic;
using Jellyfish.Feeds;

namespace Jellyfish.Tests.Data
{
    public class UsersWindow
    {
        public UsersWindow()
        {
            Users = new List<IUser>();
            Feed<IUser>.Instance.MessageReceived += MessageReceived;
        }

        public IList<IUser> Users { get; }

        private void MessageReceived(IUser message)
        {
            Users.Add(message);
        }
    }
}