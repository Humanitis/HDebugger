#region description
///PE header Windows NT-specific fields
#endregion
namespace PEFileFormat
{
    using System;



    /// <summary>
    /// 
    /// </summary>
    public sealed class FSPEHeaderWindowsNTSpecificFields : AFileStructure
    {
        #region Constants
        private const uint ALWAYS_IMAGE_BASE = 0x400000U;
        private const uint ALWAYS_SECTION_ALIGNMENT = 0x2000U;
        private const uint ALWAYS_FILE_ALIGNMENT_1 = 0x200U;
        private const uint ALWAYS_FILE_ALIGNMENT_2 = 0x1000U;
        private const ushort ALWAYS_OS_MAJOR = 4;
        private const ushort ALWAYS_OS_MINOR = 0;
        private const ushort ALWAYS_USER_MAJOR = 0;
        private const ushort ALWAYS_USER_MINOR = 0;
        private const ushort ALWAYS_SUBSYS_MAJOR = 4;
        private const ushort ALWAYS_SUBSYS_MINOR = 0;
        private const uint ALWAYS_RESERVED = 0U;
        private const uint ALWAYS_FILE_CHECKSUM = 0U;
        private const ushort ALWAYS_IMAGE_SUBSYSTEM_WINDOWS_CE_GUI = 0x3;
        private const ushort ALWAYS_IMAGE_SUBSYSTEM_WINDOWS_GUI = 0x2;
        private const ushort ALWAYS_DLL_FLAGS = 0;
        private const uint ALWAYS_STACK_RESERVE_SIZE = 0x100000U;
        private const uint ALWAYS_STACK_COMMIT_SIZE = 0x1000U;
        private const uint ALWAYS_HEAP_RESERVE_SIZE = 0x100000U;
        private const uint ALWAYS_HEAP_COMMIT_SIZE = 0x1000U;
        private const uint ALWAYS_LOADER_FLAGS = 0U;
        private const uint ALWAYS_NUMBER_OF_DATA_DIRECTORIES = 0x10U;

        public const long OFFSET_IMAGE_BASE = 28L;
        public const long OFFSET_SECTION_ALIGNMENT = 32L;
        public const long OFFSET_FILE_ALIGNMENT = 36L;
        public const long OFFSET_OS_MAJOR = 40L;
        public const long OFFSET_OS_MINOR = 42L;
        public const long OFFSET_USER_MAJOR = 44L;
        public const long OFFSET_USER_MINOR = 46L;
        public const long OFFSET_SUBSYS_MAJOR = 48L;
        public const long OFFSET_SUBSYS_MINOR = 50L;
        public const long OFFSET_RESERVED = 52L;
        public const long OFFSET_IMAGE_SIZE = 56L;
        public const long OFFSET_HEADER_SIZE = 60L;
        public const long OFFSET_FILE_CHECKSUM = 64L;
        public const long OFFSET_SUBSYSTEM = 68L;
        public const long OFFSET_DLL_FLAGS = 70L;
        public const long OFFSET_STACK_RESERVE_SIZE = 72L;
        public const long OFFSET_STACK_COMMIT_SIZE = 76L;
        public const long OFFSET_HEAP_RESERVE_SIZE = 80L;
        public const long OFFSET_HEAP_COMMIT_SIZE = 84L;
        public const long OFFSET_LOADER_FLAGS = 88L;
        public const long OFFSET_NUMBER_OF_DATA_DIRECTORIES = 92L;
        #endregion







        #region Fields
        private readonly uint _imageBase;
        private readonly uint _sectionAlignment;
        private readonly uint _fileAlignment;
        private readonly ushort _osMajor;
        private readonly ushort _osMinor;
        private readonly ushort _userMajor;
        private readonly ushort _userMinor;
        private readonly ushort _subsysMajor;
        private readonly ushort _subsysMinor;
        private readonly uint _reserved;
        private readonly uint _imageSize;
        private readonly uint _headerSize;
        private readonly uint _fileChecksum;
        private readonly ushort _subsystem;
        private readonly ushort _dllFlags;
        private readonly uint _stackReserveSize;
        private readonly uint _stackCommitSize;
        private readonly uint _heapReserveSize;
        private readonly uint _heapCommitSize;
        private readonly uint _loaderFlags;
        private readonly uint _numberOfDataDirectories;
        #endregion









        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        public FSPEHeaderWindowsNTSpecificFields(byte[] reader, long beginOffset)
            : base(reader)
        {
            this._imageBase = reader.getUInt(beginOffset + OFFSET_IMAGE_BASE);
            Helper.CheckAlways(this._imageBase, ALWAYS_IMAGE_BASE, "ImageBase");
            this._sectionAlignment = reader.getUInt(beginOffset + OFFSET_SECTION_ALIGNMENT);
            Helper.CheckAlways(this._sectionAlignment, ALWAYS_SECTION_ALIGNMENT, "SectionAlignment");
            this._fileAlignment = reader.getUInt(beginOffset + OFFSET_FILE_ALIGNMENT);
            Helper.CheckAlways(this._fileAlignment, ALWAYS_FILE_ALIGNMENT_1, ALWAYS_FILE_ALIGNMENT_2, "FileAlignment");
            this._osMajor = reader.getUShort(beginOffset + OFFSET_OS_MAJOR);
            Helper.CheckAlways(this._osMajor, ALWAYS_OS_MAJOR, "OSMajor");
            this._osMinor = reader.getUShort(beginOffset + OFFSET_OS_MINOR);
            Helper.CheckAlways(this._osMinor, ALWAYS_OS_MINOR, "OSMinor");
            this._userMajor = reader.getUShort(beginOffset + OFFSET_USER_MAJOR);
            Helper.CheckAlways(this._userMajor, ALWAYS_USER_MAJOR, "UserMajor");
            this._userMinor = reader.getUShort(beginOffset + OFFSET_USER_MINOR);
            Helper.CheckAlways(this._userMinor, ALWAYS_USER_MAJOR, "UserMinor");
            this._subsysMajor = reader.getUShort(beginOffset + OFFSET_SUBSYS_MAJOR);
            Helper.CheckAlways(this._subsysMajor, ALWAYS_SUBSYS_MAJOR, "SubsysMajor");
            this._subsysMinor = reader.getUShort(beginOffset + OFFSET_SUBSYS_MINOR);
            Helper.CheckAlways(this._subsysMinor, ALWAYS_SUBSYS_MINOR, "SubsysMinor");
            this._reserved = reader.getUInt(beginOffset + OFFSET_RESERVED);
            Helper.CheckAlways(this._reserved, ALWAYS_RESERVED, "Reserved");
            this._imageSize = reader.getUInt(beginOffset + OFFSET_IMAGE_SIZE);
            this._headerSize = reader.getUInt(beginOffset + OFFSET_HEADER_SIZE);
            this._fileChecksum = reader.getUInt(beginOffset + OFFSET_FILE_CHECKSUM);
            Helper.CheckAlways(this._fileChecksum, ALWAYS_FILE_CHECKSUM, "FileChecksum");
            this._subsystem = reader.getUShort(beginOffset + OFFSET_SUBSYSTEM);
            Helper.CheckAlways(this._subsystem, ALWAYS_IMAGE_SUBSYSTEM_WINDOWS_CE_GUI, ALWAYS_IMAGE_SUBSYSTEM_WINDOWS_GUI, "Magic");
            this._dllFlags = reader.getUShort(beginOffset + OFFSET_DLL_FLAGS);
            Helper.CheckAlways(this._dllFlags, ALWAYS_DLL_FLAGS, "DLLFlags");
            this._stackReserveSize = reader.getUInt(beginOffset + OFFSET_STACK_RESERVE_SIZE);
            Helper.CheckAlways(this._stackReserveSize, ALWAYS_STACK_RESERVE_SIZE, "StackReserveSize");
            this._stackCommitSize = reader.getUInt(beginOffset + OFFSET_STACK_COMMIT_SIZE);
            Helper.CheckAlways(this._stackCommitSize, ALWAYS_STACK_COMMIT_SIZE, "StackCommitSize");
            this._heapReserveSize = reader.getUInt(beginOffset + OFFSET_HEAP_RESERVE_SIZE);
            Helper.CheckAlways(this._heapReserveSize, ALWAYS_HEAP_RESERVE_SIZE, "HeapReserveSize");
            this._heapCommitSize = reader.getUInt(beginOffset + OFFSET_HEAP_COMMIT_SIZE);
            Helper.CheckAlways(this._heapCommitSize, ALWAYS_HEAP_COMMIT_SIZE, "HeapCommitSize");
            this._loaderFlags = reader.getUInt(beginOffset + OFFSET_LOADER_FLAGS);
            Helper.CheckAlways(this._loaderFlags, ALWAYS_LOADER_FLAGS, "LoaderFlags");
            this._numberOfDataDirectories = reader.getUInt(beginOffset + OFFSET_NUMBER_OF_DATA_DIRECTORIES);
            Helper.CheckAlways(this._numberOfDataDirectories, ALWAYS_NUMBER_OF_DATA_DIRECTORIES, "NumberOfDataDirectories");
        }
        #endregion








        #region Properties
        /// <summary>
        /// Always 0x400000
        /// </summary>
        public uint ImageBase
        {
            get { return this._imageBase; }
        }
        /// <summary>
        /// Always 0x2000
        /// </summary>
        public uint SectionAlignment
        {
            get { return this._sectionAlignment; }
        }
        /// <summary>
        /// Either 0x200 or 0x1000.
        /// </summary>
        public uint FileAlignment
        {
            get { return this._fileAlignment; }
        }
        /// <summary>
        /// Always 4
        /// </summary>
        public ushort OSMajor
        {
            get { return this._osMajor; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort OSMinor
        {
            get { return this._osMinor; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort UserMajor
        {
            get { return this._userMajor; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort UserMinor
        {
            get { return this._userMinor; }
        }
        /// <summary>
        /// Always 4
        /// </summary>
        public ushort SubsysMajor
        {
            get { return this._subsysMajor; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort SubsysMinor
        {
            get { return this._subsysMinor; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint Reserved
        {
            get { return this._reserved; }
        }
        /// <summary>
        /// Size, in bytes, of image, including all headers and padding;
        ///shall be a multiple of Section Alignment.
        /// </summary>
        public uint ImageSize
        {
            get { return this._imageSize; }
        }
        /// <summary>
        /// Combined size of MS-DOS Header, PE Header, PE Optional
        ///Header and padding; shall be a multiple of the file alignment.
        /// </summary>
        public uint HeaderSize
        {
            get { return this._headerSize; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint FileChecksum
        {
            get { return this._fileChecksum; }
        }
        /// <summary>
        /// Subsystem required to run this image. Shall be either
        ///IMAGEthis._SUBSYSTEMthis._WINDOWSthis._CEthis._GUI (0x3) or
        ///IMAGEthis._SUBSYSTEMthis._WINDOWSthis._GUI (0x2).
        /// </summary>
        public ushort Subsystem
        {
            get { return this._subsystem; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort DLLFlags
        {
            get { return this._dllFlags; }
        }
        /// <summary>
        /// Always 0x100000 (1Mb)
        /// </summary>
        public uint StackReserveSize
        {
            get { return this._stackReserveSize; }
        }
        /// <summary>
        /// Always 0x1000 (4Kb)
        /// </summary>
        public uint StackCommitSize
        {
            get { return this._stackCommitSize; }
        }
        /// <summary>
        /// Always 0x100000 (1Mb)
        /// </summary>
        public uint HeapReserveSize
        {
            get { return this._heapReserveSize; }
        }
        /// <summary>
        /// Always 0x1000 (4Kb)
        /// </summary>
        public uint HeapCommitSize
        {
            get { return this._heapCommitSize; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint LoaderFlags
        {
            get { return this._loaderFlags; }
        }
        /// <summary>
        /// Always 0x10
        /// </summary>
        public uint NumberOfDataDirectories
        {
            get { return this._numberOfDataDirectories; }
        }
        #endregion
    }
}
