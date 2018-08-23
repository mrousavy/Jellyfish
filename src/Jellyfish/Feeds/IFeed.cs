using System;

namespace Jellyfish.Feeds
{
    /// <summary>
    ///     A method delegate representing a message received event handler
    /// </summary>
    /// <param name="message">The message that was received by the sender</param>
    /// <typeparam name="TMessage">The type of the messages this delegate accepts</typeparam>
    public delegate void MessageReceivedHandler<in TMessage>(TMessage message);

    /// <summary>
    ///     An event based feed in the message network to notify any observers about new data. There is a feed for each type `
    ///     <see cref="TMessage" />`
    /// </summary>
    /// <typeparam name="TMessage">The type of the messages this feed handles</typeparam>
    public interface IFeed<TMessage>
    {
        /// <summary>
        ///     Notify all nodes in this feed with the given <see cref="message" />
        /// </summary>
        /// <param name="message">The message to notify all nodes about</param>
        void Notify(TMessage message);

        /// <summary>
        ///     Subscribe a new node to this <see cref="IFeed{TMessage}"/> network
        /// </summary>
        /// <param name="node">The node to subscribe</param>
        /// <exception cref="ArgumentException">
        ///     Thrown if the given node is already subscribed to this network
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the node is null
        /// </exception>
        void SubscribeNode(INode<TMessage> node);

        /// <summary>
        ///     Unsubscribe a node from this <see cref="IFeed{TMessage}"/> network
        /// </summary>
        /// <param name="node">The node to unsubscribe</param>
        /// <exception cref="ArgumentException">
        ///     Thrown if the given node is not subscribed in this network
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the node is null
        /// </exception>
        void UnsubscribeNode(INode<TMessage> node);
    }
}