// 【変更】 画像ファイル アップロード用のコントローラー

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoardWeb.Controllers
{
    using Models;
    using ViewModels;

    public class ImageFileController : Controller
    {
        readonly PostContext _context;

        public ImageFileController(PostContext context) => _context = context;

        // GET: ImageFileEntries
        public async Task<IActionResult> Index()
            => _context.ImageFiles is null
               ? Problem($"Entity set '{nameof(PostContext)}.{nameof(PostContext.ImageFiles)}' is null.")
               : View(await _context.ImageFiles.ToListAsync());

        public IActionResult Upload() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(ImageFileUploadViewModel model)
        {
            if (ModelState.IsValid) {
                using (var memoryStream = new MemoryStream()) {
                    await model.PostedFile.CopyToAsync(memoryStream);

                    // アップロードできる画像ファイルは 2 MB 以下
                    if (memoryStream.Length <= 2 * 1024 * 1024) {
                        var byteArray = memoryStream.ToArray();
                        var file = new ImageFile() {
                            Name = model.Name,
                            Description = model.Description,
                            Image = byteArray
                        };
                        _context.ImageFiles.Add(file);
                        await _context.SaveChangesAsync();
                    } else {
                        ModelState.AddModelError("PostedFile", "サイズは 2MB 以下");
                        return View(model);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ImageFileEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null || _context.ImageFiles is null)
                return NotFound();

            var imageFile = await _context.ImageFiles.FindAsync(id);
            return imageFile is null ?  NotFound() : View(imageFile);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            //if (id != imageFile.Id)
            //    return NotFound();
            if (id is null)
                return NotFound();

            var fileToUpdate = await _context
                                     .ImageFiles
                                     .FirstOrDefaultAsync(f => f.Id == id);
            if (fileToUpdate != null) {
                if (await TryUpdateModelAsync<ImageFile>(
                    fileToUpdate            ,
                    ""                      ,
                    file => file.Name       ,
                    file => file.Description)) {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(fileToUpdate);
        }

        // GET: ImageFileEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || _context.ImageFiles is null)
                return NotFound();

            var imageFileEntry = await _context.ImageFiles
                                               .AsNoTracking()
                                               .FirstOrDefaultAsync(m => m.Id == id);
            return imageFileEntry is null ? NotFound() : View(imageFileEntry);
        }

        // POST: ImageFileEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ImageFiles is null)
                return Problem($"Entity set '{nameof(PostContext)}.{nameof(PostContext.ImageFiles)}' is null.");

            var imageFileEntry = await _context.ImageFiles.FindAsync(id);
            if (imageFileEntry is not null)
                _context.ImageFiles.Remove(imageFileEntry);
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
