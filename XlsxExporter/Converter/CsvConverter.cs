using System;
using System.Collections.Generic;
using System.Text;

namespace XlsxExporter.Converter
{
    /**
     * bool   ==> bool
     * uint8  ==> byte,   int8    ==> sbyte
     * uint16 ==> ushort, int16   ==> short
     * uint32 ==> uint,   int32   ==> int
     * uint64 ==> ulong,  int64   ==> long
     * float  ==> float,  float64 ==> double
     * string ==> string,
     */
    //using bool = System.Boolean;
    using uint8 = System.Byte;
    using int8 = System.SByte;
    using uint16 = System.UInt16;
    using int16 = System.Int16;
    using uint32 = System.UInt32;
    using int32 = System.Int32;
    using uint64 = System.UInt64;
    using int64 = System.Int64;
    //using float = System.Single;
    using float64 = System.Double;
    //using string = System.String;

    public class CsvConverter : Converter
    {
        public override bool Convert(string path, List<List<object>> sheet, out string content, string progressFormat = "{0}", OnStatusHandler onStatus = null)
        {
            int rowIndex = 0;
            onStatus?.Invoke(path, "正在处理", string.Format(progressFormat, "0%"));
            StringBuilder data = new StringBuilder();
            foreach (var row in sheet)
            {
                StringBuilder rowData = new StringBuilder();
                foreach (var cell in row)
                {
                    string value = "";
                    if (cell is bool)
                    {
                        value = (bool)cell ? "1" : "0";
                    }
                    else if (cell is bool[])
                    {
                        foreach (var subRawValue in (bool[])cell)
                        {
                            if (value.Length > 0) value += ",";
                            value += subRawValue ? "1" : "0";
                        }
                        if (value.Length > 0) value = '"' + value + '"';
                    }
                    else if (cell is uint8 || cell is int8
                        || cell is uint16 || cell is int16
                        || cell is uint32 || cell is int32
                        || cell is uint64 || cell is int64
                        || cell is float || cell is float64)
                    {
                        value = cell.ToString();
                    }
                    else if (cell is uint8[] || cell is int8[]
                        || cell is uint16[] || cell is int16[]
                        || cell is uint32[] || cell is int32[]
                        || cell is uint64[] || cell is int64[]
                        || cell is float[] || cell is float64[])
                    {
                        foreach (var subRawValue in (Array)cell)
                        {
                            if (value.Length > 0) value += ",";
                            value += subRawValue.ToString();
                        }
                        if (value.Length > 0) value = '"' + value + '"';
                    }
                    else if (cell is string)
                    {
                        string rawValue = (string)cell;
                        if (rawValue.IndexOf(',') != -1 || rawValue.IndexOf('"') != -1 || rawValue.IndexOf('\r') != -1 || rawValue.IndexOf('\n') != -1)
                            value = '"' + rawValue.Replace("\"", "\"\"") + '"';
                        else
                            value = rawValue;
                    }
                    else if (cell is string[])
                    {
                        foreach (var subRawValue in (string[])cell)
                        {
                            if (value.Length > 0) value += ",";
                            if (subRawValue.IndexOf(',') != -1 || subRawValue.IndexOf('"') != -1 || subRawValue.IndexOf('\r') != -1 || subRawValue.IndexOf('\n') != -1)
                                value += subRawValue.Replace("\"", "\"\"");
                            else
                                value += subRawValue;
                        }
                        if (value.Length > 0) value = '"' + value + '"';
                    }

                    if (rowData.Length > 0) rowData.Append(',');
                    rowData.Append(value);
                }

                rowData.Append("\r\n");
                data.Append(rowData.ToString());

                ++rowIndex;
                onStatus?.Invoke(path, "正在处理", string.Format(progressFormat, (int)(rowIndex * 100.0 / sheet.Count) + "%"));
            }

            content = data.ToString();
            return true;
        }
    }
}
