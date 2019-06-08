using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace XlsxExporter
{
    /// <summary>
    /// 输出类型
    /// </summary>
    public enum ExportType { Text, Binary };
    static class Config
    {
        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string ConfigFilePath => Path.GetDirectoryName(Application.ExecutablePath) + '/' + Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".config";
        /// <summary>
        /// 源目录
        /// </summary>
        public static string ImportDir { get; set; } = Application.StartupPath;
        /// <summary>
        /// 输出目录
        /// </summary>
        public static string ExportDir { get; set; } = Application.StartupPath;
        /// <summary>
        /// 输出类型
        /// </summary>
        public static ExportType ExportType { get; set; } = ExportType.Text;
        /// <summary>
        /// 输出线程数
        /// </summary>
        public static int ExportThreadCount { get; set; } = 1;

        /// <summary>
        /// 读取配置
        /// </summary>
        public static void Read()
        {
            try
            {
                /**
                 * <?xml version="1.0" encoding="UTF-8"?>
                 * <config>
                 *      <import path="C:/Xlsx"/>
                 *      <export path="C:/XlsxOut" type="text"/>
                 * </config>
                 */
                XmlDocument doc = new XmlDocument();
                doc.Load(ConfigFilePath);
                foreach (XmlNode node in doc.SelectSingleNode("config").ChildNodes)
                {
                    if (node.Name.ToLower().Trim() == "import")
                    {
                        ImportDir = node.Attributes["path"].Value;
                    }
                    else if (node.Name.ToLower().Trim() == "export")
                    {
                        ExportDir = node.Attributes["path"].Value;
                        switch (node.Attributes["type"].Value.ToLower().Trim())
                        {
                            case "text": ExportType = ExportType.Text; break;
                            case "binary": ExportType = ExportType.Binary; break;
                        }
                        if (int.TryParse(node.Attributes["threadCount"].Value, out int count))
                        {
                            ExportThreadCount = count;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static void Save()
        {
            /**
             * <?xml version="1.0" encoding="UTF-8"?>
             * <config>
             *      <import path="C:/Xlsx"/>
             *      <export path="C:/XlsxOut" type="text"/>
             * </config>
             */
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlElement config = doc.CreateElement("config");
            XmlElement import = doc.CreateElement("import");
            XmlElement export = doc.CreateElement("export");
            import.SetAttribute("path", ImportDir);
            export.SetAttribute("path", ExportDir);
            export.SetAttribute("type", Enum.GetName(typeof(ExportType), ExportType).ToLower());
            export.SetAttribute("threadCount", ExportThreadCount + "");

            config.AppendChild(import);
            config.AppendChild(export);
            doc.AppendChild(config);
            doc.Save(ConfigFilePath);
        }
    }
}
