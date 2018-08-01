using System.Collections.Generic;
using Jellyfish.Feeds;

namespace Jellyfish.Tests.Data
{
    public class UsersWindow : IFeedNode<IUser>
    {
        public IList<IUser> Users { get; }

        public UsersWindow()
        {
            Users = new List<IUser>();
            this.Subscribe();
        }

        public void MessageReceived(IUser message)
        {
            Users.Add(message);
        }
    }
}
