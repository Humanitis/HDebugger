#region description
/*The “#~” streams contain the actual physical representations of the logical metadata tables (§22). A “#~”
stream has the following top-level structure:*/
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class SHStream : AStreamHeap
    {
        private static readonly uint ALWAYS_RESERVEDONE = 0;
        private static readonly byte ALWAYS_RESERVEDTWO = 1;

        private static readonly ulong OFFSET_RESERVEDONE = 0UL;
        private static readonly ulong OFFSET_MAJOR_VERSION = 4UL;
        private static readonly ulong OFFSET_MINOR_VERSION = 5UL;
        private static readonly ulong OFFSET_HEAP_SIZES = 6UL;
        private static readonly ulong OFFSET_RESERVEDTWO = 7UL;
        private static readonly ulong OFFSET_VALID = 8UL;
        private static readonly ulong OFFSET_SORTED = 16UL;
        private static readonly ulong OFFSET_ROWS = 24UL;
        private static readonly ulong OFFSET_TABLES = 0UL;

        private uint _reservedone;
        private byte _majorVersion;
        private byte _minorVersion;
        private HeapSizeFlag _heapSizes;
        private byte _reservedtwo;
        private ulong _valid;
        private int _validCount;
        private ulong _sorted;
        private List<uint> _rows;
        private Dictionary<TypeMetaData, List<AStreamTableRow>> _tables;

        /// <summary>
        /// Reserved, always 0
        /// </summary>
        public uint Reservedone
        {
            get { return _reservedone; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_RESERVEDONE, "Reservedone");
                _reservedone = value;
            }
        }
        /// <summary>
        /// Major version of table schemata; shall be 2
        /// </summary>
        public byte MajorVersion
        {
            get { return _majorVersion; }
            private set { _majorVersion = value; }
        }
        /// <summary>
        /// Minor version of table schemata; shall be 0
        /// </summary>
        public byte MinorVersion
        {
            get { return _minorVersion; }
            private set { _minorVersion = value; }
        }
        /// <summary>
        /// Bit vector for heap sizes.
        /// </summary>
        public HeapSizeFlag HeapSizes
        {
            get { return _heapSizes; }
            private set { _heapSizes = value; }
        }
        /// <summary>
        /// Reserved, always 1
        /// </summary>
        public byte Reservedtwo
        {
            get { return _reservedtwo; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_RESERVEDTWO, "Reservedtwo");
                _reservedtwo = value;
            }
        }
        /// <summary>
        /// Bit vector of present tables, let n be the number of bits that
        ///are 1.
        /// </summary>
        public ulong Valid
        {
            get { return _valid; }
            private set
            {
                _valid = value;
                _validCount = 0;
                ulong bit = unchecked((ulong)1 << 63);
                for (; bit > 0; bit >>= 1)
                {
                    if ((bit & _valid) != 0)
                        _validCount++;
                }
            }
        }
        public int ValidCount
        {
            get { return _validCount; }
        }
        /// <summary>
        /// Bit vector of sorted tables.
        /// </summary>
        public ulong Sorted
        {
            get { return _sorted; }
            private set { _sorted = value; }
        }
        /// <summary>
        /// Array of n 4-byte unsigned integers indicating the number of
        ///rows for each present table.
        /// </summary>
        public List<uint> Rows
        {
            get { return _rows; }
            private set { _rows = value; }
        }
        /// <summary>
        /// The sequence of physical tables.
        /// </summary>
        public Dictionary<TypeMetaData, List<AStreamTableRow>> Tables
        {
            get { return _tables; }
            private set { _tables = value; }
        }

        private SHStream()
        { }
        public SHStream(byte[] reader, ulong beginOffset, ulong offsetFromMetaData, AFileFormatMediator mediator)
            : base(reader, beginOffset, offsetFromMetaData, mediator)
        {
            Reservedone = reader.getUInt(OffsetFromMetaData + OFFSET_RESERVEDONE);
            MajorVersion = reader[OffsetFromMetaData + OFFSET_MAJOR_VERSION];
            MinorVersion = reader[OffsetFromMetaData + OFFSET_MINOR_VERSION];
            HeapSizes = (HeapSizeFlag)reader[OffsetFromMetaData + OFFSET_HEAP_SIZES];
            Reservedtwo = reader[OffsetFromMetaData + OFFSET_RESERVEDTWO];
            Valid = reader.getULong(OffsetFromMetaData + OFFSET_VALID);
            Sorted = reader.getULong(OffsetFromMetaData + OFFSET_SORTED);

            Rows = new List<uint>(ValidCount);
            for (int index = 0; index < ValidCount; ++index)
            {
                Rows.Add(reader.getUInt(OffsetFromMetaData + OFFSET_ROWS + (ulong)index * 4));
            }

            Tables = new Dictionary<TypeMetaData, List<AStreamTableRow>>(ValidCount);
            ulong bit = unchecked((ulong)1 << 63);
            int numberOfTable = 0;
            END_OFFSET = OffsetFromMetaData + OFFSET_ROWS + OFFSET_TABLES + 4 * (ulong)ValidCount;
            for (int index = 0; index < 64; ++index, bit >>= 1)
            {
                if ((bit & Valid) != 0)
                {
                    var temp = AStreamTableRow.BuildStreamTable(reader, END_OFFSET, mediator, numberOfTable, (int)Rows[numberOfTable],(AStreamTableRow.HeapSizeFlag)HeapSizes);
                    Tables.Add(temp.Key, temp.Value);
                    END_OFFSET = temp.Value[temp.Value.Count - 1].END_OFFSET;
                    numberOfTable++;
                }
            }
        }

    }
}
