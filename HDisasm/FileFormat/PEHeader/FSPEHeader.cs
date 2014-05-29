#region description
///A PE image starts with an MS-DOS header followed by a PE signature, followed by the PE file header, and
///then the PE optional header followed by PE section headers.
#endregion
namespace PEFileFormat
{
    using System;
    using System.Collections.Generic;




    /// <summary>
    /// 
    /// </summary>
    public sealed class FSPEHeader : AFileStructure
    {
        #region Constants
        private const string ALWAYS_PE_SIGNATURE = "PE";
        #endregion






        #region Fields
        private readonly FSMSDOSHeader _headerMSDOS;
        private readonly FSPEFileHeader _peFileHeader;
        private readonly FSPEOptionalHeader _peOptionalHeader;
        private readonly string _peSignature;
        private readonly Dictionary<string, FSSectionHeader> _sectionsHeader;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        public FSPEHeader(byte[] reader, long beginOffset)
            : base(reader)
        {
            this._headerMSDOS = new FSMSDOSHeader(reader, beginOffset);
            this._peSignature = reader.getStringWithNullEnd((long)HeaderMSDOS.LFANEW + beginOffset);
            Helper.CheckAlways(this._peSignature, ALWAYS_PE_SIGNATURE, "PESignature");
            this._peFileHeader = new FSPEFileHeader(reader, beginOffset + (long)HeaderMSDOS.LFANEW + (long)PESignature.Length + 2L);
            this._peOptionalHeader = new FSPEOptionalHeader(reader, beginOffset + FSPEFileHeader.OFFSET_HARACTERISTICS + 2L);

            //initialize sections of header
            long lastOffset = beginOffset + FSPEHEaderDataDirectories.OFFSET_RESERVED + 8L;
            this._sectionsHeader = new Dictionary<string, FSSectionHeader>(PEFileHeader.NumberOfSections);
            FSSectionHeader sectionHeader;
            for (int index = 0; index < PEFileHeader.NumberOfSections; ++index)
            {
                sectionHeader = new FSSectionHeader(reader, lastOffset);
                SectionsHeader.Add(sectionHeader.Name, sectionHeader);
                lastOffset += FSSectionHeader.OFFSET_CHARACTERISTICS + 4L;
            }
            //

            //END_OFFSET = BEGIN_OFFSET + PEOptionalHeader.PEHeaderWindowsNTSpecificFields.HeaderSize;
        }
        #endregion











        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public FSMSDOSHeader HeaderMSDOS
        {
            get { return _headerMSDOS; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FSPEFileHeader PEFileHeader
        {
            get { return _peFileHeader; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FSPEOptionalHeader PEOptionalHeader
        {
            get { return _peOptionalHeader; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PESignature
        {
            get { return _peSignature; }
        }

        public Dictionary<string, FSSectionHeader> SectionsHeader
        {
            get { return _sectionsHeader; }
        }
        #endregion









        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rva"></param>
        /// <returns></returns>
        public long TranslateRVA(long rva)
        {
            foreach (var sectionPair in SectionsHeader)
            {
                if (sectionPair.Value.VirtualAddress <= rva && (sectionPair.Value.VirtualAddress + sectionPair.Value.VirtualSize) > rva)
                {
                    return sectionPair.Value.PointerToRawData + rva - sectionPair.Value.VirtualAddress;
                }
            }
            return -1;
        }
        #endregion



    }
}
