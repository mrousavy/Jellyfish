namespace Jellyfish.Observer
{
    /// <summary>
    ///     An event based node in the observer network observable for notifications by receivers
    /// </summary>
    /// <typeparam name="T">The type of the messages to receive and send</typeparam>
    public class ObservableNode<T>
    {
        /// <summary>
        ///     A method delegate representing a message received event handler
        /// </summary>
        /// <param name="message">The message that was received by the sender</param>
        public delegate void MessageReceivedHandler(T message);

        /// <summary>
        ///     The handleable event for messages received from a sender's <see cref="Send"/> call
        /// </summary>
        public event MessageReceivedHandler MessageReceived;

        /// <summary>
        ///     Send a new message of type <see cref="T"/> and notify all subscribers
        /// </summary>
        /// <param name="message">The message to put</param>
        public void Send(T message)
        {
            MessageReceived?.Invoke(message);
        }
    }
}
