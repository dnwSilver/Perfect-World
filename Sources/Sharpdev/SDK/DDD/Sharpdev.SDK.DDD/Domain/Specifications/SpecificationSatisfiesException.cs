using System;
using System.Runtime.Serialization;

namespace Sharpdev.SDK.Domain.Specifications
{
    [Serializable]
    public class SpecificationSatisfiesException: Exception
    {
        public SpecificationSatisfiesException()
        {
        }

        public SpecificationSatisfiesException(string message): base(message)
        {
        }

        public SpecificationSatisfiesException(string message, Exception inner): base(message, inner)
        {
        }

        protected SpecificationSatisfiesException(SerializationInfo info,
                              StreamingContext context): base(info, context)
        {
        }
    }
}
