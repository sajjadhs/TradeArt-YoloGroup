using System;
using System.Linq;
using System.Text;

namespace Test___TradeArt_YoloGroup.Utilities
{
    public static class StringHelper
    {

        public static string InvertText(this string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = text.Length-1; i >=0; i--)
            {
                stringBuilder.Append(text[i]);
            }
            return stringBuilder.ToString();
        }

        #region old Method
        //[Obsolete("This method is deprecated, please use InvertText")]
        //public static string InvertText(this string text)
        //{
        //    var chars = text.ToCharArray();
        //    Array.Reverse(chars);
        //    return new string(chars);
        //}
        #endregion
    }
}
