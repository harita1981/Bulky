using BulkyWebRazor_Web.Data;
using BulkyWebRazor_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Web.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;

        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0)
            {
                Category = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            }
        }

        public IActionResult OnPost(Category category)
        {
            if(category == null)
            {
                return NotFound();
            }
            
                dbContext.Remove(category);
                dbContext.SaveChanges();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToPage("Index");

        }

        
    }
}
