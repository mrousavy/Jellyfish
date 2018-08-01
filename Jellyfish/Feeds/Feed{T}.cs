using System.Collections.Generic;

namespace Jellyfish.Feeds
{
    /// <inheritdoc />
    /// <summary>
    ///     An event based feed in the message network to notify any observers about new data. There is a feed for each type `
    ///     <see cref="!:TMessage" />`
    /// </summary>
    /// <typeparam name="TMessage">The type of the messages this feed handles</typeparam>
    public class Feed<TMessage> : IFeed<TMessage>
    {
        private static IFeed<TMessage> _instance;

        /// <summary>
        ///     Initialize a new instance of the Message Feed
        /// </summary>
        public Feed()
        {
            Messages = new List<TMessage>();
        }

        /// <summary>
        ///     Get the feed for the given type `<see cref="TMessage" />`
        /// </summary>
        public static IFeed<TMessage> Instance => _instance ?? (_instance = new Feed<TMessage>());

        public IList<TMessage> Messages { get; }

        public void Notify(TMessage message)
        {
            Messages.Add(message);
            MessageReceived?.Invoke(message);
        }

        public event MessageReceivedHandler<TMessage> MessageReceived;
    }
}