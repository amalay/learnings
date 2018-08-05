using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Amalay.Helpers.DataAccess.SqlServer
{
    public class SqlDbParameter : DbParameter
    {
        private string _name = string.Empty;
        private object _value = null;
        private ParameterDirection _direction = ParameterDirection.InputOutput;
        private SqlParameterTypes _parameterType;

        public override string Name
        {
            get
            {
                return this._name;
            }
        }

        public override object Value
        {
            get
            {
                return (this._value != null) ? this._value : DBNull.Value;
            }
        }

        public override ParameterDirection Direction
        {
            get
            {
                return this._direction;
            }
        }

        public override object ParameterType
        {
            get
            {
                SqlDbType parameterType = SqlDbType.VarChar;

                switch (this._parameterType)
                {
                    case SqlParameterTypes.VarChar:
                        parameterType = SqlDbType.VarChar;
                        break;

                    case SqlParameterTypes.NVarChar:
                        parameterType = SqlDbType.NVarChar;
                        break;

                    case SqlParameterTypes.Int:
                        parameterType = SqlDbType.Int;
                        break;
                }

                return parameterType;
            }
        }

        public SqlDbParameter() { }

        public SqlDbParameter(string name, object value)
        {
            this._name = name;
            this._value = value;
        }

        public SqlDbParameter(string name, object value, ParameterDirection direction)
        {
            this._name = name;
            this._value = value;
            this._direction = direction;
        }

        public SqlDbParameter(string name, object value, SqlParameterTypes sqlParameterType, ParameterDirection direction)
        {
            this._name = name;
            this._value = value;
            this._parameterType = sqlParameterType;
            this._direction = direction;
        }
    }

    
    public enum SqlParameterTypes
    {
        BigInt = 0,     // System.Int64. A 64-bit signed integer.
        
        Binary = 1,     // System.Array of type System.Byte. A fixed-length stream of binary data ranging between 1 and 8,000 bytes.
        
        Bit = 2,        //System.Boolean. An unsigned numeric value that can be 0, 1, or null.
        
        Char = 3,       // System.String. A fixed-length stream of non-Unicode characters ranging between 1 and 8,000 characters.

        DateTime = 4,   // System.DateTime. Date and time data ranging in value from January 1, 1753 to December 31, 9999 to an accuracy of 3.33 milliseconds.
        //
        // Summary:
        //     System.Decimal. A fixed precision and scale numeric value between -10 38
        //     -1 and 10 38 -1.
        Decimal = 5,
        //
        // Summary:
        //     System.Double. A floating point number within the range of -1.79E +308 through
        //     1.79E +308.
        Float = 6,
        //
        // Summary:
        //     System.Array of type System.Byte. A variable-length stream of binary data
        //     ranging from 0 to 2 31 -1 (or 2,147,483,647) bytes.
        Image = 7,
        //
        // Summary:
        //     System.Int32. A 32-bit signed integer.
        Int = 8,
        //
        // Summary:
        //     System.Decimal. A currency value ranging from -2 63 (or -9,223,372,036,854,775,808)
        //     to 2 63 -1 (or +9,223,372,036,854,775,807) with an accuracy to a ten-thousandth
        //     of a currency unit.
        Money = 9,
        //
        // Summary:
        //     System.String. A fixed-length stream of Unicode characters ranging between
        //     1 and 4,000 characters.
        NChar = 10,
        //
        // Summary:
        //     System.String. A variable-length stream of Unicode data with a maximum length
        //     of 2 30 - 1 (or 1,073,741,823) characters.
        NText = 11,
        //
        // Summary:
        //     System.String. A variable-length stream of Unicode characters ranging between
        //     1 and 4,000 characters. Implicit conversion fails if the string is greater
        //     than 4,000 characters. Explicitly set the object when working with strings
        //     longer than 4,000 characters.
        NVarChar = 12,
        //
        // Summary:
        //     System.Single. A floating point number within the range of -3.40E +38 through
        //     3.40E +38.
        Real = 13,
        //
        // Summary:
        //     System.Guid. A globally unique identifier (or GUID).
        UniqueIdentifier = 14,
        //
        // Summary:
        //     System.DateTime. Date and time data ranging in value from January 1, 1900
        //     to June 6, 2079 to an accuracy of one minute.
        SmallDateTime = 15,
        //
        // Summary:
        //     System.Int16. A 16-bit signed integer.
        SmallInt = 16,
        //
        // Summary:
        //     System.Decimal. A currency value ranging from -214,748.3648 to +214,748.3647
        //     with an accuracy to a ten-thousandth of a currency unit.
        SmallMoney = 17,
        //
        // Summary:
        //     System.String. A variable-length stream of non-Unicode data with a maximum
        //     length of 2 31 -1 (or 2,147,483,647) characters.
        Text = 18,
        //
        // Summary:
        //     System.Array of type System.Byte. Automatically generated binary numbers,
        //     which are guaranteed to be unique within a database. timestamp is used typically
        //     as a mechanism for version-stamping table rows. The storage size is 8 bytes.
        Timestamp = 19,
        //
        // Summary:
        //     System.Byte. An 8-bit unsigned integer.
        TinyInt = 20,
        //
        // Summary:
        //     System.Array of type System.Byte. A variable-length stream of binary data
        //     ranging between 1 and 8,000 bytes. Implicit conversion fails if the byte
        //     array is greater than 8,000 bytes. Explicitly set the object when working
        //     with byte arrays larger than 8,000 bytes.
        VarBinary = 21,
        //
        // Summary:
        //     System.String. A variable-length stream of non-Unicode characters ranging
        //     between 1 and 8,000 characters.
        VarChar = 22,
        //
        // Summary:
        //     System.Object. A special data type that can contain numeric, string, binary,
        //     or date data as well as the SQL Server values Empty and Null, which is assumed
        //     if no other type is declared.
        Variant = 23,
        //
        // Summary:
        //     An XML value. Obtain the XML as a string using the System.Data.SqlClient.SqlDataReader.GetValue(System.Int32)
        //     method or System.Data.SqlTypes.SqlXml.Value property, or as an System.Xml.XmlReader
        //     by calling the System.Data.SqlTypes.SqlXml.CreateReader() method.
        Xml = 25,
        //
        // Summary:
        //     A SQL Server 2005 user-defined type (UDT).
        Udt = 29,
        //
        // Summary:
        //     A special data type for specifying structured data contained in table-valued
        //     parameters.
        Structured = 30,
        //
        // Summary:
        //     Date data ranging in value from January 1,1 AD through December 31, 9999
        //     AD.
        Date = 31,
        //
        // Summary:
        //     Time data based on a 24-hour clock. Time value range is 00:00:00 through
        //     23:59:59.9999999 with an accuracy of 100 nanoseconds. Corresponds to a SQL
        //     Server time value.
        Time = 32,
        //
        // Summary:
        //     Date and time data. Date value range is from January 1,1 AD through December
        //     31, 9999 AD. Time value range is 00:00:00 through 23:59:59.9999999 with an
        //     accuracy of 100 nanoseconds.
        DateTime2 = 33,
        //
        // Summary:
        //     Date and time data with time zone awareness. Date value range is from January
        //     1,1 AD through December 31, 9999 AD. Time value range is 00:00:00 through
        //     23:59:59.9999999 with an accuracy of 100 nanoseconds. Time zone value range
        //     is -14:00 through +14:00.
        DateTimeOffset = 34,
    }
}
