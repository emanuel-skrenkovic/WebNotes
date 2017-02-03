using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    public interface INote
    {
        int Id { get; set; }
        string Title { get; set; }
        string Text { get; set; }

        int? CategoryId { get; set; }
        ICategory Category { get; set; }
    }
}
