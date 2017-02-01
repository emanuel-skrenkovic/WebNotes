using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NotesContext : DbContext, INotesContext 
    {
        public NotesContext()
            : base()
        {
        }

        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
