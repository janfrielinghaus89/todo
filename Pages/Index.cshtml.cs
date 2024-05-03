using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationManager _manager;

        // BindProperties für das Formular
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Content { get; set; }
        [BindProperty]
        public string TagsString { get; set; }
        [BindProperty]
        public string CategoryName { get; set; }

        public IndexModel(ApplicationManager manager)
        {
            _manager = manager;
        }

        public List<ToDoPost> AllToDoPosts { get; private set; }
        public List<Category> AllCategories { get; private set; }

        public void OnGet()
        {
            try
            {
                AllToDoPosts = _manager.GetAllToDoPosts();
                AllCategories = _manager.GetAllCategories();

                if (AllCategories == null)
                {
                    ViewData["ErrorMessage"] = "Fehler beim Laden der Kategorien";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ViewData["ErrorMessage"] = "Ein unerwarteter Fehler ist aufgetreten";
            }
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(CategoryName))
            {
                ModelState.AddModelError("CategoryName", "Bitte wählen Sie eine Kategorie aus.");
                return Page();
            }

            var newToDo = new ToDoPost
            {
                Title = this.Title,
                CategoryId = _manager.GetCategoryByName(this.CategoryName),
                Content = this.Content,
                CreateDate = DateTime.Now,
                TagsString = this.TagsString
            };

            _manager.AddToDoPost(newToDo);

            return RedirectToPage("Index");
        }

        public string getCategoryImage(string categoryName)
        {
            return $"Images/{categoryName}.png";
        }
        
    }
}
