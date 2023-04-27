using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class BaseModel
    {
        public string Id { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
    }
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
