using System;

namespace Common.Math
{
    /// <summary>
    /// An extension class for the between operation
    /// name pattern IsBetweenXX where X = I -> Inclusive, X = E -> Exclusive
    /// <a href="https://stackoverflow.com/a/13470099/37055"></a>
    /// </summary>
    public static class BetweenExtensions
    {
        /// <summary>
        /// Between check <![CDATA[min <= value <= max]]> 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Inclusive minimum border</param>
        /// <param name="max">Inclusive maximum border</param>
        /// <returns>return true if the value is between the min & max else false</returns>
        public static bool IsBetweenII<T>(this T value, T min, T max) where T : IComparable<T>
        {
            return (min.CompareTo(value) <= 0) && (value.CompareTo(max) <= 0);
        }
        /// <summary>
        /// Between check <![CDATA[min < value <= max]]>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Exclusive minimum border</param>
        /// <param name="max">Inclusive maximum border</param>
        /// <returns>return true if the value is between the min & max else false</returns>
        public static bool IsBetweenEI<T>(this T value, T min, T max) where T : IComparable<T>
        {
            return (min.CompareTo(value) < 0) && (value.CompareTo(max) <= 0);
        }
        /// <summary>
        /// between check <![CDATA[min <= value < max]]>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Inclusive minimum border</param>
        /// <param name="max">Exclusive maximum border</param>
        /// <returns>return true if the value is between the min & max else false</returns>
        public static bool IsBetweenIE<T>(this T value, T min, T max) where T : IComparable<T>
        {
            return (min.CompareTo(value) <= 0) && (value.CompareTo(max) < 0);
        }
        /// <summary>
        /// between check <![CDATA[min < value < max]]>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Exclusive minimum border</param>
        /// <param name="max">Exclusive maximum border</param>
        /// <returns>return true if the value is between the min & max else false</returns>
        public static bool IsBetweenEE<T>(this T value, T min, T max) where T : IComparable<T>
        {
            return (min.CompareTo(value) < 0) && (value.CompareTo(max) < 0);
        }
        /// <summary>
        /// Between check <![CDATA[min <= value <= max]]> 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Inclusive minimum border</param>
        /// <param name="max">Inclusive maximum border</param>
        /// <returns>return value between the min inclusively & max  inclusively </returns>
        public static T InBetweenII<T>(this T value, T min, T max) where T : IComparable<T>
        {
            var ret = value;
            if (min.CompareTo(value) > 0) { ret = min; }
            if (value.CompareTo(max) > 0) { ret = max; }
            return ret;
        }
        /// <summary>
        /// Between check <![CDATA[min < value <= max]]>
        /// </summary>
        /// <typeparam name="int"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Exclusive minimum border</param>
        /// <param name="max">Inclusive maximum border</param>
        /// <returns>return int between the min exclusively & max inclusively </returns>
        public static int IntBetweenEI(this int value, int min, int max)
        {
            var ret = value;
            if (min.CompareTo(value) >= 0) { ret = min + 1; }
            if (value.CompareTo(max) >= 0) { ret = max; }
            return ret;
        }
        /// <summary>
        /// between check <![CDATA[min <= value < max]]>
        /// </summary>
        /// <typeparam name="int"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Inclusive minimum border</param>
        /// <param name="max">Exclusive maximum border</param>
        /// <returns>return int between the min inclusively & max exclusively </returns>
        public static int IntBetweenIE(this int value, int min, int max)
        {
            var ret = value;
            if (min.CompareTo(value) >= 0) { ret = min; }
            if (value.CompareTo(max) >= 0) { ret = max - 1; }
            return ret;
        }
        /// <summary>
        /// between check <![CDATA[min < value < max]]>
        /// </summary>
        /// <typeparam name="int"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Exclusive minimum border</param>
        /// <param name="max">Exclusive maximum border</param>
        /// <returns>return integer between the min exclusively & max exclusively </returns>
        public static int IntBetweenEE(this int value, int min, int max)
        {
            var ret = value;
            if (min.CompareTo(value) >= 0) { ret = min + 1; }
            if (value.CompareTo(max) >= 0) { ret = max - 1; }
            return ret;
        }
    }
}