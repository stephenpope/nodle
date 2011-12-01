using System;

namespace Nodle.Distribution
{
    /// <summary>
    /// Simple implementation of a message
    /// </summary>
    public class NodleMessage: INodleMessage
    {
        /// <summary>
        /// Gets the time the send created the message
        /// </summary>
        public DateTime Created { get; private set; }

        /// <summary>
        /// The message body.  Contents will vary based on the object sent
        /// </summary>
        public object Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodleMessage"/> class.
        /// </summary>
        public NodleMessage()
        {
            Created = DateTime.Now;
        }
    }
}