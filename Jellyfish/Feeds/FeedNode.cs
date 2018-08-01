namespace Jellyfish.Feeds
{
    /// <summary>
    ///     Represents a single node in the <see cref="IFeed{TMessage}"/> network.
    ///     Inherit from this class to notify and receive in this feed.
    /// </summary>
    /// <typeparam name="TMessage">The type of the message to notify and receive</typeparam>
    public interface IFeedNode<in TMessage>
    {
        /// <summary>
        ///     The callback for a message of type <see cref="TMessage"/> received
        /// </summary>
        void MessageReceived(TMessage message);
    }
}
