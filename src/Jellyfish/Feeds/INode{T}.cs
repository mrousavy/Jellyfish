namespace Jellyfish.Feeds
{
    /// <summary>
    ///     A single node in the <see cref="IFeed{TMessage}"/> network
    /// </summary>
    /// <typeparam name="TMessage">The type of the message this node can receive</typeparam>
    public interface INode<in TMessage>
    {
        /// <summary>
        ///     The callback for receiving new messages from the <see cref="IFeed{TMessage}"/>
        /// </summary>
        /// <param name="message">The message that was sent</param>
        void MessageReceived(TMessage message);
    }
}
