using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Controllers;

public class LearnerController : Controller
{
    private readonly SchoolContext _db;

    public LearnerController(SchoolContext context)
    {
        _db = context;
    }

    public async Task<IActionResult> Index()
    {
        var learners = await _db.Learners
            .Include(l => l.Major)
            .OrderBy(l => l.LearnerID)
            .ToListAsync();

        return View(learners);
    }

    public async Task<IActionResult> Create()
    {
        await LoadMajors();
        return View(new Learner { EnrollmentDate = DateTime.Today });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Learner learner)
    {
        if (ModelState.IsValid)
        {
            _db.Learners.Add(learner);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        await LoadMajors(learner.MajorID);
        return View(learner);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var learner = await _db.Learners.FindAsync(id);
        if (learner == null) return NotFound();

        await LoadMajors(learner.MajorID);
        return View(learner);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Learner learner)
    {
        if (id != learner.LearnerID) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _db.Update(learner);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Learners.AnyAsync(l => l.LearnerID == id))
                    return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        await LoadMajors(learner.MajorID);
        return View(learner);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var learner = await _db.Learners
            .Include(l => l.Major)
            .FirstOrDefaultAsync(l => l.LearnerID == id);

        if (learner == null) return NotFound();

        return View(learner);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var learner = await _db.Learners.FindAsync(id);
        if (learner != null)
        {
            _db.Learners.Remove(learner);
            await _db.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadMajors(int? selectedMajor = null)
    {
        ViewBag.MajorID = new SelectList(
            await _db.Majors.OrderBy(m => m.MajorName).ToListAsync(),
            nameof(Major.MajorID),
            nameof(Major.MajorName),
            selectedMajor);
    }
}
