#region description
///Section headers
///Immediately following the optional header is the Section Table, which contains a number of section headers.
///This positioning is required because the file header does not contain a direct pointer to the section table; the
///location of the section table is determined by calculating the location of the first byte after the headers.
///Each section header has the following format, for a total of 40 bytes per entry:
#endregion
namespace PEFileFormat
{
    using System;




    /// <summary>
    /// 
    /// </summary>
    public sealed class FSSectionHeader:AFileStructure
    {
        #region Constants
        private const uint ALWAYS_POINTER_TO_LINENUMBERS = 0;
        private const ushort ALWAYS_NUMBER_OF_LINENUMBERS = 0;

        public const long OFFSET_NAME = 0L;
        public const long OFFSET_VIRTUAL_SIZE = 8L;
        public const long OFFSET_VIRTUAL_ADDRESS = 12L;
        public const long OFFSET_SIZE_OF_RAW_DATA = 16L;
        public const long OFFSET_POINTER_TO_RAW_DATA = 20L;
        public const long OFFSET_POINTER_TO_RELOCATIONS = 24L;
        public const long OFFSET_POINTER_TO_LINENUMBERS = 28L;
        public const long OFFSET_NUMBER_OF_RELOCATIONS = 32L;
        public const long OFFSET_NUMBER_OF_LINENUMBERS = 34L;
        public const long OFFSET_CHARACTERISTICS = 36L;
        #endregion







        #region Fields
        private readonly string _name;
        private readonly uint _virtualSize;
        private readonly uint _virtualAddress;
        private readonly uint _sizeOfRawData;
        private readonly uint _pointerToRawData;
        private readonly uint _pointerToRelocationsRVA;
        private readonly uint _pointerToLinenumbers;
        private readonly ushort _numberOfRelocations;
        private readonly ushort _numberOfLinenumbers;
        private readonly CharacteristicFlag _characteristics;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        public FSSectionHeader(byte[] reader, long beginOffset)
            : base(reader)
        {
            this._name = reader.getString(beginOffset + OFFSET_NAME, OFFSET_VIRTUAL_SIZE - OFFSET_NAME);
            this._virtualSize = reader.getUInt(beginOffset + OFFSET_VIRTUAL_SIZE);
            this._virtualAddress = reader.getUInt(beginOffset + OFFSET_VIRTUAL_ADDRESS);
            this._sizeOfRawData = reader.getUInt(beginOffset + OFFSET_SIZE_OF_RAW_DATA);
            this._pointerToRawData = reader.getUInt(beginOffset + OFFSET_POINTER_TO_RAW_DATA);
            this._pointerToRelocationsRVA = reader.getUInt(beginOffset + OFFSET_POINTER_TO_RELOCATIONS);
            this._pointerToLinenumbers = reader.getUInt(beginOffset + OFFSET_POINTER_TO_LINENUMBERS);
            Helper.CheckAlways(this._pointerToLinenumbers, ALWAYS_POINTER_TO_LINENUMBERS, "PointerToLinenumbers");
            this._numberOfRelocations = reader.getUShort(beginOffset + OFFSET_NUMBER_OF_RELOCATIONS);
            this._numberOfLinenumbers = reader.getUShort(beginOffset + OFFSET_NUMBER_OF_LINENUMBERS);
            Helper.CheckAlways(this._numberOfLinenumbers, ALWAYS_NUMBER_OF_LINENUMBERS, "NumberOfLinenumbers");
            this._characteristics = (CharacteristicFlag)reader.getUInt(beginOffset + OFFSET_CHARACTERISTICS);
            //END_OFFSET = BEGIN_OFFSET + OFFSET_CHARACTERISTICS + 4;
        }
        #endregion








        #region Properties
        /// <summary>
        /// An 8-byte, null-padded ASCII string. There is no terminating null
        ///if the string is exactly eight characters long.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        /// <summary>
        /// Total size of the section in bytes. If this value is greater than
        ///SizeOfRawData, the section is zero-padded.
        /// </summary>
        public uint VirtualSize
        {
            get { return _virtualSize; }
        }
        /// <summary>
        /// For executable images this is the address of the first byte of the
        ///section, when loaded into memory, relative to the image base.
        /// </summary>
        public uint VirtualAddress
        {
            get { return _virtualAddress; }
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
        }
        /// <summary>
        /// Offset of section’s first page within the PE file. This shall be a
        ///multiple of FileAlignment from the optional header. When a
        ///section contains only uninitialized data, this field should be 0.
        /// </summary>
        public uint PointerToRawData
        {
            get { return _pointerToRawData; }
        }
        /// <summary>
        /// RVA of Relocation section.
        /// </summary>
        public uint PointerToRelocationsRVA
        {
            get { return _pointerToRelocationsRVA; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint PointerToLinenumbers
        {
            get { return _pointerToLinenumbers; }
        }
        /// <summary>
        /// Number of relocations, set to 0 if unused.
        /// </summary>
        public ushort NumberOfRelocations
        {
            get { return _numberOfRelocations; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort NumberOfLinenumbers
        {
            get { return _numberOfLinenumbers; }
        }
        /// <summary>
        /// Flags describing section’s characteristics, see below.
        /// </summary>
        public CharacteristicFlag Characteristics
        {
            get { return _characteristics; }
        }
        #endregion









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
