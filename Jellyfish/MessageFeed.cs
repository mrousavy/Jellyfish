namespace Jellyfish
{
    /// <summary>
    ///     An event based feed in the message network to notify any observers about new data. There is a feed for each type `<see cref="TMessage"/>`
    /// </summary>
    /// <typeparam name="TMessage">The type of the messages this feed handles</typeparam>
    public class MessageFeed<TMessage> : IFeed<TMessage>
    {
        private static MessageFeed<TMessage> _instance;

        /// <summary>
        ///     Get the feed for the given type `<see cref="TMessage"/>`
        /// </summary>
        public static MessageFeed<TMessage> Feed => _instance ?? (_instance = new MessageFeed<TMessage>());

        /// <summary>
        ///     Notify all <see cref="MessageReceived"/> subscribers in this feed with the given <see cref="message"/>
        /// </summary>
        /// <param name="message">The message to notify all subscribers about</param>
        public void Notify(TMessage message)
        {
            MessageReceived?.Invoke(message);
        }

        /// <summary>
        ///     The handleable event for messages received from a sender's <see cref="Notify"/> call
        /// </summary>
        public event MessageReceivedHandler<TMessage> MessageReceived;
    }
}
