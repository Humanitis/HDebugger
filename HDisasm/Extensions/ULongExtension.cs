namespace PEFileFormat.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ULongExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ulong BoundaryToMerge4Byte(this ulong value)
        {
            return value + (value % 4 != 0 ? (4 - value % 4) : 0);
        }
    }
}
