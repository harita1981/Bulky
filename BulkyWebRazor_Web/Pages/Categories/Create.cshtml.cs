using BulkyWebRazor_Web.Data;
using BulkyWebRazor_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Web.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;

        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToPage("Index");
        }
    }
}
