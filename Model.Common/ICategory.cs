using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    public interface ICategory
    {
        int Id { get; set; }
        string Name { get; set; }

        ICollection<INote> Notes { get; set; }
    }
}
