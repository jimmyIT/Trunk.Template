using System.Text;

namespace Template.Trunk.Shared.Extension
{
    public static class StringValueExtension
    {
        /// <summary>
        /// Extension method to convert a string to a byte array.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length">length of the byte array</param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return Array.Empty<byte>();
            }

            // Convert the string to a byte array using UTF8 encoding
            byte[] originalBytes = Encoding.UTF8.GetBytes(str);

            // Create a byte array with the specified length
            byte[] fixedLengthBytes = new byte[length];

            // Copy the original byte array to the fixed length array, truncating or padding as necessary
            Array.Copy(originalBytes, fixedLengthBytes, Math.Min(originalBytes.Length, length));

            return fixedLengthBytes;
        }
    }
}
