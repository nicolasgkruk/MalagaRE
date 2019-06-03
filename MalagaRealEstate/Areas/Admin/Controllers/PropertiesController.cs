using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MalagaRealEstate.Data;
using MalagaRealEstate.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using System.IO;
using MalagaRealEstate.Utility;

namespace MalagaRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;


        public PropertiesController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        // GET: Admin/Properties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Properties.ToListAsync());
        }

        // GET: Admin/Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properties = await _context.Properties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (properties == null)
            {
                return NotFound();
            }

            return View(properties);
        }

        // GET: Admin/Properties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Properties property)
        {
            if (ModelState.IsValid)
            {
                _context.Add(property);
                await _context.SaveChangesAsync();


                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var propertyFromDb = await _context.Properties.FindAsync(property.Id);
                if (files.Count > 0)
                {
                    //if user uploaded image:
                    var uploads = Path.Combine(webRootPath, "images");
                    var extension = Path.GetExtension(files[0].FileName);

                    using (var filesStream = new FileStream(Path.Combine(uploads, property.Id + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStream);
                    }
                    propertyFromDb.Image = @"\images\" + propertyFromDb.Id + extension;
                }
                else
                {
                    //no file was uploaded, so use default
                    var uploads = Path.Combine(webRootPath, @"images\" + SD.DefaultPropImage);
                    System.IO.File.Copy(uploads, webRootPath + @"\images\" + propertyFromDb.Id + ".jpg");
                    propertyFromDb.Image = @"\images\" + propertyFromDb.Id + ".jpg";
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }

        // GET: Admin/Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properties = await _context.Properties.FindAsync(id);
            if (properties == null)
            {
                return NotFound();
            }
            return View(properties);
        }

        // POST: Admin/Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Properties property)
        {
            if (id != property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Work on the image saving section
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    var files = HttpContext.Request.Form.Files;

                    if (files.Count > 0)
                    {
                        //New Image has been uploaded
                        var uploads = Path.Combine(webRootPath, "images");
                        var extension_new = Path.GetExtension(files[0].FileName);

                        //Delete the original file
                        if (property.Image != null)
                        {
                         var imagePath = Path.Combine(webRootPath, property.Image.TrimStart('\\'));

                            if (System.IO.File.Exists(imagePath))
                            {
                                System.IO.File.Delete(imagePath);
                            }
                        }
                       
                        //we will upload the new file
                        using (var filesStream = new FileStream(Path.Combine(uploads, property.Id + extension_new), FileMode.Create))
                        {
                            files[0].CopyTo(filesStream);
                        }
                        property.Image = @"\images\" + id + extension_new;
                    }

                    var imageFromDb = await _context.Properties
                        .Where(m => m.Id == id)
                        .Select(s => s.Image)
                        .SingleAsync();

                    if (imageFromDb != null) {
                        property.Image = imageFromDb;
                    }

                    _context.Update(property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertiesExists(property.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(property);
        }

        // GET: Admin/Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var properties = await _context.Properties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (properties == null)
            {
                return NotFound();
            }

            return View(properties);
        }

        // POST: Admin/Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var properties = await _context.Properties.FindAsync(id);
            _context.Properties.Remove(properties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertiesExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
