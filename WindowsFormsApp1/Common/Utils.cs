using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp1.Common
{
    public static class Utils
    {
        public static string GetSql(string filePath)
        {
            if (!File.Exists(filePath)) return "";
            string sql = "";
            using (StreamReader stream = new StreamReader(filePath))
            {
                sql = stream.ReadToEnd();
            }
            return sql;
        }
    }
}
