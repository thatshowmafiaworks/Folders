using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Folders.Models
{
    public class FoldersContext: DbContext
    {

        public DbSet<Folder> Folders { get; set; }

        public FoldersContext(DbContextOptions<FoldersContext> options) : base(options)
        {
        }

    }
}
