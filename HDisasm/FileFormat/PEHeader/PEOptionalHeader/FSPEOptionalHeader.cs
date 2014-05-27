#region description
///PE optional header
//Immediately after the PE Header is the PE Optional Header. 
#endregion
namespace PEFileFormat
{
    using System;



    /// <summary>
    /// 
    /// </summary>
    public sealed class FSPEOptionalHeader:AFileStructure
    {
        #region Fields
        private readonly FSPEHeaderStandartFields _peHeaderStandartFields;
        private readonly FSPEHeaderWindowsNTSpecificFields _peHeaderWindowsNTSpecificFields;
        private readonly FSPEHEaderDataDirectories _peHeaderDataDirectories;
        #endregion








        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        public FSPEOptionalHeader(byte[] reader, long beginOffset)
            : base(reader)
        {
            this._peHeaderStandartFields = new FSPEHeaderStandartFields(reader, beginOffset);
            this._peHeaderWindowsNTSpecificFields = new FSPEHeaderWindowsNTSpecificFields(reader, beginOffset);
            this._peHeaderDataDirectories = new FSPEHEaderDataDirectories(reader, beginOffset);
        }
        #endregion








        #region Properties
        /// <summary>
        /// These define general properties of the PE file
        /// </summary>
        public FSPEHeaderStandartFields PEHeaderStandartFields
        {
            get { return _peHeaderStandartFields; }
        }
        /// <summary>
        /// These include additional fields to support specific features of Windows
        /// </summary>
        public FSPEHeaderWindowsNTSpecificFields PEHeaderWindowsNTSpecificFields
        {
            get { return _peHeaderWindowsNTSpecificFields; }
        }
        /// <summary>
        /// These fields are address/size pairs for special tables, found in
        ///the image file (for example, Import Table and Export Table).
        /// </summary>
        public FSPEHEaderDataDirectories PEHEaderDataDirectories
        {
            get { return _peHeaderDataDirectories; }
        }
        #endregion
    }
}
