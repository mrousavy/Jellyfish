namespace Jellyfish
{
    /// <summary>
    ///     An event based channel in the message network, observable for notifications by receivers. There is a channel for each type `<see cref="TMessage"/>`
    /// </summary>
    /// <typeparam name="TMessage">The type of the messages this channel handles</typeparam>
    public class MessageChannel<TMessage>
    {
        private static MessageChannel<TMessage> _instance;

        /// <summary>
        ///     Get the channel for the given type `<see cref="TMessage"/>`
        /// </summary>
        public static MessageChannel<TMessage> Channel => _instance ?? (_instance = new MessageChannel<TMessage>());

        /// <summary>
        ///     Notify all <see cref="MessageReceived"/> subscribers in this channel with the given <see cref="message"/>
        /// </summary>
        /// <param name="message">The message to notify all subscribers about</param>
        public void Notify(TMessage message)
        {
            MessageReceived?.Invoke(message);
        }

        /// <summary>
        ///     A method delegate representing a message received event handler
        /// </summary>
        /// <param name="message">The message that was received by the sender</param>
        public delegate void MessageReceivedHandler(TMessage message);

        /// <summary>
        ///     The handleable event for messages received from a sender's <see cref="Notify"/> call
        /// </summary>
        public event MessageReceivedHandler MessageReceived;
    }
}
