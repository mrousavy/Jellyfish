namespace Jellyfish.Feeds
{
    /// <summary>
    ///     A static helper class for notifying feeds
    /// </summary>
    public static class Feed
    {
        /// <summary>
        ///     Notify all <see cref="Feed{TMessage}.MessageReceived" /> subscribers in this feed with the given
        ///     <see cref="!:message" />
        /// </summary>
        /// <param name="message">The message to notify all subscribers about</param>
        public static void Notify<TMessage>(TMessage message)
        {
            Feed<TMessage>.Instance.Notify(message);
        }
    }
}
