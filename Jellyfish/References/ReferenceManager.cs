using System;
using System.Collections.Generic;
using System.Linq;

namespace Jellyfish.References
{
    public class ReferenceManager<TReference> : IReferenceManager<TReference> where TReference : class
    {
        public ReferenceManager()
        {
            References = new List<IReference<TReference>>();
        }


        public void Register(TReference reference)
        {
            if (Has(reference))
            {
                throw new ArgumentException($"The Reference Manager already contains a reference to {reference}!");
            }
            References.Add(new Reference<TReference>(reference));
        }

        private bool Has(TReference reference) => References.Any(r => r.Value == reference);

        public IList<IReference<TReference>> References { get; }

        public IReference<TReference> this[TReference reference] => References.SingleOrDefault(r => r.Value == reference) ??
                                                                    throw new ArgumentOutOfRangeException($"This Reference Manager does not contain any active references to the reference {reference}!");
    }
}
