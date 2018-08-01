using System.Collections.Generic;
using Jellyfish.Feeds;

namespace Jellyfish.Tests.Data
{
    public class UsersWindow : FeedNode<IUser>
    {
        public IList<IUser> Users { get; }

        public UsersWindow()
        {
            Users = new List<IUser>();
        }

        protected override void MessageReceived(IUser message)
        {
            Users.Add(message);
        }
    }
}
