using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Category : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<INote> Notes { get; set; }
    }
}
