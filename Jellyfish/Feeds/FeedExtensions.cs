namespace Jellyfish.Feeds
{
    /// <summary>
    ///     Extension methods for the <see cref="IFeedNode{TMessage}"/> interface
    /// </summary>
    public static class FeedExtensions
    {
        /// <summary>
        ///     Notify all <see cref="IFeed{TMessage}.MessageReceived" /> subscribers in this feed with the given <see cref="message" />
        /// </summary>
        /// <typeparam name="TMessage">The type of the message for this feed</typeparam>
        /// <param name="feed">This feed instance</param>
        /// <param name="message">The message to notify all subscribers about</param>
        public static void Notify<TMessage>(this IFeedNode<TMessage> feed, TMessage message)
        {
            MessageFeed<TMessage>.Feed.Notify(message);
        }

        /// <summary>
        ///     Subscribe to the feed of type `<see cref="TMessage"/>`
        /// </summary>
        /// <typeparam name="TMessage">The type of the message for this feed</typeparam>
        /// <param name="feed">This feed instance</param>
        public static void Subscribe<TMessage>(this IFeedNode<TMessage> feed)
        {
            MessageFeed<TMessage>.Feed.MessageReceived += feed.MessageReceived;
        }
    }
}
