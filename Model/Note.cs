using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Common;

namespace Model
{
    public class Note : INote
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int? CategoryId { get; set; }
        public ICategory Category { get; set; }
    }
}
