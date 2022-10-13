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


        public IActionResult Folder(int id)
        {
            var folder = _context.Folders.FirstOrDefault(x => x.FolderId == id);
            this.ViewData.Add("Folder", folder.Name);
            this.ViewData.Add("FolderId", folder.Id);
            var parent = _context.Folders.FirstOrDefault(x => x.FolderId == folder.ParentId);
            if(parent != null) { 
                this.ViewData.Add("ParentName", parent.Name);
                this.ViewData.Add("ParentId", parent.FolderId);
            }
            else
            {
                this.ViewData.Add("ParentName", "root");
                this.ViewData.Add("ParentId", 10);
            }
            var folders = _context.Folders.Where(x => x.ParentId == id).ToArray();
            return View(folders);
        }
    }
}
