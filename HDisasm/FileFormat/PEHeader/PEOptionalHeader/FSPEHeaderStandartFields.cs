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

        /// <summary>
        /// Always 0x10B
        /// </summary>
        public ushort Magic
        {
            get { return _magic; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_MAGIC, "Magic");
                _magic = value;
            }
        }
        /// <summary>
        /// Always 6
        /// </summary>
        public byte LMajor
        {
            get { return _lmajor; }
            private set
            {
                //Helper.CheckAlways(value ,ALWAYS_LMAJOR,"LMajor");
                _lmajor = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public byte LMinor
        {
            get { return _lminor; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_LMINOR, "LMinor");
                _lminor = value;
            }
        }
        /// <summary>
        /// Size of the code (text) section, or the sum of all code sections
        ///if there are multiple sections.
        /// </summary>
        public uint CodeSize
        {
            get { return _codeSize; }
            private set
            {
                _codeSize = value;
            }
        }
        /// <summary>
        /// Size of the initialized data section, or the sum of all such
        ///sections if there are multiple data sections.
        /// </summary>
        public uint InitializedDataSize
        {
            get { return _initializedDataSize; }
            private set
            {
                _initializedDataSize = value;
            }
        }
        /// <summary>
        /// Size of the uninitialized data section, or the sum of all such
        ///sections if there are multiple unitinitalized data sections.
        /// </summary>
        public uint UninitializedDataSize
        {
            get { return _uninitializedDataSize; }
            private set
            {
                _uninitializedDataSize = value;
            }
        }
        /// <summary>
        /// RVA of entry point , needs to point to bytes 0xFF 0x25
        ///followed by the RVA in a section marked execute/read for
        ///EXEs or 0 for DLLs
        /// </summary>
        public uint EntryPointRVA
        {
            get { return _entryPointRVA; }
            private set
            {
                _entryPointRVA = value;
            }
        }
        /// <summary>
        /// RVA of the code section. (This is a hint to the loader.)
        /// </summary>
        public uint BaseOFCodeRVA
        {
            get { return _baseOfCodeRVA; }
            private set
            {
                _baseOfCodeRVA = value;
            }
        }
        /// <summary>
        /// RVA of the data section. (This is a hint to the loader.)
        /// </summary>
        public uint BaseOFDataRVA
        {
            get { return _baseOfDataRVA; }
            private set
            {
                _baseOfDataRVA = value;
            }
        }

        private FSPEHeaderStandartFields()
        { }

        public FSPEHeaderStandartFields(byte[] reader, ulong beginOffset, AFileFormatMediator mediator)
            : base(reader, beginOffset, mediator)
        {
            Magic = reader.getUShort(BEGIN_OFFSET + OFFSET_MAGIC);
            LMajor = reader[BEGIN_OFFSET + OFFSET_LMAJOR];
            LMajor = reader[BEGIN_OFFSET + OFFSET_LMINOR];
            CodeSize = reader.getUInt(BEGIN_OFFSET + OFFSET_CODE_SIZE);
            InitializedDataSize = reader.getUInt(BEGIN_OFFSET + OFFSET_INITIALIZED_DATA_SIZE);
            UninitializedDataSize = reader.getUInt(BEGIN_OFFSET + OFFSET_UNINITIALIZED_DATA_SIZE);
            EntryPointRVA = reader.getUInt(BEGIN_OFFSET + OFFSET_ENTRY_POINT_RVA);
            BaseOFCodeRVA = reader.getUInt(BEGIN_OFFSET + OFFSET_BASE_OF_CODE);
            BaseOFDataRVA = reader.getUInt(BEGIN_OFFSET + OFFSET_BASE_OF_DATA);
            END_OFFSET = BEGIN_OFFSET + OFFSET_BASE_OF_DATA + 4;
        }
    }
}
