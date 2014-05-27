
namespace PEFileFormat.Extensions
{
    public static class ULongExtension
    {
        public static ulong BoundaryToMerge4Byte(this ulong value)
        {
            return value + (value % 4 != 0 ? (4 - value % 4) : 0);
        }
    }
}
