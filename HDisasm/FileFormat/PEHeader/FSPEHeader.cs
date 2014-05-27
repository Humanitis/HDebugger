#region description
///A PE image starts with an MS-DOS header followed by a PE signature, followed by the PE file header, and
///then the PE optional header followed by PE section headers.
#endregion
using System;
using System.Collections.Generic;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.PEHeader
{
    public sealed class FSPEHeader:AFileStructure
    {
        private static readonly string ALWAYS_PE_SIGNATURE = "PE";

        private FSMSDOSHeader _headerMSDOS;
        private FSPEFileHeader _peFileHeader;
        private FSPEOptionalHeader _peOptionalHeader;
        private string _peSignature;
        private Dictionary<string, FSSectionHeader> _sectionsHeader;

        public FSMSDOSHeader HeaderMSDOS
        {
            get { return _headerMSDOS; }
            private set { _headerMSDOS = value; }
        }

        public FSPEFileHeader PEFileHeader
        {
            get { return _peFileHeader; }
            private set { _peFileHeader = value; }
        }

        public FSPEOptionalHeader PEOptionalHeader
        {
            get { return _peOptionalHeader; }
            private set { _peOptionalHeader = value; }
        }

        public string PESignature
        {
            get { return _peSignature; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_PE_SIGNATURE, "PESignature");
                _peSignature = value;
            }
        }

        public Dictionary<string, FSSectionHeader> SectionsHeader
        {
            get { return _sectionsHeader; }
            private set { _sectionsHeader = value; }
        }


        public ulong TranslateRVA(ulong rva)
        {
            foreach (var sectionPair in SectionsHeader)
            {
                if (sectionPair.Value.VirtualAddress <= rva && (sectionPair.Value.VirtualAddress + sectionPair.Value.VirtualSize) > rva)
                {
                    return sectionPair.Value.PointerToRawData + rva - sectionPair.Value.VirtualAddress;
                }
            }
            return unchecked((ulong)-1);
        }


        public FSPEHeader(byte[] reader, long beginOffset)
            :base(reader)
        {
            HeaderMSDOS = new FSMSDOSHeader(reader, beginOffset);
            PESignature = reader.getStringWithNullEnd((long)HeaderMSDOS.LFANEW + beginOffset);
            PEFileHeader = new FSPEFileHeader(reader, beginOffset + (long)HeaderMSDOS.LFANEW + (long)PESignature.Length + 2L);
            PEOptionalHeader = new FSPEOptionalHeader(reader, beginOffset + FSPEFileHeader.OFFSET_HARACTERISTICS + 2L);

            //initialize sections of header
            ulong lastOffset = PEOptionalHeader.END_OFFSET;
            SectionsHeader = new Dictionary<string, FSSectionHeader>(PEFileHeader.NumberOfSections);
            FSSectionHeader sectionHeader;
            for (int index = 0; index < PEFileHeader.NumberOfSections; ++index)
            {
                sectionHeader = new FSSectionHeader(reader, lastOffset,mediator);
                SectionsHeader.Add(sectionHeader.Name, sectionHeader);
                lastOffset = sectionHeader.END_OFFSET;
            }
            //

            END_OFFSET = BEGIN_OFFSET + PEOptionalHeader.PEHeaderWindowsNTSpecificFields.HeaderSize;
        }
    }
}
