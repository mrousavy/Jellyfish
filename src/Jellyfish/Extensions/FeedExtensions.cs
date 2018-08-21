using Jellyfish.Feeds;

namespace Jellyfish.Extensions
{
    public static class FeedExtensions
    {
        /// <summary>
        ///     Register the given node in the <see cref="IFeed{TMessage}"/> network
        /// </summary>
        /// <typeparam name="TMessage">The type of the message this feed notifies about</typeparam>
        /// <param name="node">The node to register in the network</param>
        public static void Register<TMessage>(this INode<TMessage> node)
        {
            Feed<TMessage>.Instance.RegisterNode(node);
        }

        /// <summary>
        ///     Unregister the given node in the <see cref="IFeed{TMessage}"/> network
        /// </summary>
        /// <typeparam name="TMessage">The type of the message this feed notifies about</typeparam>
        /// <param name="node">The node to unregister in the network</param>
        public static void Unregister<TMessage>(this INode<TMessage> node)
        {
            Feed<TMessage>.Instance.UnregisterNode(node);
        }
    }
}
