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


            var folders = new Folder[]{
                new Folder() { FolderId = 10, Name = "root", ParentId = -1 },
                new Folder() { FolderId = 11, Name = "Creating Digital Images", ParentId = 10 },
                new Folder() { FolderId = 12, Name = "Resources", ParentId = 11 },
                new Folder() { FolderId = 13, Name = "Evidence", ParentId = 11 },
                new Folder() { FolderId = 14, Name = "Graphic Products", ParentId = 11 },
                new Folder() { FolderId = 15, Name = "Primary Sources", ParentId = 12 },
                new Folder() { FolderId = 16, Name = "Secondary Sources", ParentId = 12 },
                new Folder() { FolderId = 17, Name = "Process", ParentId = 14 },
                new Folder() { FolderId = 18, Name = "Final Product", ParentId = 14 }
            };
            context.Folders.AddRange(folders);
            context.SaveChanges();
        }
    }
}
