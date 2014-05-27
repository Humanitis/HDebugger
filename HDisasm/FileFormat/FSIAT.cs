#region description
///The Import Lookup Table and the Import Address Table (IAT) are both one element, zero terminated arrays of
///RVAs into the Hint/Name table. Bit 31 of the RVA shall be set to 0. In a general PE file there is one entry in
///this table for every imported symbol.
#endregion
using System;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat
{
    public sealed class FSIAT : AFileStructure
    {
        private static readonly uint ALWAYS31B_HINT_NAME_TABLE_RVA = (uint)1 << 31;
        private static readonly uint ALWAYS_END_OF_TABLE = 0;

        private static readonly ulong OFFSET_HINT_NAME_TABLE_RVA = 0UL;
        private static readonly ulong OFFSET_END_OF_TABLE = 4UL;

        private uint _hintNameTableRVA;

        /// <summary>
        /// A 31-bit RVA into the Hint/Name Table. Bit 31
        ///shall be set to 0 indicating import by name.
        /// </summary>
        public uint HintNameTableRVA
        {
            get
            {
                return _hintNameTableRVA;
            }
            protected set
            {
                if ((value & ALWAYS31B_HINT_NAME_TABLE_RVA) != 0)
                    throw new ArgumentException(String.Format("HintNameTableRVA={0} must be set 21 bit in zero", value));
                _hintNameTableRVA = value;
            }
        }

        internal override void DescribeMediator()
        {
            base.DescribeMediator();//TODO:change it holder
        }

        internal override void UndescribeMediator()
        {
            base.UndescribeMediator();//TODO:change it holder
        }

        public FSIAT(byte[] reader, ulong beginOffset, AFileFormatMediator mediator)
            : base(reader, beginOffset, mediator)
        {
            HintNameTableRVA = reader.getUInt(BEGIN_OFFSET + OFFSET_HINT_NAME_TABLE_RVA);
            Helper.CheckAlways(reader.getUInt(BEGIN_OFFSET + OFFSET_END_OF_TABLE), ALWAYS_END_OF_TABLE, "End of table");
            END_OFFSET = BEGIN_OFFSET + OFFSET_END_OF_TABLE + 4;
            //TODO:End of table, shall be filled with zeros.
        }
    }
}
