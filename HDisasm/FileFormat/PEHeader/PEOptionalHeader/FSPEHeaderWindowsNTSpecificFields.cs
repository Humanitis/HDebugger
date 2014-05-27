#region description
///PE header Windows NT-specific fields
#endregion
using System;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.PEHeader
{
    public sealed class FSPEHeaderWindowsNTSpecificFields:AFileStructure
    {
        private static readonly uint ALWAYS_IMAGE_BASE = 0x400000U;
        private static readonly uint ALWAYS_SECTION_ALIGNMENT = 0x2000U;
        private static readonly uint ALWAYS_FILE_ALIGNMENT_1 = 0x200U;
        private static readonly uint ALWAYS_FILE_ALIGNMENT_2 = 0x1000U;
        private static readonly ushort ALWAYS_OS_MAJOR = 4;
        private static readonly ushort ALWAYS_OS_MINOR = 0;
        private static readonly ushort ALWAYS_USER_MAJOR = 0;
        private static readonly ushort ALWAYS_USER_MINOR = 0;
        private static readonly ushort ALWAYS_SUBSYS_MAJOR = 4;
        private static readonly ushort ALWAYS_SUBSYS_MINOR = 0;
        private static readonly uint ALWAYS_RESERVED = 0U;
        private static readonly uint ALWAYS_FILE_CHECKSUM = 0U;
        private static readonly ushort ALWAYS_IMAGE_SUBSYSTEM_WINDOWS_CE_GUI = 0x3;
        private static readonly ushort ALWAYS_IMAGE_SUBSYSTEM_WINDOWS_GUI = 0x2;
        private static readonly ushort ALWAYS_DLL_FLAGS = 0;
        private static readonly uint ALWAYS_STACK_RESERVE_SIZE = 0x100000U;
        private static readonly uint ALWAYS_STACK_COMMIT_SIZE = 0x1000U;
        private static readonly uint ALWAYS_HEAP_RESERVE_SIZE = 0x100000U;
        private static readonly uint ALWAYS_HEAP_COMMIT_SIZE = 0x1000U;
        private static readonly uint ALWAYS_LOADER_FLAGS = 0U;
        private static readonly uint ALWAYS_NUMBER_OF_DATA_DIRECTORIES = 0x10U;

        private static readonly ulong OFFSET_IMAGE_BASE = 28UL;
        private static readonly ulong OFFSET_SECTION_ALIGNMENT = 32UL;
        private static readonly ulong OFFSET_FILE_ALIGNMENT = 36UL;
        private static readonly ulong OFFSET_OS_MAJOR = 40UL;
        private static readonly ulong OFFSET_OS_MINOR = 42UL;
        private static readonly ulong OFFSET_USER_MAJOR = 44UL;
        private static readonly ulong OFFSET_USER_MINOR = 46UL;
        private static readonly ulong OFFSET_SUBSYS_MAJOR = 48UL;
        private static readonly ulong OFFSET_SUBSYS_MINOR = 50UL;
        private static readonly ulong OFFSET_RESERVED = 52UL;
        private static readonly ulong OFFSET_IMAGE_SIZE = 56UL;
        private static readonly ulong OFFSET_HEADER_SIZE = 60UL;
        private static readonly ulong OFFSET_FILE_CHECKSUM = 64UL;
        private static readonly ulong OFFSET_SUBSYSTEM = 68UL;
        private static readonly ulong OFFSET_DLL_FLAGS = 70UL;
        private static readonly ulong OFFSET_STACK_RESERVE_SIZE = 72UL;
        private static readonly ulong OFFSET_STACK_COMMIT_SIZE = 76UL;
        private static readonly ulong OFFSET_HEAP_RESERVE_SIZE = 80UL;
        private static readonly ulong OFFSET_HEAP_COMMIT_SIZE = 84UL;
        private static readonly ulong OFFSET_LOADER_FLAGS = 88UL;
        private static readonly ulong OFFSET_NUMBER_OF_DATA_DIRECTORIES = 92UL;

        private uint _imageBase;
        private uint _sectionAlignment;
        private uint _fileAlignment;
        private ushort _osMajor;
        private ushort _osMinor;
        private ushort _userMajor;
        private ushort _userMinor;
        private ushort _subsysMajor;
        private ushort _subsysMinor;
        private uint _reserved;
        private uint _imageSize;
        private uint _headerSize;
        private uint _fileChecksum;
        private ushort _subsystem;
        private ushort _dllFlags;
        private uint _stackReserveSize;
        private uint _stackCommitSize;
        private uint _heapReserveSize;
        private uint _heapCommitSize;
        private uint _loaderFlags;
        private uint _numberOfDataDirectories;

        /// <summary>
        /// Always 0x400000
        /// </summary>
        public uint ImageBase
        {
            get { return _imageBase; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_IMAGE_BASE, "ImageBase");
                _imageBase = value;
            }
        }
        /// <summary>
        /// Always 0x2000
        /// </summary>
        public uint SectionAlignment
        {
            get { return _sectionAlignment; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_SECTION_ALIGNMENT, "SectionAlignment");
                _sectionAlignment = value;
            }
        }
        /// <summary>
        /// Either 0x200 or 0x1000.
        /// </summary>
        public uint FileAlignment
        {
            get { return _fileAlignment; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_FILE_ALIGNMENT_1, ALWAYS_FILE_ALIGNMENT_2, "FileAlignment");
                _fileAlignment = value;
            }
        }
        /// <summary>
        /// Always 4
        /// </summary>
        public ushort OSMajor
        {
            get { return _osMajor; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_OS_MAJOR, "OSMajor");
                _osMajor = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort OSMinor
        {
            get { return _osMinor; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_OS_MINOR, "OSMinor");
                _osMinor = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort UserMajor
        {
            get { return _userMajor; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_USER_MAJOR, "UserMajor");
                _userMajor = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort UserMinor
        {
            get { return _userMinor; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_USER_MAJOR, "UserMinor");
                _userMinor = value;
            }
        }
        /// <summary>
        /// Always 4
        /// </summary>
        public ushort SubsysMajor
        {
            get { return _subsysMajor; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_SUBSYS_MAJOR, "SubsysMajor");
                _subsysMajor = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort SubsysMinor
        {
            get { return _subsysMinor; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_SUBSYS_MINOR, "SubsysMinor");
                _subsysMinor = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint Reserved
        {
            get { return _reserved; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_RESERVED, "Reserved");
                _reserved = value;
            }
        }
        /// <summary>
        /// Size, in bytes, of image, including all headers and padding;
        ///shall be a multiple of Section Alignment.
        /// </summary>
        public uint ImageSize
        {
            get { return _imageSize; }
            private set { _imageSize = value; }
        }
        /// <summary>
        /// Combined size of MS-DOS Header, PE Header, PE Optional
        ///Header and padding; shall be a multiple of the file alignment.
        /// </summary>
        public uint HeaderSize
        {
            get { return _headerSize; }
            private set { _headerSize = value; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint FileChecksum
        {
            get { return _fileChecksum; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_FILE_CHECKSUM, "FileChecksum");
                _fileChecksum = value;
            }
        }
        /// <summary>
        /// Subsystem required to run this image. Shall be either
        ///IMAGE_SUBSYSTEM_WINDOWS_CE_GUI (0x3) or
        ///IMAGE_SUBSYSTEM_WINDOWS_GUI (0x2).
        /// </summary>
        public ushort Subsystem
        {
            get { return _subsystem; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_IMAGE_SUBSYSTEM_WINDOWS_CE_GUI, ALWAYS_IMAGE_SUBSYSTEM_WINDOWS_GUI, "Magic");
                _subsystem = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public ushort DLLFlags
        {
            get { return _dllFlags; }
            private set
            {
                //Helper.CheckAlways(value, ALWAYS_DLL_FLAGS, "DLLFlags");
                _dllFlags = value;
            }
        }
        /// <summary>
        /// Always 0x100000 (1Mb)
        /// </summary>
        public uint StackReserveSize
        {
            get { return _stackReserveSize; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_STACK_RESERVE_SIZE, "StackReserveSize");
                _stackReserveSize = value;
            }
        }
        /// <summary>
        /// Always 0x1000 (4Kb)
        /// </summary>
        public uint StackCommitSize
        {
            get { return _stackCommitSize; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_STACK_COMMIT_SIZE, "StackCommitSize");
                _stackCommitSize = value;
            }
        }
        /// <summary>
        /// Always 0x100000 (1Mb)
        /// </summary>
        public uint HeapReserveSize
        {
            get { return _heapReserveSize; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_HEAP_RESERVE_SIZE, "HeapReserveSize");
                _heapReserveSize = value;
            }
        }
        /// <summary>
        /// Always 0x1000 (4Kb)
        /// </summary>
        public uint HeapCommitSize
        {
            get { return _heapCommitSize; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_HEAP_COMMIT_SIZE, "HeapCommitSize");
                _heapCommitSize = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint LoaderFlags
        {
            get { return _loaderFlags; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_LOADER_FLAGS, "LoaderFlags");
                _loaderFlags = value;
            }
        }
        /// <summary>
        /// Always 0x10
        /// </summary>
        public uint NumberOfDataDirectories
        {
            get { return _numberOfDataDirectories; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_NUMBER_OF_DATA_DIRECTORIES, "NumberOfDataDirectories");
                _numberOfDataDirectories = value;
            }
        }


        private FSPEHeaderWindowsNTSpecificFields()
        { }

        public FSPEHeaderWindowsNTSpecificFields(byte[] reader, ulong beginOffset,AFileFormatMediator mediator)
            :base(reader,beginOffset,mediator)
        {
            ImageBase = reader.getUInt(BEGIN_OFFSET + OFFSET_IMAGE_BASE);
            SectionAlignment = reader.getUInt(BEGIN_OFFSET + OFFSET_SECTION_ALIGNMENT);
            FileAlignment = reader.getUInt(BEGIN_OFFSET + OFFSET_FILE_ALIGNMENT);
            OSMajor = reader.getUShort(BEGIN_OFFSET + OFFSET_OS_MAJOR);
            OSMinor = reader.getUShort(BEGIN_OFFSET + OFFSET_OS_MINOR);
            UserMajor = reader.getUShort(BEGIN_OFFSET + OFFSET_USER_MAJOR);
            UserMinor = reader.getUShort(BEGIN_OFFSET + OFFSET_USER_MINOR);
            SubsysMajor = reader.getUShort(BEGIN_OFFSET + OFFSET_SUBSYS_MAJOR);
            SubsysMinor = reader.getUShort(BEGIN_OFFSET + OFFSET_SUBSYS_MINOR);
            Reserved = reader.getUInt(BEGIN_OFFSET + OFFSET_RESERVED);
            ImageSize = reader.getUInt(BEGIN_OFFSET + OFFSET_IMAGE_SIZE);
            HeaderSize = reader.getUInt(BEGIN_OFFSET + OFFSET_HEADER_SIZE);
            FileChecksum = reader.getUInt(BEGIN_OFFSET + OFFSET_FILE_CHECKSUM);
            Subsystem = reader.getUShort(BEGIN_OFFSET + OFFSET_SUBSYSTEM);
            DLLFlags = reader.getUShort(BEGIN_OFFSET + OFFSET_DLL_FLAGS);
            StackReserveSize = reader.getUInt(BEGIN_OFFSET + OFFSET_STACK_RESERVE_SIZE);
            StackCommitSize = reader.getUInt(BEGIN_OFFSET + OFFSET_STACK_COMMIT_SIZE);
            HeapReserveSize = reader.getUInt(BEGIN_OFFSET + OFFSET_HEAP_RESERVE_SIZE);
            HeapCommitSize = reader.getUInt(BEGIN_OFFSET + OFFSET_HEAP_COMMIT_SIZE);
            LoaderFlags = reader.getUInt(BEGIN_OFFSET + OFFSET_LOADER_FLAGS);
            NumberOfDataDirectories = reader.getUInt(BEGIN_OFFSET + OFFSET_NUMBER_OF_DATA_DIRECTORIES);

            END_OFFSET = BEGIN_OFFSET + OFFSET_NUMBER_OF_DATA_DIRECTORIES + 4;
        }
    }
}
