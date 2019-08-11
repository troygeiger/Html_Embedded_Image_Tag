using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TG.INI;
using TG.INI.Serialization;

namespace Html_Embedded_Image_Tag
{
    public class UserOptions
    {
        static UserOptions _instance = null;
        static string _path;

        [Category("Generate")]
        public bool Include_Tag { get; set; } = true;

        [Category("Generate")]
        public bool Include_Size { get; set; } = false;

        public static void Load()
        {
            if (!File.Exists(FilePath))
            {
                return;
            }

            IniDocument doc = new IniDocument(FilePath);
            IniSerialization.DeserializeDocumentInto(doc, Properties);
        }

        public static void Save()
        {
            IniDocument doc = new IniDocument();
            IniSerialization.SerializeObjectIntoDocument(Properties, doc);
            doc.Write(FilePath);
        }

        public static UserOptions Properties
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserOptions();
                }
                return _instance;
            }
        }

        public static string FilePath
        {
            get
            {
                if (string.IsNullOrEmpty(_path))
                {
                    _path = Path.Combine(
                        TG.Common.AppData.GetAppDataPath(TG.Common.AppData.AppDataSchemes.Product),
                        "UserOptions.ini");
                }
                return _path;
            }
            set
            {
                _path = value;
            }
        }
    }
}
