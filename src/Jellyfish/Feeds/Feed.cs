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
    }
}