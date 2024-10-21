using System.Security.Cryptography;
using System.Text;

namespace Template.Trunk.Shared.Helpers
{
    public static class StringHelper
    {
        private const string Global_Charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string Global_UpperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Global_LowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string Global_Digits = "0123456789";

        /// <summary>
        /// Generate a random string.
        /// </summary>
        /// <param name="length">length of string.</param>
        /// <returns></returns>
        public static string GetRandom(int length)
        {
            StringBuilder result = new StringBuilder(length);
            byte[] randomBytes = new byte[length];

            // Use RandomNumberGenerator to generate secure random bytes
            RandomNumberGenerator.Fill(randomBytes);

            for (int i = 0; i < length; i++)
            {
                // Use the random byte to select a character from the charset
                result.Append(Global_Charset[randomBytes[i] % Global_Charset.Length]);
            }

            return result.ToString();
        }

        /// <summary>
        /// To automatically generate a code with proper formatting by Xs and 9s.
        /// </summary>
        /// <param name="template">Default is X9XX99XX9X</param>
        /// <returns></returns>
        public static string GetRandomCode(string template = "X9XX99XX9X")
        {
            StringBuilder result = new StringBuilder(template.Length);
            byte[] randomBytes = new byte[template.Length];
            
            // Generate cryptographically secure random bytes
            RandomNumberGenerator.Fill(randomBytes);

            for (int i = 0; i < template.Length; i++)
            {
                if (template[i] == 'X')
                {
                    // For 'X', choose a random letter from A-Z
                    result.Append(Global_UpperAlphabet[randomBytes[i] % Global_UpperAlphabet.Length]);
                }
                else if (template[i] == '9')
                {
                    // For '9', choose a random digit from 0-9
                    result.Append(Global_Digits[randomBytes[i] % Global_Digits.Length]);
                }
                else
                {
                    // For any other character, just append it as it is
                    result.Append(template[i]);
                }
            }

            return result.ToString();
        }
    }
}
