using Microsoft.EntityFrameworkCore;
using NotesWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesWebApplication.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(new Note
            {
                Name = "Первая заметка",
                Text = "Провозглашаю данную заметку - Первой! Пароль:123123"
            });
        }
    }
}
