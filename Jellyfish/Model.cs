namespace Jellyfish
{
    /// <summary>
    ///     The base class of any Model in the MVVM pattern providing boilerplate Model code
    /// </summary>
    public abstract class Model
    {
        /// <summary>
        ///     Get the feed for the given type `<see cref="TMessage" />`
        /// </summary>
        /// <typeparam name="TMessage">The type of the messages this feed handles</typeparam>
        /// <returns>The opened message feed</returns>
        public static IFeed<TMessage> FeedFor<TMessage>()
        {
            return MessageFeed<TMessage>.Feed;
        }
    }
}