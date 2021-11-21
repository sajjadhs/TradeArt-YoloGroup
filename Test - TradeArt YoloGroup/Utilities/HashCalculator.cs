namespace Test___TradeArt_YoloGroup.Utilities
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Collections.Generic;
    using System.Text;

    public class HashCalculator
    {
        /// <summary>
        /// Calculates SHA Hash In Hex Form
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>HEX form of SHA hash</returns>
        public string CalculateSHA1(byte[] bytes)
        {
            return ToHex(SHA1(bytes));
        }

        /// <summary>
        /// Converts bytes to HEX form
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public string ToHex(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", string.Empty).ToLower();
        }
        

        /// <summary>
        /// Calculate SHA hash 
        /// </summary>
        /// <returns></returns>
        public byte[] SHA1(byte[] input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(input);
                return hash;
            }
        }
    }
}
