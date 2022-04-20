using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesWebApplication.ViewModels
{
    public class NoteViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime UpdationDate { get; set; } = DateTime.Now;
    }
}
