using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BananaUtils
{
    public static class StreamExtensions
    {
        /// <summary>
        /// Tries to read the given number of bytes and throws if there weren't enough.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to read from.</param>
        /// <param name="count">How many bytes have to be read.</param>
        /// <returns>An array containing the given number of bytes.</returns>
        public static byte[] ReallyRead(this Stream stream, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("count", "Count can't be less than zero.");

            var result = new byte[count];
            var offset = 0;

            while (count - offset > 0)
            {
                var read = stream.Read(result, offset, count - offset);

                if (read == 0)
                    throw new IOException("Stream ended before enough bytes were received.");

                offset += read;
            }

            return result;
        }
    }
}