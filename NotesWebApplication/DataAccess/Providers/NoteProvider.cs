using NotesWebApplication.DataAccess.Providers.Abstract;
using NotesWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesWebApplication.DataAccess.Providers
{
    public class NoteProvider : EntityProvider<ApplicationContext, Note, Guid>
    {
        private readonly ApplicationContext _context;

        public NoteProvider(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
