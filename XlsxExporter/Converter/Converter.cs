using System.Collections.Generic;

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

    public abstract class Converter
    {
        /// <summary>
        /// 工作簿路径
        /// </summary>
        public string Path { get; }
        /// <summary>
        /// 工作表名字
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 进度提示格式化
        /// </summary>
        public string ProgressFormat { get; set; }

        /// <summary>
        /// Converter
        /// </summary>
        /// <param name="path">工作簿路径</param>
        /// <param name="name">工作表名字</param>
        /// <param name="progressFormat">进度提示格式化</param>
        public Converter(string path, string name, string progressFormat = "{0}")
        {
            Path = path;
            Name = name;
            ProgressFormat = progressFormat;
        }

        /// <summary>
        /// 转换工作表数据
        /// </summary>
        /// <param name="sheet">工作表数据</param>
        /// <param name="content">工作表数据</param>
        /// <param name="onStatus">状态回调</param>
        public abstract bool Convert(List<List<object>> sheet, out string content, OnStatusHandler onStatus = null);
    }
}
