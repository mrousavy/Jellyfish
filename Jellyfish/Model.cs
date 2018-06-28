namespace Jellyfish
{
    /// <summary>
    ///     The base class of any Model in the MVVM pattern providing boilerplate Model code
    /// </summary>
    public abstract class Model
    {
        /// <summary>
        ///     Get the channel for the given type `<see cref="TMessage"/>`
        /// </summary>
        /// <typeparam name="TMessage">The type of the messages this channel handles</typeparam>
        /// <returns>The opened message channel</returns>
        public MessageChannel<TMessage> ChannelFor<TMessage>() => MessageChannel<TMessage>.Channel;
    }
}
