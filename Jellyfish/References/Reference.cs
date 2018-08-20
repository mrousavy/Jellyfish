using System;

namespace Jellyfish.References
{
    internal class Reference<TReference> : IReference<TReference> where TReference : class
    {
        public TReference Value
        {
            get
            {
                bool valid = WeakReference.TryGetTarget(out var reference);
                return reference;
            }
        }

        public bool IsValid => WeakReference.TryGetTarget(out var _);

        private WeakReference<TReference> WeakReference { get; }

        public Reference(TReference reference)
        {
            WeakReference = new WeakReference<TReference>(reference);
        }
    }
}
