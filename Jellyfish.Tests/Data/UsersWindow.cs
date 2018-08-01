using System.Collections.Generic;
using Jellyfish.Feeds;

namespace Jellyfish.Tests.Data
{
    public class UsersWindow
    {
        public IList<IUser> Users { get; }

        public UsersWindow()
        {
            Users = new List<IUser>();
            Feed<IUser>.Instance.MessageReceived += MessageReceived;
        }

        private void MessageReceived(IUser message)
        {
            Users.Add(message);
        }
    }
}
