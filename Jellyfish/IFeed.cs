namespace Jellyfish
{

    /// <summary>
    ///     A method delegate representing a message received event handler
    /// </summary>
    /// <param name="message">The message that was received by the sender</param>
    /// <typeparam name="TMessage">The type of the messages this delegate accepts</typeparam>
    public delegate void MessageReceivedHandler<TMessage>(TMessage message);

    /// <summary>
    ///     An event based feed in the message network to notify any observers about new data. There is a feed for each type `<see cref="TMessage"/>`
    /// </summary>
    /// <typeparam name="TMessage">The type of the messages this feed handles</typeparam>
    public interface IFeed<TMessage>
    {
        /// <summary>
        ///     Notify all <see cref="MessageReceived"/> subscribers in this feed with the given <see cref="message"/>
        /// </summary>
        /// <param name="message">The message to notify all subscribers about</param>
        void Notify(TMessage message);

        /// <summary>
        ///     The handleable event for messages received from a sender's <see cref="Notify"/> call
        /// </summary>
        event MessageReceivedHandler<TMessage> MessageReceived;
    }
}
