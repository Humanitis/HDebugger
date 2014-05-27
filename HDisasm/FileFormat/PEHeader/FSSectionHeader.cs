#region description
///Section headers
///Immediately following the optional header is the Section Table, which contains a number of section headers.
///This positioning is required because the file header does not contain a direct pointer to the section table; the
///location of the section table is determined by calculating the location of the first byte after the headers.
///Each section header has the following format, for a total of 40 bytes per entry:
#endregion
using System;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat
{
    public sealed class FSSectionHeader:AFileStructure
    {
        private static readonly uint ALWAYS_POINTER_TO_LINENUMBERS = 0;
        private static readonly ushort ALWAYS_NUMBER_OF_LINENUMBERS = 0;

        private static readonly ulong OFFSET_NAME = 0UL;
        private static readonly ulong OFFSET_VIRTUAL_SIZE = 8UL;
        private static readonly ulong OFFSET_VIRTUAL_ADDRESS = 12UL;
        private static readonly ulong OFFSET_SIZE_OF_RAW_DATA = 16UL;
        private static readonly ulong OFFSET_POINTER_TO_RAW_DATA = 20UL;
        private static readonly ulong OFFSET_POINTER_TO_RELOCATIONS = 24UL;
        private static readonly ulong OFFSET_POINTER_TO_LINENUMBERS = 28UL;
        private static readonly ulong OFFSET_NUMBER_OF_RELOCATIONS = 32UL;
        private static readonly ulong OFFSET_NUMBER_OF_LINENUMBERS = 34UL;
        private static readonly ulong OFFSET_CHARACTERISTICS = 36UL;

        private string _name;
        private uint _virtualSize;
        private uint _virtualAddress;
        private uint _sizeOfRawData;
        private uint _pointerToRawData;
        private uint _pointerToRelocationsRVA;
        private uint _pointerToLinenumbers;
        private ushort _numberOfRelocations;
        private ushort _numberOfLinenumbers;
        private CharacteristicFlag _characteristics;

        /// <summary>
        /// An 8-byte, null-padded ASCII string. There is no terminating null
        ///if the string is exactly eight characters long.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// Total size of the section in bytes. If this value is greater than
        ///SizeOfRawData, the section is zero-padded.
        /// </summary>
        public uint VirtualSize
        {
            get { return _virtualSize; }
            private set { _virtualSize = value; }
        }
        /// <summary>
        /// For executable images this is the address of the first byte of the
        ///section, when loaded into memory, relative to the image base.
        /// </summary>
        public uint VirtualAddress
        {
            get { return _virtualAddress; }
            private set { _virtualAddress = value; }
        }
        /// <summary>
        /// Size of the initialized data on disk in bytes, shall be a multiple of
        ///FileAlignment from the PE header. If this is less than VirtualSize
        ///the remainder of the section is zero filled. Because this field is
        ///rounded while the VirtualSize field is not it is possible for this to
        ///be greater than VirtualSize as well. When a section contains only
        ///uninitialized data, this field should be 0.
        /// </summary>
        public uint SizeOfRawData
        {
            get { return _sizeOfRawData; }
            private set { _sizeOfRawData = value; }
        }
        /// <summary>
        /// Offset of section’s first page within the PE file. This shall be a
        ///multiple of FileAlignment from the optional header. When a
        ///section contains only uninitialized data, this field should be 0.
        /// </summary>
        public uint PointerToRawData
        {
            get { return _pointerToRawData; }
            private set { _pointerToRawData = value; }
        }
        /// <summary>
        /// RVA of Relocation section.
        /// </summary>
        public uint PointerToRelocationsRVA
        {
            get { return _pointerToRelocationsRVA; }
            private set { _pointerToRelocationsRVA = value; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint PointerToLinenumbers
        {
            get { return _pointerToLinenumbers; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_POINTER_TO_LINENUMBERS, "PointerToLinenumbers");
                _pointerToLinenumbers = value;
            }
        }
        /// <summary>
        /// Number of relocations, set to 0 if unused.
        /// </summary>
        public ushort NumberOfRelocations
        {
            get { return _numberOfRelocations; }
            private set { _numberOfRelocations = value; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort NumberOfLinenumbers
        {
            get { return _numberOfLinenumbers; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_NUMBER_OF_LINENUMBERS, "NumberOfLinenumbers");
                _numberOfLinenumbers = value;
            }
        }
        /// <summary>
        /// Flags describing section’s characteristics, see below.
        /// </summary>
        public CharacteristicFlag Characteristics
        {
            get { return _characteristics; }
            private set { _characteristics = value; }
        }


        private FSSectionHeader()
        { }
        public FSSectionHeader(byte[] reader, ulong beginOffset,AFileFormatMediator mediator)
            :base(reader,beginOffset,mediator)
        {
            Name = reader.getString(BEGIN_OFFSET + OFFSET_NAME, OFFSET_VIRTUAL_SIZE - OFFSET_NAME);
            VirtualSize = reader.getUInt(BEGIN_OFFSET + OFFSET_VIRTUAL_SIZE);
            VirtualAddress = reader.getUInt(BEGIN_OFFSET + OFFSET_VIRTUAL_ADDRESS);
            SizeOfRawData = reader.getUInt(BEGIN_OFFSET + OFFSET_SIZE_OF_RAW_DATA);
            PointerToRawData = reader.getUInt(BEGIN_OFFSET + OFFSET_POINTER_TO_RAW_DATA);
            PointerToRelocationsRVA = reader.getUInt(BEGIN_OFFSET + OFFSET_POINTER_TO_RELOCATIONS);
            PointerToLinenumbers = reader.getUInt(BEGIN_OFFSET + OFFSET_POINTER_TO_LINENUMBERS);
            NumberOfRelocations = reader.getUShort(BEGIN_OFFSET + OFFSET_NUMBER_OF_RELOCATIONS);
            NumberOfLinenumbers = reader.getUShort(BEGIN_OFFSET + OFFSET_NUMBER_OF_LINENUMBERS);
            Characteristics = (CharacteristicFlag)reader.getUInt(BEGIN_OFFSET + OFFSET_CHARACTERISTICS);
            END_OFFSET = BEGIN_OFFSET + OFFSET_CHARACTERISTICS + 4;
        }

        #region inner types
        [Flags]
        public enum CharacteristicFlag : uint
        {
            IMAGE_SCN_CNT_CODE = 0x00000020,//Section contains executable code.
            IMAGE_SCN_CNT_INITIALIZED_DATA = 0x00000040,//Section contains initialized data.
            IMAGE_SCN_CNT_UNINITIALIZED_DATA = 0x00000080,//Section contains uninitialized data.
            IMAGE_SCN_MEM_EXECUTE = 0x20000000,//Section can be executed as code.
            IMAGE_SCN_MEM_READ = 0x40000000,//Section can be read.
            IMAGE_SCN_MEM_WRITE = 0x80000000,//Section can be written to.
            UNDEFINED = 0x2000000,//TODO:delete later
        }
        #endregion
    }
}
