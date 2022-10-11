using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Folders.Models
{
    public static class DbInitializer
    {
        public static void Initialize(FoldersContext context)
        {
            if (context.Folders.Any())
            {
                return;
            }

            var folder = new Folder(){ Id = 0, Name = "root", ParentId = -1 };
            context.Folders.Add(folder);
            context.SaveChanges();
        }
    }
}
