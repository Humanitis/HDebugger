#region description
///The Hint/Name table contains the name of the dll-entry that is imported.
#endregion
using System;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat
{
    public sealed class FSHintNameTable:AFileStructure
    {
        private static readonly ushort ALWAYS_HINT = 0;
        private static readonly string ALWAYS_NAME_EXE = "_CorExeMain";
        private static readonly string ALWAYS_NAME_DLL = "_CorDllMain";

        private static readonly ulong OFFSET_HINT = 0UL;
        private static readonly ulong OFFSET_NAME = 2UL;

        private ushort _hint;
        private string _name;

        /// <summary>
        /// Shall be 0.
        /// </summary>
        public ushort Hint
        {
            get { return _hint; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_HINT, "Hint");
                _hint = value;
            }
        }
        /// <summary>
        /// Case sensitive, null-terminated ASCII string containing name to
        ///import. Shall be “_CorExeMain” for a .exe file and
        ///“_CorDllMain” for a .dll file.
        /// </summary>
        public string Name
        {
            get { return _name; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_NAME_EXE,ALWAYS_NAME_DLL, "Name");
                _name = value;
            }
        }

        private FSHintNameTable()
        { }

        public FSHintNameTable(byte[] reader, ulong beginOffset,AFileFormatMediator mediator)
            :base(reader,beginOffset,mediator)
        {
            Hint = reader.getUShort(BEGIN_OFFSET + OFFSET_HINT);
            Name = reader.getStringWithNullEnd(BEGIN_OFFSET + OFFSET_NAME);
            END_OFFSET = BEGIN_OFFSET + OFFSET_NAME + (ulong)Name.Length + 1UL;
        }
    }
}
