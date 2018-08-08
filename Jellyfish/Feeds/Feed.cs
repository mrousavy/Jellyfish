namespace Jellyfish.Feeds
{
    /// <summary>
    ///     A static helper class for notifying feeds
    /// </summary>
    public static class Feed
    {
        /// <summary>
        ///     Notify all nodes in this feed with the given <see cref="!:message" />
        /// </summary>
        /// <typeparam name="TMessage">The type of the message this feed notifies about</typeparam>
        /// <param name="message">The message to notify all nodes about</param>
        public static void Notify<TMessage>(TMessage message)
        {
            Feed<TMessage>.Instance.Notify(message);
        }

        /// <summary>
        ///     Register the given node in the <see cref="IFeed{TMessage}"/> network
        /// </summary>
        /// <typeparam name="TMessage">The type of the message this feed notifies about</typeparam>
        /// <param name="node">The node to register in the network</param>
        public static void Register<TMessage>(INode<TMessage> node)
        {
            Feed<TMessage>.Instance.RegisterNode(node);
        }
    }
}