using System;
using System.Runtime.Serialization;

namespace Sharpdev.SDK.DataSources.Databases
{
    [Serializable]
    public class DataSourceInnerException: Exception
    {
        public DataSourceInnerException()
        {
        }

        public DataSourceInnerException(string message): base(message)
        {
        }

        public DataSourceInnerException(string message, Exception inner): base(message, inner)
        {
        }

        protected DataSourceInnerException(SerializationInfo info,
                              StreamingContext context): base(info, context)
        {
        }
    }
}
