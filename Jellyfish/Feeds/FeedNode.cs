namespace Jellyfish.Feeds
{
    /// <summary>
    ///     Represents a single node in the <see cref="IFeed{TMessage}"/> network.
    ///     Inherit from this class to notify and receive in this feed.
    /// </summary>
    /// <typeparam name="TMessage">The type of the message to notify and receive</typeparam>
    public abstract class FeedNode<TMessage>
    {
        /// <summary>
        ///     A reference to the <see cref="IFeed{TMessage}"/> instance
        /// </summary>
        protected IFeed<TMessage> Feed => MessageFeed<TMessage>.Feed;

        protected FeedNode()
        {
            MessageFeed<TMessage>.Feed.MessageReceived += MessageReceived;
        }

        /// <summary>
        ///     Notify all <see cref="MessageReceived" /> subscribers in this feed with the given <see cref="message" />
        /// </summary>
        /// <param name="message">The message to notify all subscribers about</param>
        protected void Notify(TMessage message)
        {
            Feed.Notify(message);
        }

        /// <summary>
        ///     The callback for a message of type <see cref="TMessage"/> received
        /// </summary>
        protected abstract void MessageReceived(TMessage message);
    }
}
