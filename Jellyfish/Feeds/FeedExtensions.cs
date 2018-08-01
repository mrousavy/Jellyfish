namespace Jellyfish.Feeds
{
    /// <summary>
    ///     Extension methods for the <see cref="IFeedNode{TMessage}"/> interface
    /// </summary>
    public static class FeedExtensions
    {
        /// <summary>
        ///     Subscribe to the feed of type `<see cref="TMessage"/>`
        /// </summary>
        /// <typeparam name="TMessage">The type of the message for this feed</typeparam>
        /// <param name="feed">This feed instance</param>
        public static void Subscribe<TMessage>(this IFeedNode<TMessage> feed)
        {
            Feed<TMessage>.Instance.MessageReceived += feed.MessageReceived;
        }
    }
}
