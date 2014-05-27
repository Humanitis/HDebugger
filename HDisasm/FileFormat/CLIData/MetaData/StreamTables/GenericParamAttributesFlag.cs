using System;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    /// <summary>
    /// Flags for Generic Parameters [GenericParamAttributes]
    /// </summary>
    [Flags()]
    public enum GenericParamAttributesFlag
    {
        /*VarianceMask 0x0003 These 2 bits contain one of the following values:*/
        NONE = 0x0000,// The generic parameter is non-variant and has no special constraints
        COVARIANT = 0x0001,// The generic parameter is covariant
        CONTRAVARIANT = 0x0002,// The generic parameter is contravariant
        /*SpecialConstraintMask 0x001C These 3 bits contain one of the following values:*/
        REFERENCE_TYPE_CONSTRAINT = 0x0004,// The generic parameter has the class special constraint
        NOT_NULLABLE_VALUE_TYPE_CONSTRAINT = 0x0008,// The generic parameter has the valuetype special constraint
        DEFAULT_CONSTRUCTOR_CONSTRAINT = 0x0010,// The generic parameter has the .ctor special constraint
    }
}
