using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Common
{
    public static class Utils
    {
        public static string GetSql(string filePath)
        {
            string APP_DIR = Application.StartupPath + "\\Sql\\";
            if (!File.Exists(APP_DIR + filePath)) return "";
            string sql = "";
            using (StreamReader stream = new StreamReader(APP_DIR + filePath))
            {
                sql = stream.ReadToEnd();
            }
            return sql;
        }

        public static byte[] ImageToByte(Image img, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            if (img == null) return null;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, imageFormat);
                return ms.ToArray();
            }
        }
        public static Image ByteToImage(byte[] data)
        {
            if (data == null || data.Length == 0) return null;
            MemoryStream ms = new MemoryStream(data);
            Image image = Image.FromStream(ms);
            return image;
        }
    }
}
