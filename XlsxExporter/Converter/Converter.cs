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
        /// <param name="view">进度视图</param>
        public abstract void Convert(Dictionary<string, Dictionary<string, List<List<XlsxTextCell>>>> xlsxData, Action onCompleted, IProgresser view);
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="onCompleted">完成回调</param>
        /// <param name="view">进度视图</param>
        protected abstract void Save(Action onCompleted, IProgresser view);
    }
}
