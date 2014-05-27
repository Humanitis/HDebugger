#region description
///In a pure CIL image, a single fixup of type IMAGE_REL_BASED_HIGHLOW (0x3) is required for the x86
///startup stub which access the IAT to load the runtime engine on down level loaders. When building a mixed
///CIL/native image or when the image contains embedded RVAs in user data, the relocation section contains
///relocations for these as well.
///The relocations shall be in their own section, named “.reloc”, which shall be the final section in the PE file. The
///relocation section contains a Fix-Up Table. The fixup table is broken into blocks of fixups. Each block
///represents the fixups for a 4K page, and each block shall start on a 32-bit boundary.
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat
{
    public sealed class FSRelocations : AFileStructure
    {
        private static readonly ulong OFFSET_PAGERVA = 0UL;
        private static readonly ulong OFFSET_BLOCK_SIZE = 4UL;

        private static readonly uint USEFUL_BIT = 0xFFF;

        private uint _pageRVA;
        private uint _blockSize;
        /*The Block Size field is then followed by (BlockSize –8)/2 Type/Offset. Each entry is a word (2 bytes) and has
        the following structure (if necessary, insert 2 bytes of 0 to pad to a multiple of 4 bytes in length):*/
        private ushort _typeOffset = 0;

        /// <summary>
        /// The RVA of the block in which the fixup needs to be
        ///applied. The low 12 bits shall be zero.
        /// </summary>
        public uint PageRVA
        {
            get { return _pageRVA; }
            private set { _pageRVA = value; }
        }
        /// <summary>
        /// Total number of bytes in the fixup block, including the
        ///Page RVA and Block Size fields, as well as the
        ///Type/Offset fields that follow, rounded up to the next
        ///multiple of 4.
        /// </summary>
        public uint BlockSize
        {
            get { return _blockSize; }
            set { _blockSize = value; }
        }
        /// <summary>
        /// Stored in high 4 bits of word. Value indicating which
        ///type of fixup is to be applied (described above)
        /// </summary>
        public ushort Type
        {
            get { return (ushort)(_typeOffset >> 12); }
            private set
            {
                _typeOffset = (ushort)(value << 12 | Offset);
            }
        }
        /// <summary>
        /// Stored in remaining 12 bits of word. Offset from starting
        ///address specified in the Page RVA field for the block.
        ///This offset specifies where the fixup is to be applied.
        /// </summary>
        public ushort Offset
        {
            get { return (ushort)(_typeOffset & USEFUL_BIT); }
            private set
            {
                _typeOffset = (ushort)((value & USEFUL_BIT) | Type);
            }
        }

        private FSRelocations()
        { }
        public FSRelocations(byte[] reader, ulong beginOffset, AFileFormatMediator mediator)
            : base(reader, beginOffset, mediator)
        {
            PageRVA = reader.getUInt(BEGIN_OFFSET + OFFSET_PAGERVA);
            BlockSize = reader.getUInt(BEGIN_OFFSET + OFFSET_BLOCK_SIZE);
            _typeOffset = reader.getUShort(BEGIN_OFFSET + 8);//TODO:replace offset on correct offset
            END_OFFSET = BEGIN_OFFSET + BlockSize;
        }
    }
}
