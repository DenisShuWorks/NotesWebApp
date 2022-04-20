using NotesWebApplication.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesWebApplication.Models
{
    public class Note : Entity
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
