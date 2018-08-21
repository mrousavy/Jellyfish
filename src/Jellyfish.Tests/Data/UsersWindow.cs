using System.Collections.Generic;
using Jellyfish.Extensions;
using Jellyfish.Feeds;

namespace Jellyfish.Tests.Data
{
    public class UsersWindow : INode<IUser>
    {
        public UsersWindow()
        {
            this.Register();
            Users = new List<IUser>();
        }

        public IList<IUser> Users { get; }

        public void MessageReceived(IUser message)
        {
            Users.Add(message);
        }
    }
}