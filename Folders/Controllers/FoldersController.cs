using Folders.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Root()
        {
            var folders = _context.Folders.Where(x=> x.ParentId == -1).ToArray(); 
            return View(folders);
        }

        public IActionResult Folder(int id)
        {
            var folders = _context.Folders.Where(x => x.ParentId == id).ToArray();
            return View(folders);
        }
    }
}
