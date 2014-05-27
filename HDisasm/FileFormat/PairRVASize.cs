#region description
///structure contains RVA and Size of data block wich RVA point
#endregion
using System;

namespace PEFileFormat.FileFormat
{
    public struct PairRVASize:IComparable<PairRVASize>
    {
        public static readonly PairRVASize Zero = new PairRVASize(0, 0);

        public uint RVA;
        public uint Size;

        public static bool operator ==(PairRVASize left, PairRVASize right)
        {
            return (left.RVA == right.RVA) && (left.Size == right.Size);
        }

        public static bool operator !=(PairRVASize left, PairRVASize right)
        {
            return !(left==right);
        }

        public override bool Equals(object obj)
        {
            PairRVASize right = (PairRVASize)obj;
            return (this.RVA == right.RVA) && (this.Size == right.Size); ;
        }

        public override int GetHashCode()
        {
            return (int)Size ^ (int)RVA;
        }

        public override string ToString()
        {
            return String.Format("RVA = {0,10}, Size= {1,10}", RVA, Size);
        }

        public PairRVASize(ulong data)
        {
            RVA = (uint)(data & 0xFFFFFFFFUL);
            Size = (uint)(data >> 32);
        }
        public PairRVASize(uint rva, uint size)
        {
            RVA = rva;
            Size = size;
        }

        public int CompareTo(PairRVASize other)
        {
            return (int)(this.RVA + this.Size) - (int)(other.RVA + other.Size);
        }

    }
}
