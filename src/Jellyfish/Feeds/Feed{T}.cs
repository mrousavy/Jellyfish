using Jellyfish.References;
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
            References = new List<IReference<INode<TMessage>>>();
        }

        /// <summary>
        ///     Get the feed for the given type `<see cref="TMessage" />`
        /// </summary>
        public static IFeed<TMessage> Instance => _instance ?? (_instance = new Feed<TMessage>());

        private IList<INode<TMessage>> Nodes => GetReferences();
        private IList<IReference<INode<TMessage>>> References { get; }

        public void Notify(TMessage message)
        {
            foreach (var node in Nodes)
            {
                node.MessageReceived(message);
            }
        }

        public void RegisterNode(INode<TMessage> node)
        {
            lock (References)
            {
                if (node == null)
                {
                    throw new ArgumentNullException(nameof(node));
                }

                if (Nodes.Contains(node))
                {
                    throw new ArgumentException(
                        $"The feed for type {typeof(TMessage).Name} already contains this node!");
                }

                var reference = new Reference<INode<TMessage>>(node);
                References.Add(reference);
            }
        }

        public void UnregisterNode(INode<TMessage> node)
        {
            lock (References)
            {
                if (node == null)
                {
                    throw new ArgumentNullException(nameof(node));
                }

                if (!Nodes.Contains(node))
                {
                    throw new ArgumentException(
                        $"The feed for type {typeof(TMessage).Name} does not contain this node!");
                }

                for (int i = 0; i < References.Count; i++)
                {
                    if (References[i].Value == node)
                    {
                        References.RemoveAt(i);
                        return;
                    }
                }
            }
        }

        private IList<INode<TMessage>> GetReferences()
        {
            lock (References)
            {
                var nodes = new List<INode<TMessage>>();
                foreach (var reference in References)
                {
                    if (reference.IsValid)
                    {
                        // add to return value
                        nodes.Add(reference.Value);
                    } else
                    {
                        // remove dead reference
                        References.Remove(reference);
                    }
                }

                return nodes;
            }
        }
    }
}