using Jellyfish.Feeds;

namespace Jellyfish.Extensions
{
    public static class FeedExtensions
    {
        /// <summary>
        ///     Subscribe this node to the <see cref="IFeed{TMessage}"/> network
        /// </summary>
        /// <typeparam name="TMessage">The type of the message this feed notifies about</typeparam>
        /// <param name="node">The node to subscribe in the network</param>
        public static void Subscribe<TMessage>(this INode<TMessage> node)
        {
            Feed<TMessage>.Instance.SubscribeNode(node);
        }

        /// <summary>
        ///     Unsubscribe this node from the <see cref="IFeed{TMessage}"/> network
        /// </summary>
        /// <typeparam name="TMessage">The type of the message this feed notifies about</typeparam>
        /// <param name="node">The node to unsubscribe from the network</param>
        public static void Unsubscribe<TMessage>(this INode<TMessage> node)
        {
            Feed<TMessage>.Instance.UnsubscribeNode(node);
        }
    }
}
