using Folders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folders.Controllers
{
    public class FolderController:Controller
    {
        private readonly FoldersContext _context;

        public FolderController(FoldersContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Folder(int id)
        {
            var folder = await _context.Folders.FirstOrDefaultAsync(x => x.FolderId == id);
            this.ViewData.Add("Folder", folder.Name);
            var folders = _context.Folders.Where(x => x.ParentId == id).ToArray();
            return View(folders);
        }
    }
}
