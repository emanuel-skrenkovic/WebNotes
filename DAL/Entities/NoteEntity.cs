using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class NoteEntity
    {
        [Key]
        public int NoteId { get; set; }

        public string Text { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public virtual CategoryEntity Category { get; set; }
    }
}
