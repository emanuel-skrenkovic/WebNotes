using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class NotesViewModel
    {
        public IEnumerable<INote> Notes { get; set; }
        public IEnumerable<ICategory> Categories { get; set; }
    }
}