using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public delegate AStreamTableRow BuilderRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes);

    public abstract class AStreamTableRow : AFileStructure
    {
        private HeapSizeFlag _heapSizes;

        protected TypeMetaData _typeTable;

        public HeapSizeFlag HeapSizes
        {
            get { return _heapSizes; }
            private set { _heapSizes = value; }
        }

        public TypeMetaData TypeTable
        {
            get { return _typeTable; }
        }

        public static KeyValuePair<TypeMetaData, List<AStreamTableRow>> BuildStreamTable(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, int numberOfTable, int countRow, HeapSizeFlag heapSizes)
        {
            BuilderRow rowBuilder = null;
            switch ((TypeMetaData)numberOfTable)
            {
                case TypeMetaData.ASSEMBLY: rowBuilder = STAssemblyRow.CreateStreamTableRow; break;
                case TypeMetaData.ASSEMBLY_OS: rowBuilder = STAssemblyOSRow.CreateStreamTableRow; break;
                case TypeMetaData.ASSEMBLY_PROCESSOR: rowBuilder = STAssemblyProcessorRow.CreateStreamTableRow; break;
                case TypeMetaData.ASSEMBLY_REF: rowBuilder = STAssemblyRefRow.CreateStreamTableRow; break;
                case TypeMetaData.ASSEMBLY_REF_OS: rowBuilder = STAssemblyRefOSRow.CreateStreamTableRow; break;
                case TypeMetaData.ASSEMBLY_REF_PROCESSOR: rowBuilder = STAssemblyRefProcessorRow.CreateStreamTableRow; break;
                case TypeMetaData.CLASS_LAYOUT: rowBuilder = STClassLayoutRow.CreateStreamTableRow; break;
                case TypeMetaData.CONSTANT: rowBuilder = STConstantRow.CreateStreamTableRow; break;
                case TypeMetaData.CUSTOM_ATTRIBUTE: rowBuilder = STCustomAttributeRow.CreateStreamTableRow; break;
                case TypeMetaData.DECL_SECURITY: rowBuilder = STDeclSecurityRow.CreateStreamTableRow; break;
                case TypeMetaData.EVENT_MAP: rowBuilder = STEventMapRow.CreateStreamTableRow; break;
                case TypeMetaData.EVENT: rowBuilder = STEventRow.CreateStreamTableRow; break;
                case TypeMetaData.EXPORTED_TYPE: rowBuilder = STExportedTypeRow.CreateStreamTableRow; break;
                case TypeMetaData.FIELD: rowBuilder = STFieldRow.CreateStreamTableRow; break;
                case TypeMetaData.FIELD_LAYOUT: rowBuilder = STFieldLayoutRow.CreateStreamTableRow; break;
                case TypeMetaData.FIELD_MARSHAL: rowBuilder = STFieldMarshalRow.CreateStreamTableRow; break;
                case TypeMetaData.FIELD_RVA: rowBuilder = STFieldRVARow.CreateStreamTableRow; break;
                case TypeMetaData.FILE: rowBuilder = STFileRow.CreateStreamTableRow; break;
                case TypeMetaData.GENERIC_PARAM: rowBuilder = STGenericParamRow.CreateStreamTableRow; break;
                case TypeMetaData.GENERIC_PARAM_CONSTRAINT: rowBuilder = STGenericParamConstraintRow.CreateStreamTableRow; break;
                case TypeMetaData.IMPL_MAP: rowBuilder = STImplMapRow.CreateStreamTableRow; break;
                case TypeMetaData.INTERFACE_IMPL: rowBuilder = STInterfaceImplRow.CreateStreamTableRow; break;
                case TypeMetaData.MANIFEST_RESOURCE: rowBuilder = STManifestResourceRow.CreateStreamTableRow; break;
                case TypeMetaData.MEMBER_REF: rowBuilder = STMemberRefRow.CreateStreamTableRow; break;
                default: throw new ArgumentException();
            }
            List<AStreamTableRow> table = new List<AStreamTableRow>(countRow);
            AStreamTableRow temp;
            for (int index = 0; index < countRow; index++)
            {
                table.Add(temp = rowBuilder(reader, beginOffset, mediator, heapSizes));
                beginOffset = temp.END_OFFSET;
            }
            return new KeyValuePair<TypeMetaData, List<AStreamTableRow>>((TypeMetaData)numberOfTable, table);
        }

        protected AStreamTableRow()
        { }
        protected AStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
        }

    }
}
