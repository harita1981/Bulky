using BulkyWebRazor_Web.Data;
using BulkyWebRazor_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Web.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(int? id)
        {
            if(id !=null && id != 0)
            {
                Category = dbContext.Categories.Find(id);
            }
        }

        public IActionResult OnPost(Category category)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Update(category);
                dbContext.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                //return RedirectToPage("Index");
            }

            return RedirectToPage("Index");

        }

        
    }
}
