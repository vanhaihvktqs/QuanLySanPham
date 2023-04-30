using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CategoryModel:BaseModel
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }
    }
}
