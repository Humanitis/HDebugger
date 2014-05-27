namespace PEFileFormat
{
    using System;


    /// <summary>
    /// 
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="checkValue"></param>
        /// <param name="alwaysValue"></param>
        /// <param name="name"></param>
        public static void CheckAlways<T>(T checkValue, T alwaysValue, string name) where T : IComparable<T>
        {
            //if (checkValue.CompareTo(alwaysValue) != 0)
            //    throw new ArgumentException(String.Format("{0}={1} must be equal {2}", name, checkValue, alwaysValue));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="checkValue"></param>
        /// <param name="alwaysValueOne"></param>
        /// <param name="alwaysValueTwo"></param>
        /// <param name="name"></param>
        public static void CheckAlways<T>(T checkValue, T alwaysValueOne, T alwaysValueTwo, string name) where T : IComparable<T>
        {
            //if (checkValue.CompareTo(alwaysValueOne) != 0 && checkValue.CompareTo(alwaysValueTwo) != 0)
            //    throw new ArgumentException(String.Format("{0}={1} must be equal {2} or {3}", name, checkValue, alwaysValueOne, alwaysValueTwo));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkValue"></param>
        /// <param name="enumType"></param>
        /// <param name="name"></param>
        public static void CheckAlways(object checkValue, Type enumType,  string name) 
        {
            if (!Enum.IsDefined(enumType,checkValue))
                throw new ArgumentException(String.Format("{0}={1} must be belong {2}", name, checkValue, enumType));
        }
    }
}
