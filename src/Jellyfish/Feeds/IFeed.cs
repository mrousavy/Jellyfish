using System;
using System.Collections.Generic;

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
        ///     Register a new node in this <see cref="IFeed{TMessage}"/> network
        /// </summary>
        /// <param name="node">The node to register</param>
        /// <exception cref="ArgumentException">
        ///     Thrown if the given node is already registered in this network
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the node is null
        /// </exception>
        void RegisterNode(INode<TMessage> node);

        /// <summary>
        ///     Unregister a node in this <see cref="IFeed{TMessage}"/> network
        /// </summary>
        /// <param name="node">The node to unregister</param>
        /// <exception cref="ArgumentException">
        ///     Thrown if the given node is not registered in this network
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if the node is null
        /// </exception>
        void UnregisterNode(INode<TMessage> node);
    }
}