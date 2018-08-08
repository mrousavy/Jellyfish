using System;
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
            References = new List<WeakReference<INode<TMessage>>>();
        }

        /// <summary>
        ///     Get the feed for the given type `<see cref="TMessage" />`
        /// </summary>
        public static IFeed<TMessage> Instance => _instance ?? (_instance = new Feed<TMessage>());

        public IList<TMessage> Messages { get; }
        private IList<INode<TMessage>> Nodes => GetReferences();
        private IList<WeakReference<INode<TMessage>>> References { get; }

        public void Notify(TMessage message)
        {
            Messages.Add(message);
            foreach (var node in Nodes)
            {
                node.MessageReceived(message);
            }
        }

        public void RegisterNode(INode<TMessage> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            if (Nodes.Contains(node))
            {
                throw new ArgumentException($"The feed for type {typeof(TMessage).Name} already contains this node!");
            }

            var weakRef = new WeakReference<INode<TMessage>>(node);
            References.Add(weakRef);
        }

        private IList<INode<TMessage>> GetReferences()
        {
            var nodes = new List<INode<TMessage>>();
            foreach (var reference in References)
            {
                bool received = reference.TryGetTarget(out var node);
                if (received)
                {
                    nodes.Add(node);
                }
            }

            return nodes;
        }
    }
}