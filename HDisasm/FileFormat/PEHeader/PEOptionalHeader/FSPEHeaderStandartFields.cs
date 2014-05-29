#region description
///PE header standard fields
///These fields are required for all PE files
#endregion
namespace PEFileFormat
{
    using System;



    /// <summary>
    /// 
    /// </summary>
    public sealed class FSPEHeaderStandartFields : AFileStructure
    {
        #region Constants
        private const ushort ALWAYS_MAGIC = 0x10b;
        private const byte ALWAYS_LMAJOR = 6;
        private const byte ALWAYS_LMINOR = 0;

        public const long OFFSET_MAGIC = 0L;
        public const long OFFSET_LMAJOR = 2L;
        public const long OFFSET_LMINOR = 3L;
        public const long OFFSET_CODE_SIZE = 4L;
        public const long OFFSET_INITIALIZED_DATA_SIZE = 8L;
        public const long OFFSET_UNINITIALIZED_DATA_SIZE = 12L;
        public const long OFFSET_ENTRY_POINT_RVA = 16L;
        public const long OFFSET_BASE_OF_CODE = 20L;
        public const long OFFSET_BASE_OF_DATA = 24L;
        #endregion




        #region Fields
        private readonly ushort _magic;
        private readonly byte _lmajor;
        private readonly byte _lminor;
        private readonly uint _codeSize;
        private readonly uint _initializedDataSize;
        private readonly uint _uninitializedDataSize;
        private readonly uint _entryPointRVA;
        private readonly uint _baseOfCodeRVA;
        private readonly uint _baseOfDataRVA;
        #endregion








        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        public FSPEHeaderStandartFields(byte[] reader, long beginOffset)
            : base(reader)
        {
            this._magic = reader.getUShort(beginOffset + OFFSET_MAGIC);
            Helper.CheckAlways(this._magic, ALWAYS_MAGIC, "Magic");
            this._lmajor = reader[beginOffset + OFFSET_LMAJOR];
            Helper.CheckAlways(this._lmajor, ALWAYS_LMAJOR, "LMajor");
            this._lminor = reader[beginOffset + OFFSET_LMINOR];
            Helper.CheckAlways(this._lminor, ALWAYS_LMINOR, "LMinor");
            this._codeSize = reader.getUInt(beginOffset + OFFSET_CODE_SIZE);
            this._initializedDataSize = reader.getUInt(beginOffset + OFFSET_INITIALIZED_DATA_SIZE);
            this._uninitializedDataSize = reader.getUInt(beginOffset + OFFSET_UNINITIALIZED_DATA_SIZE);
            this._entryPointRVA = reader.getUInt(beginOffset + OFFSET_ENTRY_POINT_RVA);
            this._baseOfCodeRVA = reader.getUInt(beginOffset + OFFSET_BASE_OF_CODE);
            this._baseOfDataRVA = reader.getUInt(beginOffset + OFFSET_BASE_OF_DATA);
        }
        #endregion








        #region Properties
        /// <summary>
        /// Always 0x10B
        /// </summary>
        public ushort Magic
        {
            get { return this._magic; }
        }
        /// <summary>
        /// Always 6
        /// </summary>
        public byte LMajor
        {
            get { return this._lmajor; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public byte LMinor
        {
            get { return this._lminor; }
        }
        /// <summary>
        /// Size of the code (text) section, or the sum of all code sections
        ///if there are multiple sections.
        /// </summary>
        public uint CodeSize
        {
            get { return this._codeSize; }
        }
        /// <summary>
        /// Size of the initialized data section, or the sum of all such
        ///sections if there are multiple data sections.
        /// </summary>
        public uint InitializedDataSize
        {
            get { return this._initializedDataSize; }
        }
        /// <summary>
        /// Size of the uninitialized data section, or the sum of all such
        ///sections if there are multiple unitinitalized data sections.
        /// </summary>
        public uint UninitializedDataSize
        {
            get { return this._uninitializedDataSize; }
        }
        /// <summary>
        /// RVA of entry point , needs to point to bytes 0xFF 0x25
        ///followed by the RVA in a section marked execute/read for
        ///EXEs or 0 for DLLs
        /// </summary>
        public uint EntryPointRVA
        {
            get { return this._entryPointRVA; }
        }
        /// <summary>
        /// RVA of the code section. (This is a hint to the loader.)
        /// </summary>
        public uint BaseOFCodeRVA
        {
            get { return this._baseOfCodeRVA; }
        }
        /// <summary>
        /// RVA of the data section. (This is a hint to the loader.)
        /// </summary>
        public uint BaseOFDataRVA
        {
            get { return this._baseOfDataRVA; }
        }
        #endregion
    }
}
