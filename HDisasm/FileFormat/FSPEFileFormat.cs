namespace PEFileFormat
{
    using System;
    using System.IO;






    /// <summary>
    /// 
    /// </summary>
    public sealed class FSPEFileFormat
    {
        #region Fields
        private readonly Stream _reader;
        private readonly FSPEHeader _peHeader;
        private readonly FSImportTable _importTable;
        private readonly FSIAT _iat;//import address table
        private readonly FSIAT _ilt;//import lookup table
        private readonly FSHintNameTable _hintNameTable;
        private readonly FSCLIHeader _cliHeader;
        private readonly FSRelocations _relocations;
        private readonly byte[] _bufferArray;
        #endregion









        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        private FSPEFileFormat() {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public FSPEFileFormat(Stream reader)
        {

            this._reader = reader;
            this._bufferArray = new byte[this._reader.Length];
            this._reader.Read(this._bufferArray, 0, (int)this._reader.Length);

            //PEHeaders
            this._peHeader = new FSPEHeader(BufferByte, 0);

            long address = PEHeader.TranslateRVA(PEHeader.PEOptionalHeader.PEHEaderDataDirectories.ImportTable.RVA);
            ImportTable = new FSImportTable(BufferByte, address);
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
        #endregion











        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public byte[] BufferByte
        {
            get { return _bufferArray; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FSPEHeader PEHeader
        {
            get { return _peHeader; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FSIAT IAT
        {
            get { return _iat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FSIAT ILT
        {
            get { return _ilt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FSHintNameTable HintNameTable
        {
            get { return _hintNameTable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FSImportTable ImportTable
        {
            get { return _importTable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FSCLIHeader CLIHeader
        {
            get { return _cliHeader; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FSRelocations Relocations
        {
            get { return _relocations; }
        }
        #endregion
    }
}
