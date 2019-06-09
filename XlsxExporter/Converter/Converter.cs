using System;
using System.Collections.Generic;
using XlsxText;

namespace XlsxExporter.Converter
{
    public abstract class Converter
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="xlsxData">Xlsx数据</param>
        /// <param name="onCompleted">完成回调</param>
        /// <param name="onStatus">状态回调</param>
        public abstract void Convert(Dictionary<string, Dictionary<string, List<List<XlsxTextCell>>>> xlsxData, OnCompletedHandler onCompleted, OnStatusHandler onStatus);
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="onCompleted">完成回调</param>
        /// <param name="onStatus">状态回调</param>
        protected abstract void Save(OnCompletedHandler onCompleted, OnStatusHandler onStatus);
    }
}
