#region description
///PE file header
///Immediately after the PE signature is the PE File header
#endregion
namespace PEFileFormat
{
    using System;



    /// <summary>
    /// 
    /// </summary>
    public sealed class FSPEFileHeader : AFileStructure
    {
        #region Constants
        public const ushort ALWAYS_MACHINE = 0x14c;
        public const ushort ALWAYS_POINTER_TO_SYMBOL_TABLE = 0;
        public const ushort ALWAYS_NUMBER_OF_SYMBOLS = 0;

        public const long OFFSET_MACHINE = 0L;
        public const long OFFSET_NUMBER_OF_SECTIONS = 2L;
        public const long OFFSET_TIMEDATESTAMP = 4L;
        public const long OFFSET_POINTER_TO_SYMBOL_TABLE = 8L;
        public const long OFFSET_NUMBER_OF_SYMBOLS = 12L;
        public const long OFFSET_OPTIONAL_HEADER_SIZE = 16L;
        public const long OFFSET_HARACTERISTICS = 18L;

        public static readonly DateTime FILE_CREATED_SINCE = new DateTime(1970, 1, 1, 0, 0, 0);
        #endregion





        #region Fields
        private readonly ushort _machine;
        private readonly ushort _numberOfSections;
        private readonly uint _timeDateStamp;
        private readonly uint _pointerToSymbolTable;
        private readonly uint _numberOfSymbols;
        private readonly ushort _optionalHeaderSize;
        private readonly CharacteristicFlag _characterisrics;

        private readonly DateTime _dtFileCreated;
        #endregion






        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        public FSPEFileHeader(byte[] reader, long beginOffset)
            : base(reader)
        {
            this._machine = reader.getUShort(beginOffset + OFFSET_MACHINE);
            Helper.CheckAlways(this._machine, ALWAYS_MACHINE, "Machine");
            this._numberOfSections = reader.getUShort(beginOffset + OFFSET_NUMBER_OF_SECTIONS);
            this._timeDateStamp = reader.getUInt(beginOffset + OFFSET_TIMEDATESTAMP);
            this._dtFileCreated = FILE_CREATED_SINCE.AddSeconds(this._timeDateStamp);
            this._pointerToSymbolTable = reader.getUInt(beginOffset + OFFSET_POINTER_TO_SYMBOL_TABLE);
            Helper.CheckAlways(this._pointerToSymbolTable, ALWAYS_POINTER_TO_SYMBOL_TABLE, "PointerToSymbolTable");
            this._numberOfSymbols = reader.getUInt(beginOffset + OFFSET_NUMBER_OF_SYMBOLS);
            Helper.CheckAlways(this._numberOfSymbols, ALWAYS_NUMBER_OF_SYMBOLS, "NumberOfSymbols");
            this._optionalHeaderSize = reader.getUShort(beginOffset + OFFSET_OPTIONAL_HEADER_SIZE);
            this._characterisrics = (CharacteristicFlag)reader.getUShort(beginOffset + OFFSET_HARACTERISTICS);
        }
        #endregion





        #region Properties
        /// <summary>
        /// Always 0x14c
        /// </summary>
        public ushort Machine
        {
            get { return this._machine; }
        }
        /// <summary>
        /// Number of sections; indicates size of the Section Table,
        ///which immediately follows the headers.
        /// </summary>
        public ushort NumberOfSections
        {
            get { return this._numberOfSections; }
        }
        /// <summary>
        /// Time and date the file was created in seconds since
        ///January 1st 1970 00:00:00 or 0.
        /// </summary>
        public uint TimeDateStamp
        {
            get { return this._timeDateStamp; }
        }
        /// <summary>
        /// Time and date the file was created 
        /// </summary>
        public DateTime DTFileCreated
        {
            get { return this._dtFileCreated; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint PointerToSymbolTable
        {
            get { return this._pointerToSymbolTable; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint NumberOfSymbols
        {
            get { return this._numberOfSymbols; }
        }
        /// <summary>
        /// Size of the optional header, the format is described below.
        /// </summary>
        public ushort OptionalHeaderSize
        {
            get { return this._optionalHeaderSize; }
        }
        /// <summary>
        /// Flags indicating attributes of the file,
        /// </summary>
        public CharacteristicFlag Characterisrics
        {
            get { return this._characterisrics; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDLL
        {
            get { return (_characterisrics & CharacteristicFlag.IMAGE_FILE_DLL) != 0; }
        }
        #endregion







        #region inner types
        [Flags()]
        public enum CharacteristicFlag : uint
        {
            IMAGE_FILE_RELOCS_STRIPPED = 0x0001,//  Shall be zero 
            IMAGE_FILE_EXECUTABLE_IMAGE = 0x0002,//  Shall be one 
            IMAGE_FILE_32BIT_MACHINE = 0x0100,//  Shall be one if and only if COMIMAGE_FLA
            IMAGE_FILE_DLL = 0x2000,//The image file is a dynamic-link library (DLL).
        }
        #endregion
    }
}
