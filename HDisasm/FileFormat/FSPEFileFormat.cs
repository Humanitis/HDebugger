using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;
using PEFileFormat.FileFormat.CLIHeader;
using PEFileFormat.FileFormat.PEHeader;

namespace PEFileFormat.FileFormat
{
    public sealed class FSPEFileFormat
    {
        private Stream _reader;
        private FSPEHeader _peHeader;
        private FSImportTable _importTable;
        private FSIAT _iat;//import address table
        private FSIAT _ilt;//import lookup table
        private FSHintNameTable _hintNameTable;
        private FSCLIHeader _cliHeader;
        private FSRelocations _relocations;
        private byte[] _bufferArray;
        private AFileFormatMediator _mediator;


        public byte[] BufferByte
        {
            get { return _bufferArray; }
        }

        public FSPEHeader PEHeader
        {
            get { return _peHeader; }
            private set { _peHeader = value; }
        }

        public FSIAT IAT
        {
            get { return _iat; }
            private set { _iat = value; }
        }

        public FSIAT ILT
        {
            get { return _ilt; }
            private set { _ilt = value; }
        }

        public FSHintNameTable HintNameTable
        {
            get { return _hintNameTable; }
            private set { _hintNameTable = value; }
        }

        public FSImportTable ImportTable
        {
            get { return _importTable; }
            private set { _importTable = value; }
        }

        public FSCLIHeader CLIHeader
        {
            get { return _cliHeader; }
            private set { _cliHeader = value; }
        }

        public FSRelocations Relocations
        {
            get { return _relocations; }
            private set { _relocations = value; }
        }


        private void Parse()
        {
            _bufferArray = new byte[_reader.Length];
            _reader.Read(_bufferArray, 0, (int)_reader.Length);
            PEHeader = new FSPEHeader(BufferByte, 0,_mediator);

            ulong address = PEHeader.TranslateRVA(PEHeader.PEOptionalHeader.PEHEaderDataDirectories.ImportTable.RVA);
            ImportTable = new FSImportTable(BufferByte, address, _mediator);
            //ImportTable.Name = BufferByte.getStringWithNullEnd(PEHeader.TranslateRVA(ImportTable.NameRVA));

            address = PEHeader.TranslateRVA(PEHeader.PEOptionalHeader.PEHEaderDataDirectories.CLIHeader.RVA);
            CLIHeader = new FSCLIHeader(BufferByte, address, _mediator);

            address = PEHeader.TranslateRVA(PEHeader.PEOptionalHeader.PEHEaderDataDirectories.IAT.RVA);
            IAT = new FSIAT(BufferByte, address, _mediator);

            address = PEHeader.TranslateRVA(ImportTable.ImportLookupTableRVA);
            ILT = new FSIAT(BufferByte, address, _mediator);

            address = PEHeader.TranslateRVA(IAT.HintNameTableRVA);
            HintNameTable = new FSHintNameTable(BufferByte, address, _mediator);

            address = PEHeader.TranslateRVA(PEHeader.PEOptionalHeader.PEHEaderDataDirectories.BaseRelocationTable.RVA);
            Relocations = new FSRelocations(BufferByte, address, _mediator);

        }

        public FSPEFileFormat(Stream reader)
        {
            _reader = reader;
            Parse();
        }
    }
}
