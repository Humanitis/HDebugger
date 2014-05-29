#region description
///structure contains RVA and Size of data block wich RVA point
#endregion
namespace PEFileFormat
{
    using System;




    /// <summary>
    /// 
    /// </summary>
    public struct PairRVASize:IComparable<PairRVASize>
    {
        #region Constants
        public static readonly PairRVASize Zero = new PairRVASize(0, 0);
        #endregion




        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public PairRVASize(ulong data)
        {
            RVA = (uint)(data & 0xFFFFFFFFUL);
            Size = (uint)(data >> 32);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rva"></param>
        /// <param name="size"></param>
        public PairRVASize(uint rva, uint size)
        {
            RVA = rva;
            Size = size;
        }
        #endregion





        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public uint RVA { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint Size { get; set; }
        #endregion






        #region Operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(PairRVASize left, PairRVASize right)
        {
            return (left.RVA == right.RVA) && (left.Size == right.Size);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(PairRVASize left, PairRVASize right)
        {
            return !(left==right);
        }
        #endregion






        #region methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            PairRVASize right = (PairRVASize)obj;
            return (this.RVA == right.RVA) && (this.Size == right.Size); ;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)Size ^ (int)RVA;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("RVA = {0,10}, Size= {1,10}", RVA, Size);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(PairRVASize other)
        {
            return (int)(this.RVA + this.Size) - (int)(other.RVA + other.Size);
        }
        #endregion

    }
}
